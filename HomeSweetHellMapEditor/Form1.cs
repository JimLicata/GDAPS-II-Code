using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Nicholas Mercadante
 * Section 2(?)
 * B(ee) Team [team 12] Tower Defense Map Editor
 * current issues: cannot load a map if a grid is already present onscreen
 */
namespace HomeSweetHellMapEditor
{
    public partial class Form1 : Form
    {
        //attributes for form-specific functions
        private int tileType;
        private int[,] tiles;
        private PictureBox[,] mapGrid;
        private Image backgroundPic;
        private Image towerPlacablePic;
        private Image enemyPathPic;
        //for file reading/writing
        private StreamWriter saveMap;
        private StreamReader loadMap;
        private Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            backgroundPic = null;
            towerPlacablePic = null;
            enemyPathPic = null;
            tileType = 0;
            tiles = new int[10, 15];
        }

        //getters and setters for attributes that need them
        public Image BackgroundPic
        {
            get { return backgroundPic; }
            set
            {
                backgroundPic = value;
            }
        }
        public Image TowerPlacablePic
        {
            get { return towerPlacablePic; }
            set
            {
                towerPlacablePic = value;
            }
        }
        public Image EnemyPathPic
        {
            get { return enemyPathPic; }
            set
            {
                enemyPathPic = value;
            }
        }
        public int TileType
        {
            get { return tileType; }
            set
            {
                tileType = value;
            }
        }
        public int[,] Tiles
        {
            get { return tiles; }
            set
            {
                tiles = value;
            }
        }
        public PictureBox[,] MapGrid
        {
            get { return mapGrid; }
            set
            {
                mapGrid = value;
            }
        }
        //generates a map grid to edit if one hasn't been loaded in
        private void mapButton_Click(object sender, EventArgs e)
        {
            mapGenerator();
        }
        //edit the map grid
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox tile = (PictureBox)sender; //casts sender object as a PictureBox because it is one
            int tileRow = (tile.Location.Y - 12) / 50;
            int tileColumn = (tile.Location.X - 12) / 50;
            if (tileTypeSelectionBox.SelectedItem == null) //when no tile type is selected, do nothing
            {

            }
            else
            {
                switch (tileTypeSelectionBox.SelectedItem.ToString()) //associate each item in the selection box to a tileType int
                {
                    case "Background":
                        tileType = 0;
                        break;
                    case "Tower Placable":
                        tileType = 1;
                        break;
                    case "Enemy Path Start":
                        tileType = 2;
                        break;
                    case "Enemy Path Step":
                        tileType = 3;
                        break;
                    case "Enemy Path End":
                        tileType = 6;
                        break;
                    default:
                        tileType = 0;
                        break;
                }
                tiles[tileRow, tileColumn] = tileType; //sets the associated spot in the int array to the value representing its type for later file writing
                switch (tileType) //visual correspondence for the user (background property set in case no picture was chosen for tile type)
                {
                    case 0:
                        mapGrid[tileRow, tileColumn].Image = null;
                        mapGrid[tileRow, tileColumn].BackColor = Color.Gray;
                        mapGrid[tileRow, tileColumn].Image = backgroundPic;
                        break;
                    case 1:
                        mapGrid[tileRow, tileColumn].Image = null;
                        mapGrid[tileRow, tileColumn].BackColor = Color.DarkRed;
                        mapGrid[tileRow, tileColumn].Image = towerPlacablePic;
                        break;
                    case 2:
                        mapGrid[tileRow, tileColumn].Image = null;
                        mapGrid[tileRow, tileColumn].BackColor = Color.Tan;
                        mapGrid[tileRow, tileColumn].Image = enemyPathPic;
                        break;
                    case 3:
                        mapGrid[tileRow, tileColumn].Image = null;
                        mapGrid[tileRow, tileColumn].BackColor = Color.Tan;
                        mapGrid[tileRow, tileColumn].Image = enemyPathPic;
                        break;
                    case 6:
                        mapGrid[tileRow, tileColumn].Image = null;
                        mapGrid[tileRow, tileColumn].BackColor = Color.Tan;
                        mapGrid[tileRow, tileColumn].Image = enemyPathPic;
                        break;
                    default:
                        break;
                }
            }
        }
        //save the array of tiles
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextBox != null)
            {
                saveMap = new StreamWriter(fileNameTextBox.Text + ".txt");
            }
            else //if no file name was put in, give a random string of numbers for a name
            {
                string randomFileName = rng.Next().ToString();
                saveMap = new StreamWriter(randomFileName + ".txt");
            }
            //streamwrite the tiles int array
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                    saveMap.Write(tiles[row, column]);
                }
                saveMap.WriteLine("\n");
            }
            saveMap.Close();
        }
        //load an array of tiles
        private void loadButton_Click(object sender, EventArgs e)
        {
            //browse for a file to load within the directory 
            OpenFileDialog mapFileSelection = new OpenFileDialog();
            mapFileSelection.Title = "Load Map";
            mapFileSelection.InitialDirectory = Application.StartupPath;
            mapFileSelection.Filter = "Text Files (*.txt)|*.txt";
            DialogResult result = mapFileSelection.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                //attempt to read in the chosen text file for array creation
                try
                {
                    string mapFile = mapFileSelection.FileName;
                    loadMap = new StreamReader(mapFile);
                    string line;
                    int tileRow = 0;
                    int tileColumn = 0;
                    //read in the array line-by-line and attach each number to its associated position in the tiles in array
                    while ((line = loadMap.ReadLine()) != null)
                    {
                        if (line == "")//ignores the \n commands to split up rows in the array
                        {
                            continue;
                        }
                        else
                        {
                            char[] rowTiles = line.ToCharArray();
                            foreach (char tile in rowTiles)
                            {
                                int type = 0;
                                string tileStr = tile.ToString();
                                int.TryParse(tileStr, out type);
                                tiles[tileRow, tileColumn] = type;
                                tileColumn++;
                            }
                            tileRow++;
                            if (tileRow > 9) //autobreaks if the loop exceeds number of rows in array
                            {
                                break;
                            }
                            tileColumn = 0;
                        }
                    }
                    loadMap.Close();
                    //create the visual component of the editor based on the tiles array that was just formatted
                    if (mapGrid == null)
                    {
                        mapGenerator();
                    }
                    for (int row = 0; row < 10; row++)
                    {
                        for (int column = 0; column < 15; column++)
                        {
                            switch (tiles[row, column])
                            {
                                case 0:
                                    mapGrid[row, column].Image = null;
                                    mapGrid[row, column].BackColor = Color.Gray;
                                    mapGrid[row, column].Image = backgroundPic;
                                    break;
                                case 1:
                                    mapGrid[row, column].Image = null;
                                    mapGrid[row, column].BackColor = Color.DarkRed;
                                    mapGrid[row, column].Image = towerPlacablePic;
                                    break;
                                case 2:
                                    mapGrid[row, column].Image = null;
                                    mapGrid[row, column].BackColor = Color.Tan;
                                    mapGrid[row, column].Image = enemyPathPic;
                                    break;
                                case 3:
                                    mapGrid[row, column].Image = null;
                                    mapGrid[row, column].BackColor = Color.Tan;
                                    mapGrid[row, column].Image = enemyPathPic;
                                    break;
                                case 6:
                                    mapGrid[row, column].Image = null;
                                    mapGrid[row, column].BackColor = Color.Tan;
                                    mapGrid[row, column].Image = enemyPathPic;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                //catch all exceptions thrown when attempting to generate the arrays from a file
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("An error occured while loading a file.  Please make sure the map file is formatted correctly!\nError message: " + ex.Message);
                }
            }
        }
        //browse files for a background tile picture
        private void pictureSelectionButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureSelectionDialogue = new OpenFileDialog();
            pictureSelectionDialogue.Title = "Background Tile Picture";
            pictureSelectionDialogue.InitialDirectory = "\\Pictures";
            pictureSelectionDialogue.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF"; //checks to make sure opnly image files are being passed
            DialogResult result = pictureSelectionDialogue.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                backgroundPic = new Bitmap(pictureSelectionDialogue.FileName);
                //reset any tiles set before the picture was set
                for (int row = 0; row < 10; row++)
                {
                    for (int column = 0; column < 15; column++)
                    {
                        if (tiles[row, column] == 0)
                        {
                            mapGrid[row, column].Image = backgroundPic;
                        }
                    }
                }
            }
        }
        //browse files for a tower placable tile picture
        private void towerPlacablePictureSelectionButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureSelectionDialogue = new OpenFileDialog();
            pictureSelectionDialogue.Title = "Tower-Placable Tile Picture";
            pictureSelectionDialogue.InitialDirectory = "\\Pictures";
            pictureSelectionDialogue.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF"; //checks to make sure opnly image files are being passed
            DialogResult result = pictureSelectionDialogue.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                towerPlacablePic = new Bitmap(pictureSelectionDialogue.FileName);
                //reset any tiles set before the picture was set
                for (int row = 0; row < 10; row++)
                {
                    for (int column = 0; column < 15; column++)
                    {
                        if (tiles[row, column] == 1)
                        {
                            mapGrid[row, column].Image = towerPlacablePic;
                        }
                    }
                }
            }
        }
        //browse files for an enemy path tile picture
        private void enemyPathPictureSelectionButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureSelectionDialogue = new OpenFileDialog();
            pictureSelectionDialogue.Title = "Enemy Path Tile Picture";
            pictureSelectionDialogue.InitialDirectory = "\\Pictures";
            pictureSelectionDialogue.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF"; //checks to make sure opnly image files are being passed
            DialogResult result = pictureSelectionDialogue.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                enemyPathPic = new Bitmap(pictureSelectionDialogue.FileName);
                //reset any tiles set before the picture was set
                for (int row = 0; row < 10; row++)
                {
                    for (int column = 0; column < 15; column++)
                    {
                        if (tiles[row, column] > 1)
                        {
                            mapGrid[row, column].Image = enemyPathPic;
                        }
                    }
                }
            }
        }
        //map generation helper
        public void mapGenerator()
        {
            mapButton.Visible = false;
            mapGrid = new PictureBox[10, 15];
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 15; column++)
                {
                    mapGrid[row, column] = new PictureBox();
                    mapGrid[row, column].Location = new Point(column * 50 + 12, row * 50 + 12);
                    mapGrid[row, column].Width = 50;
                    mapGrid[row, column].Height = 50;
                    mapGrid[row, column].Visible = true;
                    mapGrid[row, column].BorderStyle = BorderStyle.FixedSingle;
                    mapGrid[row, column].BringToFront();
                    mapGrid[row, column].MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
                    this.Controls.Add(mapGrid[row, column]);
                }
            }
        }
        //IGNORE
        private void tileTypeSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //IGNORE
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //IGNORE
        private void generateMapButton_Click(object sender, EventArgs e)
        {

        }
        //IGNORE
        private void submitButton_Click(object sender, EventArgs e)
        {

        }
        //IGNORE
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //IGNORE
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        //IGNORE
        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace HomeSweetHellMapEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveButton = new System.Windows.Forms.Button();
            this.tileTypeSelectionBox = new System.Windows.Forms.ListBox();
            this.backgroundPictureSelectionButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mapButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.towerPlacablePictureSelectionButton = new System.Windows.Forms.Button();
            this.enemyPathPictureSelectionButton = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(683, 524);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 43);
            this.saveButton.TabIndex = 157;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tileTypeSelectionBox
            // 
            this.tileTypeSelectionBox.FormattingEnabled = true;
            this.tileTypeSelectionBox.Items.AddRange(new object[] {
            "Background",
            "Tower Placable",
            "Enemy Path Start",
            "Enemy Path Step 1",
            "Enemy Path Step 2",
            "Enemy Path Step 3",
            "Enemy Path End"});
            this.tileTypeSelectionBox.Location = new System.Drawing.Point(93, 524);
            this.tileTypeSelectionBox.Name = "tileTypeSelectionBox";
            this.tileTypeSelectionBox.Size = new System.Drawing.Size(114, 43);
            this.tileTypeSelectionBox.TabIndex = 158;
            this.tileTypeSelectionBox.SelectedIndexChanged += new System.EventHandler(this.tileTypeSelectionBox_SelectedIndexChanged);
            // 
            // backgroundPictureSelectionButton
            // 
            this.backgroundPictureSelectionButton.Location = new System.Drawing.Point(213, 524);
            this.backgroundPictureSelectionButton.Name = "backgroundPictureSelectionButton";
            this.backgroundPictureSelectionButton.Size = new System.Drawing.Size(120, 43);
            this.backgroundPictureSelectionButton.TabIndex = 159;
            this.backgroundPictureSelectionButton.Text = "Background Picture";
            this.backgroundPictureSelectionButton.UseVisualStyleBackColor = true;
            this.backgroundPictureSelectionButton.Click += new System.EventHandler(this.pictureSelectionButton_Click);
            // 
            // mapButton
            // 
            this.mapButton.Location = new System.Drawing.Point(333, 286);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(120, 23);
            this.mapButton.TabIndex = 160;
            this.mapButton.Text = "Generate Map";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 524);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 43);
            this.loadButton.TabIndex = 161;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // towerPlacablePictureSelectionButton
            // 
            this.towerPlacablePictureSelectionButton.Location = new System.Drawing.Point(339, 524);
            this.towerPlacablePictureSelectionButton.Name = "towerPlacablePictureSelectionButton";
            this.towerPlacablePictureSelectionButton.Size = new System.Drawing.Size(120, 43);
            this.towerPlacablePictureSelectionButton.TabIndex = 162;
            this.towerPlacablePictureSelectionButton.Text = "Tower-Placable Picture";
            this.towerPlacablePictureSelectionButton.UseVisualStyleBackColor = true;
            this.towerPlacablePictureSelectionButton.Click += new System.EventHandler(this.towerPlacablePictureSelectionButton_Click);
            // 
            // enemyPathPictureSelectionButton
            // 
            this.enemyPathPictureSelectionButton.Location = new System.Drawing.Point(465, 524);
            this.enemyPathPictureSelectionButton.Name = "enemyPathPictureSelectionButton";
            this.enemyPathPictureSelectionButton.Size = new System.Drawing.Size(120, 43);
            this.enemyPathPictureSelectionButton.TabIndex = 163;
            this.enemyPathPictureSelectionButton.Text = "Enemy Path Picture";
            this.enemyPathPictureSelectionButton.UseVisualStyleBackColor = true;
            this.enemyPathPictureSelectionButton.Click += new System.EventHandler(this.enemyPathPictureSelectionButton_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(592, 547);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(85, 20);
            this.fileNameTextBox.TabIndex = 164;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(606, 531);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fileNameLabel.TabIndex = 165;
            this.fileNameLabel.Text = "File Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 579);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.enemyPathPictureSelectionButton);
            this.Controls.Add(this.towerPlacablePictureSelectionButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.mapButton);
            this.Controls.Add(this.backgroundPictureSelectionButton);
            this.Controls.Add(this.tileTypeSelectionBox);
            this.Controls.Add(this.saveButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListBox tileTypeSelectionBox;
        private System.Windows.Forms.Button backgroundPictureSelectionButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button mapButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button towerPlacablePictureSelectionButton;
        private System.Windows.Forms.Button enemyPathPictureSelectionButton;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileNameLabel;
    }
}


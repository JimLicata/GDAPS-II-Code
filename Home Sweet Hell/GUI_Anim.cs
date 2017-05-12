using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Home_Sweet_Hell
{
    //Sophia Baker, Group 12, GUI-centric code 3/22/17
    //anim class
    //animates dynamic objects
    class GUI_Anim : GUI_Graphics
    {
        //animation attributes
        private int frame; // current frame number
        private int timeSinceLastFrame; // elapsed time since frame was drawn
        private int millisecondsPerFrame; // millisec to display a frame
        private Vector2 oldPos; //saves old position for directional movement
        private int moveType; //save type of movement. 0=non-directional, 1 = directional
        private SpriteEffects flip; //is sprite flipped
        private bool attacking = false;

        //-constructor
        public GUI_Anim(Vector2 pPos, Texture2D img, Point pSpriteSize, int pNumSprites, int pRows, int pCols, int msPerFrame, int moveType)
        {
            position = pPos;
            image = img;
            spriteSize = pSpriteSize;
            numSprites = pNumSprites;
            rows = pRows;
            cols = pCols;
            millisecondsPerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            this.moveType = moveType;
        }
        //-constructor
        public GUI_Anim(Texture2D img, Point pSpriteSize, int pNumSprites, int pRows, int pCols, int msPerFrame, int moveType)
        {
            image = img;
            spriteSize = pSpriteSize;
            numSprites = pNumSprites;
            rows = pRows;
            cols = pCols;
            millisecondsPerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            this.moveType = moveType;
        }

        //methods
        //update
        public void Update(GameTime gameTime)
        {
            //time + animation
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0; //frame duration over
                frame++;

                // animation loop over
                if (frame >= numSprites)
                {
                    frame = 0; // restart
                }

                if (moveType == 1)
                {

                    if (oldPos.Y != position.Y) //y movemenr
                    {
                        flip = SpriteEffects.None;
                        switch (frame)
                        {
                            case 0:
                                currentFrame.X = frame * (spriteSize.X / cols);
                                currentFrame.Y = 0;
                                break;
                            case 1:
                                currentFrame.X = frame * (spriteSize.X / cols);
                                currentFrame.Y = 0;
                                break;
                        }
                    }
                    else if (oldPos.X < position.X)
                    {
                        flip = SpriteEffects.None;
                        switch (frame)
                        {
                            case 0:
                                currentFrame.X = (frame * (spriteSize.X / cols)) + 2;
                                currentFrame.Y = 0;
                                break;
                            case 1:
                                currentFrame.X = (frame * (spriteSize.X / cols)) + 2;
                                currentFrame.Y = 0;
                                break;
                        }
                    }
                    else if (oldPos.X > position.X)
                    {
                        flip = SpriteEffects.FlipHorizontally; //flip image
                        switch (frame)
                        {
                            case 0:
                                currentFrame.X = (frame * (spriteSize.X / cols)) + 2;
                                currentFrame.Y = 0;
                                break;
                            case 1:
                                currentFrame.X = (frame * (spriteSize.X / cols)) + 2;
                                currentFrame.Y = 0;
                                break;
                        }
                    }
                }
                else if (moveType == 0)
                {
                    if (attacking == true)
                    {
                        if (currentFrame.Y < 99)
                        {
                            currentFrame.Y += 50;
                        }
                        else
                        {
                            currentFrame.Y = 0;
                            attacking = false;
                        }
                    }
                }
                else
                {
                    // set location of frame to display
                    switch (frame)
                    {
                        case 0:
                            currentFrame.X = frame * (spriteSize.X / cols);
                            currentFrame.Y = 0;
                            break;
                        case 1:
                            currentFrame.X = frame * (spriteSize.X / cols);
                            currentFrame.Y = 0;
                            break;
                        case 2:
                            currentFrame.X = frame * (spriteSize.X / cols);
                            currentFrame.Y = 0;
                            break;
                    }
                }
            }
        }

        public void switchAnim(Enemy enem)
        {

            try
            {
                //if nearest enemy.position.Y > position.Y
                if (enem.Position.Y >= position.Y + 25)
                {
                    currentFrame.X = 0 * (spriteSize.X / cols);
                }
                else
                {
                    currentFrame.X = 1 * (spriteSize.X / cols);
                }
                //face up
                //else face down
                //until then 


            }
            catch(Exception all)
            {

            }
        }

        //draw
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 pPos)
        {
            if (position != pPos)
            {
                oldPos = position; //so it doesn't save over and over
                position = pPos;
            }



            spriteBatch.Draw(image, position, new Rectangle(currentFrame.X, currentFrame.Y, (spriteSize.X / cols), (spriteSize.Y / rows)), // draws image based on given size and frame num
                Color.White, 0, Vector2.Zero, 1f, flip, 1);


        }
        public void SizeChangeDraw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 pPos, float scale)
        {
            
            spriteBatch.Draw(image, pPos, new Rectangle(1, 0, (spriteSize.X / cols), (spriteSize.Y / rows)), // draws image based on given size and frame num
                Color.White, 0, Vector2.Zero, scale, flip, 1);


        }

        public void AttackAnim()
        {
            attacking = true;
            
        }

    }
}

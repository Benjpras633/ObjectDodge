using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTemplate
{
    public partial class GameScreen : UserControl
    {
        // arrow key boolean variables
        Boolean leftArrowDown, rightArrowDown;

        // player variables
        Object player;
        int playerSize = 20; // size of player
        int playerSpeed = 10; // speed of player
        SolidBrush playerBrush = new SolidBrush(Color.White); // brush to draw player

        // object variables
        SolidBrush objectBrush = new SolidBrush(Color.White);
        Random randGen = new Random(); //generates x values and colour of objects 

        // list of all objects
        List<Object> objects = new List<Object>();

        public GameScreen()
        {
            InitializeComponent();
            OnStart(); // call OnStart method
        }

        public void OnStart()
        {
            MakeObjects(); // call MakeObjects method

            player = new Object(this.Width / 2 - playerSize / 2, this.Height - 100, playerSize);
        }

        public void MakeObjects()
        {
            int color = randGen.Next(1, 6);
            int objectX = randGen.Next(1, 781);

            Color c = Color.White;

            if (color == 1)
            {
                c = Color.Green;
            }
            else if (color == 2)
            {
                c = Color.Yellow;
            }
            else if (color == 3)
            {
                c = Color.Red;
            }
            else if (color == 4)
            {
                c = Color.Purple;
            }
            else if (color == 5)
            {
                c = Color.Orange;
            }


            // set object start values
            Object newObject = new Object(objectX, 0, 20, c);
            objects.Add(newObject);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // player button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            // player button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // update location of all boxes (drop down screen)
            foreach (Object b in objects)
            {
                b.Fall(5);
            }

            // remove box if it has gone of screen
            if (objects[0].y > this.Height - 100)
            {
                objects.RemoveAt(0);
            }

            // add new box if it is time
            if (objects[objects.Count - 1].y > 21)
            {
                MakeObjects();
            }

            // controlling hero
            if (leftArrowDown == true && player.x > 0)
            {
                player.Move(playerSpeed, false);
            }
            if (rightArrowDown == true && player.x < this.Width - playerSize - 10)
            {
                player.Move(playerSpeed, true);
            }

            // check for player collision with objects from list
            Rectangle playerRec = new Rectangle(player.x, player.y, player.size, player.size);

            if (objects.Count >= 4)
            {
                // check objects 0-3 in lists
                for (int i = 0; i < 4; i++)
                {
                    Rectangle leftBoxRec = new Rectangle(objects[i].x, objects[i].y, objects[i].size, objects[i].size);

                    // stop game timer 
                    if (leftBoxRec.IntersectsWith(playerRec))
                    {
                        gameTimer.Enabled = false;
                    }
                }
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // draw objects to screen
            foreach (Object o in objects)
            {
                objectBrush.Color = o.color;
                e.Graphics.FillRectangle(objectBrush, o.x, o.y, o.size, o.size);
            }

            // draw player
            e.Graphics.FillRectangle(playerBrush, player.x, player.y, player.size, player.size);
        }
    }
}

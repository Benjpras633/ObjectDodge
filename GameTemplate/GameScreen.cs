using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

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
        int playerScore = 0; // player score
        SolidBrush playerBrush = new SolidBrush(Color.White); // brush to draw player

        // object variables
        SolidBrush objectBrush = new SolidBrush(Color.White); // brush to draw objects
        Random randGen = new Random(); // generates x values and colour of objects 

        // list of all objects
        List<Object> objects = new List<Object>();

        // sounds
        SoundPlayer explosion = new SoundPlayer(Properties.Resources.explosion);

        public GameScreen()
        {
            InitializeComponent();
            OnStart(); // call OnStart method
        }

        public void OnStart()
        {
            MakeObjects(); // call MakeObjects method

            Cursor.Hide(); // hide cursor

            scoreLabel.Text = "Score: " + playerScore; // display on score label

            // draw player in starting position
            player = new Object(this.Width / 2 - playerSize / 2, this.Height - 100, playerSize);
        }

        public void MakeObjects()
        {
            int objectX = randGen.Next(0, 781); // gives x value for each object
            int r = randGen.Next(0, 256);
            int g = randGen.Next(0, 256);
            int b = randGen.Next(0, 256);

            Color c = Color.FromArgb(r, g, b);

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
            // update location of all objects (drop down screen)
            foreach (Object b in objects)
            {
                b.Fall(8);
            }

            // remove object if it has gone off the screen
            if (objects[0].y > this.Height - 50)
            {
                objects.RemoveAt(0);

                // adjust player score and display new player score
                playerScore++;
                scoreLabel.Text = "Score: " + playerScore;
            }

            // add new object if it is time
            if (objects[objects.Count - 1].y > 21)
            {
                MakeObjects();
            }

            // player controls
            if (leftArrowDown == true && player.x > 0)
            {
                player.Move(playerSpeed, false); // move left
            }
            if (rightArrowDown == true && player.x < this.Width - playerSize - 10)
            {
                player.Move(playerSpeed, true); // move right
            }

            // check for player collision with objects from list
            Rectangle playerRec = new Rectangle(player.x, player.y, player.size, player.size);

            if (objects.Count >= 4)
            {
                // check objects 0-3 in lists
                for (int i = 0; i < 4; i++)
                {
                    Rectangle objectRec = new Rectangle(objects[i].x, objects[i].y, objects[i].size, objects[i].size);

                    // stop game timer 
                    if (objectRec.IntersectsWith(playerRec))
                    {
                        Hit(); // call hit method
                    }
                }
            }
            Refresh(); // update game timer
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // draw objects to screen
            foreach (Object o in objects)
            {
                objectBrush.Color = o.color;
                e.Graphics.FillRectangle(objectBrush, o.x, o.y, o.size, o.size);
            }

            // draw player to screen
            e.Graphics.FillRectangle(playerBrush, player.x, player.y, player.size, player.size);
        }

        public void Hit()
        {
            explosion.Play(); // play explosion sound
            gameTimer.Enabled = false; // stop game timer

            // displaying message on screen
            messageLabel.Visible = true;
            messageLabel.Text = "YOU'VE BEEN HIT! \n";

            // making the play again and main menu buttons visible
            playButton.Enabled = true;
            playButton.Visible = true;
            menuButton.Enabled = true;
            menuButton.Visible = true; 
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // deenable and hide buttons
            playButton.Enabled = false;
            playButton.Visible = false;
            menuButton.Enabled = false;
            menuButton.Visible = false;

            // close current game screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            // make new game screen
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Focus();

            // restart game timer
            gameTimer.Enabled = true;

            // hide cursor
            Cursor.Hide();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            // close game screen and open menu screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
            ms.Focus();
        }        
    }
}

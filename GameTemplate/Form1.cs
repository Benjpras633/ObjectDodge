/// Declan Feore
/// October 2020
/// A simple 2d dodging game that uses a class for attributes and behaviours as well as other coding concepts
/// The objective is to get as high a score as possible before being hit by an object
/// Every object dodged successfully is added to the player's score
/// Use left and right arrow keys to control player

using System;
using System.Windows.Forms;

namespace GameTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // open menu screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {

            gameScreen.lives = 5;
            gameScreen.difficulty = 2;
            
            Form1.ChangeScreen(this, new gameScreen());
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            gameScreen.lives = 4;
            gameScreen.difficulty = 4;
            Form1.ChangeScreen(this, new gameScreen());
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            gameScreen.lives = 3;
            gameScreen.difficulty = 6;
            Form1.ChangeScreen(this, new gameScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

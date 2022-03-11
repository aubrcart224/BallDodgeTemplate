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
    public partial class gameScreen : UserControl
    {
        Ball chaseball;
        Player hero;

        List<Ball> dodgeBalls = new List<Ball>();

        Random randgen = new Random();

        Size screenSize;

        public static int gsWidth = 600;
        public static int gsHeight = 600;

        public static int  score;
        public static int lives;
        public static int difficulty;

        //keys
        bool leftArrowDown = false;
        bool rightArrowDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        public gameScreen()
        {
            InitializeComponent();
            InitialzeGame();
        }

        public void InitialzeGame()
        {

            screenSize = new Size(this.Width, this.Height);
            score = 0;
            lives = 3;

            int x = randgen.Next(40, screenSize.Width - 40);
            int y = randgen.Next(40, screenSize.Height - 40);
            chaseball = new Ball(x, y, 8, 8);
            hero = new Player(x, y);
            
            for (int i = 0; i <difficulty; i++)
            {
                NewBall();
            }


        }

        public void NewBall()
        {
            int x = randgen.Next(40, screenSize.Width - 40);
            int y = randgen.Next(40, screenSize.Height - 40);
            Ball b = new Ball(x, y, 8, 8);
            dodgeBalls.Add(b);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            chaseball.Move(screenSize);
            
            foreach (Ball b in dodgeBalls)
            {
                b.Move(screenSize);

                
            }

            if (chaseball.Collision(hero))
            {
                score++;
                NewBall();

            }

            

            foreach (Ball b in dodgeBalls)
            {
                if (b.Collision(hero))
                {
                    lives--;
                    if (lives == 0)
                    {
                        gameTimer.Enabled = false;
                        Form1.ChangeScreen(this, new gameOverScreen());
                        
                    }
                    
                    
                }


            }



            //key intputs 
            if (leftArrowDown == true )
            {
                hero.Move("left", screenSize);
            }
            if (rightArrowDown == true)
            {
                hero.Move("right", screenSize);
            }
            if (upArrowDown == true)
            {
                hero.Move("up", screenSize);
            }
            if (downArrowDown == true)
            {
                hero.Move("down", screenSize);
            }

            Refresh();
        }

        private void gameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;

            }


        }

        private void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {


                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {

            scoreLable.Text = $"{score}";
            livesLable.Text = $"{lives}";

            e.Graphics.FillEllipse(Brushes.Green, chaseball.x, chaseball.y, chaseball.size, chaseball.size);
            
            e.Graphics.FillRectangle(Brushes.White , hero.x, hero.y, hero.width, hero.height);

            foreach (Ball b in dodgeBalls)
            {
                 e.Graphics.FillEllipse(Brushes.Red, b.x, b.y, b.size, b.size);
            }
        }
    }
}

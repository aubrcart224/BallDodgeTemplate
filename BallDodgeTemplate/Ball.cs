using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        public int size = 10;
        public int xSpeed, ySpeed;
        public int x,y;

        //color rectangle 

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x; 
            y = _y; 
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }


        public void Move(Size ss)
        {
           x += xSpeed;
           y += ySpeed;

            //check if ball has reached right and left edge 
            if (x > ss.Width - size || x < 0)
            {
               xSpeed *= -1; ;


            }

            //check for top and bottom collsions
            if (y > ss.Height - size || y < 0)
            {
              ySpeed *= -1; ;
            }
        }
        
        public bool Collision(Player p)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(playerRec))
            {
                if (ySpeed > 0)
                {
                    y = p.y - size;
                }
                else
                {
                    y = p.y + size; 
                }
                    ySpeed *= -1;
                    return true;
                

            }

            //if (scoreDivide = true)

            ////if (gameScreen.score % 5 == 0)
            ////{
            ////    gameScreen.lives++;

            ////}
            return false;
        }

       

    }
}

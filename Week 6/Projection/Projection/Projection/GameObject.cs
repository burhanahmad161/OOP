using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection
{
    class GameObject
    {
        public char[,] shape;
        public string direction;
        public Point startingPoint;
        public Boundary premises;
        public int count;

        public GameObject()
        {
            this.startingPoint.x = 0;
            this.startingPoint.y = 0;

            this.premises.TopLeft.x = 0;
            this.premises.TopLeft.y = 0;

            this.premises.TopRight.x = 0;
            this.premises.TopRight.y = 90;

            this.premises.BottomLeft.x = 90;
            this.premises.BottomLeft.y = 0;

            this.premises.BottomLeft.x = 90;
            this.premises.BottomLeft.y =90;

        }
        public GameObject(char[,] shape, Point startingPoint, Boundary permise, string direction)
        {
            this.shape = shape;
            this.direction = direction;
            this.startingPoint = startingPoint;
            this.premises = permise;
        }
        public GameObject(char[,] shape, Point start)
        {
            this.shape = shape;
            this.startingPoint = start;
            this.premises = new Boundary();
            this.direction = "LeftToRight";
        }
        public void moveLeftToRight()
        {
            if (direction == "LeftToRight")
            {
                if (this.startingPoint.getX() < this.premises.TopRight.x || this.startingPoint.getX() < this.premises.TopRight.y)
                {
                    this.startingPoint.setX(startingPoint.getX() + 1);
                }
            }
        }

        public void moveRightToLeft()
        {
            if (direction == "RightToLeft")
            {
                if (this.startingPoint.getX() > this.premises.TopRight.x || this.startingPoint.getX() > this.premises.TopRight.y)
                {
                    this.startingPoint.setX(startingPoint.getX() - 1);
                }
            }
        }

        public void moveDiagonally()
        {
            if (direction == "diagonal")
            {
                if (this.startingPoint.getX() < this.premises.BottomRight.x || this.startingPoint.getX() > this.premises.TopRight.y)
                {
                    this.startingPoint.setX(startingPoint.getX() + 1);
                    this.startingPoint.setY(startingPoint.getY() + 1);
                }
            }
        }
        public void movePatrol()
        {
            if ((this.direction == "patrol"))
            {
                if (this.direction == "RightToLeft")
                {
                    if (this.startingPoint.x > premises.TopRight.x && this.startingPoint.x < premises.TopLeft.x)
                    {
                        startingPoint.x--;
                    }
                }
                else
                {
                    direction = "LeftToRight";
                }

                if (direction == "LeftToRight")
                {
                    if (this.startingPoint.getX() < premises.TopRight.x && this.startingPoint.getX() > premises.TopLeft.x)
                    {
                        startingPoint.x++;
                    }
                }
                else
                {
                    this.direction = "RightToLeft";
                }
            }
        }
        public void move()
        {
            if (this.direction == "LeftToRight")
            {
                moveLeftToRight();
            }
            else if (this.direction == "RightToLeft")
            {
                moveRightToLeft();
            }
            else if (this.direction == "diagonal")
            {
                moveDiagonally();
            }
            else if (this.direction == "projectile")
            {

                moveProjectile();
            }
            else if (this.direction == "patrol")
            {
                movePatrol();
            }
        }

        public void towardstopright5()
        {

            if (this.startingPoint.getX() < this.premises.TopRight.y)
            {
                this.startingPoint.setY(startingPoint.getY() - 1);
                this.count++;
            }

        }
        public void moverightpro2()
        {
            if (this.startingPoint.getX() < premises.TopRight.y && this.startingPoint.getX() > premises.TopLeft.x)
            {

                this.startingPoint.setX(startingPoint.getX() + 1);
                this.count++;
            }

        }
        public void movebottom4()
        {
            if (this.startingPoint.getY() < this.premises.BottomLeft.y)
            {
                this.startingPoint.setX(this.startingPoint.getX() + 1);
                this.startingPoint.setY(this.startingPoint.getY() + 1);
                this.count++;
            }
        }
        public void moveProjectile()
        {
            if (this.direction == "projectile")
            {
                if (count < 5)
                {
                    towardstopright5();
                }
                if (count >= 5 && count <= 12)
                {
                    moverightpro2();
                }
                if (count > 12 && count <= 16)
                {
                    movebottom4();
                }

            }
        }
        public void erase()
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(startingPoint.x + i, startingPoint.y + j);
                    Console.Write(" ");
                }
            }
        }
        public void print()
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(startingPoint.x + i, startingPoint.y + j);
                    Console.Write(shape[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}

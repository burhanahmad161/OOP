using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class GameObject
    {
        public char[,] shape;
        public string direction;
        public Point startingPoint;
        public Boundary premises;

        public GameObject()
        {
            shape = new char[,] {{ '-', '-', '-' }};
            startingPoint = new Point();
            premises = new Boundary();
            direction = "LeftToRight";
        }
        public GameObject(char[,] shape, Point startingPoint, Boundary permise, string direction)
        {
            this.shape = shape;
            this.direction = direction;
            this.startingPoint = startingPoint;
            this.premises = permise;
        }
        public GameObject(char[,] shape,Point start)
        {
            this.shape = shape;
            this.startingPoint = start;
            this.premises = new Boundary();
            this.direction = "LeftToRight";
        }
        public void moveRight()
        {
            startingPoint.x++;
        }
        public void moveLeft()
        {
            startingPoint.x--;
        }
        public void moveUp()
        {
            startingPoint.y++;
        }
        public void moveDown()
        {
            startingPoint.y--;
        }
        public void erase()
        {
            for(int i=0; i<shape.GetLength(0); i++)
            {
                for (int j=0; j< shape.GetLength(1); j++)
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
                    Console.Write(shape[i,j]);
                }
                Console.WriteLine();
            }
        }

    }
}

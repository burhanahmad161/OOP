using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;

namespace Points
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = new char[5, 3] { { '@', ' ', ' ' }, { '@', '@', ' ' }, { '@', '@', '@' }, { '@', '@', ' ' }, { '@', ' ', ' ' } };
            char[,] opTriangle = new char[5, 3] { { ' ', ' ', '@' }, { ' ', '@', '@' }, { '@', '@', '@' }, { ' ', '@', '@' }, { ' ', ' ', '@' } };
            Boundary b = new Boundary();
            GameObject g1 = new GameObject(triangle, new Point(5, 5), b , "LeftToRight");
            //GameObject g2 = new GameObject(triangle, new Point(30, 60), b, "RightToLeft");
            List<GameObject> lst = new List<GameObject>();
            lst.Add(g1);
            //lst.Add(g2);
            while(true)
            {
                foreach(GameObject g in lst)
                {
                    if(Keyboard.IsKeyPressed(Key.RightArrow))
                    { 
                    g.erase();
                    g.moveRight();
                    g.print();
                    Thread.Sleep(100);                    
                    }
                    if (Keyboard.IsKeyPressed(Key.LeftArrow))
                    {
                        g.erase();
                        g.moveLeft();
                        g.print();
                        Thread.Sleep(100);
                    }
                    if (Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        g.erase();
                        g.moveDown();
                        g.print();
                        Thread.Sleep(100);
                    }
                    if (Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        g.erase();
                        g.moveUp();
                        g.print();
                        Thread.Sleep(100);
                    }
                }
            }

        }

    }
}

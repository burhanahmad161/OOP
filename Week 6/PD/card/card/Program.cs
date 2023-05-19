using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Line_Equation
{
    internal class Program
    {
        public class MyPoint
        {
            public int x;
            public int y;
            public MyPoint()
            {
                x = 0; y = 0;
            }
            public MyPoint(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int GetX()
            {
                return x;
            }
            public int GetY()
            {
                return y;
            }
            void SetX(int x)
            {
                this.x = x;
            }
            void SetY(int y)
            {
                this.y = y;
            }
            void SetXY(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public double distanceWithCords(int x1, int y1)
            {

                double distance = 0;
                distance = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
                return distance;

            }
            public double distancewithobject(MyPoint another)
            {
                another.GetX();
                another.GetY();
                double distance = 0;
                distance = Math.Sqrt(Math.Pow(another.GetX() - x, 2) + Math.Pow(another.GetY() - y, 2));
                return distance;
            }
            double distanceFromZero()
            {
                double distance = 0;
                int x2 = 0;
                int y2 = 0;
                distance = Math.Sqrt(Math.Pow(x - x2, 2) + Math.Pow(y - y2, 2));
                return distance;
            }

        }
        class MyLine
        {
            MyPoint begin;
            MyPoint end;

            public MyLine(MyPoint begin, MyPoint end)
            {
                this.begin = begin;
                this.end = end;
            }
            public MyPoint getBegin()
            {
                return begin;
            }
            public MyPoint getend()
            {
                return end;
            }
            public void setBegin(MyPoint begin)
            {

                this.begin = begin;

            }
            public void setEnd(MyPoint end)
            {
                this.end = end;
            }
            public double getLength()
            {
                return begin.distancewithobject(end);
            }
            public double getGradient()
            {
                double gradient;
                gradient = (end.GetY() - begin.GetY()) / (end.GetX() - begin.GetX());
                return gradient;
            }
        }

        static void Main(string[] args)
        {
            MyLine line = null;
            while (true)
            {
                string option;
                option = Menu();

                if (option == "1")
                {
                    Console.Clear();
                    header();
                    line = MakeALine();
                }
                else if (option == "2")
                {
                    Console.Clear();
                    header();
                    Updatebegin(line);
                }
                else if (option == "3")
                {
                    Console.Clear();
                    header();
                    Updateend(line);
                }
                else if (option == "4")
                {
                    Console.Clear();
                    header();
                    ShowBeginPoint(line);
                }
                else if (option == "5")
                {
                    Console.Clear();
                    header();
                    ShowEndPoint(line);
                }
                else if (option == "6")
                {
                    Console.Clear();
                    header();
                    GetLengthOFLine(line);
                }
                else if (option == "7")
                {
                    Console.Clear();
                    header();
                    GetGradientOfLine(line);
                }
                else if (option == "8")
                {
                    Console.Clear();
                    header();
                    GetDistanceOfBeginPoint(line);
                }
                else if (option == "9")
                {
                    Console.Clear();
                    header();
                    GetDistanceOfEndPoint(line);
                }
                else if (option == "10")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input...");
                    Console.WriteLine("Try Again");
                    Console.ReadKey();
                }
            }

            Console.ReadKey();
        }
        static MyLine MakeALine()
        {
            int x1, x2, y1, y2;
            Console.WriteLine("Enter the x1 point :");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the x2 point :");
            x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the y1 point :");
            y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the y2 point :");
            y2 = int.Parse(Console.ReadLine());
            MyPoint point = new MyPoint(x1, y1);
            MyPoint point1 = new MyPoint(x2, y2);
            MyLine line = new MyLine(point, point1);
            return line;

        }
        static void Updatebegin(MyLine line)
        {
            int changeX, changeY;
            Console.WriteLine("Enter new x point :");
            changeX = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new y point :");
            changeY = int.Parse(Console.ReadLine());

            MyPoint ChangePoint = new MyPoint(changeX, changeY);
            line.setBegin(ChangePoint);
        }

        static void Updateend(MyLine line)
        {
            int ChangeEndX, ChangeEndY;
            Console.WriteLine("Enter the new X point :");
            ChangeEndX = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Y point :");
            ChangeEndY = int.Parse(Console.ReadLine());

            MyPoint ChangeEndPoint = new MyPoint(ChangeEndX, ChangeEndY);
            line.setEnd(ChangeEndPoint);

        }
        static void ShowBeginPoint(MyLine line)
        {
            Console.WriteLine(line.getBegin().x);
            Console.WriteLine(line.getBegin().y);
        }
        static void ShowEndPoint(MyLine line)
        {
            Console.WriteLine(line.getend().x);
            Console.WriteLine(line.getend().y);
        }
        static void GetLengthOFLine(MyLine line)

        {
            Console.WriteLine("The Length of Line is : " + line.getLength());

        }
        static void GetGradientOfLine(MyLine line)
        {
            Console.WriteLine("The gradient of line is :" + line.getGradient());
        }
        static void GetDistanceOfBeginPoint(MyLine line)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow(line.getBegin().x - 0, 2) + Math.Pow(line.getBegin().y - 0, 2));
            Console.WriteLine("Distance of beginning points from zero coordinates are :" + distance);
        }
        static void GetDistanceOfEndPoint(MyLine line)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow(line.getend().x - 0, 2) + Math.Pow(line.getend().y - 0, 2));
            Console.WriteLine("Distance of Ending points from zero coordinates are :" + distance);
        }
        static string Menu()
        {
            string choice;
            header();
            Console.WriteLine("1. Make a Line");
            Console.WriteLine("2. Update the begin point");
            Console.WriteLine("3. Update the end point");
            Console.WriteLine("4. Show the begin point");
            Console.WriteLine("5. Show the end point");
            Console.WriteLine("6. Get the Length of the line");
            Console.WriteLine("7. Get the gradient of the line");
            Console.WriteLine("8. Find the distance of begin point from zero coordinates");
            Console.WriteLine("9. Find the distance of end point from zero coordinates");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }
        static void header()
        {
            Console.Clear();
            Console.WriteLine("********************************");
            Console.WriteLine("**********Line Equation*********");
            Console.WriteLine("********************************");
        }
    }
}

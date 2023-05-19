using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation
{
    internal class Program
    {
        public class Angle
        {
            public int degree;
            public float minute;
            public char direction;
            public Angle(int degree, float minute, char direction)
            {
                this.degree = degree;
                this.minute = minute;
                this.direction = direction;
            }


        }
        public class Ship
        {
            public Angle latitude;
            public Angle longitude;
            public String SerialNumber;

            public Ship()
            { }
            public Ship(int degree, float minute, char direction, int degree1, float minute1, char direction1, string Ship_ID)
            {
                Angle obj = new Angle(degree, minute, direction);
                Angle obj2 = new Angle(degree1, minute1, direction1);
                latitude = obj;
                longitude = obj2;
                this.SerialNumber = Ship_ID;

            }

            public void ViewShipPosition()
            {
                Console.WriteLine("Latitude is : " + latitude.degree + "\u00b0" + latitude.minute + "'" + latitude.direction);
                Console.WriteLine("Longitude is : " + longitude.degree + "\u00b0" + longitude.minute + "'" + longitude.direction);
                Console.ReadKey();
            }
            public void ViewShipSerialNumber()
            {
                Console.WriteLine("Serial number of the given ship is : {0}", SerialNumber);
            }
        }

        static void Main(string[] args)
        {

            List<Ship> ShipList = new List<Ship>();

            int option;

            while (true)
            {
                Console.Clear();
                DriverMenu();
                Console.Write("Enter the Options: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    AddShip(ShipList);
                }
                else if (option == 2)
                {
                    Ship s = new Ship();
                    s = searchShipBySerialNumber(ShipList);
                    if (s != null)
                        s.ViewShipPosition();
                    else
                        Console.WriteLine("Invalid ship ID");

                }
                else if (option == 3)
                {
                    Ship s = new Ship();

                    s = searchShipByPosition(ShipList);

                    if (s != null)
                        s.ViewShipSerialNumber();
                    else
                        Console.WriteLine("Invalid ship Location");
                }
                else if (option == 4)
                {
                    ChangeShipPosition(ShipList);
                }
                else
                {
                    if (option == 5)
                        break;
                }
                Console.ReadKey();
            }


        }
        static void DriverMenu()

        {
            Console.WriteLine("1- Add A New Ship");
            Console.WriteLine("2- View Position of Ship");
            Console.WriteLine("3- View Ship Serial Number");
            Console.WriteLine("4- Change Ship Position");
            Console.WriteLine("5- Exit");

        }
        static void AddShip(List<Ship> ShipList)
        {

            Console.Write("Enter the degree of Latitude :");
            int degree = int.Parse(Console.ReadLine());
            Console.Write("Enter the minutes of latitude :");
            float minute = float.Parse(Console.ReadLine());
            Console.Write("Enter the direction of latitude :");
            char direction = char.Parse(Console.ReadLine());
            Console.Write("Enter the degree of Longitude :");
            int degree1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the Minutes of Longitude :");
            float minutes1 = float.Parse(Console.ReadLine());
            Console.Write("Enter the direction of Longitude :");
            char direction1 = char.Parse(Console.ReadLine());
            Console.Write("Enter ship ID : ");
            String Ship_ID = Console.ReadLine();
            Ship ShipObject = new Ship(degree, minute, direction, degree1, minutes1, direction1, Ship_ID);
            ShipList.Add(ShipObject);
            Console.WriteLine(Ship_ID + "has been added!");
            Console.ReadKey();


        }
        static Ship searchShipBySerialNumber(List<Ship> ShipList)
        {
            Console.WriteLine("Enter the Ship Id to track the Ship Location");
            String ShipID = Console.ReadLine();
            for (int i = 0; i < ShipList.Count(); i++)
            {
                if (ShipList[i].SerialNumber == ShipID)
                    return ShipList[i];
            }

            return null;
        }
        static Ship searchShipByPosition(List<Ship> ShipList)
        {
            Console.Write("Enter the degree of Latitude :");
            int DegreeOfLatitude = int.Parse(Console.ReadLine());

            Console.Write("Enter the minutes of latitude :");
            float MinutesOfLatitude = float.Parse(Console.ReadLine());

            Console.Write("Enter the direction of latitude :");
            Char DirectionOfLatitude = char.Parse(Console.ReadLine());

            Angle obj = new Angle(DegreeOfLatitude, MinutesOfLatitude, DirectionOfLatitude);

            Console.Write("Enter the degree of Longitude :");
            int DegreeOfLongitude = int.Parse(Console.ReadLine());

            Console.Write("Enter the Minutes of Longitude :");
            float MinuteOfLongitude = float.Parse(Console.ReadLine());

            Console.Write("Enter the direction of Longitude :");
            char DirectionOfLongitude = char.Parse(Console.ReadLine());

            Angle obj2 = new Angle(DegreeOfLongitude, MinuteOfLongitude, DirectionOfLongitude);

            for (int i = 0; i < ShipList.Count(); i++)
            {
                if (ShipList[i].latitude.degree == obj.degree && ShipList[i].latitude.minute == obj.minute && ShipList[i].latitude.direction == obj.direction &&
                    ShipList[i].longitude.degree == obj2.degree && ShipList[i].longitude.minute == obj2.minute && ShipList[i].longitude.direction == obj2.direction)
                    return ShipList[i];
            }
            return null;
        }
        static void ChangeShipPosition(List<Ship> ShipList)
        {
            bool flag = true;
            Console.Write("Enter the Ship Id of which you want to change the position : ");
            String ShipId = Console.ReadLine();
            for (int i = 0; i < ShipList.Count(); i++)
            {
                if (ShipList[i].SerialNumber == ShipId)
                {
                    flag = false;
                    Console.WriteLine("Enter the New Location of the Ship :");

                    Console.Write("Enter the new degree of Latitude :");
                    int NewDegreeOfLatitude = int.Parse(Console.ReadLine());

                    Console.Write("Enter the new minutes of latitude :");
                    float NewMinutesOfLatitude = float.Parse(Console.ReadLine());

                    Console.Write("Enter the new direction of latitude :");
                    char NewDirectionOfLatitude = char.Parse(Console.ReadLine());

                    Console.Write("Enter the new degree of Latitude :");
                    int NewDegreeOfLongitude = int.Parse(Console.ReadLine());

                    Console.Write("Enter the new minutes of latitude :");
                    float NewMinutesOfLongitude = float.Parse(Console.ReadLine());

                    Console.Write("Enter the new direction of latitude :");
                    char NewDirectionOfLongitude = char.Parse(Console.ReadLine());

                    ShipList[i].latitude.degree = NewDegreeOfLatitude;
                    ShipList[i].latitude.minute = NewMinutesOfLatitude;
                    ShipList[i].latitude.direction = NewDirectionOfLatitude;
                    ShipList[i].longitude.degree = NewDegreeOfLongitude;
                    ShipList[i].longitude.minute = NewMinutesOfLongitude;
                    ShipList[i].longitude.direction = NewDirectionOfLongitude;

                    Console.WriteLine("Position of " + ShipList[i].SerialNumber + " has been changed successfully!");
                }
                if (flag)
                    Console.Write("Invalid Serial number !");
            }
        }


    }
}

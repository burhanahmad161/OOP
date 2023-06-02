using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocean.BL;
using Ocean.DL;
using Ocean.UI;


namespace Ocean.UI
{
    class UI
    {
        public  static void DriverMenu()
        {
            Console.WriteLine("1- Add A New Ship");
            Console.WriteLine("2- View Position of Ship");
            Console.WriteLine("3- View Ship Serial Number");
            Console.WriteLine("4- Change Ship Position");
            Console.WriteLine("5- Exit");
        }
        public static Ship AddShip()
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
            return ShipObject;
        }
        public static Ship searchShipByPosition(List<Ship> ShipList)
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
        public static void ChangeShipPosition(List<Ship> ShipList)
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

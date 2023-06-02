using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.BL
{
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
}

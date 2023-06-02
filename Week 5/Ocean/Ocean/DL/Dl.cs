using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocean.DL;
using Ocean.BL;
using Ocean.UI;

namespace Ocean.DL
{
    class Dl
    {
        public static List<Ship> ShipList = new List<Ship>();
        public static bool addShipToList(Ship newObj)
        {
            ShipList.Add(newObj);
            return true;
        }
        public static Ship searchShipBySerialNumber(List<Ship> ShipList)
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
    }
}

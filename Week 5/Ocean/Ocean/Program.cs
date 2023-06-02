using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocean.BL;
using Ocean.DL;
using Ocean.UI;

namespace OceanNavigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;

            while (true)
            {
                Console.Clear();
                UI.DriverMenu();
                Console.Write("Enter the Options: ");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    UI.AddShip();
                }
                else if (option == 2)
                {
                    Ship s = new Ship();
                    s = Dl.searchShipBySerialNumber(Dl.ShipList);
                    if (s != null)
                        s.ViewShipPosition();
                    else
                        Console.WriteLine("Invalid ship ID");

                }
                else if (option == 3)
                {
                    Ship s = new Ship();

                    s = UI.searchShipByPosition(Dl.ShipList);

                    if (s != null)
                        s.ViewShipSerialNumber();
                    else
                        Console.WriteLine("Invalid ship Location");
                }
                else if (option == 4)
                {
                    UI.ChangeShipPosition(Dl.ShipList);
                }
                else
                {
                    if (option == 5)
                        break;
                }
                Console.ReadKey();
            }


        }
        

    }
}

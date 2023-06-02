using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    class Program
    {
        /*static void Main(string[] args)
        {
            DayScholar std = new DayScholar();
            std.name = "Burhan";
            std.busNo = 1;
            Console.WriteLine(std.name + " is allocated bus number " + std.busNo);
            Console.ReadKey();
        }*/
        static void Main(string[] args)
        {
            Hostelite std = new Hostelite();
            std.name = "Burhan";
            std.RoomNumber = 12;
            Console.WriteLine(std.name + " is allocated bus number " + std.RoomNumber);
            Console.ReadKey();
        }
    }
}

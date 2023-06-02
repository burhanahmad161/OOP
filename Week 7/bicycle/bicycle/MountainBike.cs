using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycle
{
    class MountainBike : Bicycle
    {
        public int seatHeight;

        public MountainBike(int cadence, int gear, int speed, int h) : base(cadence, gear , speed)
        {
            seatHeight = h;
        }
        public void setSeatHeight(int seatHeight)
        {
            // function to set seat height
        }
  
    }
}

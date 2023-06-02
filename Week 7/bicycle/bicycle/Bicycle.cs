using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycle
{
    class Bicycle
    {
        public int Cadence;
        public int Gear;
        public int Speed;
        public Bicycle(int cadence,int gear,int speed)
        {
            this.Cadence = cadence;
            this.Gear = gear;
            this.Speed = speed;
        }
        public void setCadence(int cardence)
        {
            // funtion to calculate candence
        }
        public void setGear(int Gear)
        {
            // function to change gear
        }
        public void applyBrake(int decrement)
        {
            // function to apply brake
        }
        public void speedUp(int increment)
        {
            // function to increase speed
        }
    }
}

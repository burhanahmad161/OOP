using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge01
{
    class FireTruck
    {
        private Ladder ladder;
        private HosePipe hosepipe;
        private FireFighter firefighter;

        public void setHosePipe(HosePipe pipe)
        {
            hosepipe = pipe;
        }

        public void ladderConstruct(string color,float length)
        {

            Ladder L = new Ladder();
            L.length = length;
            L.color = color;
            ladder = L;
        }
    }
}

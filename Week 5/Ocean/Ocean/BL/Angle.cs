using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.BL
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS6.BL
{
    class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        public Subject(string Code, string Type, int CreditHours, int SubjectFees)
        {
            this.code = Code;
            this.type = Type;
            this.creditHours = CreditHours;
            this.subjectFees = SubjectFees;
        }
    }


}

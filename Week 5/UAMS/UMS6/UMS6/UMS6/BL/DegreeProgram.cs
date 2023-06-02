using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS6.BL
{
    class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects;
        public int seats;

        public DegreeProgram(string DegreeName, float DegreeDuration , int seats)
        {
            this.degreeName = DegreeName;
            this.degreeDuration = DegreeDuration;
            this.seats = seats;

            subjects = new List<Subject>();
        }

        public bool isSubjectExists(Subject sub)
        {
            foreach(Subject s in subjects)
            {
                if(s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if(creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int calculateCreditHours()
        {
            int count = 0;
            for(int x = 0; x < subjects.Count; x++)
            {
                count = count + subjects[x].creditHours;
            }
            return count;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPA_Calculator
{
    public static class UnitCalculator
    {
        public static (char Grade, int GradeUnit, string Remark) Gradescore(int score)
        {

            if (score >= 70 && score <= 100)
            {
                return ('A', 5, "Excellent");
            }
            else if (score >= 60 && score <= 69)
            {
                return ('B', 4, "Very Good");
            }
            else if (score >= 50 && score <= 59)
            {
                return ('C', 3, "Good");
            }
            else if (score >= 45 && score <= 49)
            {
                return ('D', 2, "Pass");
            }
            else if (score >= 40 && score <= 44)
            {
                return ('E', 1, "Poor");
            }
            else
            {
                return ('F', 0, "Fail");
            }            
        }
    }
}

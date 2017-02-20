using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_68
{
    public class Day
    {
        public static string Solve(int year)
        {
            if (year != 1918)
            {
                bool learYear = false;

                if (year <= 1917 && year % 4 == 0)
                {
                    learYear = true;
                }

                if (year > 1917 && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0))
                {
                    learYear = true;
                }

                int day = learYear ? 12 : 13;

                return string.Format("{0}.09.{1}", day, year);
            }

            return "26.09.1918";
        }
    }
}

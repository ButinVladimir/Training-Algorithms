using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class DayOfTheProgrammer
    {
        public static string Solve(int year)
        {
            if (year == 1918)
            {
                return "26.09." + year;
            }

            if (year < 1918 && year % 4 == 0)
            {
                return "12.09." + year;
            }

            if (year >= 1918 && (year % 400 == 0) || (year % 100 != 0 && year % 4 == 0))
            {
                return "12.09." + year;
            }

            return "13.09." + year;
        }
    }
}

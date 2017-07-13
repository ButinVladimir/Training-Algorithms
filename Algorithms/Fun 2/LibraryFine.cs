using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class LibraryFine
    {
        public static int Solve(
            int returnDay,
            int returnMonth,
            int returnYear,
            int expectedDay,
            int expectedMonth,
            int expectedYear)
        {
            if (returnYear > expectedYear)
            {
                return 10000;
            }
            if (returnYear < expectedYear)
            {
                return 0;
            }

            if (returnMonth > expectedMonth)
            {
                return 500 * (returnMonth - expectedMonth);
            }
            if (returnMonth < expectedMonth)
            {
                return 0;
            }

            if (returnDay > expectedDay)
            {
                return 15 * (returnDay - expectedDay);
            }

            return 0;
        }
    }
}

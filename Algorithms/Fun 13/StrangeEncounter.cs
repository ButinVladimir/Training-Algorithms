using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class StrangeEncounter
    {
        public static long Solve(long t)
        {
            long initValue = 3;
            while (t > initValue)
            {
                t -= initValue;
                initValue *= 2;
            }

            return initValue - t + 1;
        }
    }
}

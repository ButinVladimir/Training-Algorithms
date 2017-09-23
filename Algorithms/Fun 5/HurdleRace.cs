using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class HurdleRace
    {
        public static int Solve(int[] a, int k)
        {
            return Math.Max(a.Max() - k, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class BirthdayCakeCandles
    {
        public static int Solve(int[] a)
        {
            int max = a.Max();
            return a.Count(v => v == max);
        }
    }
}

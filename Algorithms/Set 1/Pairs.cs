using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_1
{
    public static class Pairs
    {
        public static int Solve(long[] a, long k)
        {
            SortedSet<long> set = new SortedSet<long>();

            foreach (long value in a)
            {
                set.Add(value);
            }

            int result = 0;
            foreach (long value in set)
            {
                if (set.Contains(value - k))
                {
                    result++;
                }
            }

            return result;
        }
    }
}

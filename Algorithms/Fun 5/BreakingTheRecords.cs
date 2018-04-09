using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class BreakingTheRecords
    {
        public static Tuple<int, int> Solve(int[] a)
        {
            int min = a[0];
            int max = a[0];
            int countMin = 0;
            int countMax = 0;

            for (int i=1;i<a.Length;i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                    countMax++;
                }

                if (a[i] < min)
                {
                    min = a[i];
                    countMin++;
                }
            }

            return new Tuple<int, int>(countMax, countMin);
        }
    }
}

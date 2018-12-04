using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class CompareTheTriplets
    {
        public static Tuple<int, int> Solve(int[] a, int[] b)
        {
            int resultA = 0;
            int resultB = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    resultA++;
                }
                else
                if (a[i] < b[i])
                {
                    resultB++;
                }
            }

            return new Tuple<int, int>(resultA, resultB);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class RunningTimeOfAlgorithms
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            int b;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j > 0 && a[j] < a[j - 1]; j--)
                {
                    b = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = b;
                    result++;
                }
            }

            return result;
        }
    }
}

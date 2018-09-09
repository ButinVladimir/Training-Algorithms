using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class TheMaximumSubarray
    {
        public static int SolveSubarray(int[] a)
        {
            int result = a[0];
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                result = Math.Max(sum, result);
                if (sum < 0)
                {
                    sum = 0;
                }
            }

            return result;
        }

        public static int SolveSubsequence(int[] a)
        {
            int result = a[0];
            int sum = 0;

            for (int i=0;i<a.Length;i++)
            {
                result = Math.Max(a[i], result);
                if (a[i] > 0)
                {
                    sum += a[i];
                }
            }

            if (sum > 0)
            {
                result = Math.Max(result, sum);
            }

            return result;
        }
    }
}

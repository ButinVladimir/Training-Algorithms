using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class DifferencePairs
    {
        public static long Solve(long[] a, long k)
        {
            Array.Sort(a);
            long left = 0;
            long right = 0;
            long result = 0;

            long countLeft, countRight;

            while (left < a.Length)
            {
                while (right < a.Length && a[right] - a[left] < k)
                {
                    right++;
                }

                if (right >= a.Length)
                {
                    break;
                }

                countLeft = 0;

                while (countLeft + left < a.Length && a[left] == a[left + countLeft])
                {
                    countLeft++;
                }

                if (a[right] - a[left] == k)
                {
                    countRight = 0;

                    while (countRight + right < a.Length && a[right] == a[right + countRight])
                    {
                        countRight++;
                    }

                    result += countLeft * countRight;
                }

                left += countLeft;
            }

            return result;
        }
    }
}

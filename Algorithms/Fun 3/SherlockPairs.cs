using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class SherlockPairs
    {
        public static long Solve(int[] a)
        {
            Array.Sort(a);

            int left = 0;
            int right;
            long result = 0;
            long cnt;

            while (left < a.Length)
            {
                right = left;

                while (right < a.Length && a[left] == a[right])
                {
                    right++;
                }

                cnt = right - left;
                result += cnt * (cnt - 1);
                left = right;
            }

            return result;
        }
    }
}

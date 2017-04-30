using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class GreedyFlorist
    {
        public static long Solve(long[] a, int k)
        {
            Array.Sort(a);
            Array.Reverse(a);

            int currentFriend = 0;
            int x = 0;
            long result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result += a[i] * (x + 1);

                currentFriend++;
                if (currentFriend == k)
                {
                    currentFriend = 0;
                    x++;
                }
            }

            return result;
        }
    }
}

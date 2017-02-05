using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_66
{
    class Plants
    {
        public static int Solve(long[] amount)
        {
            int n = amount.Length;
            int[] link = new int[n];
            int[] length = new int[n];

            link[0] = -1;
            length[0] = 0;

            int prev, currentLength;

            for (int current = 1; current < n; current++)
            {
                prev = current - 1;
                currentLength = 0;
                while (prev >= 0 && amount[prev] >= amount[current])
                {
                    currentLength = Math.Max(currentLength, length[prev]);
                    prev = link[prev];
                }

                if (prev == -1)
                {
                    currentLength = 0;
                }
                else
                {
                    currentLength++;
                }

                link[current] = prev;
                length[current] = currentLength;
            }

            int result = length[0];
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, length[i]);
            }

            return result;
        }
    }
}

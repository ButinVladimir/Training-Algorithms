using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_38
{
    public class ThreeBalls
    {
        public static bool Solve(int[] sizes)
        {
            Array.Sort(sizes);
            List<int> sortedList = new List<int>();

            int current, next;
            current = 0;
            while (current < sizes.Length)
            {
                sortedList.Add(sizes[current]);

                next = current + 1;
                while (next < sizes.Length && sizes[current] == sizes[next])
                {
                    next++;
                }

                current = next;
            }

            int[] sortedSizes = sortedList.ToArray();
            int n = sortedSizes.Length - 2;
            for (int i = 0; i < n; i++)
            {
                if (sortedSizes[i + 2] - sortedSizes[i] == 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Knapsack
    {
        public static int Solve(int n, int k, int[] items)
        {
            bool[] reach = new bool[k + 1];
            reach[0] = true;

            int nextReach;
            int result = 0;

            for (int i = 0; i <= k; i++)
            {
                if (!reach[i])
                {
                    continue;
                }

                result = Math.Max(result, i);

                for (int j = 0; j < n; j++)
                {
                    nextReach = i + items[j];
                    if (nextReach <= k)
                    {
                        reach[nextReach] = true;
                    }
                }
            }

            return result;
        }
    }
}

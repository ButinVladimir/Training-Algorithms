using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class MinimumSwaps2
    {
        public static int Solve(int[] array)
        {
            int n = array.Length;
            int[] positions = new int[n];
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                array[i]--;
                positions[array[i]] = i;
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                int start = i;
                if (visited[start])
                {
                    continue;
                }

                visited[start] = true;
                int current = positions[start];
                while (current != start)
                {
                    visited[current] = true;
                    result++;
                    current = positions[current];
                }
            }

            return result;
        }
    }
}

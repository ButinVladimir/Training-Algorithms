using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class LilyHomework
    {
        public static int Solve(int[] a)
        {
            int n = a.Length;

            Dictionary<int, int> valueToLocationMap = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                valueToLocationMap[a[i]] = i;
            }

            int[] b = new int[n];
            bool[] visited = new bool[n];
            a.CopyTo(b, 0);
            Array.Sort(b);

            int result = CalculateHops(n, b, valueToLocationMap, visited);
            Array.Reverse(b);

            return Math.Min(result, CalculateHops(n, b, valueToLocationMap, visited));
        }

        private static int CalculateHops(int n, int[] b, Dictionary<int, int> valueToLocationMap, bool[] visited)
        {
            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
            }

            int result = 0;
            int pos;
            for (int start = 0; start < n; start++)
            {
                if (visited[start])
                {
                    continue;
                }
                visited[start] = true;

                pos = valueToLocationMap[b[start]];
                while (pos != start)
                {
                    visited[pos] = true;
                    result++;
                    pos = valueToLocationMap[b[pos]];
                }
            }

            return result;
        }
    }
}

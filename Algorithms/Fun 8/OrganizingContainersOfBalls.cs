using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class OrganizingContainersOfBalls
    {
        public static bool Solve(int n, long[,] m)
        {
            bool[,] can = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    long sum = 0;

                    for (int k = 0; k < n; k++)
                    {
                        sum += m[i, k] - m[k, j];
                    }

                    can[i, j] = sum == 0;
                }
            }

            bool[] visited = new bool[n];
            int[] from = new int[n];
            for (int i = 0; i < n; i++)
            {
                from[i] = -1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    visited[j] = false;
                }

                Kuhn(i, n, visited, from, can);
            }

            return from.All(v => v != -1);
        }

        private static bool Kuhn(int v, int n, bool[] visited, int[] from, bool[,] can)
        {
            if (visited[v])
            {
                return false;
            }

            visited[v] = true;
            for (int to = 0; to < n; to ++)
            {
                if (can[v, to] && (from[to] == -1 || Kuhn(from[to], n, visited, from, can)))
                {
                    from[to] = v;

                    return true;
                }
            }

            return false;
        }
    }
}

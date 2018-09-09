using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class RedKnightShortestPath
    {
        private static readonly int[] dx = { -2, -2, 0, 2, 2, 0 };
        private static readonly int[] dy = { -1, 1, 2, 1, -1, -2 };
        private static readonly string[] labels = { "UL", "UR", "R", "LR", "LL", "L" };

        public static string[] Solve(int n, int istart, int jstart, int iend, int jend)
        {
            int[,] distance = new int[n, n];
            int[,] moves = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distance[i, j] = -1;
                }
            }

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(istart, jstart));
            distance[istart, jstart] = 0;

            int x, y, nx, ny;
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                x = p.Item1;
                y = p.Item2;
                for (int i = 0; i < 6; i++)
                {
                    nx = x + dx[i];
                    ny = y + dy[i];

                    if (nx >= 0 && nx < n && ny >= 0 && ny < n && distance[nx, ny] == -1)
                    {
                        distance[nx, ny] = distance[x, y] + 1;
                        moves[nx, ny] = i;
                        queue.Enqueue(new Tuple<int, int>(nx, ny));
                    }
                }
            }

            if (distance[iend, jend] == -1)
            {
                return new string[0];
            }

            int l = distance[iend, jend];
            int m;
            string[] result = new string[l];
            while (l > 0)
            {
                m = moves[iend, jend];
                result[l - 1] = labels[m];
                iend -= dx[m];
                jend -= dy[m];
                l--;
            }

            return result;
        }
    }
}

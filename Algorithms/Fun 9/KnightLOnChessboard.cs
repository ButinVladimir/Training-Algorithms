using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class KnightLOnChessboard
    {
        private static readonly int[] dx = { -1, -1, 1, 1 };
        private static readonly int[] dy = { -1, 1, -1, 1 };

        public static int[,] Solve(int n)
        {
            int[,] distance = new int[n, n];
            int[,] result = new int[n - 1, n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i; j < n - 1; j++)
                {
                    result[j, i] = result[i, j] = Visit(i + 1, j + 1, n, distance);
                }
            }

            return result;
        }

        private static int Visit(int a, int b, int n, int[,] distance)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distance[i, j] = -1;
                }
            }

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));
            distance[0, 0] = 0;
            int x, y;
            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                x = pos.Item1;
                y = pos.Item2;

                for (int i = 0; i < 4; i++)
                {
                    TryGo(x, y, x + dx[i] * a, y + dy[i] * b, n, queue, distance);
                    TryGo(x, y, x + dx[i] * b, y + dy[i] * a, n, queue, distance);
                }
            }

            return distance[n - 1, n - 1];
        }

        private static void TryGo(int x, int y, int nx, int ny, int n, Queue<Tuple<int, int>> queue, int[,] distance)
        {
            if (nx >= 0 && nx < n && ny >= 0 && ny < n && distance[nx, ny] == -1)
            {
                queue.Enqueue(new Tuple<int, int>(nx, ny));
                distance[nx, ny] = distance[x, y] + 1;
            }
        }
    }
}

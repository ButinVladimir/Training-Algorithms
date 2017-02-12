using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_67
{
    class Knight
    {
        private static readonly int[] dx = { -1, -1, 1, 1 };
        private static readonly int[] dy = { -1, 1, -1, 1 };

        public static int Solve(int n, int a, int b)
        {
            int[,] steps = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    steps[i, j] = int.MaxValue;
                }
            }

            steps[0, 0] = 0;
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));

            int x, y;
            while (queue.Count > 0)
            {
                var top = queue.Dequeue();
                x = top.Item1;
                y = top.Item2;

                if (x == n - 1 && y == n - 1)
                {
                    return steps[x, y];
                }

                for (int i = 0; i < 4; i++)
                {
                    Go(x + dx[i] * a, y + dy[i] * b, steps[x, y] + 1, steps, queue, n);
                    Go(x + dx[i] * b, y + dy[i] * a, steps[x, y] + 1, steps, queue, n);
                }
            }

            return -1;
        }

        private static void Go(int nx, int ny, int nv, int[,] steps, Queue<Tuple<int, int>> queue, int n)
        {
            if (nx >= 0 && nx < n && ny >= 0 && ny < n && steps[nx, ny] > nv)
            {
                steps[nx, ny] = nv;
                queue.Enqueue(new Tuple<int, int>(nx, ny));
            }
        }
    }
}

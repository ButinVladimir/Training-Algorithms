using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public class ConnectedCells
    {
        private static readonly int[] dx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        private static readonly int[] dy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };

        public int[,] Grid { get; set; }

        private int n;
        private int m;

        public int Solve()
        {
            this.n = this.Grid.GetLength(0);
            this.m = this.Grid.GetLength(1);

            int result = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (this.Grid[i, j] != 0)
                    {
                        result = Math.Max(result, GetArea(i, j));
                    }
                }
            }

            return result;
        }

        private int GetArea(int x, int y)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(new Tuple<int, int>(x, y));
            this.Grid[x, y] = 0;
            int result = 1;

            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();
                int sx = currentItem.Item1;
                int sy = currentItem.Item2;

                for (int i=0;i<dx.Length;i++)
                {
                    int nx = sx + dx[i];
                    int ny = sy + dy[i];

                    if (nx >= 0 && nx < this.n && ny >= 0 && ny < m && this.Grid[nx, ny] != 0)
                    {
                        this.Grid[nx, ny] = 0;
                        queue.Enqueue(new Tuple<int, int>(nx, ny));
                        result++;
                    }
                }
            }

            return result;
        }
    }
}

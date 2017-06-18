using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public class CountLuck
    {
        private static readonly int[] dx = new int[] { -1, 1, 0, 0 };
        private static readonly int[] dy = new int[] { 0, 0, -1, 1 };

        public string[] Grid { get; set; }
        public int K { get; set; }

        private int n;
        private int m;
        private int[,] distance;
        private int[,] pred;

        public bool Solve()
        {
            this.n = this.Grid.Length;
            this.m = this.Grid[0].Length;
            this.distance = new int[this.n, this.m];
            this.pred = new int[this.n, this.m];

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (this.Grid[i][j] == 'M')
                    {
                        queue.Enqueue(new Tuple<int, int>(i, j));
                        distance[i, j] = 1;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                int sx = pos.Item1;
                int sy = pos.Item2;
                int nx, ny;

                if (this.Grid[sx][sy] == '*')
                {
                    return this.GetCount(sx, sy) == this.K;
                }

                for (int i = 0; i < 4; i++)
                {
                    nx = sx + dx[i];
                    ny = sy + dy[i];

                    if (CheckPos(nx, ny) && this.Grid[nx][ny] != 'X' && this.distance[nx, ny] == 0)
                    {
                        this.distance[nx, ny] = this.distance[sx, sy] + 1;
                        this.pred[nx, ny] = i;
                        queue.Enqueue(new Tuple<int, int>(nx, ny));
                    }
                }
            }

            return false;
        }

        private int GetCount(int x, int y)
        {
            int length = this.distance[x, y] - 1;
            int result = 0;
            int nx, ny, c;

            for (; length > 0; length--)
            {
                nx = x - dx[this.pred[x, y]];
                ny = y - dy[this.pred[x, y]];
                x = nx;
                y = ny;

                c = 0;
                for (int i = 0; i < 4; i++)
                {
                    nx = x + dx[i];
                    ny = y + dy[i];

                    if (CheckPos(nx, ny) && this.distance[x, y] + 1 == this.distance[nx, ny])
                    {
                        c++;
                    }
                }

                if (c > 1)
                {
                    result++;
                }
            }

            return result;
        }

        private bool CheckPos(int x, int y)
        {
            return x >= 0 && x < this.n && y >= 0 && y < this.m;
        }
    }
}

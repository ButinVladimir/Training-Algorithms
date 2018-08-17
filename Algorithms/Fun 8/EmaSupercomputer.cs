using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public class EmaSupercomputer
    {
        private static readonly int[] dx = { -1, 1, 0, 0 };
        private static readonly int[] dy = { 0, 0, -1, 1 };
        private int n;
        private int m;
        private string[] input;
        private int[,] pluses;

        public int Solve(string[] input)
        {
            this.input = input;
            this.n = this.input.Length;
            this.m = this.input[0].Length;

            this.DeterminePluses();

            return this.IterateFirstPlus();
        }

        private void DeterminePluses()
        {
            this.pluses = new int[this.n, this.m];
            bool correct;
            int nx, ny;

            for (int x = 0; x < this.n; x++)
            {
                for (int y = 0; y < this.m; y++)
                {
                    this.pluses[x, y] = 0;
                    correct = true;
                    while (correct)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            nx = x + dx[i] * this.pluses[x, y];
                            ny = y + dy[i] * this.pluses[x, y];
                            if (!(nx >= 0 && nx < n && ny >= 0 && ny < m && this.input[nx][ny] == 'G'))
                            {
                                correct = false;
                            }
                        }

                        if (correct)
                        {
                            this.pluses[x, y]++;
                        }
                    }
                }
            }
        }

        private int IterateFirstPlus()
        {
            int result = 0;

            for (int x = 0; x < this.n; x++)
            {
                for (int y = 0; y < this.m; y++)
                {
                    for (int p = 1; p <= this.pluses[x, y]; p++)
                    {
                        result = Math.Max(result, (4 * p - 3) * this.IterateSecondPlus(x, y, p));
                    }
                }
            }

            return result;
        }

        private int IterateSecondPlus(int tx, int ty, int tp)
        {
            int result = 0;
            int v;

            for (int x = 0; x < this.n; x++)
            {
                for (int y = 0; y < this.m; y++)
                {
                    v = this.pluses[x, y];

                    if (x == tx)
                    {
                        if (y <= (ty - tp))
                        {
                            v = ty - tp - y + 1;
                        }
                        else
                        if (y >= (ty + tp))
                        {
                            v = y - ty - tp + 1;
                        }
                        else
                        {
                            v = 0;
                        }
                    }
                    else
                    if (y == ty)
                    {
                        if (x <= (tx - tp))
                        {
                            v = tx - tp - x + 1;
                        }
                        else
                        if (x >= (tx + tp))
                        {
                            v = x - tx - tp + 1;
                        }
                        else
                        {
                            v = 0;
                        }
                    }
                    else
                    if ((x > (tx - tp))
                        && (x < (tx + tp))
                        && (y > (ty - tp))
                        && (y < (ty + tp)))
                    {
                        v = Math.Min(Math.Abs(x - tx), Math.Abs(y - ty));
                    }
                    else
                    if ((x > (tx - tp))
                        && (x < (tx + tp)))
                    {
                        v = Math.Abs(y - ty);
                    }
                    else
                    if ((y > (ty - tp))
                        && (y < (ty + tp)))
                    {
                        v = Math.Abs(x - tx);
                    }

                    v = Math.Min(v, this.pluses[x, y]);
                    result = Math.Max(result, v);
                }
            }

            return 4 * result - 3;
        }
    }
}



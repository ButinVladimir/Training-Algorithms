using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public class TheBombermanGame
    {
        private static readonly int[] dx = { -1, 1, 0, 0 };
        private static readonly int[] dy = { 0, 0, -1, 1 };
        private int[,] Grid;
        private int n;

        public TheBombermanGame(string[] field, int n)
        {
            this.n = n;
            this.Grid = new int[field.Length, field[0].Length];
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[0].Length; j++)
                {
                    this.Grid[i, j] = field[i][j] == 'O' ? 3 : 0;
                }
            }
        }

        public string[] Solve()
        {
            for (int time = 0; time < n && time < 4; time++)
            {
                Step(time);
            }

            if (n > 4)
            {
                n = (n - 5) % 4 + 1;
                for (int time = 0; time < n; time++)
                {
                    Step(time);
                }
            }

            return this.BuildResult();
        }

        private void Step(int time)
        {
            if (time % 2 == 0)
            {
                TransformWait();
                TransformDecrease();
            }
            else
            {
                TransformDecrease();
                TransformPlant();
            }
        }

        private void TransformWait()
        {
            int ni, nj;
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grid.GetLength(1); j++)
                {
                    if (this.Grid[i, j] != 1)
                    {
                        continue;
                    }

                    for (int k = 0; k < dx.Length; k++)
                    {
                        ni = i + dx[k];
                        nj = j + dy[k];
                        if (ni >= 0 && ni < this.Grid.GetLength(0) &&
                            nj >= 0 && nj < this.Grid.GetLength(1) &&
                            this.Grid[ni, nj] != 1)
                        {
                            this.Grid[ni, nj] = 0;
                        }
                    }
                }
            }
        }

        private void TransformPlant()
        {
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grid.GetLength(1); j++)
                {
                    if (this.Grid[i, j] == 0)
                    {
                        this.Grid[i, j] = 3;
                    }
                }
            }
        }

        private void TransformDecrease()
        {
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grid.GetLength(1); j++)
                {
                    if (this.Grid[i, j] > 0)
                    {
                        this.Grid[i, j]--;
                    }
                }
            }
        }

        private string[] BuildResult()
        {
            string[] field = new string[this.Grid.GetLength(0)];
            StringBuilder sb = new StringBuilder(this.Grid.GetLength(1));
            for (int i = 0; i < this.Grid.GetLength(0); i++)
            {
                sb.Clear();
                for (int j = 0; j < this.Grid.GetLength(1); j++)
                {
                    sb.Append(this.Grid[i, j] == 0 ? '.' : 'O');
                }
                field[i] = sb.ToString();
            }

            return field;
        }
    }
}

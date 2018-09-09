using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class SurfaceArea
    {
        private static readonly int[] dx = { -1, 1, 0, 0 };
        private static readonly int[] dy = { 0, 0, -1, 1 };

        public static int Solve(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int result = n * m * 2;
            int nx, ny, v;

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < m; y++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        nx = x + dx[i];
                        ny = y + dy[i];
                        if (nx >= 0 && nx < n && ny >= 0 && ny < m)
                        {
                            v = a[nx, ny];
                        }
                        else
                        {
                            v = 0;
                        }

                        if (a[x, y] > v)
                        {
                            result += a[x, y] - v;
                        }
                    }
                }
            }

            return result;
        }
    }
}

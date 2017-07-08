using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_73
{
    public static class CavityMap
    {
        private static readonly int[] dx = new int[] { -1, 1, 0, 0 };
        private static readonly int[] dy = new int[] { 0, 0, -1, 1 };

        public static char[][] Solve(char[][] map)
        {
            int n = map.Length;
            bool can;
            char[][] result = new char[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = map[i][j];
                }
            }

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    can = true;
                    for (int k = 0; k < 4; k++)
                    {
                        if (map[i + dx[k]][j + dy[k]] >= map[i][j])
                        {
                            can = false;
                        }
                    }

                    if (can)
                    {
                        result[i][j] = 'X';
                    }
                }
            }

            return result;
        }
    }
}

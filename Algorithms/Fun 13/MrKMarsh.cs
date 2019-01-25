using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class MrKMarsh
    {
        public static int Solve(string[] field)
        {
            int result = 0;
            int n = field.Length;
            int m = field[0].Length;

            int[,] height = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i][j] == 'x')
                    {
                        height[i, j] = 0;
                        continue;
                    }

                    height[i, j] = 1;
                    if (i > 0)
                    {
                        height[i, j] += height[i - 1, j];
                    }
                }
            }

            int l, r;
            for (int h1 = 0; h1 < n; h1++)
            {
                for (int h2 = h1 + 1; h2 < n; h2++)
                {
                    l = 0;
                    while (l < m)
                    {
                        if (height[h2, l] >= (h2 - h1 + 1))
                        {
                            r = l + 1;
                            while (r < m && field[h1][r] =='.' && field[h2][r] =='.')
                            {
                                if (height[h2, r] >= (h2 - h1 + 1))
                                {
                                    result = Math.Max(result, 2 * ((h2 - h1 + 1) + (r - l + 1) - 2));
                                }

                                r++;
                            }

                            l = r;
                        }
                        else
                        {
                            l++;
                        }
                    }
                }
            }

            return result;
        }
    }
}

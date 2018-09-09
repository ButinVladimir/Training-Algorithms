using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_6
{
    public static class Abbreviation
    {
        public static bool Solve(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;

            bool[,] dp = new bool[n + 1, m + 1];

            for (int i = n; i >= 0; i--)
            {
                for (int j = m; j >= 0; j--)
                {
                    if (i == n && j == m)
                    {
                        dp[i, j] = true;
                        continue;
                    }

                    if (i == n)
                    {
                        dp[i, j] = false;
                        continue;
                    }

                    if (j == m)
                    {
                        dp[i, j] = !char.IsUpper(a[i]) && dp[i + 1, j];
                        continue;
                    }

                    if (char.IsUpper(a[i]))
                    {
                        dp[i, j] = (a[i] == b[j]) && dp[i + 1, j + 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j] || ((char.ToUpper(a[i]) == b[j]) && dp[i + 1, j + 1]);
                    }
                }
            }

            return dp[0, 0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public class CommonChild
    {
        public string A { get; set; }
        public string B { get; set; }

        private int[,] dp;

        public int Solve()
        {
            int n = A.Length;
            int m = B.Length;

            this.dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.UpdateValue(i, j);
                }
            }

            return this.dp[n - 1, m - 1];
        }

        private void UpdateValue(int i, int j)
        {
            if (this.A[i] == this.B[j])
            {
                this.dp[i, j]++;

                if (i > 0 && j > 0)
                {
                    this.dp[i, j] += this.dp[i - 1, j - 1];
                }
            }

            if (i > 0)
            {
                this.dp[i, j] = Math.Max(this.dp[i, j], this.dp[i - 1, j]);
            }

            if (j > 0)
            {
                this.dp[i, j] = Math.Max(this.dp[i, j], this.dp[i, j - 1]);
            }
        }
    }
}

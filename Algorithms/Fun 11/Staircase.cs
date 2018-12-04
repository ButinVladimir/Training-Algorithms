using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class Staircase
    {
        public static string Solve(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    sb.Append(' ');
                }
                for (int j = 0; j < i; j++)
                {
                    sb.Append('#');
                }

                sb.Append(System.Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}

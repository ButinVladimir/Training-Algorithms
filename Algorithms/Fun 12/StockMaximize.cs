using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public static class StockMaximize
    {
        public static long Solve(long[] prices)
        {
            int n = prices.Length;
            long max = prices[n - 1];
            long result = 0;
            for (int i = n - 2; i >= 0; i--)
            {
                if (max >= prices[i])
                {
                    result += max - prices[i];
                }

                max = Math.Max(max, prices[i]);
            }

            return result;
        }
    }
}

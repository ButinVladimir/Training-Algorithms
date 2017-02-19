using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    public class Candies
    {
        public static long Solve(long[] rating)
        {
            int n = rating.Length;
            long[] candies = new long[n];

            for (int i = 0; i < n; i++)
            {
                candies[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                if (rating[i] > rating[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                if (rating[i] > rating[i + 1])
                {
                    candies[i] = candies[i + 1] + 1;
                }
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += candies[i];
            }

            return result;
        }
    }
}

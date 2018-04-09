using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class KaprekarNumbers
    {
        public static List<long> Solve(long p, long q)
        {
            List<long> result = new List<long>();
            for (long i = p; i <= q; i++)
            {
                if (IsKaprekarNumber(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static bool IsKaprekarNumber(long value)
        {
            int d = value.ToString().Length;
            long sqr = value * value;

            string convertedSqr = sqr.ToString();
            int take = convertedSqr.Length - d;
            long left = take == 0 ? 0 : Convert.ToInt64(convertedSqr.Substring(0, take));
            long right = Convert.ToInt64(convertedSqr.Substring(take));

            return left + right == value;
        }
    }
}

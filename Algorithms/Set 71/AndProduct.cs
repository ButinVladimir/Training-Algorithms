using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class AndProduct
    {
        public static long Solve(long a, long b)
        {
            long result = 0;

            for (int i = 0; i < 32; i++)
            {
                if (((1L << i) & a) != 0)
                {
                    long c = ((a >> i) + 1) << i;
                    if (c > b)
                    {
                        result += 1L << i;
                    }
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_24
{
    public class Candy
    {
        private static readonly int[] bills = new int[] { 1, 2, 5, 10, 20, 50, 100 };

        public static long Solve(int n)
        {
            int l = bills.Length;

            long[,] vals = new long[l, n + 1];
            for (int val = 0; val <= n; val++)
            {
                vals[0, val] = 1;
            }

            for (int bill = 1; bill < l; bill++)
            {
                for (int val = 0; val <= n; val++)
                {
                    vals[bill, val] = vals[bill - 1, val];
                    if (val >= bills[bill])
                    {
                        vals[bill, val] += vals[bill, val - bills[bill]];
                    }
                }
            }

            return vals[l - 1, n];
        }
    }
}

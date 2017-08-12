using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class SockMerchant
    {
        public static int Solve(int[] a)
        {
            Array.Sort(a);
            int pos = 0;
            int result = 0;

            while (pos < a.Length - 1)
            {
                if (a[pos] == a[pos + 1])
                {
                    result++;
                    pos += 2;
                }
                else
                {
                    pos++;
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class FairRations
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            int l = 0;
            int r = a.Length - 1;
            while (r - l > 1)
            {
                if (a[l] % 2 == 1)
                {
                    a[l]++;
                    a[l + 1]++;
                    result += 2;
                }

                if (a[r] % 2 == 1)
                {
                    a[r]++;
                    a[r - 1]++;
                    result += 2;
                }
                l++;
                r--;
            }

            if (l == r && a[l] % 2 == 1)
            {
                return -1;
            }
            if (r == l + 1)
            {
                if (a[l] % 2 == 1 && a[r] % 2 == 1)
                {
                    result += 2;
                    a[l]++;
                    a[r]++;
                }
                if (a[l] % 2 == 1 || a[r] % 2 == 1)
                {
                    return -1;
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class AbsolutePermutation
    {
        public static string Solve(int n, int k)
        {
            int[] a;

            if (k==0)
            {
                a = new int[n];

                for (int i=0;i<n;i++)
                {
                    a[i] = i + 1;
                }

                return string.Join(" ", a.Select(x => x.ToString()));
            }

            if (n % (2 * k) != 0)
            {
                return "-1";
            }

            a = new int[n];
            int l = n / (2 * k);
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    a[i * 2 * k + j] = i * 2 * k + j + k + 1;
                    a[i * 2 * k + k + j] = i * 2 * k + j + 1;
                }
            }

            return string.Join(" ", a.Select(x => x.ToString()));
        }
    }
}

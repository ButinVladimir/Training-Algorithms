using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class DivisibleSubset
    {
        public static int Solve(int n, int k, int[] a)
        {
            int[] mod = new int[k];
            for (int i = 0; i < k; i++)
            {
                mod[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                mod[a[i] % k]++;
            }

            int size = mod[0] > 0 ? 1 : 0;
            for (int i = 1; i < k / 2 + k % 2; i++)
            {
                size += Math.Max(mod[i], mod[k - i]);
            }

            if (k % 2 == 0 && a[k/2] > 0)
            {
                size++;
            }

            return size;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class ElectronicsShop
    {
        public static int Solve(int s, int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Reverse(b);

            int posB = 0;
            int result = -1;

            for (int i = 0; i < a.Length; i++)
            {
                while (posB < b.Length && a[i] + b[posB] > s)
                {
                    posB++;
                }

                if (posB < b.Length)
                {
                    result = Math.Max(result, a[i] + b[posB]);
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class QuickSort1
    {
        public static void Solve(int[] a)
        {
            int p = a[0];

            int i = 0;
            int j = a.Length - 1;
            int b;

            while (i < j)
            {
                while (a[i] < p)
                {
                    i++;
                }

                while (a[j] > p)
                {
                    j--;
                }

                b = a[i];
                a[i] = a[j];
                a[j] = b;
            }
        }
    }
}

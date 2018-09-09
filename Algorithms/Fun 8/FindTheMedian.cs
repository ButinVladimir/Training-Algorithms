using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class FindTheMedian
    {
        public static int Solve(int[] a)
        {
            int n2 = a.Length / 2;
            int l = 0;
            int r = a.Length - 1;
            int i, j, middle, buff;

            while (l + 1 < r)
            {
                i = l;
                j = r;
                middle = a[(l + r) / 2];
                while (i < j)
                {
                    while (i < j && a[i] < middle)
                    {
                        i++;
                    }
                    while (j > i && a[j] > middle)
                    {
                        j--;
                    }

                    if (i < j)
                    {
                        buff = a[i];
                        a[i] = a[j];
                        a[j] = buff;
                        i++;
                        j--;
                    }
                }

                if (i >= n2)
                {
                    r = i;
                }
                if (i <= n2)
                {
                    l = i;
                }
            }

            if (l + 1 == r && a[l] > a[r])
            {
                buff = a[l];
                a[l] = a[r];
                a[r] = buff;
            }

            return a[n2];
        }
    }
}

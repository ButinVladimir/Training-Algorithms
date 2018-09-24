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
            int n = a.Length;
            int l = 0;
            int r = n - 1;
            int buffer;
            int barrier;

            while (r - l > 2)
            {
                int i = l;
                int j = r;
                barrier = a[(l + r) / 2];

                while (i < j)
                {
                    while (a[i] < barrier)
                    {
                        i++;
                    }

                    while (a[j] > barrier)
                    {
                        j--;
                    }

                    if (i < j)
                    {
                        buffer = a[i];
                        a[i] = a[j];
                        a[j] = buffer;
                        i++;
                        j--;
                    }
                }

                if (n / 2 <= j)
                {
                    r = j;
                }
                else
                if (n / 2 >= i)
                {
                    l = i;
                }
                else
                {
                    l = j;
                    r = i;
                }
            }

            for (int i = l; i < r; i++)
            {
                for (int j = i; j <= r; j++)
                {
                    if (a[i] > a[j])
                    {
                        buffer = a[i];
                        a[i] = a[j];
                        a[j] = buffer;
                    }
                }
            }

            return a[n / 2];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public static class MinimumLoss
    {
        private static long[] buffer;

        public static long Solve(long[] a)
        {
            buffer = new long[a.Length];

            return Merge(0, a.Length - 1, a);
        }

        private static long Merge(int left, int right, long[] a)
        {
            long value = long.MaxValue;
            if (left >= right)
            {
                return value;
            }

            if (right - left == 1)
            {
                if (a[left] > a[right])
                {
                    value = a[left] - a[right];

                    long buffer = a[left];
                    a[left] = a[right];
                    a[right] = buffer;
                }

                return value;
            }

            int mid = (left + right) / 2;
            value = Math.Min(value, Merge(left, mid, a));
            value = Math.Min(value, Merge(mid + 1, right, a));

            int i = left;
            int j = mid + 1;
            int pos = 0;

            while (i <= mid && j <= right)
            {
                if (a[i] > a[j])
                {
                    value = Math.Min(value, a[i] - a[j]);
                    buffer[pos] = a[j];
                    pos++;
                    j++;
                }
                else
                {
                    buffer[pos] = a[i];
                    pos++;
                    i++;
                }
            }

            while (i <= mid)
            {
                buffer[pos] = a[i];
                pos++;
                i++;
            }

            while (j <= right)
            {
                buffer[pos] = a[j];
                pos++;
                j++;
            }

            for (i = 0; i < pos; i++)
            {
                a[left + i] = buffer[i];
            }

            return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class BeautifulQuadruplets
    {
        public static long Solve(long[] a)
        {
            Array.Sort(a);

            long result = 0;
            SortedDictionary<long, long> secondHalf = new SortedDictionary<long, long>();
            long value;

            for (long i = a[1] + 1; i <= a[2]; i++)
            {
                for (long j = i; j <= a[3]; j++)
                {
                    if (secondHalf.TryGetValue(i ^ j, out value))
                    {
                        value++;
                    }
                    else
                    {
                        value = 1;
                    }

                    secondHalf[i ^ j] = value;
                }
            }

            for (long i = a[1]; i >= 1; i--)
            {
                for (long j = i; j <= a[3]; j++)
                {
                    if (secondHalf.TryGetValue(i ^ j, out value))
                    {
                        value++;
                    }
                    else
                    {
                        value = 1;
                    }

                    secondHalf[i ^ j] = value;
                }

                for (long j = 1; j <= a[0] && j <= i; j++)
                {
                    if (secondHalf.TryGetValue(i ^ j, out value))
                    {
                        result += value;
                    }
                }
            }

            long all = 0;
            for (long i = 1; i <= a[1]; i++)
            {
                for (long j = i;j <= a[2]; j++)
                {
                    all += (a[3] - j + 1) * (Math.Min(i, a[0]));
                }
            }

            return all - result;
        }
    }
}

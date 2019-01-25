using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class CountTriplets
    {
        public static long Solve(long[] a, long r)
        {
            Dictionary<long, long> prefix = new Dictionary<long, long>();
            Dictionary<long, long> suffix = new Dictionary<long, long>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!prefix.ContainsKey(a[i]))
                {
                    prefix[a[i]] = 1;
                }
                else
                {
                    prefix[a[i]]++;
                }

                if (!suffix.ContainsKey(a[i]))
                {
                    suffix[a[i]] = 0;
                }
            }

            long result = 0;
            long prev, next;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                prefix[a[i]]--;

                if (a[i] % r == 0)
                {
                    prev = a[i] / r;
                    next = a[i] * r;

                    if (prefix.ContainsKey(prev) && suffix.ContainsKey(next))
                    {
                        result += prefix[prev] * suffix[next];
                    }
                }

                suffix[a[i]]++;
            }

            return result;
        }
    }
}

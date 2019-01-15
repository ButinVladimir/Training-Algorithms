using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class Bonetrousle
    {
        public static long[] Solve(long n, long k, long b)
        {
            BigInteger nl = new BigInteger(n);
            BigInteger kl = new BigInteger(k);
            BigInteger bl = new BigInteger(b);
            BigInteger min = (bl + BigInteger.One) * bl / new BigInteger(2);
            BigInteger max = (kl + kl - bl + BigInteger.One) * bl / new BigInteger(2);

            if (nl < min || nl > max)
            {
                return new long[] { -1 };
            }

            long[] result = new long[b];
            for (int i = 0; i < b; i++)
            {
                result[i] = i + 1;
            }

            BigInteger sum = min;
            long pos = b - 1;
            long diff;
            while (sum < nl)
            {
                diff = k - (b - 1 - pos) - result[pos];
                if (sum + diff < n)
                {
                    result[pos] = k - (b - 1 - pos);
                    sum += diff;
                    pos--;
                    continue;
                }

                result[pos] += (long) (nl - sum);
                sum = nl;
            }

            return result;
        }
    }
}

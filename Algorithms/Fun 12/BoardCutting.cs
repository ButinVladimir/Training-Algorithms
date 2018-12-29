using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public static class BoardCutting
    {
        private const long Mod = 1000000000 + 7;

        public static long Solve(long[] a, long[] b)
        {
            Array.Sort(a);
            a.Reverse();

            Array.Sort(b);
            b.Reverse();

            int n = a.Length;
            int m = b.Length;

            long[] aSum = MakeSum(a);
            long[] bSum = MakeSum(b);

            long result = 0;
            long i = 0;
            long j = 0;
            long aBuf, bBuf;

            while (i < n && j < m)
            {
                aBuf = a[i] + bSum[j];
                bBuf = b[j] + aSum[i];
                if (bBuf > aBuf)
                {
                    result = (result + aBuf) % Mod;
                    i++;
                }
                else
                {
                    result = (result + bBuf) % Mod;
                    j++;
                }
            }

            while (i < n)
            {
                result = (result + a[i]) % Mod;
                i++;
            }

            while (j < m)
            {
                result = (result + b[j]) % Mod;
                j++;
            }

            return result;
        }

        private static long[] MakeSum(long[] a)
        {
            long[] aSum = new long[a.Length + 1];
            for (int i = a.Length - 1; i >= 0; i--)
            {
                aSum[i] = (aSum[i + 1] + a[i]) % Mod;
            }

            return aSum;
        }
    }
}

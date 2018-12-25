using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class PrimeXor
    {
        private const long N = 8200;

        private const long mod = 1000000000 + 7;
        private List<long> primes = new List<long>();

        public PrimeXor()
        {
            bool isPrime = true;
            for (long i = 2; i <= N; i++)
            {
                isPrime = true;
                for (long j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    this.primes.Add(i);
                }
            }
        }

        public long Solve(long[] a)
        {
            Array.Sort(a);

            long result = 0;
            int left = 0;
            int right = 0;
            int count, lowerHalf, upperHalf;
            long[] xors = new long[N];
            long[] newXors = new long[N];
            xors[0] = 1;

            while (left < a.Length)
            {
                right = left;
                while (right < a.Length && a[left] == a[right])
                {
                    right++;
                }

                count = right - left;
                lowerHalf = count / 2;
                upperHalf = count - lowerHalf;

                foreach (long prime in this.primes)
                {
                    result = (result + (xors[prime ^ a[left]] * upperHalf) % mod) % mod;
                    result = (result + (xors[prime] * lowerHalf) % mod) % mod;
                }

                for (long i = 0; i < N; i++)
                {
                    newXors[i ^ a[left]] = (newXors[i ^ a[left]] + xors[i] * upperHalf % mod) % mod;
                    newXors[i] = (newXors[i] + xors[i] * (lowerHalf + 1) % mod) % mod;
                }

                for (long i = 0; i < N; i++)
                {
                    xors[i] = newXors[i];
                    newXors[i] = 0;
                }

                left = right;
            }

            return result;
        }
    }
}

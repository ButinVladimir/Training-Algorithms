using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public static class AliceAndBobSillyGame
    {
        private const int N = 200000;
        private static int[] prefix = new int[N];
        private static bool[] prime = new bool[N];

        static AliceAndBobSillyGame()
        {
            for (int i = 2; i < N; i++)
            {
                prime[i] = true;
            }

            List<int> primes = new List<int>();

            for (int i = 2; i < N; i++)
            {
                if (prime[i])
                {
                    primes.Add(i);
                }

                foreach (int v in primes)
                {
                    if (i * v >= N)
                    {
                        break;
                    }

                    prime[i * v] = false;
                }
            }

            for (int i = 2; i < N; i++)
            {
                prefix[i] += prefix[i - 1];
                if (prime[i])
                {
                    prefix[i]++;
                }
            }
        }

        public static bool Solve(int n)
        {
            int v = prefix[n];

            return v % 2 > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class RedJohnIsBack
    {
        private const int M = 300000;
        private static int[] answers = new int[41];
        private static int[] count = new int[M];

        static RedJohnIsBack()
        {
            answers[0] = 1;
            for (int i = 1; i < 41; i++)
            {
                answers[i] += answers[i - 1];
                if (i >= 4)
                {
                    answers[i] += answers[i - 4];
                }
            }

            List<int> primes = new List<int>();
            bool[] visited = new bool[M];
            for (int i = 2; i < M; i++)
            {
                if (!visited[i])
                {
                    primes.Add(i);
                }

                foreach (int prime in primes)
                {
                    if (prime * i >= M)
                    {
                        break;
                    }

                    visited[prime * i] = true;
                }
            }

            for (int i = 2;i<M;i++)
            {
                count[i] = count[i - 1];
                if (!visited[i])
                {
                    count[i]++;
                }
            }
        }

        public static int Solve(int p)
        {
            return count[answers[p]];
        }
    }
}

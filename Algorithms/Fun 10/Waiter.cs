using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class Waiter
    {
        private const int N = 1000000;
        public static List<int> Solve(int[] a, int q)
        {
            List<int> primes = new List<int>();
            bool[] flagged = new bool[N];
            for (int i = 2; i < N; i++)
            {
                if (!flagged[i])
                {
                    primes.Add(i);
                }

                foreach (int prime in primes)
                {
                    if (i * prime >= N)
                    {
                        break;
                    }

                    flagged[i * prime] = true;
                }
            }

            Stack<int> sa = new Stack<int>();
            for (int i = 0; i < a.Length; i++)
            {
                sa.Push(a[i]);
            }

            Stack<int>[] sb = new Stack<int>[q + 1];
            for (int i = 0; i < q; i++)
            {
                sb[i] = new Stack<int>();
            }

            Stack<int> nsa = new Stack<int>();
            int[] primesArray = primes.ToArray();
            int v;

            for (int i = 0; i < q; i++)
            {
                while (sa.Count > 0)
                {
                    v = sa.Pop();
                    if (v % primesArray[i] == 0)
                    {
                        sb[i].Push(v);
                    }
                    else
                    {
                        nsa.Push(v);
                    }
                }

                sa = nsa;
                nsa = new Stack<int>();
            }

            List<int> result = new List<int>();
            for (int i = 0; i < q; i++)
            {
                while (sb[i].Count > 0)
                {
                    v = sb[i].Pop();
                    result.Add(v);
                }
            }

            while (sa.Count > 0)
            {
                v = sa.Pop();
                result.Add(v);
            }

            return result;
        }
    }
}

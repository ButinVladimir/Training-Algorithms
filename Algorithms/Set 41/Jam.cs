using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_41
{
    class Jam
    {
        private Random random;
        private long[] values;
        private long[] divisors;
        private PrimeChecker primeChecker;
        private HashSet<long> visited;

        public Jam()
        {
            this.random = new Random();
            this.primeChecker = new PrimeChecker(1000000);

            this.divisors = new long[10];
        }

        public int N { get; set; }

        public int J { get; set; }

        public long[,] Solve()
        {
            long[,] result = new long[J, 10];

            this.values = new long[N];
            values[0] = values[N - 1] = 1;
            this.visited = new HashSet<long>();

            int counter = 0;
            while (counter < J)
            {
                while (!this.GetNext()) ;

                for (int i = 0; i < 10; i++)
                {
                    result[counter, i] = this.divisors[i];
                }

                counter++;
            }

            return result;
        }

        private bool GetNext()
        {
            for (int i = 1; i < N - 1; i++)
            {
                this.values[i] = random.Next(0, 2);
            }

            this.divisors[0] = this.Convert(10);
            if (this.visited.Contains(this.divisors[0]))
            {
                return false;
            }
            this.visited.Add(this.divisors[0]);

            for (int i = 1; i < 10; i++)
            {
                this.divisors[i] = this.primeChecker.Check(this.Convert(i + 1));
                if (this.divisors[i] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private long Convert(long mod)
        {
            long result = 0;
            long mult = 1;
            for (int i = 0; i < this.N; i++)
            {
                result += mult * values[i];
                mult *= mod;
            }

            return result;
        }

        private class PrimeChecker
        {
            private List<long> primes;
            private bool[] sieve;

            public long Size { get; private set; }

            public PrimeChecker(long size)
            {
                this.primes = new List<long>();
                this.sieve = new bool[size];
                this.Size = size;

                this.Build();
            }

            public long Check(long number)
            {
                foreach (long prime in this.primes)
                {
                    if (prime * prime > number)
                    {
                        break;
                    }

                    if (number % prime == 0)
                    {
                        return prime;
                    }
                }

                return 0;
            }

            private void Build()
            {
                long next;

                for (int number = 2; number < this.Size; number++)
                {
                    foreach (long prime in this.primes)
                    {
                        next = prime * number;
                        if (next >= this.Size)
                        {
                            break;
                        }

                        this.sieve[next] = true;
                    }

                    if (!this.sieve[number])
                    {
                        this.primes.Add(number);
                    }
                }
            }
        }
    }
}

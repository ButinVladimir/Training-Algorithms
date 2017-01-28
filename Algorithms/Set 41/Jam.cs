using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithms.Set_41
{
    class Jam
    {
        private Random random;
        private BigInteger[] values;
        private string[] divisors;
        private PrimeChecker primeChecker;
        private HashSet<string> visited;

        public Jam()
        {
            this.random = new Random();
            this.primeChecker = new PrimeChecker(100000000);

            this.divisors = new string[10];
        }

        public int N { get; set; }

        public int J { get; set; }

        public string[,] Solve()
        {
            string[,] result = new string[J, 10];

            this.values = new BigInteger[N];
            values[0] = values[N - 1] = 1;
            this.visited = new HashSet<string>();

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

            this.divisors[0] = this.Convert(10).ToString();
            if (this.visited.Contains(this.divisors[0]))
            {
                return false;
            }
            this.visited.Add(this.divisors[0]);

            for (int i = 1; i < 10; i++)
            {
                this.divisors[i] = this.primeChecker.Check(this.Convert(i + 1)).ToString();
                if (this.divisors[i].Equals("0"))
                {
                    return false;
                }
            }

            return true;
        }

        private BigInteger Convert(long mod)
        {
            BigInteger result = 0;
            BigInteger mult = 1;
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

            public long Check(BigInteger number)
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

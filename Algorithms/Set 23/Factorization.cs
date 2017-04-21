using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_23
{
    public class Factorization
    {
        private int n;
        private int[] sieve;
        private bool[] composite;

        public Factorization(int n)
        {
            this.n = n;
            this.sieve = new int[n + 1];
            this.composite = new bool[n + 1];
        }

        public void Prepare()
        {
            List<int> primes = new List<int>();

            for (int i = 2; i <= this.n; i++)
            {
                if (!this.composite[i])
                {
                    primes.Add(i);
                    this.sieve[i] = i;
                }

                foreach (int prime in primes)
                {
                    if (i * prime > n)
                    {
                        break;
                    }

                    this.composite[i * prime] = true;
                    this.sieve[i * prime] = prime;
                }
            }
        }

        public SortedSet<int> Factorize(int number)
        {
            SortedSet<int> result = new SortedSet<int>();

            while (number > 1)
            {
                result.Add(this.sieve[number]);
                number /= this.sieve[number];
            }

            return result;
        }
    }

    [TestClass]
    public class FactorizationTest
    {
        private const int max = 1000000;
        private Factorization factorization;

        [TestInitialize]
        public void Prepare()
        {
            this.factorization = new Factorization(max);
            this.factorization.Prepare();
        }

        [TestMethod]
        public void Test1()
        {
            int value = 3458;
            SortedSet<int> expected = this.BuildExpected(value);
            SortedSet<int> result = this.factorization.Factorize(value);

            Assert.IsTrue(this.CompareTest(result, expected));
        }

        [TestMethod]
        public void Test2()
        {
            int value = 22;
            SortedSet<int> expected = this.BuildExpected(value);
            SortedSet<int> result = this.factorization.Factorize(value);

            Assert.IsTrue(this.CompareTest(result, expected));
        }

        [TestMethod]
        public void Test3()
        {
            int value = 2;
            SortedSet<int> expected = this.BuildExpected(value);
            SortedSet<int> result = this.factorization.Factorize(value);

            Assert.IsTrue(this.CompareTest(result, expected));
        }

        [TestMethod]
        public void Test4()
        {
            int value = 3;
            SortedSet<int> expected = this.BuildExpected(value);
            SortedSet<int> result = this.factorization.Factorize(value);

            Assert.IsTrue(this.CompareTest(result, expected));
        }

        [TestMethod]
        public void Test5()
        {
            int value = 101;
            SortedSet<int> expected = this.BuildExpected(value);
            SortedSet<int> result = this.factorization.Factorize(value);

            Assert.IsTrue(this.CompareTest(result, expected));
        }

        private bool CompareTest(SortedSet<int> result, SortedSet<int> expected)
        {
            if (result.Count != expected.Count)
            {
                return false;
            }

            foreach (int number in expected)
            {
                if (!result.Contains(number))
                {
                    return false;
                }
            }

            return true;
        }

        private SortedSet<int> BuildExpected(int number)
        {
            SortedSet<int> result = new SortedSet<int>();

            for (int divisor = 2; divisor <= number; divisor++)
            {
                if (number % divisor == 0)
                {
                    result.Add(divisor);

                    while (number % divisor == 0)
                    {
                        number /= divisor;
                    }
                }
            }

            return result;
        }
    }
}

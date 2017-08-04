using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_15
{
    public class MatrixGcd
    {
        private int[,] numbers;
        private int[,] blocks;
        private int blocksM;
        private int blocksN;
        private int blocksLengthM;
        private int blocksLengthN;

        public MatrixGcd(int[,] a)
        {
            this.numbers = a;

            int m = this.numbers.GetLength(0);
            int n = this.numbers.GetLength(1);

            this.blocksLengthM = Sqrt(m);
            this.blocksM = GetBlocksNumber(m, this.blocksLengthM);

            this.blocksLengthN = Sqrt(n);
            this.blocksN = GetBlocksNumber(n, this.blocksLengthN);

            this.blocks = new int[this.blocksM, this.blocksN];
            for (int i = 0; i < this.blocksM; i++)
            {
                for (int j = 0; j < this.blocksN; j++)
                {
                    this.blocks[i, j] = 0;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    this.blocks[i / this.blocksLengthM, j / this.blocksLengthN] =
                        Gcd(this.blocks[i / this.blocksLengthM, j / this.blocksLengthN], this.numbers[i, j]);
                }
            }
        }

        public int QueryBrute(int top, int left, int bottom, int right)
        {
            int result = 0;

            for (int i = top; i <= bottom; i++)
            {
                for (int j = left; j <= right; j++)
                {
                    result = Gcd(result, this.numbers[i, j]);
                }
            }

            return result;
        }

        public int Query(int top, int left, int bottom, int right)
        {
            int result = 0;
            int t, l, b, r;
            int m = this.numbers.GetLength(0);
            int n = this.numbers.GetLength(1);

            for (int i = 0; i < this.blocksM; i++)
            {
                for (int j = 0; j < this.blocksN; j++)
                {
                    t = this.blocksLengthM * i;
                    b = Math.Min(t + this.blocksLengthM - 1, m);
                    l = this.blocksLengthN * j;
                    r = Math.Min(l + this.blocksLengthN - 1, n);

                    if (top <= t && bottom >= b && left <= l && right >= r)
                    {
                        result = Gcd(result, this.blocks[i, j]);
                    }
                    else
                    {
                        result = Gcd(result, this.QueryBrute(
                            Math.Max(t, top),
                            Math.Max(l, left),
                            Math.Min(b, bottom),
                            Math.Min(r, right)));
                    }
                }
            }

            return result;
        }

        private static int GetBlocksNumber(int length, int blockLength)
        {
            int result = length / blockLength;
            if (length % blockLength > 0)
            {
                result++;
            }

            return result;
        }

        private static int Sqrt(int a)
        {
            int r = 0;
            while (r * r <= a)
            {
                r++;
            }

            return r - 1;
        }

        private static int Gcd(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }
    }

    [TestClass]
    public class MatrixGcdTest
    {
        [TestMethod]
        public void Test1()
        {
            int m = 30;
            int n = 10;
            int q = 10000;
            int max = 9000;
            int seed = 1;

            this.Test(m, n, q, max, seed);
        }

        [TestMethod]
        public void Test2()
        {
            int m = 500;
            int n = 600;
            int q = 100000;
            int max = 900000;
            int seed = 3;

            this.Test(m, n, q, max, seed);
        }

        private void Test(int m, int n, int q, int max, int seed)
        {
            int[,] a = new int[m, n];
            Random random = new Random(seed);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = random.Next(1, max);
                }
            }

            MatrixGcd gcd = new MatrixGcd(a);
            int top, left, bottom, right;

            for (int query = 0; query < q; query++)
            {
                top = random.Next(0, m);
                bottom = random.Next(top, m);
                left = random.Next(0, n);
                right = random.Next(left, n);

                int brute = gcd.QueryBrute(top, left, bottom, right);
                int fine = gcd.Query(top, left, bottom, right);

                Assert.AreEqual(brute, fine);
            }
        }
    }
}

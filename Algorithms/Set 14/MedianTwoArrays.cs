using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_14
{
    public class MedianTwoArrays
    {
        public int[] A { get; set; }
        public int[] B { get; set; }
        private int n;

        public double SolveLinear()
        {
            this.n = this.A.Length;

            int p1 = 0;
            int p2 = 0;

            for (int i = 0; i < n - 1; i++)
            {
                Move(ref p1, ref p2);
            }

            int v1 = GetValue(p1, p2);
            Move(ref p1, ref p2);
            int v2 = GetValue(p1, p2);

            return (v1 + v2) / 2.0;
        }

        public double SolveLog()
        {
            this.n = this.A.Length;

            return (this.GetValueLog(n) + this.GetValueLog(n + 1)) / 2.0;
        }

        private void Move(ref int p1, ref int p2)
        {
            if (p1 < this.n && p2 < this.n)
            {
                if (this.A[p1] < this.B[p2])
                {
                    p1++;
                }
                else
                {
                    p2++;
                }
            }
            else if (p1 < n)
            {
                p1++;
            }
            else if (p2 < n)
            {
                p2++;
            }
        }

        private int GetValue(int p1, int p2)
        {
            if (p1 < this.n && p2 < this.n)
            {
                return Math.Min(this.A[p1], this.B[p2]);
            }
            if (p1 < n)
            {
                return this.A[p1];
            }
            if (p2 < n)
            {
                return this.B[p2];
            }

            return 0;
        }

        private int GetValueLog(int p)
        {
            int? v = GetValueLog(this.A, p);
            if (v != null)
            {
                return v.Value;
            }

            v = GetValueLog(this.B, p);
            if (v != null)
            {
                return v.Value;
            }

            return 0;
        }

        private void GetRange(int[] a, int v, out int left, out int right)
        {
            int step = this.n;
            int pos = -1;
            int nextPos;

            while (step > 0)
            {
                nextPos = pos + step;
                if (nextPos >= 0 && nextPos < this.n && a[nextPos] < v)
                {
                    pos = nextPos;
                }
                else
                {
                    step /= 2;
                }
            }

            left = pos + 1;

            step = a.Length + 1;
            while (step > 0)
            {
                nextPos = pos + step;
                if (nextPos >= 0 && nextPos < a.Length && a[nextPos] <= v)
                {
                    pos = nextPos;
                }
                else
                {
                    step /= 2;
                }
            }

            right = pos + 1;
        }

        private int? GetValueLog(int[] a, int p)
        {
            int step = n;
            int pos = -1;
            int nextPos;

            int leftA, leftB, rightA, rightB;
            while (step > 0)
            {
                nextPos = pos + step;
                if (nextPos >= 0 && nextPos < this.n)
                {
                    this.GetRange(this.A, a[nextPos], out leftA, out rightA);
                    this.GetRange(this.B, a[nextPos], out leftB, out rightB);

                    if (leftA + leftB < p && rightA + rightB >= p)
                    {
                        return a[nextPos];
                    }

                    if (rightA + rightB < p)
                    {
                        pos = nextPos;
                    }
                    else
                    {
                        step /= 2;
                    }
                }
                else
                {
                    step /= 2;
                }
            }

            return null;
        }
    }

    [TestClass]
    public class MedianTwoArraysTest
    {
        private Random random;

        [TestInitialize]
        public void TestInit()
        {
            this.random = new Random(1);
        }

        [TestMethod]
        public void Test1()
        {
            int n = 10;
            int min = 0;
            int max = 1000;

            int[] a, b;
            this.PrepareArrays(n, min, max, out a, out b);
            MedianTwoArrays mta = new MedianTwoArrays()
            {
                A = a,
                B = b
            };

            Assert.AreEqual(mta.SolveLinear(), mta.SolveLog());
        }

        [TestMethod]
        public void Test2()
        {
            int n = 1000;
            int min = 0;
            int max = 1000;

            int[] a, b;
            this.PrepareArrays(n, min, max, out a, out b);
            MedianTwoArrays mta = new MedianTwoArrays()
            {
                A = a,
                B = b
            };

            Assert.AreEqual(mta.SolveLinear(), mta.SolveLog());
        }

        [TestMethod]
        public void Test3()
        {
            int n = 10;
            int min = 0;
            int max = 10;

            int[] a, b;
            this.PrepareArrays(n, min, max, out a, out b);
            MedianTwoArrays mta = new MedianTwoArrays()
            {
                A = a,
                B = b
            };

            Assert.AreEqual(mta.SolveLinear(), mta.SolveLog());
        }

        [TestMethod]
        public void Test4()
        {
            int n = 1000;
            int min = 0;
            int max = 10;

            int[] a, b;
            this.PrepareArrays(n, min, max, out a, out b);
            MedianTwoArrays mta = new MedianTwoArrays()
            {
                A = a,
                B = b
            };

            Assert.AreEqual(mta.SolveLinear(), mta.SolveLog());
        }

        private void PrepareArrays(int n, int min, int max, out int[] a, out int[] b)
        {
            a = new int[n];
            b = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = this.random.Next(min, max);
                b[i] = this.random.Next(min, max);
            }

            Array.Sort(a);
            Array.Sort(b);
        }
    }
}

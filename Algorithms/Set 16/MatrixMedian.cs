using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_16
{
    public class MatrixMedian
    {
        public int[,] Matrix { get; set; }
        private int n;
        private int m;

        public double SolveLog()
        {
            this.n = this.Matrix.GetLength(0);
            this.m = this.Matrix.GetLength(1);

            int nm = this.n * this.m;

            return (this.GetNumberLog((nm - 1) / 2 + 1) + this.GetNumberLog((nm - 1) - ((nm - 1) / 2) + 1)) / 2.0;
        }

        private int GetNumberLog(int find)
        {
            for (int i = 0; i < this.n; i++)
            {
                int step = this.m;
                int pos = -1;
                int nextPos;
                int left, right;

                while (step > 0)
                {
                    nextPos = pos + step;

                    if (nextPos >= 0 && nextPos < m)
                    {
                        left = this.GetLeft(this.Matrix[i, nextPos]) + 1;
                        right = this.GetRight(this.Matrix[i, nextPos]);

                        if (find >= left && find <= right)
                        {
                            return this.Matrix[i, nextPos];
                        }

                        if (find < left)
                        {
                            step /= 2;
                        }
                        else
                        {
                            pos = nextPos;
                        }
                    }
                    else
                    {
                        step /= 2;
                    }
                }
            }

            return 0;
        }

        private int GetLeft(int value)
        {
            int result = 0;
            for (int i = 0; i < this.n; i++)
            {
                int step = this.m;
                int pos = -1;
                int nextPos;

                while (step > 0)
                {
                    nextPos = pos + step;

                    if (nextPos >= 0 && nextPos < this.m && this.Matrix[i, nextPos] < value)
                    {
                        pos = nextPos;
                    }
                    else
                    {
                        step /= 2;
                    }
                }

                result += pos + 1;
            }

            return result;
        }

        private int GetRight(int value)
        {
            int result = 0;
            for (int i = 0; i < this.n; i++)
            {
                int step = this.m;
                int pos = -1;
                int nextPos;

                while (step > 0)
                {
                    nextPos = pos + step;

                    if (nextPos >= 0 && nextPos < this.m && this.Matrix[i, nextPos] <= value)
                    {
                        pos = nextPos;
                    }
                    else
                    {
                        step /= 2;
                    }
                }

                result += pos + 1;
            }

            return result;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MatrixMedianTest
    {
        [TestMethod]
        public void Test1()
        {
            MatrixMedian mm = new MatrixMedian()
            {
                Matrix = new int[,]
                {
                    { 1, 2, 3, 4, 5 }
                }
            };

            Assert.AreEqual(3, mm.SolveLog());
        }

        [TestMethod]
        public void Test2()
        {
            MatrixMedian mm = new MatrixMedian()
            {
                Matrix = new int[,]
                {
                    { 1, 2, 3, 4, 5, 7 }
                }
            };

            Assert.AreEqual(3.5, mm.SolveLog());
        }

        [TestMethod]
        public void Test3()
        {
            MatrixMedian mm = new MatrixMedian()
            {
                Matrix = new int[,]
                {
                    { 1, 2, 3, 4, 5, 7 },
                    { 2, 3, 5, 10, 11, 12}
                }
            };

            Assert.AreEqual(4.5, mm.SolveLog());
        }

        [TestMethod]
        public void Test4()
        {
            MatrixMedian mm = new MatrixMedian()
            {
                Matrix = new int[,]
                {
                    { 1, 2, 3, 4, 5 },
                    { 2, 3, 5, 10, 11},
                    { 2, 3, 5, 10, 11},
                }
            };

            Assert.AreEqual(4, mm.SolveLog());
        }
    }
}

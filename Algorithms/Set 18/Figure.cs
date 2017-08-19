using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_18
{
    public class Figure
    {
        public int[] X { get; set; }
        public int[] Y { get; set; }

        public string Solve()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    for (int k = 1; k < 4; k++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            string result = this.Solve(i, j, k);

                            if (!result.Equals("None"))
                            {
                                return result;
                            }
                        }
                    }
                }
            }

            return "None";
        }

        private string Solve(int p2, int p3, int p4)
        {
            int p1 = 0;

            if (!this.IsOrtogonal(p1, p2, p3)
                || !this.IsOrtogonal(p2, p1, p4)
                || !this.IsOrtogonal(p3, p1, p4)
                || !this.IsOrtogonal(p4, p2, p3))
            {
                return "None";
            }

            if (this.Length(p1, p2) != this.Length(p3, p4) || this.Length(p1, p3) != this.Length(p2, p4))
            {
                return "None";
            }

            return this.Length(p1, p2) == this.Length(p1, p3) ? "Square" : "Rectangle";
        }

        private double Length(int p1, int p2)
        {
            double dx = this.X[p1] - this.X[p2];
            double dy = this.Y[p1] - this.Y[p2];

            return dx * dx + dy * dy;
        }

        private int Scalar(int p1, int p2, int p3)
        {
            int x1 = this.X[p2] - this.X[p1];
            int y1 = this.Y[p2] - this.Y[p1];

            int x2 = this.X[p3] - this.X[p1];
            int y2 = this.Y[p3] - this.Y[p1];

            return x1 * x2 + y1 * y2;
        }

        private bool IsOrtogonal(int p1, int p2, int p3)
        {
            return this.Scalar(p1, p2, p3) == 0;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class FigureTest
    {
        [TestMethod]
        public void Test1()
        {
            Figure f = new Figure()
            {
                X = new int[] { 5, 3, 7, 5 },
                Y = new int[] { 0, 2, 2, 4 }
            };

            Assert.AreEqual("Square", f.Solve());
        }

        [TestMethod]
        public void Test2()
        {
            Figure f = new Figure()
            {
                X = new int[] { 5, 11, 9, 3 },
                Y = new int[] { 0, 3, 7, 4 }
            };

            Assert.AreEqual("Rectangle", f.Solve());
        }

        [TestMethod]
        public void Test3()
        {
            Figure f = new Figure()
            {
                X = new int[] { 0, 0, 0, 0 },
                Y = new int[] { 0, 1, 5, 10 }
            };

            Assert.AreEqual("None", f.Solve());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_1
{
    public static class PointsNotOnLine
    {
        public static Tuple<int, int>[] Solve(int n)
        {
            int x = 0;
            int y = 0;

            Tuple<int, int>[] result = new Tuple<int, int>[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = new Tuple<int, int>(x, y);
                x++;
                y += x;
            }

            return result;
        }
    }

    [TestClass]
    public class PointsNotOnLineTest
    {
        [TestMethod]
        public void Test1()
        {
            int n = 5;
            Tuple<int, int>[] result = PointsNotOnLine.Solve(n);

            Assert.IsNotNull(result);
            Assert.AreEqual(n, result.Length);
            Assert.IsTrue(this.Validate(result));
        }

        [TestMethod]
        public void Test2()
        {
            int n = 10;
            Tuple<int, int>[] result = PointsNotOnLine.Solve(n);

            Assert.IsNotNull(result);
            Assert.AreEqual(n, result.Length);
            Assert.IsTrue(this.Validate(result));
        }

        private bool Validate(Tuple<int, int>[] result)
        {
            int dx1, dy1, dx2, dy2;

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    dx1 = result[j].Item1 - result[i].Item1;
                    dy1 = result[j].Item2 - result[i].Item2;

                    for (int k = j + 1; k < result.Length; k++)
                    {
                        dx2 = result[k].Item1 - result[i].Item1;
                        dy2 = result[k].Item2 - result[i].Item2;

                        if (dx1 * dy2 - dx2 * dy1 == 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_8
{
    public class Triangles
    {
        private List<int>[] ribs;

        public Triangles(int n)
        {
            this.ribs = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }
        }

        public void AddRib(int from, int to)
        {
            this.ribs[from].Add(to);
            this.ribs[to].Add(from);
        }

        public int Solve()
        {
            int n = this.ribs.Length;
            int[][] ribsArrays = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ribsArrays[i] = this.ribs[i].ToArray();
                Array.Sort(ribsArrays[i]);
            }

            int v2, v3;
            int result = 0;
            for (int v1 = 0; v1 < n; v1++)
            {
                for (int i = 0; i < ribsArrays[v1].Length; i++)
                {
                    v2 = ribsArrays[v1][i];

                    if (v2 <= i)
                    {
                        continue;
                    }

                    for (int j = i + 1; j < ribsArrays[v1].Length; j++)
                    {
                        v3 = ribsArrays[v1][j];

                        if (Array.BinarySearch(ribsArrays[v2], v3) >= 0)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }
    }

    [TestClass]
    public class TrianglesTest
    {
        [TestMethod]
        public void Test1()
        {
            Triangles t = new Triangles(4);
            t.AddRib(0, 1);
            t.AddRib(0, 2);
            t.AddRib(0, 3);
            t.AddRib(1, 3);
            t.AddRib(2, 3);

            Assert.AreEqual(2, t.Solve());
        }

        [TestMethod]
        public void Test2()
        {
            Triangles t = new Triangles(4);
            t.AddRib(0, 1);
            t.AddRib(0, 2);
            t.AddRib(0, 3);
            t.AddRib(1, 3);
            t.AddRib(2, 3);
            t.AddRib(1, 2);

            Assert.AreEqual(4, t.Solve());
        }

        [TestMethod]
        public void Test3()
        {
            Triangles t = new Triangles(5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    t.AddRib(i, j);
                }
            }

            Assert.AreEqual(10, t.Solve());
        }
    }
}

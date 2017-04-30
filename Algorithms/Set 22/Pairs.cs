using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public class Pairs
    {
        private int n;
        private PairsApi api;

        public Pairs(int n, int[] bolts, int[] nuts)
        {
            this.n = n;
            this.api = new PairsApi(bolts, nuts);
        }

        public int[] Solve()
        {
            int[] result = new int[this.n];
            bool[] visited = new bool[this.n];

            for (int nut = 0; nut < n; nut++)
            {
                for (int bolt = 0; bolt < n; bolt++)
                {
                    if (visited[bolt] == false && this.api.Compare(bolt, nut) == 0)
                    {
                        visited[bolt] = true;
                        result[nut] = bolt;
                        break;
                    }
                }
            }

            return result;
        }

        private class PairsApi
        {
            private int[] bolts;
            private int[] nuts;

            public PairsApi(int[] bolts, int[] nuts)
            {
                this.bolts = bolts;
                this.nuts = nuts;
            }

            public int Compare(int bolt, int nut)
            {
                return this.nuts[nut].CompareTo(this.bolts[bolt]);
            }
        }
    }

    [TestClass]
    public class PairsTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] bolts = new int[] { 2, 3, 1, 5, 4 };
            int[] nuts = new int[] { 5, 2, 3, 4, 1 };
            int n = 5;

            Pairs pairs = new Pairs(n, bolts, nuts);
            int[] result = pairs.Solve();

            Assert.AreEqual(n, result.Length);

            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(nuts[i], bolts[result[i]]);
            }
        }

        [TestMethod]
        public void Test2()
        {
            int[] bolts = new int[] { 3, 3, 2, 1, 4, 10 };
            int[] nuts = new int[] { 10, 1, 4, 3, 2, 3 };
            int n = 6;

            Pairs pairs = new Pairs(n, bolts, nuts);
            int[] result = pairs.Solve();
            bool[] visited = new bool[n];

            Assert.AreEqual(n, result.Length);

            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(nuts[i], bolts[result[i]]);
                visited[result[i]] = true;
            }

            for (int i = 0; i < n; i++)
            {
                Assert.IsTrue(visited[i]);
            }
        }
    }
}

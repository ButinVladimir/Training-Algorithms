using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_2
{
    public class Ancestor
    {
        private List<int>[] ribs;
        private int[] tin;
        private int[] tout;
        private int time;

        public Ancestor(int n, List<Tuple<int, int>> ribList)
        {
            this.ribs = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }

            foreach (var rib in ribList)
            {
                this.ribs[rib.Item1].Add(rib.Item2);
                this.ribs[rib.Item2].Add(rib.Item1);
            }

            this.time = 0;
            this.tin = new int[n];
            this.tout = new int[n];
            this.DFS(0);
        }

        public bool IsAncestor(int a, int b)
        {
            return this.tin[a] < this.tin[b] && this.tout[a] > this.tout[b];
        }

        private void DFS(int current, int pred = -1)
        {
            this.tin[current] = ++this.time;

            foreach (int to in this.ribs[current])
            {
                if (pred == to)
                {
                    continue;
                }

                DFS(to, current);
            }

            this.tout[current] = ++this.time;
        }
    }

    [TestClass]
    public class AncestorTest
    {
        [TestMethod]
        public void Test()
        {
            List<Tuple<int, int>> ribs = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(4, 2),
                new Tuple<int, int>(5, 3),
            };

            Ancestor ancestor = new Ancestor(6, ribs);

            Assert.IsTrue(ancestor.IsAncestor(0, 1));
            Assert.IsTrue(ancestor.IsAncestor(0, 5));
            Assert.IsFalse(ancestor.IsAncestor(1, 4));
            Assert.IsTrue(ancestor.IsAncestor(2, 4));
            Assert.IsFalse(ancestor.IsAncestor(2, 2));
        }
    }
}

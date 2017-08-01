using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_12
{
    public class Height
    {
        private int root;
        private List<int>[] ribs;

        public Height(int[] parents)
        {
            this.ribs = new List<int>[parents.Length];
            
            for (int i=0;i<parents.Length;i++)
            {
                this.ribs[i] = new List<int>();
            }

            for (int i = 0; i < parents.Length; i++)
            {
                if (parents[i] == -1)
                {
                    root = i;
                }
                else
                {
                    this.ribs[parents[i]].Add(i);
                }
            }
        }

        public int Solve()
        {
            return this.DFS(this.root);
        }

        public int DFS(int current)
        {
            int result = 0;

            foreach (int next in this.ribs[current])
            {
                result = Math.Max(result, this.DFS(next));
            }

            return result + 1;
        }
    }

    [TestClass]
    public class HeightTest
    {
        [TestMethod]
        public void Test()
        {
            int[] parents = { 3, 3, 3, -1, 2 };
            Height h = new Height(parents);

            Assert.AreEqual(3, h.Solve());
        }
    }
}
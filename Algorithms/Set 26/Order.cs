using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_26
{
    public class Order
    {
        public Order(int n, int root)
        {
            this.N = n;
            this.Root = root;

            this.ribs = new List<int>[this.N];

            for (int i = 0; i < this.N; i++)
            {
                this.ribs[i] = new List<int>();
            }
        }

        public int N { get; private set; }
        public int Root { get; private set; }

        public void AddRib(int from, int to)
        {
            this.ribs[from].Add(to);
        }

        public int[] Solve()
        {
            int height = this.GetHeight(this.Root);

            List<int>[] levels = new List<int>[height];
            for (int i = 0; i < height; i++)
            {
                levels[i] = new List<int>();
            }

            GetLevels(this.Root, 0, levels);

            List<int> result = new List<int>();

            int l = 0;
            int r = height - 1;
            while (l <= r)
            {
                foreach (int node in levels[l])
                {
                    result.Add(node);
                }

                if (r > l)
                {
                    levels[r].Reverse();
                    foreach (int node in levels[r])
                    {
                        result.Add(node);
                    }
                }

                l++;
                r--;
            }

            return result.ToArray();
        }

        private int GetHeight(int node)
        {
            int result = 0;

            foreach (int to in this.ribs[node])
            {
                result = Math.Max(result, this.GetHeight(to));
            }

            return result + 1;
        }

        private void GetLevels(int node, int height, List<int>[] levels)
        {
            levels[height].Add(node);

            foreach (int to in this.ribs[node])
            {
                GetLevels(to, height + 1, levels);
            }
        }

        private List<int>[] ribs;
    }

    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Test()
        {
            Order order = new Order(15, 0);
            for (int i = 0; i < 7; i++)
            {
                order.AddRib(i, 2 * i + 1);
                order.AddRib(i, 2 * i + 2);
            }

            Assert.IsTrue(Check(order.Solve(), new int[] { 0, 14, 13, 12, 11, 10, 9, 8, 7, 1, 2, 6, 5, 4, 3 }));
        }

        private bool Check(int[] actual, int[] expected)
        {
            if (actual.Length != expected.Length)
            {
                return false;
            }

            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

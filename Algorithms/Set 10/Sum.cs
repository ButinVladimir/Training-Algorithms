using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_10
{
    public class Sum
    {
        private TreeNode rootNode;

        public int[] Content { get; set; }
        public int X { get; set; }

        public Tuple<int, int> Solve()
        {
            this.rootNode = ConvertToTree(Content);

            Tuple<int, int> result = this.DFS(this.rootNode);
            if (result != null)
            {
                return new Tuple<int, int>(Math.Min(result.Item1, result.Item2), Math.Max(result.Item1, result.Item2));
            }

            return null;
        }

        private Tuple<int, int> DFS(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            if (this.Find(node, this.X - node.Value))
            {
                return new Tuple<int, int>(node.Value, this.X - node.Value);
            }

            return this.DFS(node.Left) ?? this.DFS(node.Right) ?? null;
        }

        private bool Find(TreeNode compareNode, int value)
        {
            TreeNode currentNode = this.rootNode;

            while (currentNode != null)
            {
                if (currentNode.Value + compareNode.Value == this.X)
                {
                    if (currentNode != compareNode)
                    {
                        return true;
                    }

                    if (currentNode.Left != null && currentNode.Left.Value == currentNode.Value)
                    {
                        return true;
                    }

                    if (currentNode.Right != null && currentNode.Right.Value == currentNode.Value)
                    {
                        return true;
                    }

                    return false;
                }

                if (value > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }

            return false;
        }

        private static TreeNode ConvertToTree(int[] array)
        {
            Array.Sort(array);

            return ConvertToTree(array, 0, array.Length - 1);
        }

        private static TreeNode ConvertToTree(int[] array, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int m = (left + right) / 2;

            return new TreeNode()
            {
                Value = array[m],
                Left = ConvertToTree(array, left, m - 1),
                Right = ConvertToTree(array, m + 1, right)
            };
        }

        private class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
    }

    [TestClass]
    public class SumTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = { 2, 3, 7, 4, 2, 9 };
            Sum sum = new Sum() { Content = a, X = 4 };
            Tuple<int, int> result = sum.Solve();

            Assert.AreEqual(2, result.Item1);
            Assert.AreEqual(2, result.Item2);
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = { 2, 3, 5, 10, 11, 200 };
            Sum sum = new Sum() { Content = a, X = -1 };
            Tuple<int, int> result = sum.Solve();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test3()
        {
            int[] a = { 2, 3, 4, 10, 11 };
            Sum sum = new Sum() { Content = a, X = 14 };
            Tuple<int, int> result = sum.Solve();

            Assert.AreEqual(4, result.Item1);
            Assert.AreEqual(10, result.Item2);
        }
    }
}

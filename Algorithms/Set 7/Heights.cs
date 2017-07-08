using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_7
{
    public static class Heights
    {
        public static int[] Solve(int[] heights, int[] front)
        {
            int n = heights.Length;
            SegmentTree tree = new SegmentTree();

            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                tree.ChangeCount(heights[i], 1);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = tree.GetValue(i - front[i] + 1);
                tree.ChangeCount(result[i], -1);
            }

            return result;
        }

        private class SegmentTree
        {
            private const int Min = 0;
            private const int Max = 1000000;
            private SegmentTreeNode rootNode;

            public SegmentTree()
            {
                this.rootNode = new SegmentTreeNode();
            }

            public void ChangeCount(int value, int delta)
            {
                this.ChangeCount(this.rootNode, value, delta, Min, Max);
            }

            public int GetValue(int count)
            {
                return this.GetValue(this.rootNode, count, Min, Max);
            }

            private int GetCount(SegmentTreeNode node)
            {
                return node != null ? node.Count : 0;
            }

            private void ChangeCount(SegmentTreeNode node, int value, int delta, int left, int right)
            {
                node.Count += delta;

                if (left == right)
                {
                    return;
                }

                int mid = (left + right) / 2;

                if (value <= mid)
                {
                    if (node.Left == null)
                    {
                        node.Left = new SegmentTreeNode();
                    }

                    this.ChangeCount(node.Left, value, delta, left, mid);
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new SegmentTreeNode();
                    }

                    this.ChangeCount(node.Right, value, delta, mid + 1, right);
                }
            }

            private int GetValue(SegmentTreeNode node, int count, int left, int right)
            {
                if (left == right)
                {
                    return left;
                }

                int mid = (left + right) / 2;
                int leftCount = this.GetCount(node.Left);
                if (leftCount >= count)
                {
                    return this.GetValue(node.Left, count, left, mid);
                }

                return this.GetValue(node.Right, count - leftCount, mid + 1, right);
            }

            private class SegmentTreeNode
            {
                public SegmentTreeNode Left { get; set; }
                public SegmentTreeNode Right { get; set; }
                public int Count { get; set; }
            }
        }
    }

    [TestClass]
    public class HeightsTest
    {
        [TestMethod]
        public void Test()
        {
            int[] heights = { 3, 2, 1 };
            int[] front = { 0, 1, 1 };
            int[] expected = { 3, 1, 2 };

            int[] result = Heights.Solve(heights, front);
            Compare(expected, result);
        }

        [TestMethod]
        public void Test2()
        {
            int[] heights = { 5, 3, 3, 2, 1 };
            int[] front = { 0, 0, 1, 1, 3 };
            int[] expected = { 1, 5, 3, 3, 2};

            int[] result = Heights.Solve(heights, front);
            Compare(expected, result);
        }

        private static void Compare(int[] expected, int[] result)
        {
            Assert.AreEqual(expected.Length, result.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}

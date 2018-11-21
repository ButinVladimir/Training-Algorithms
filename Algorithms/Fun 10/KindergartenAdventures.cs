using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class KindergartenAdventures
    {
        public static int Solve(int[] t)
        {
            int n = t.Length;
            int left, right, b;
            SegmentTree segmentTree = new SegmentTree();

            for (int i = 0; i < n; i++)
            {
                if (t[i] <= n - 1)
                {
                    right = (i - t[i] + n) % n;
                    left = i + 1;

                    if (left <= right)
                    {
                        segmentTree.Add(left, right);
                    }
                    else
                    {
                        segmentTree.Add(left, n - 1);
                        segmentTree.Add(0, right);
                    }
                }
            }

            int v = 0;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                b = segmentTree.Get(i);
                if (b > v)
                {
                    v = b;
                    index = i;
                }
            }

            return index + 1;
        }

        private class SegmentTree
        {
            private const int N = 100001;
            private SegmentTreeNode root;

            public void Add(int left, int right)
            {
                this.root = this.Add(left, right, 0, N, this.root);
            }

            public int Get(int index)
            {
                return this.Get(index, 0, N, this.root);
            }

            private SegmentTreeNode Add(int left, int right, int treeLeft, int treeRight, SegmentTreeNode node)
            {
                if (left > right || treeLeft > treeRight || left > treeRight || right < treeLeft)
                {
                    return node;
                }

                if (node == null)
                {
                    node = new SegmentTreeNode();
                }

                if (treeLeft >= left && treeRight <= right)
                {
                    node.Sum++;
                }
                else
                {
                    int m = (treeLeft + treeRight) / 2;
                    node.Left = this.Add(left, right, treeLeft, m, node.Left);
                    node.Right = this.Add(left, right, m + 1, treeRight, node.Right);
                }

                return node;
            }

            private int Get(int index, int treeLeft, int treeRight, SegmentTreeNode node)
            {
                if (treeLeft > treeRight || index > treeRight || index < treeLeft || node == null)
                {
                    return 0;
                }

                int m = (treeLeft + treeRight) / 2;
                if (index <= m)
                {
                    return node.Sum + this.Get(index, treeLeft, m, node.Left);
                }

                return node.Sum + this.Get(index, m + 1, treeRight, node.Right);
            }

            private class SegmentTreeNode
            {
                public int Sum { get; set; }
                public SegmentTreeNode Left { get; set; }
                public SegmentTreeNode Right { get; set; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class InsertionSortAdvancedAnalysis
    {
        public const int Max = 10000001;
        public static long SolveFenvick(long[] a, int n)
        {
            long result = 0;
            long sum = 0;
            long[] fenvick = new long[Max + 1];

            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (long v = a[i]; v >= 0; v = (v & (v + 1)) - 1)
                {
                    sum += fenvick[v];
                }

                result += i - sum;

                for (long v = a[i]; v < Max; v = v | (v + 1))
                {
                    fenvick[v]++;
                }
            }

            return result;
        }

        public static long Solve(long[] a, int n)
        {
            long result = 0;

            SegmentTree st = new SegmentTree(1, 10000000);
            for (int i = 0; i < n; i++)
            {
                result += st.Get(a[i]);
                st.Add(a[i]);
            }

            return result;
        }

        private class SegmentTree
        {
            private SegmentTreeNode root;

            public int Left { get; private set; }
            public int Right { get; private set; }

            public SegmentTree(int left, int right)
            {
                this.Left = left;
                this.Right = right;
            }

            public void Add(long value)
            {
                this.root = AddInternal(this.root, this.Left, this.Right, value);
            }

            public long Get(long value)
            {
                return GetInternal(this.root, this.Left, this.Right, value + 1, this.Right);
            }

            static private SegmentTreeNode AddInternal(SegmentTreeNode node, int left, int right, long pos)
            {
                if (left > right)
                {
                    return null;
                }

                node = node == null ? new SegmentTreeNode() : node;

                if (left == right)
                {
                    node.Value++;
                    return node;
                }

                int mid = (left + right) / 2;
                if (pos <= mid)
                {
                    node.Left = AddInternal(node.Left, left, mid, pos);
                }
                else
                {
                    node.Right = AddInternal(node.Right, mid + 1, right, pos);
                }
                node.Value = GetValue(node.Left) + GetValue(node.Right);

                return node;
            }

            static private long GetInternal(SegmentTreeNode node, int left, int right, long queryLeft, long queryRight)
            {
                if (queryLeft > right || queryRight < left || node == null)
                {
                    return 0;
                }

                if (left >= queryLeft && right <= queryRight)
                {
                    return node.Value;
                }

                int mid = (left + right) / 2;

                return GetInternal(node.Left, left, mid, queryLeft, queryRight) + GetInternal(node.Right, mid + 1, right, queryLeft, queryRight);
            }

            static private long GetValue(SegmentTreeNode node)
            {
                return node != null ? node.Value : 0;
            }

            private class SegmentTreeNode
            {
                public long Value { get; set; }
                public SegmentTreeNode Left { get; set; }
                public SegmentTreeNode Right { get; set; }
            }
        }
    }
}

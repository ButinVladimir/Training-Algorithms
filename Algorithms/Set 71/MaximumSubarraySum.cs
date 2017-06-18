using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public class MaximumSubarraySum
    {
        public ulong M { get; set; }
        public ulong[] A { get; set; }

        public ulong Solve()
        {
            SegmentTree tree = new SegmentTree() { Max = this.M };
            ulong sum = 0;
            ulong result = 0;

            for (int i = 0; i < this.A.Length; i++)
            {
                sum = (sum + this.A[i]) % this.M;
                result = Math.Max(result, sum);

                ulong next = tree.Get(sum + 1);
                result = Math.Max(result, sum + this.M - next);

                tree.Add(sum);
            }

            return result;
        }

        private class SegmentTree
        {
            public ulong Max { get; set; }
            private SegmentTreeNode rootNode;

            public void Add(ulong value)
            {
                this.rootNode = this.Add(this.rootNode, 0, this.Max, value);
            }

            public ulong Get(ulong left)
            {
                return this.Get(this.rootNode, 0, this.Max, left, this.Max);
            }

            private SegmentTreeNode Add(SegmentTreeNode rootNode, ulong left, ulong right, ulong value)
            {
                if (left > right)
                {
                    return null;
                }

                SegmentTreeNode node = rootNode != null ? rootNode : new SegmentTreeNode();
                if (left == right)
                {
                    node.Value = value;
                }
                else
                {
                    ulong m = (left + right) / 2;
                    if (value <= m)
                    {
                        node.Left = this.Add(node.Left, left, m, value);
                    }
                    else
                    {
                        node.Right = this.Add(node.Right, m + 1, right, value);
                    }

                    this.UpdateNode(node);
                }

                return node;
            }

            private ulong Get(SegmentTreeNode rootNode, ulong segmentLeft, ulong segmentRight, ulong left, ulong right)
            {
                if (rootNode == null || segmentLeft > right || segmentRight < left)
                {
                    return this.Max;
                }

                if (segmentLeft >= left && segmentRight <= right)
                {
                    return rootNode.Value;
                }

                ulong m = (segmentLeft + segmentRight) / 2;

                return Math.Min(this.Get(rootNode.Left, segmentLeft, m, left, right), this.Get(rootNode.Right, m + 1, segmentRight, left, right));
            }

            private void UpdateNode(SegmentTreeNode node)
            {
                if (node != null)
                {
                    node.Value = Math.Min(this.GetNodeValue(node.Left), this.GetNodeValue(node.Right));
                }
            }

            private ulong GetNodeValue(SegmentTreeNode node)
            {
                return node != null ? node.Value : this.Max;
            }

            private class SegmentTreeNode
            {
                public ulong Value { get; set; }
                public SegmentTreeNode Left { get; set; }
                public SegmentTreeNode Right { get; set; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public class SimpleQueries
    {
        private Treap treap = new Treap();

        public void Add(int value, int position)
        {
            this.treap.Add(value, position);
        }

        public void Move(int from, int to, bool toBack)
        {
            this.treap.Move(from, to, toBack);
        }

        public int GetValue()
        {
            return this.treap.GetValue();
        }

        public string Walk()
        {
            List<int> result = this.treap.Walk();

            return string.Join(" ", result);
        }

        private class Treap
        {
            private Random random;
            private TreapNode first;

            public Treap()
            {
                this.random = new Random(0);
            }

            public List<int> Walk()
            {
                List<int> result = new List<int>();

                this.Walk(this.first, result);

                return result;
            }

            public void Add(int value, int position)
            {
                TreapNode insertedNode = new TreapNode()
                {
                    Value = value,
                    Rank = this.random.Next(),
                    Count = 1,
                };

                this.first = this.Add(this.first, insertedNode, position);
            }

            public void Move(int from, int to, bool toBack)
            {
                TreapNode left = null;
                TreapNode middle = null;
                TreapNode right = null;
                TreapNode buffer = null;

                this.Split(this.first, to + 1, x => buffer = x, x => right = x);
                this.Split(buffer, from, x => left = x, x => middle = x);

                buffer = this.Merge(left, right);

                if (toBack)
                {
                    this.first = this.Merge(buffer, middle);
                }
                else
                {
                    this.first = this.Merge(middle, buffer);
                }
            }

            public int GetValue()
            {
                int result;

                TreapNode currentNode = this.first;
                while (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }

                result = currentNode.Value;

                currentNode = this.first;
                while (currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                }

                result -= currentNode.Value;

                return Math.Abs(result);
            }

            private void Walk(TreapNode currentNode, List<int> result)
            {
                if (currentNode == null)
                {
                    return;
                }

                this.Walk(currentNode.Left, result);

                result.Add(currentNode.Value);

                this.Walk(currentNode.Right, result);
            }

            private TreapNode Add(TreapNode currentNode, TreapNode insertedNode, int key)
            {
                if (currentNode == null)
                {
                    return insertedNode;
                }

                if (insertedNode.Rank > currentNode.Rank)
                {
                    this.Split(currentNode, key, x => insertedNode.Left = x, x => insertedNode.Right = x);
                    this.UpdateCount(insertedNode);

                    return insertedNode;
                }

                int currentKey = this.GetCount(currentNode.Left) + 1;
                if (key <= currentKey)
                {
                    currentNode.Left = this.Add(currentNode.Left, insertedNode, key);
                }
                else
                {
                    currentNode.Right = this.Add(currentNode.Right, insertedNode, key - currentKey);
                }

                this.UpdateCount(currentNode);

                return currentNode;
            }

            private void Split(TreapNode node, int key, Action<TreapNode> setLeft, Action<TreapNode> setRight)
            {
                if (node == null)
                {
                    setLeft(null);
                    setRight(null);

                    return;
                }

                int currentKey = this.GetCount(node.Left) + 1;
                if (key <= currentKey)
                {
                    setRight(node);
                    this.Split(node.Left, key, setLeft, x => node.Left = x);
                }
                else
                {
                    setLeft(node);
                    this.Split(node.Right, key - currentKey, x => node.Right = x, setRight);
                }

                this.UpdateCount(node);
            }

            private TreapNode Merge(TreapNode left, TreapNode right)
            {
                if (left == null)
                {
                    return right;
                }

                if (right == null)
                {
                    return left;
                }

                if (left.Rank > right.Rank)
                {
                    left.Right = this.Merge(left.Right, right);
                    this.UpdateCount(left);

                    return left;
                }

                right.Left = this.Merge(left, right.Left);
                this.UpdateCount(right);

                return right;
            }

            private void UpdateCount(TreapNode node)
            {
                if (node != null)
                {
                    node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
                }
            }

            private int GetCount(TreapNode node)
            {
                return node != null ? node.Count : 0;
            }

            private class TreapNode
            {
                public int Value { get; set; }
                public int Rank { get; set; }
                public TreapNode Left { get; set; }
                public TreapNode Right { get; set; }
                public int Count { get; set; }
            }
        }
    }
}

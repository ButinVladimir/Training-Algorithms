using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class FraudulentActivityNotifications
    {
        public static int Solve(int[] a, int d)
        {
            int result = 0;
            Treap treap = new Treap();
            for (int i = 0; i < a.Length && i < d; i++)
            {
                treap.Add(a[i]);
            }

            int median;
            for (int i = d; i < a.Length; i++)
            {
                if (d % 2 == 1)
                {
                    median = treap.Get(d / 2 + 1) * 2;
                }
                else
                {
                    median = treap.Get(d / 2) + treap.Get(d / 2 + 1);
                }

                if (a[i] >= median)
                {
                    result++;
                }
                treap.Add(a[i]);
                treap.Remove(a[i - d]);
            }

            return result;
        }

        private class Treap
        {
            private TreapNode root;
            private Random random;

            public Treap()
            {
                this.random = new Random();
            }

            public void Add(int value)
            {
                TreapNode node = this.CreateNode(value);
                this.root = this.Add(this.root, node);
            }

            public int Get(int index)
            {                
                if (this.root == null)
                {
                    throw new ArgumentException("Root is empty");
                }

                TreapNode currentNode = this.root;
                int pos;
                while (currentNode != null)
                {
                    pos = GetCount(currentNode.Left) + 1;
                    if (pos == index)
                    {
                        return currentNode.Key;
                    }

                    if (pos > index)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        index -= pos;
                        currentNode = currentNode.Right;
                    }
                }

                throw new ArgumentException("Index is out of boundary");
            }

            public void Remove(int value)
            {
                this.root = this.Remove(this.root, value);
            }

            private TreapNode Add(TreapNode currentNode, TreapNode insertNode)
            {
                if (currentNode == null)
                {
                    UpdateCount(insertNode);

                    return insertNode;
                }

                if (insertNode.Priority > currentNode.Priority)
                {
                    TreapNode leftTree = null;
                    TreapNode rightTree = null;
                    Split(currentNode, insertNode.Key, ref leftTree, ref rightTree);
                    insertNode.Left = leftTree;
                    insertNode.Right = rightTree;
                    UpdateCount(insertNode);

                    return insertNode;
                }

                if (currentNode.Key > insertNode.Key)
                {
                    currentNode.Left = this.Add(currentNode.Left, insertNode);
                }
                else
                {
                    currentNode.Right = this.Add(currentNode.Right, insertNode);
                }
                UpdateCount(currentNode);

                return currentNode;
            }

            private TreapNode Remove(TreapNode currentNode, int value)
            {
                if (currentNode == null)
                {
                    return null;
                }

                if (currentNode.Key == value)
                {
                    return this.Merge(currentNode.Left, currentNode.Right);
                }

                if (currentNode.Key > value)
                {
                    currentNode.Left = this.Remove(currentNode.Left, value);
                }
                else
                {
                    currentNode.Right = this.Remove(currentNode.Right, value);
                }
                UpdateCount(currentNode);

                return currentNode;
            }

            private void Split(TreapNode currentNode, int key, ref TreapNode leftTree, ref TreapNode rightTree)
            {
                if (currentNode == null)
                {
                    leftTree = null;
                    rightTree = null;
                    return;
                }

                if (currentNode.Key < key)
                {
                    leftTree = currentNode;
                    TreapNode innerRightTree = null;
                    Split(currentNode.Right, key, ref innerRightTree, ref rightTree);
                    currentNode.Right = innerRightTree;
                    UpdateCount(currentNode);
                }
                else
                {
                    rightTree = currentNode;
                    TreapNode innerLeftTree = null;
                    Split(currentNode.Left, key, ref leftTree, ref innerLeftTree);
                    currentNode.Left = innerLeftTree;
                    UpdateCount(currentNode);
                }
            }

            private TreapNode Merge(TreapNode leftTree, TreapNode rightTree)
            {
                if (leftTree == null || rightTree == null)
                {
                    return leftTree == null ? rightTree : leftTree;
                }

                if (leftTree.Priority > rightTree.Priority)
                {
                    leftTree.Right = this.Merge(leftTree.Right, rightTree);
                    UpdateCount(leftTree);

                    return leftTree;
                }

                rightTree.Left = this.Merge(leftTree, rightTree.Left);
                UpdateCount(rightTree);

                return rightTree;
            }

            private TreapNode CreateNode(int value)
            {
                return new TreapNode()
                {
                    Count = 1,
                    Key = value,
                    Priority = this.random.Next(),
                };
            }

            static private void UpdateCount(TreapNode node)
            {
                if (node != null)
                {
                    node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
                }
            }

            static private int GetCount(TreapNode node)
            {
                return node != null ? node.Count : 0;
            }

            private class TreapNode
            {
                public int Key { get; set; }
                public TreapNode Left { get; set; }
                public TreapNode Right { get; set; }
                public int Count { get; set; }
                public int Priority { get; set; }
            }
        }
    }
}

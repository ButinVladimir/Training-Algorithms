using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public class MedianUpdates
    {
        private Trie trie = new Trie();

        public string Add(long value)
        {
            this.trie.Add(value);

            return this.GetMedian();
        }

        public string Remove(long value)
        {
            int countBefore = this.trie.GetCount();

            this.trie.Remove(value);

            if (this.trie.GetCount() == countBefore)
            {
                return "Wrong!";
            }

            return this.GetMedian();
        }

        private string GetMedian()
        {
            int count = this.trie.GetCount();
            
            if (count == 0)
            {
                return "Wrong!";
            }

            if (count % 2 == 1)
            {
                return this.trie.GetValue(count / 2 + 1).ToString();
            }

            long v = this.trie.GetValue(count / 2) + this.trie.GetValue(count / 2 + 1);

            if (v == -1)
            {
                return "-0.5";
            }

            return v % 2 != 0 ? string.Format("{0}.5", v/2) : (v/2).ToString();
        }

        private class Trie
        {
            private TrieNode first;
            private Random random;

            public Trie()
            {
                this.random = new Random();
            }

            public void Add(long value)
            {
                TrieNode insertedNode = new TrieNode() { Count = 1, Rank = this.random.Next(), Value = value };

                this.first = this.Add(first, insertedNode);
            }

            public void Remove(long value)
            {
                this.first = this.Remove(this.first, value);
            }

            public long GetValue(int count)
            {
                return this.GetValue(this.first, count);
            }

            public int GetCount()
            {
                return this.first != null ? this.first.Count : 0;
            }

            private TrieNode Add(TrieNode currentNode, TrieNode insertedNode)
            {
                if (currentNode == null)
                {
                    this.UpdateCount(insertedNode);

                    return insertedNode;
                }

                if (insertedNode.Rank > currentNode.Rank)
                {
                    this.Split(currentNode, insertedNode.Value, x => insertedNode.Left = x, x => insertedNode.Right = x);
                    this.UpdateCount(insertedNode);

                    return insertedNode;
                }
                
                if (insertedNode.Value < currentNode.Value)
                {
                    currentNode.Left = this.Add(currentNode.Left, insertedNode);
                }
                else
                {
                    currentNode.Right = this.Add(currentNode.Right, insertedNode);
                }

                this.UpdateCount(currentNode);
                return currentNode;
            }

            private TrieNode Remove(TrieNode currentNode, long value)
            {
                if (currentNode == null)
                {
                    return null;
                }

                if (currentNode.Value == value)
                {
                    TrieNode mergedNode = this.Merge(currentNode.Left, currentNode.Right);
                    this.UpdateCount(mergedNode);

                    return mergedNode;
                }

                if (value < currentNode.Value)
                {
                    currentNode.Left = this.Remove(currentNode.Left, value);
                }
                else
                {
                    currentNode.Right = this.Remove(currentNode.Right, value);
                }

                this.UpdateCount(currentNode);
                return currentNode;
            }

            private void Split(TrieNode node, long value, Action<TrieNode> setLeft, Action<TrieNode> setRight)
            {
                if (node == null)
                {
                    setLeft(null);
                    setRight(null);

                    return;
                }

                if (node.Value < value)
                {
                    setLeft(node);
                    this.Split(node.Right, value, x => node.Right = x, setRight);
                }
                else
                {
                    setRight(node);
                    this.Split(node.Left, value, setLeft, x => node.Left = x);
                }

                this.UpdateCount(node);
            }

            private TrieNode Merge(TrieNode left, TrieNode right)
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

                right.Left= this.Merge(left, right.Left);
                this.UpdateCount(right);

                return right;
            }

            private int GetCount(TrieNode node)
            {
                return node != null ? node.Count : 0;
            }

            private void UpdateCount(TrieNode node)
            {
                if (node != null)
                {
                    node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
                }
            }

            private long GetValue(TrieNode currentNode, int count)
            {
                if (currentNode == null)
                {
                    return 0;
                }

                int currentCount = this.GetCount(currentNode.Left) + 1;

                if (currentCount == count)
                {
                    return currentNode.Value;
                }

                if (currentCount < count)
                {
                    return this.GetValue(currentNode.Right, count - currentCount);
                }

                return this.GetValue(currentNode.Left, count);
            }

            private class TrieNode
            {
                public int Rank { get; set; }
                public long Value { get; set; }
                public int Count { get; set; }
                public TrieNode Left { get; set; }
                public TrieNode Right { get; set; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_44
{
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;

    using Algorithms.Set_62;

    public interface IVisitable
    {
        void RecordHit();

        int GetCount();
    }

    public class Visit : IVisitable
    {
        private int currentMoment;

        private Treap treap;

        public Visit()
        {
            this.currentMoment = 0;
            this.treap = new Treap();
        }

        public void RecordHit()
        {
            this.treap.Add(this.currentMoment);
        }

        public int GetCount()
        {
            this.treap.Remove(this.currentMoment - 599);
            return this.treap.GetCount();
        }

        public void Wait(int value)
        {
            this.currentMoment += value;
        }

        public string Log()
        {
            StringBuilder sb = new StringBuilder();
            this.treap.Log(sb);
            sb.Append("\n");

            return sb.ToString();
        }

        private class Treap
        {
            private Random random;

            private TreapNode rootNode;

            public Treap()
            {
                this.random = new Random();
            }

            public void Add(int value)
            {
                TreapNode node = new TreapNode(this.random, value);
                this.Add(node, ref this.rootNode);
            }

            public void Remove(int value)
            {
                TreapNode left = null;
                TreapNode right = null;

                this.Split(this.rootNode, value, ref left, ref right);
                this.rootNode = right;
            }

            public int GetCount()
            {
                if (this.rootNode == null)
                {
                    return 0;
                }

                return this.rootNode.Count;
            }

            public void Log(StringBuilder sb)
            {
                this.Log(sb, this.rootNode);
            }

            private void Log(StringBuilder sb, TreapNode node)
            {
                if (node == null)
                {
                    sb.Append('#');
                    return;
                }

                sb.Append(" { ");
                sb.Append(node.Value);
                sb.Append(" , ");
                sb.Append(node.Priority);
                sb.Append(" : ");
                this.Log(sb, node.left);
                sb.Append(" : ");
                this.Log(sb, node.right);
                sb.Append(" } ");
            }

            private void Add(TreapNode node, ref TreapNode currentNode)
            {
                if (currentNode == null)
                {
                    currentNode = node;
                    currentNode.UpdateCount();
                    return;
                }

                if (currentNode.Priority > node.Priority)
                {
                    if (currentNode.Value > node.Value)
                    {
                        this.Add(node, ref currentNode.left);
                    }
                    else
                    {
                        this.Add(node, ref currentNode.right);
                    }

                    currentNode.UpdateCount();
                    return;
                }

                this.Split(currentNode, node.Value, ref node.left, ref node.right);
                currentNode = node;
                currentNode.UpdateCount();
            }

            private void Split(TreapNode node, int value, ref TreapNode left, ref TreapNode right)
            {
                if (node == null)
                {
                    left = null;
                    right = null;

                    return;
                }

                if (value > node.Value)
                {
                    left = node;
                    this.Split(node.right, value, ref node.right, ref right);
                    left.UpdateCount();
                }
                else
                {
                    right = node;
                    this.Split(node.left, value, ref left, ref node.left);
                    right.UpdateCount();
                }
            }

            private class TreapNode
            {
                public TreapNode left;

                public TreapNode right;

                public TreapNode(Random random, int value)
                {
                    this.Priority = random.Next();
                    this.Value = value;
                }

                public int Priority { get; private set; }

                public int Count { get; private set; }

                public int Value { get; private set; }

                public void UpdateCount()
                {
                    this.Count = 1;

                    if (this.left != null)
                    {
                        this.Count += this.left.Count;
                    }

                    if (this.right != null)
                    {
                        this.Count += this.right.Count;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public class SimpleTextEditor
    {
        private Stack<PersistentArray> history = new Stack<PersistentArray>();

        public SimpleTextEditor()
        {
            this.history.Push(new PersistentArray());
        }

        public void Append(string s)
        {
            PersistentArray prevArray = this.history.Peek();
            PersistentArray newArray = new PersistentArray(prevArray);
            newArray.Append(s);
            this.history.Push(newArray);
        }

        public void Delete(int length)
        {
            PersistentArray prevArray = this.history.Peek();
            PersistentArray newArray = new PersistentArray(prevArray);
            newArray.Delete(length);
            this.history.Push(newArray);
        }

        public char Print(int position)
        {
            return this.history.Peek().Print(position);
        }

        public void Undo()
        {
            this.history.Pop();
        }

        private class PersistentArray
        {
            private static readonly Stack<bool> moves = new Stack<bool>();
            private int Length { get; set; }
            private PersistentArrayNode Root { get; set; }

            public PersistentArray()
            {
            }

            public PersistentArray(PersistentArray array)
            {
                this.Length = array.Length;
                this.Root = array.Root;
            }

            public void Append(string s)
            {
                foreach (char c in s)
                {
                    this.Length++;
                    PrepareMoves(this.Length);
                    this.Root = this.Push(this.Root, c);
                }
            }

            public void Delete(int length)
            {
                this.Length -= length;
            }

            public char Print(int position)
            {
                PrepareMoves(position);
                PersistentArrayNode node = this.Root;

                bool move;
                while (moves.Count > 0)
                {
                    move = moves.Pop();
                    if (move)
                    {
                        node = node.Right;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }

                return node.Value;
            }

            private PersistentArrayNode Push(PersistentArrayNode prevNode, char c)
            {
                PersistentArrayNode newNode = new PersistentArrayNode(prevNode);

                bool move;
                if (moves.Count > 0)
                {
                    move = moves.Pop();
                    if (move)
                    {
                        newNode.Right = this.Push(newNode.Right, c);
                    }
                    else
                    {
                        newNode.Left = this.Push(newNode.Left, c);
                    }
                }
                else
                {
                    newNode.Value = c;
                }

                return newNode;
            }

            private static void PrepareMoves(int position)
            {
                moves.Clear();
                while (position > 1)
                {
                    moves.Push(position % 2 > 0);
                    position /= 2;
                }
            }

            private class PersistentArrayNode
            {
                public PersistentArrayNode Left { get; set; }
                public PersistentArrayNode Right { get; set; }
                public char Value { get; set; }

                public PersistentArrayNode()
                {
                }

                public PersistentArrayNode(PersistentArrayNode prevNode)
                {
                    if (prevNode != null)
                    {
                        this.Left = prevNode.Left;
                        this.Right = prevNode.Right;
                        this.Value = prevNode.Value;
                    }
                }
            }
        }
    }
}

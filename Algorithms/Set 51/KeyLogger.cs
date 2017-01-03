using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_51
{
    class KeyLogger
    {
        const char PREV = '<';
        const char NEXT = '>';
        const char DEL = '-';

        private int count = 0;
        private int position = 0;
        private Node first = null;
        private Node last = null;
        private Node current = null;

        public void NextCharacter(char c)
        {
            switch (c)
            {
                case PREV:
                    this.Prev();
                    break;
                case NEXT:
                    this.Next();
                    break;
                case DEL:
                    this.DeleteCharacter();
                    break;
                default:
                    this.AddCharacter(c);
                    break;
            }
        }

        public override string ToString()
        {
            Node node = this.first;
            StringBuilder sb = new StringBuilder();

            while (node != null)
            {
                sb.Append(node.Character);
                node = node.Next;
            }

            return sb.ToString();
        }

        private void Prev()
        {
            if (this.position > 0)
            {
                this.position--;
            }
        }

        private void Next()
        {
            if (this.position < this.count)
            {
                this.position++;
            }
        }

        private void AddCharacter(char c)
        {
            Node node = new Node() { Character = c };

            if (this.count == 0)
            {
                this.first = this.last = this.current = node;
                this.position = 0;
            }
            else if (this.position == 0)
            {
                this.first.Prev = node;
                node.Next = this.first;
                this.first = node;
            }
            else if (this.position == this.count)
            {
                this.last.Next = node;
                node.Prev = this.last;
                this.last = node;
            }
            else
            {
                node.Next = this.current;
                node.Prev = this.current.Prev;
                this.current.Prev = node;
                node.Prev.Next = node;
            }

            this.current = node;
            this.position++;
            this.count++;
        }

        private void DeleteCharacter()
        {
            if (this.position == 0 || this.count == 0)
            {
                return;
            }

            if (this.count == 1)
            {
                if (this.position == 1)
                {
                    this.first = this.last = this.current = null;
                    this.position = 0;
                    this.count = 0;
                }
            } else
            {
                if (this.position == 1)
                {
                    this.current.Prev = null;
                    this.first = this.current;
                }
                else if (this.position == this.count)
                {
                    this.last.Prev.Next = null;
                    this.last = this.current = this.last.Prev;
                } else
                {
                    this.current.Prev.Prev.Next = this.current;
                    this.current.Prev = this.current.Prev.Prev;
                }

                this.position--;
                this.count--;
            }
        }

        private class Node
        {
            public char Character { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node()
            {
                this.Prev = this.Next = null;
            }
        }
    }
}

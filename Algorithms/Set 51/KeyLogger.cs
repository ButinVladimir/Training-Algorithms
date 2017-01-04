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

        private Node first;
        private Node last;
        private Node current;

        public KeyLogger()
        {
            this.first = new Node();
            this.current = this.last = new Node();
            this.first.Next = this.last;
            this.last.Prev = this.first;
        }

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
            Node node = this.first.Next;
            StringBuilder sb = new StringBuilder();

            while (node != this.last)
            {
                sb.Append(node.Character);
                node = node.Next;
            }

            return sb.ToString();
        }

        private void Prev()
        {
            if (this.current.Prev != this.first)
            {
                this.current = this.current.Prev;
            }
        }

        private void Next()
        {
            if (this.current != this.last)
            {
                this.current = this.current.Next;
            }
        }

        private void AddCharacter(char c)
        {
            Node node = new Node()
            {
                Character = c
            };

            node.Prev = this.current.Prev;
            this.current.Prev.Next = node;
            node.Next = this.current;
            this.current.Prev = node;
        }

        private void DeleteCharacter()
        {
            if (this.current.Prev != this.first)
            {
                Node node = this.current.Prev;
                this.current.Prev = node.Prev;
                node.Prev.Next = this.current;
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

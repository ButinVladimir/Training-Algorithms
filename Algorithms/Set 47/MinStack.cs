using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_47
{
    class MinStack
    {
        protected class Node
        {
            public int Value { get; set; }
            public int Min { get; set; }
            public Node Next { get; set; }

            public Node (int value, Node next)
            {
                this.Value = this.Min = value;
                this.Next = next;
                if (next != null && next.Min < this.Min)
                {
                    this.Min = next.Min;
                }
            }
        }

        private Node root;

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Pop()
        {
            if (!this.IsEmpty())
            {
                this.root = this.root.Next;
            }
        }

        public void Push(int value)
        {
            Node node = new Node(value, this.root);
            this.root = node;
        }

        public bool TryGetValue(out int value)
        {
            if (!this.IsEmpty())
            {
                value = this.root.Value;
                return true;
            }

            value = 0;
            return false;
        }

        public bool TryGetMin(out int min)
        {
            if (!this.IsEmpty())
            {
                min = this.root.Min;
                return true;
            }

            min = 0;
            return false;
        }
    }
}


/*
 * 
 * Usage
 
 static private void Push(MinStack stack, int val)
        {
            Console.WriteLine("Before");
            Output(stack);
            Console.WriteLine("");

            stack.Push(val);
            Console.WriteLine("Pushed {0}", val);

            Console.WriteLine("\nAfter");
            Output(stack);
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        static private void Pop(MinStack stack)
        {
            Console.WriteLine("Before");
            Output(stack);
            Console.WriteLine("");

            stack.Pop();
            Console.WriteLine("Popped");

            Console.WriteLine("\nAfter");
            Output(stack);
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        static private void Output(MinStack stack)
        {
            int value, min;
            bool success;
            success = stack.TryGetMin(out min);

            if (!success)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            success = stack.TryGetValue(out value);

            Console.WriteLine("Value = {0}, Min = {1}", value, min);
        }

        static void Main(string[] args)
        {
            MinStack stack = new MinStack();

            Push(stack, -10);
            Push(stack, 3);
            Push(stack, 1);
            Push(stack, 2);
            Pop(stack);
            Pop(stack);
            Pop(stack);
            Pop(stack);
            Push(stack, -1);
            Pop(stack);
            Pop(stack);
            Pop(stack);
            Pop(stack);
        }
        */
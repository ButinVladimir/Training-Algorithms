﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    using Set_47;

    class Program
    {
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
    }
}
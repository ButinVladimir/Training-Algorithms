using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public static class ReversePolishNotation
    {
        const string Plus = "+";
        const string Minus = "-";
        const string Multiply = "*";
        const string Divide = "/";

        public static long Compute(string[] parts)
        {
            Stack<long> stack = new Stack<long>();
            foreach (string part in parts)
            {
                long v;
                if (long.TryParse(part, out v))
                {
                    stack.Push(v);
                }
                else
                {
                    long b = stack.Pop();
                    long a = stack.Pop();

                    switch (part)
                    {
                        case Plus:
                            stack.Push(a + b);
                            break;
                        case Minus:
                            stack.Push(a - b);
                            break;
                        case Multiply:
                            stack.Push(a * b);
                            break;
                        case Divide:
                            stack.Push(a / b);
                            break;
                    }
                }
            }

            return stack.Peek();
        }

        public static string Transform(string[] parts)
        {
            Stack<string> stack = new Stack<string>();
            foreach (string part in parts)
            {
                long v;
                if (long.TryParse(part, out v))
                {
                    stack.Push(part);
                }
                else
                {
                    string b = stack.Pop();
                    string a = stack.Pop();

                    stack.Push(string.Format("({0}{1}{2})", a, part, b));
                }
            }

            return stack.Peek();
        }
    }
}

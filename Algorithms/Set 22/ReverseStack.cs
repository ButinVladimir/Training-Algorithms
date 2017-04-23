using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public static class ReverseStack
    {
        public static void Solve(Stack<int> input)
        {
            Stack<int> buffer = new Stack<int>();
            int value;

            for (int n = input.Count; n > 0; n--)
            {
                while (input.Count > 0)
                {
                    buffer.Push(input.Pop());
                }

                value = buffer.Pop();

                while (buffer.Count > 0)
                {
                    input.Push(buffer.Pop());
                }

                input.Push(value);
            }
        }
    }

    [TestClass]
    public class ReverseStackTest
    {
        [TestMethod]
        public void Test()
        {
            int[] inputArray = new int[] { 1, 2, 3, 4, 5 };
            Stack<int> input = new Stack<int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                input.Push(inputArray[i]);
            }

            ReverseStack.Solve(input);

            int[] result = input.ToArray();
            Array.Reverse(result);

            Assert.AreEqual(inputArray.Length, result.Length);
            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.AreEqual(inputArray[i], result[i]);
            }
        }
    }
}

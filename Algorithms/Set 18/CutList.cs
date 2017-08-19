using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_18
{
    public static class CutList
    {
        public static ListNode Solve(ListNode first, int k)
        {
            ListNode currentFirst = first;
            ListNode currentLast = first;

            for (int i = 0; i < k; i++)
            {
                if (currentLast.Next == null)
                {
                    return first;
                }

                currentLast = currentLast.Next;
            }

            while (currentLast.Next != null)
            {
                currentFirst = currentFirst.Next;
                currentLast = currentLast.Next;
            }

            ListNode start = currentFirst.Next;
            currentFirst.Next = null;

            ListNode end = start;
            while (end.Next != null)
            {
                end = end.Next;
            }
            end.Next = first;

            return start;
        }

        public class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CutListTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6 };

            CutList.ListNode first = MakeList(input);

            int[] expected = new int[] { 4, 5, 6, 1, 2, 3 };
            CutList.ListNode result = CutList.Solve(first, 3);

            CollectionAssert.AreEqual(expected, MakeArray(result));
        }

        [TestMethod]
        public void Test2()
        {
            int[] input = new int[] { 1, 2, 3 };

            CutList.ListNode first = MakeList(input);

            int[] expected = new int[] { 1, 2, 3 };
            CutList.ListNode result = CutList.Solve(first, 3);

            CollectionAssert.AreEqual(expected, MakeArray(result));
        }

        [TestMethod]
        public void Test3()
        {
            int[] input = new int[] { 1, 2, 3 };

            CutList.ListNode first = MakeList(input);

            int[] expected = new int[] { 1, 2, 3 };
            CutList.ListNode result = CutList.Solve(first, 10);

            CollectionAssert.AreEqual(expected, MakeArray(result));
        }

        [TestMethod]
        public void Test4()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            CutList.ListNode first = MakeList(input);

            int[] expected = new int[] { 9, 10, 1, 2, 3, 4, 5, 6, 7, 8 };
            CutList.ListNode result = CutList.Solve(first, 2);

            CollectionAssert.AreEqual(expected, MakeArray(result));
        }

        private static CutList.ListNode MakeList(int[] array)
        {
            CutList.ListNode first = new CutList.ListNode()
            {
                Value = array[0]
            };

            CutList.ListNode current = first;
            for (int i = 1; i < array.Length; i++)
            {
                current.Next = new CutList.ListNode()
                {
                    Value = array[i]
                };

                current = current.Next;
            }

            return first;
        }

        private static int[] MakeArray(CutList.ListNode first)
        {
            List<int> result = new List<int>();

            CutList.ListNode current = first;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }

            return result.ToArray();
        }
    }
}

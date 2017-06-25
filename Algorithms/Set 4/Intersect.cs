using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_4
{
    public static class Intersect
    {
        public static int Solve(ListNode first1, ListNode first2)
        {
            if (first1 == null || first2 == null)
            {
                return -1;
            }

            int length1 = GetLength(first1);
            int length2 = GetLength(first2);

            ListNode current1, current2;
            int index1, index2;
            int diff = length1 - length2;

            InitMove(first1, diff, out index1, out current1);
            InitMove(first2, -diff, out index2, out current2);

            while (current1 != current2 && current1 != null)
            {
                current1 = current1.Next;
                current2 = current2.Next;

                index1++;
                index2++;
            }

            return current1 == null ? -1 : index1;
        }

        private static int GetLength(ListNode first)
        {
            ListNode current = first;
            int length = 0;

            while (current != null)
            {
                length++;
                current = current.Next;
            }

            return length;
        }

        private static void InitMove(ListNode first, int diff, out int index, out ListNode current)
        {
            current = first;
            index = 0;

            for (int i = 0; i < diff; i++)
            {
                current = current.Next;
                index++;
            }
        }

        public class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
        }
    }

    [TestClass]
    public class IntersectTest
    {
        [TestMethod]
        public void Test1()
        {
            Intersect.ListNode first1 = this.MakeList(new int[] { 1, 3, 7, 10 });
            Intersect.ListNode first2 = this.MakeList(new int[] { 5, 4, 3, 2 });

            Assert.AreEqual(-1, Intersect.Solve(first1, first2));
        }

        [TestMethod]
        public void Test2()
        {
            Intersect.ListNode first1 = this.MakeList(new int[] { 1, 3, 7, 10 });
            Intersect.ListNode first2 = this.MakeList(new int[] { 5, 2 });

            Assert.AreEqual(-1, Intersect.Solve(first1, first2));
        }

        [TestMethod]
        public void Test3()
        {
            Intersect.ListNode first1 = this.MakeList(new int[] { 1 });
            Intersect.ListNode first2 = this.MakeList(new int[] { 5, 2, 3, 11, 15});

            Assert.AreEqual(-1, Intersect.Solve(first1, first2));
        }

        [TestMethod]
        public void Test4()
        {
            Intersect.ListNode first1 = this.MakeList(new int[] { 1, 3, 7, 10 });
            Intersect.ListNode first2 = this.MakeList(new int[] { 5, 4, 3, 2 });
            Intersect.ListNode crossFirst = this.MakeList(new int[] { 11, 23, 43 });
            this.MergeLists(first1, crossFirst);
            this.MergeLists(first2, crossFirst);

            Assert.AreEqual(4, Intersect.Solve(first1, first2));
        }

        [TestMethod]
        public void Test5()
        {
            Intersect.ListNode first1 = this.MakeList(new int[] { 1, 3, 7, 10 });
            Intersect.ListNode first2 = this.MakeList(new int[] { 5, 2 });
            Intersect.ListNode crossFirst = this.MakeList(new int[] { 11, 23, 43 });
            this.MergeLists(first1, crossFirst);
            this.MergeLists(first2, crossFirst);

            Assert.AreEqual(4, Intersect.Solve(first1, first2));
        }

        [TestMethod]
        public void Test6()
        {
            Intersect.ListNode first1 = this.MakeList(new int[] { 1 });
            Intersect.ListNode first2 = this.MakeList(new int[] { 5, 2, 3, 11, 15 });
            Intersect.ListNode crossFirst = this.MakeList(new int[] { 11, 23, 43 });
            this.MergeLists(first1, crossFirst);
            this.MergeLists(first2, crossFirst);

            Assert.AreEqual(1, Intersect.Solve(first1, first2));
        }

        [TestMethod]
        public void Test7()
        {
            Intersect.ListNode first = this.MakeList(new int[] { 5, 2, 3, 11, 15 });
            Intersect.ListNode crossFirst = this.MakeList(new int[] { 11, 23, 43 });
            this.MergeLists(first, crossFirst);

            Assert.AreEqual(5, Intersect.Solve(first, crossFirst));
            Assert.AreEqual(0, Intersect.Solve(crossFirst, first));
        }

        private Intersect.ListNode MakeList(int[] list)
        {
            if (list.Length == 0)
            {
                return null;
            }

            Intersect.ListNode firstNode, currentNode;
            firstNode = new Intersect.ListNode() { Value = list[0] };
            currentNode = firstNode;

            for (int i = 1; i < list.Length; i++)
            {
                currentNode.Next = new Intersect.ListNode() { Value = list[1] };
                currentNode = currentNode.Next;
            }

            return firstNode;
        }

        private void MergeLists(Intersect.ListNode first1, Intersect.ListNode first2)
        {
            while (first1.Next != null)
            {
                first1 = first1.Next;
            }

            first1.Next = first2;
        }
    }
}
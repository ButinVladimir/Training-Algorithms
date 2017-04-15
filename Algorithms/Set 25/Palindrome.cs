using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_25
{
    public class Palindrome
    {
        private static ListNode StringToList(string s)
        {
            ListNode first = null;
            ListNode current = null;

            for (int i = 0; i < s.Length; i++)
            {
                if (first == null)
                {
                    first = current = new ListNode() { Value = s[i] };
                }
                else
                {
                    current.Next = new ListNode() { Value = s[i] };
                    current = current.Next;
                }
            }

            return first;
        }

        private static string StringToList(ListNode start, int length)
        {
            ListNode current = start;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length && current != null; i++, current = current.Next)
            {
                sb.Append(current.Value);
            }

            return sb.ToString();
        }

        private static ListNode GetNode(ListNode start, int skip)
        {
            ListNode current = start;
            while (current != null && skip > 0)
            {
                current = current.Next;
                skip--;
            }

            return current;
        }

        private int n;
        private ListNode first;

        public Palindrome(string s)
        {
            this.n = s.Length;
            this.first = StringToList(s);
        }

        public string GetPalindrome()
        {
            int left, length;
            int maxLength = 1;
            int maxPos = 0;

            for (int start = 0; start < n; start++)
            {
                left = GetPalindrome(start, start);
                length = 2 * (start - left) + 1;

                if (length > maxLength)
                {
                    maxLength = length;
                    maxPos = left;
                }

                left = GetPalindrome(start, start + 1);
                length = 2 * (start - left + 1);

                if (start > left && length > maxLength)
                {
                    maxLength = length;
                    maxPos = left;
                }
            }

            return StringToList(GetNode(this.first, maxPos), maxLength);
        }

        private int GetPalindrome(int left, int right)
        {
            while (left >= 0 && right < n && GetNode(this.first, left).Value == GetNode(this.first, right).Value)
            {
                left--;
                right++;
            }

            left++;
            right--;

            return left;
        }

        private class ListNode
        {
            public char Value { get; set; }
            public ListNode Next { get; set; }
        }
    }

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void Test1()
        {
            Palindrome p = new Palindrome("abadabadoo");
            Assert.AreEqual("abadaba", p.GetPalindrome());
        }

        [TestMethod]
        public void Test2()
        {
            Palindrome p = new Palindrome("abadabcdoo");
            Assert.AreEqual("badab", p.GetPalindrome());
        }

        [TestMethod]
        public void Test3()
        {
            Palindrome p = new Palindrome("acadabbadoo");
            Assert.AreEqual("dabbad", p.GetPalindrome());
        }
    }
}

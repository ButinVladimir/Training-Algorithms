using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_23
{
    public static class Palindrome
    {
        const char divider = '#';

        public static string Solve(string s)
        {
            int n = s.Length;
            int n2 = n * 2;
            char[] chars = new char[n2];

            for (int i = 0; i < n; i++)
            {
                chars[2 * i] = s[i];
                chars[2 * i + 1] = divider;
            }

            int maxRight = 0;
            int left;
            int[] rights = new int[n2];
            for (int i = 1; i < n2; i++)
            {
                rights[i] = i;

                if (i <= rights[maxRight])
                {
                    rights[i] = i + rights[2 * maxRight - i] - (2 * maxRight - i);

                    if (rights[i] > rights[maxRight])
                    {
                        rights[i] = rights[maxRight];
                    }
                }

                left = 2 * i - rights[i];
                while (left >= 0 && rights[i] < n2 && chars[left] == chars[rights[i]])
                {
                    left--;
                    rights[i]++;
                }

                rights[i]--;
                if (rights[i] > maxRight)
                {
                    maxRight = i;
                }
            }

            int maxPosition = 0;
            int maxLength = 0;
            int length;
            for (int i = 0; i < n2; i++)
            {
                left = 2 * i - rights[i];
                if (chars[left] == divider)
                {
                    left++;
                }

                if (chars[i] == divider)
                {
                    length = 2 * ((i - left + 1) / 2);
                }
                else
                {
                    length = 2 * ((i - left) / 2) + 1;
                }

                left /= 2;

                if (length > maxLength || length == maxLength && left < maxPosition)
                {
                    maxPosition = left;
                    maxLength = length;
                }
            }

            return s.Substring(maxPosition, maxLength);
        }
        // a#a#a#a

        public static string SolveBrute(string s)
        {
            int maxPosition = 0, maxLength = 1;
            int leftPosition, rightPosition, length;

            for (int i = 0; i < s.Length; i++)
            {
                leftPosition = rightPosition = i;
                while (leftPosition >= 0 && rightPosition < s.Length && s[leftPosition] == s[rightPosition])
                {
                    leftPosition--;
                    rightPosition++;
                }

                leftPosition++;
                rightPosition--;

                length = rightPosition - leftPosition + 1;
                if (length > maxLength || length == maxLength && maxPosition > leftPosition)
                {
                    maxLength = length;
                    maxPosition = leftPosition;
                }


                leftPosition = i;
                rightPosition = i + 1;
                while (leftPosition >= 0 && rightPosition < s.Length && s[leftPosition] == s[rightPosition])
                {
                    leftPosition--;
                    rightPosition++;
                }

                leftPosition++;
                rightPosition--;

                length = rightPosition - leftPosition + 1;
                if (length > maxLength || length == maxLength && maxPosition > leftPosition)
                {
                    maxLength = length;
                    maxPosition = leftPosition;
                }
            }

            return s.Substring(maxPosition, maxLength);
        }
    }

    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void Test1()
        {
            string s = "abcaacdedaad";
            string answer = "caac";

            Test(s, answer);
        }

        [TestMethod]
        public void Test2()
        {
            string s = "abcd";
            string answer = "a";

            Test(s, answer);
        }

        [TestMethod]
        public void Test3()
        {
            string s = "abcbaqe";
            string answer = "abcba";

            Test(s, answer);
        }

        [TestMethod]
        public void Test4()
        {
            string s = "abaaabababaaaba";
            string answer = "abaaabababaaaba";

            Test(s, answer);
        }

        [TestMethod]
        public void Test5()
        {
            string s = "abaaababbabaaaba";
            string answer = "abaaababbabaaaba";

            Test(s, answer);
        }

        [TestMethod]
        public void Test6()
        {
            string s = "qabaaababbabaaabae";
            string answer = "abaaababbabaaaba";

            Test(s, answer);
        }

        [TestMethod]
        public void Test7()
        {
            string s = "aaaaaaaaaa";
            string answer = "aaaaaaaaaa";

            Test(s, answer);
        }

        [TestMethod]
        public void Test8()
        {
            string s = "aaaaaaaaaaa";
            string answer = "aaaaaaaaaaa";

            Test(s, answer);
        }

        [TestMethod]
        public void Test9()
        {
            string s = "abababc";
            string answer = "ababa";

            Test(s, answer);
        }

        private void Test(string s, string answer)
        {
            Assert.AreEqual(answer, Palindrome.SolveBrute(s));
            Assert.AreEqual(answer, Palindrome.Solve(s));
        }
    }
}

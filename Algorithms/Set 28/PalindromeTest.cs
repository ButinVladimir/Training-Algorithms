using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void TestLetter()
        {
            Assert.AreEqual("a", Palindrome.Solve("a"));
        }

        [TestMethod]
        public void TestSimple()
        {
            Assert.AreEqual("abcba", Palindrome.Solve("abc"));
        }

        [TestMethod]
        public void TestDouble()
        {
            Assert.AreEqual("abccba", Palindrome.Solve("abcc"));
        }

        [TestMethod]
        public void TestEndWithPalindrome()
        {
            Assert.AreEqual("abcdefgfedcba", Palindrome.Solve("abcdefgfed"));
        }

        [TestMethod]
        public void TestEndWithMono()
        {
            Assert.AreEqual("aaaaa", Palindrome.Solve("aaaaa"));
        }

        [TestMethod]
        public void TestEndWithMono2()
        {
            Assert.AreEqual("aaaa", Palindrome.Solve("aaaa"));
        }

        [TestMethod]
        public void TestCustom()
        {
            Assert.AreEqual("bcafdadfacb", Palindrome.Solve("bcafda"));
        }
    }
}

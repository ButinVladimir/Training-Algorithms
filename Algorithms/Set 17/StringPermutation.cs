using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_17
{
    public class StringPermutation
    {
        private Dictionary<char, int> patternCount;
        private Dictionary<char, int> substringCount;
        private int rightCount;

        public string S { get; set; }
        public string Pattern { get; set; }

        public List<int> Find()
        {
            this.patternCount = new Dictionary<char, int>();
            this.substringCount = new Dictionary<char, int>();
            this.rightCount = 0;

            List<int> result = new List<int>();

            if (this.Pattern.Length > this.S.Length)
            {
                return result;
            }

            foreach (char c in this.Pattern)
            {
                if (!this.patternCount.ContainsKey(c))
                {
                    this.patternCount[c] = 0;
                }
                this.patternCount[c]++;
            }

            for (int i = 0; i < this.Pattern.Length; i++)
            {
                this.AddSymbol(this.S[i]);
            }

            if (this.rightCount == this.patternCount.Count)
            {
                result.Add(0);
            }

            for (int i = this.Pattern.Length; i < this.S.Length; i++)
            {
                this.AddSymbol(this.S[i]);
                this.RemoveSymbol(this.S[i - this.Pattern.Length]);

                if (this.rightCount == this.patternCount.Count)
                {
                    result.Add(i - this.Pattern.Length + 1);
                }
            }

            return result;
        }

        private void AddSymbol(char c)
        {
            if (!this.substringCount.ContainsKey(c))
            {
                this.substringCount[c] = 0;
            }
            int v = ++this.substringCount[c];


            if (this.patternCount.ContainsKey(c))
            {
                if (v == this.patternCount[c])
                {
                    this.rightCount++;
                }
                if (v == this.patternCount[c] + 1)
                {
                    this.rightCount--;
                }
            }
        }

        private void RemoveSymbol(char c)
        {
            int v = --this.substringCount[c];


            if (this.patternCount.ContainsKey(c))
            {
                if (v == this.patternCount[c])
                {
                    this.rightCount++;
                }
                if (v == this.patternCount[c] - 1)
                {
                    this.rightCount--;
                }
            }
        }
    }

    [TestClass]
    public class StringPermutationTest
    {
        [TestMethod]
        public void Test1()
        {
            StringPermutation sp = new StringPermutation()
            {
                S = "abcba",
                Pattern = "abc"
            };

            List<int> result = sp.Find();

            CollectionAssert.AreEqual(result, new List<int>() { 0, 2 });
        }

        [TestMethod]
        public void Test2()
        {
            StringPermutation sp = new StringPermutation()
            {
                S = "abcbabca",
                Pattern = "abc"
            };

            List<int> result = sp.Find();

            CollectionAssert.AreEqual(result, new List<int>() { 0, 2, 4, 5 });
        }

        [TestMethod]
        public void Test3()
        {
            StringPermutation sp = new StringPermutation()
            {
                S = "aaaaaaa",
                Pattern = "abc"
            };

            List<int> result = sp.Find();

            CollectionAssert.AreEqual(result, new List<int>() { });
        }

        [TestMethod]
        public void Test4()
        {
            StringPermutation sp = new StringPermutation()
            {
                S = "aaaaaaa",
                Pattern = "aaa"
            };

            List<int> result = sp.Find();

            CollectionAssert.AreEqual(result, new List<int>() { 0, 1, 2, 3, 4 });
        }
    }
}

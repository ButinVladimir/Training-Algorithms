using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_16
{
    public class PrefixCounting
    {
        public int Result { get; private set; }
        private Node root;

        public PrefixCounting()
        {
            this.root = new Node();
            this.Result = 0;
        }

        public void AddWord(string word)
        {
            Node currentnode = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                currentnode = currentnode.Go(word[i]);
                this.Result += currentnode.Count;
                currentnode.Count++;
            }
        }

        private class Node
        {
            public Dictionary<char, Node> Next { get; private set; }
            public int Count { get; set; }

            public Node()
            {
                this.Next = new Dictionary<char, Node>();
                this.Count = 0;
            }

            public Node Go(char c)
            {
                if (!this.Next.ContainsKey(c))
                {
                    this.Next[c] = new Node();
                }

                return this.Next[c];
            }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class PrefixCountingTest
    {
        [TestMethod]
        public void Test1()
        {
            PrefixCounting pc = new PrefixCounting();
            pc.AddWord("aac");
            pc.AddWord("ab");
            pc.AddWord("bcfx");
            pc.AddWord("bcfd");

            Assert.AreEqual(4, pc.Result);
        }

        [TestMethod]
        public void Test2()
        {
            PrefixCounting pc = new PrefixCounting();
            pc.AddWord("aac");
            pc.AddWord("ab");
            pc.AddWord("bcfx");
            pc.AddWord("bcfd");
            pc.AddWord("bcfd");
            pc.AddWord("bcfda");

            Assert.AreEqual(1 + 9 + 8 + 4, pc.Result);
        }
    }
}

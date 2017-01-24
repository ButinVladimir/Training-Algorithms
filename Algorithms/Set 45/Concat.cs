using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_45
{
    class Concat
    {
        private TrieNode rootNode;

        public Concat()
        {
            this.rootNode = new TrieNode();
        }

        public void Add(string[] words)
        {
            foreach (string word in words)
            {
                TrieNode currentNode = this.rootNode;
                for (int i = 0; i < word.Length; i++)
                {
                    currentNode = currentNode.GetNext(word[i]);
                }

                currentNode.Count++;
            }
        }

        public string Generate()
        {
            LinkedList<char> buffer = new LinkedList<char>();
            StringBuilder sb = new StringBuilder();

            this.Visit(this.rootNode, sb, buffer);

            return sb.ToString();
        }

        private void Visit(TrieNode currentNode, StringBuilder sb, LinkedList<char> buffer)
        {
            if (currentNode == null)
            {
                return;
            }

            for (int i = 0; i < currentNode.Count; i++)
            {
                foreach (char symbol in buffer)
                {
                    sb.Append(symbol);
                }
            }

            foreach (var nextNode in currentNode.Next)
            {
                buffer.AddLast(nextNode.Key);
                this.Visit(nextNode.Value, sb, buffer);
                buffer.RemoveLast();
            }
        }

        private class TrieNode
        {
            public TrieNode()
            {
                this.Next = new SortedDictionary<char, TrieNode>();
            }

            public SortedDictionary<char, TrieNode> Next { get; private set; }

            public int Count { get; set; }

            public TrieNode GetNext(char c)
            {
                if (!this.Next.ContainsKey(c))
                {
                    this.Next[c] = new TrieNode();
                }

                return this.Next[c];
            }
        }
    }
}

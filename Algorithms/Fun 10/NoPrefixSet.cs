using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public class NoPrefixSet
    {
        Trie trie = new Trie();

        public string Solve(List<string> strings)
        {
            foreach (string s in strings)
            {
                if (!this.trie.AddString(s))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("BAD SET");
                    sb.AppendLine(s);

                    return sb.ToString();
                }
            }

            return "GOOD SET";
        }

        private class Trie
        {
            private TrieNode root = new TrieNode();

            public bool AddString(string s)
            {
                TrieNode currentNode = this.root;
                for (int i = 0; i < s.Length; i++)
                {
                    currentNode = currentNode.GetNext(s[i]);
                    if (i == s.Length - 1 && currentNode.isMarked)
                    {
                        return false;
                    }
                    currentNode.isMarked = true;
                }

                return true;
            }

            private class TrieNode
            {
                private SortedDictionary<char, TrieNode> next = new SortedDictionary<char, TrieNode>();
                public bool isMarked { get; set; } = false;

                public TrieNode GetNext(char c)
                {
                    TrieNode result = null;
                    if (this.next.TryGetValue(c, out result))
                    {
                        return result;
                    }

                    result = new TrieNode();
                    this.next[c] = result;

                    return result;
                }
            }
        }
    }
}

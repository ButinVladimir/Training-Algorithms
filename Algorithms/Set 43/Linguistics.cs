using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_43
{
    class Linguistics
    {
        public static List<string> Solve(string s)
        {
            int n = s.Length;
            bool[] can2 = new bool[n];
            bool[] can3 = new bool[n];

            for (int i = 0; i < n; i++)
            {
                can2[i] = false;
                can3[i] = false;
            }

            can2[n - 2] = true;
            can3[n - 3] = true;

            for (int i = n - 1; i >= 5; i--)
            {
                if (can2[i] == true)
                {
                    can3[i - 3] = true;

                    if (Compare(s, i - 2, i, 2))
                    {
                        can2[i - 2] = true;
                    }
                }

                if (can3[i] == true)
                {
                    can2[i - 2] = true;

                    if (Compare(s, i - 3, i, 3))
                    {
                        can3[i - 3] = true;
                    }
                }
            }

            TrieNode trie = new TrieNode();
            for (int i = 5; i < n; i++)
            {
                if (can2[i])
                {
                    Add(s, i, 2, trie);
                }

                if (can3[i])
                {
                    Add(s, i, 3, trie);
                }
            }

            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            trie.Visit(sb, list);

            return list;
        }

        private static bool Compare(string s, int start1, int start2, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (s[start1 + i] != s[start2 + i])
                {
                    return true;
                }
            }

            return false;
        }

        private static void Add(string s, int start, int length, TrieNode rootNode)
        {
            TrieNode currentNode = rootNode;
            for (int i = 0; i < length; i++)
            {
                currentNode = currentNode.GoNext(s[start + i]);
            }

            currentNode.Finish = true;
        }

        private class TrieNode
        {
            private SortedDictionary<char, TrieNode> next;

            public TrieNode()
            {
                this.next = new SortedDictionary<char, TrieNode>();
            }

            public bool Finish { get; set; }

            public TrieNode GoNext(char c)
            {
                if (!this.next.ContainsKey(c))
                {
                    this.next[c] = new TrieNode();
                }

                return this.next[c];
            }

            public void Visit(StringBuilder sb, List<string> list)
            {
                if (this.Finish)
                {
                    list.Add(sb.ToString());
                }

                foreach (var keyValuePair in this.next)
                {
                    sb.Append(keyValuePair.Key);
                    keyValuePair.Value.Visit(sb, list);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }
    }
}

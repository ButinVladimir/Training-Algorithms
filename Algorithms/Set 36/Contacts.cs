using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_36
{
    public class Contacts
    {
        private TrieNode rootNode;

        public Contacts()
        {
            this.rootNode = new TrieNode()
            {
                Part = "",
                Count = 0
            };
        }

        public void Add(string s)
        {
            TrieNode currentNode = this.rootNode;

            int index = 0;
            int currentNodeIndex = 0;
            while (index < s.Length)
            {
                if (currentNodeIndex == currentNode.Part.Length)
                {
                    currentNode.Count++;

                    if (currentNode.Next[s[index] - 'a'] == null)
                    {
                        currentNode.Next[s[index] - 'a'] = new TrieNode()
                        {
                            Count = 1,
                            Part = s.Substring(index)
                        };
                        return;
                    }

                    currentNode = currentNode.Next[s[index] - 'a'];
                    currentNodeIndex = 0;
                }
                else
                if (currentNode.Part[currentNodeIndex] == s[index])
                {
                    currentNodeIndex++;
                    index++;
                }
                else
                {
                    currentNode.Split(currentNodeIndex);
                    currentNode.Next[s[index] - 'a'] = new TrieNode()
                    {
                        Count = 1,
                        Part = s.Substring(index)
                    };
                    currentNode.Count++;

                    return;
                }
            }

            if (currentNodeIndex != currentNode.Part.Length)
            {
                currentNode.Split(currentNodeIndex);
            }
            currentNode.Count++;
        }

        public int Get(string s)
        {
            TrieNode currentNode = this.rootNode;

            int index = 0;
            int currentNodeIndex = 0;
            while (index < s.Length && currentNode != null)
            {
                if (currentNodeIndex == currentNode.Part.Length)
                {
                    currentNode = currentNode.Next[s[index] - 'a'];
                    currentNodeIndex = 0;
                }
                else if (currentNode.Part[currentNodeIndex] == s[index])
                {
                    currentNodeIndex++;
                    index++;
                }
                else
                {
                    return 0;
                }
            }

            return currentNode == null ? 0 : currentNode.Count;
        }

        private class TrieNode
        {
            public TrieNode()
            {
                this.Next = new TrieNode[26];
            }

            public TrieNode[] Next { get; set; }

            public string Part { get; set; }

            public int Count { get; set; }

            public void Split(int index)
            {
                TrieNode rightPart = new TrieNode()
                {
                    Part = this.Part.Substring(index),
                    Count = this.Count,
                    Next = this.Next
                };

                this.Next = new TrieNode[26];
                this.Next[this.Part[index] - 'a'] = rightPart;
                this.Part = this.Part.Substring(0, index);
            }
        }
    }
}

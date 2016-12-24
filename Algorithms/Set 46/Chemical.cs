using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_46
{
    class Chemical
    {
        private TrieNode root;

        public Chemical()
        {
            this.root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode currentNode = this.root;

            for (int i = 0; i < word.Length; i++)
            {
                TrieNode next = currentNode.GetNext(word[i]);
                if (next == null)
                {
                    next = new TrieNode()
                    {
                        Length = i + 1,
                        Character = word[i],
                        Parent = currentNode
                    };

                    currentNode.SetNext(word[i], next);
                }

                currentNode = next;
            }

            currentNode.IsWord = true;
        }

        public string Process(string stringToProcess)
        {
            int position = -1;
            int length = -1;
            TrieNode currentNode = this.root;

            for (int i = 0; i < stringToProcess.Length; i++)
            {

                currentNode = currentNode.GetGo(stringToProcess[i]);
                if (currentNode.IsWord && currentNode.Length > length)
                {
                    length = currentNode.Length;
                    position = i - length + 1;
                }
            }

            if (position == -1)
            {
                return stringToProcess;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(stringToProcess.Substring(0, position));
            sb.Append('[');
            sb.Append(stringToProcess.Substring(position, length));
            sb.Append(']');
            sb.Append(stringToProcess.Substring(position + length));

            return sb.ToString();
        }

        #region Trie

        private class TrieNode
        {
            public int Length { get; set; }
            public bool IsWord { get; set; }
            public char Character { get; set; }

            public TrieNode Parent { get; set; }
            public TrieNode SuffixLink { get; set; }
            protected Dictionary<char, TrieNode> Next { get; set; }
            protected Dictionary<char, TrieNode> Go { get; set; }

            public TrieNode()
            {
                this.Next = new Dictionary<char, TrieNode>();
                this.Go = new Dictionary<char, TrieNode>();
            }

            public TrieNode GetNext(char character)
            {
                return (this.Next.ContainsKey(character)) ? this.Next[character] : null;
            }

            public void SetNext(char character, TrieNode next)
            {
                this.Next[character] = next;
            }

            public TrieNode GetSuffixLink()
            {
                if (this.SuffixLink == null)
                {
                    if (this.Length == 0)
                    {
                        this.SuffixLink = this;
                    }
                    else 
                    if (this.Length == 1)
                    {
                        this.SuffixLink = this.Parent;
                    }
                    else
                    {
                        this.SuffixLink = this.Parent.GetSuffixLink().GetGo(Character);
                    }
                }

                return this.SuffixLink;
            }

            public TrieNode GetGo(char character)
            {
                if (!this.Go.ContainsKey(character))
                {
                    if (this.Next.ContainsKey(character))
                    {
                        this.Go[character] = this.Next[character];
                    }
                    else
                    {
                        TrieNode suffixLink = this.GetSuffixLink();
                        if (suffixLink.Length == 0)
                        {
                            this.Go[character] = suffixLink.GetNext(character) ?? suffixLink;
                        }
                        else
                        {
                            this.Go[character] = suffixLink.GetGo(character);
                        }
                    }
                }

                return this.Go[character];
            }
        }
        #endregion
    }
}
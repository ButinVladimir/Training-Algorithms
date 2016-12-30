using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_42
{
    class CountingWords
    {
        private TrieNode rootNode;
        private TrieNode currentNode;
        public Dictionary<int, int> Counts { get; set; }

        public CountingWords()
        {
            this.rootNode = new TrieNode('\0', null, 0);
            this.Counts = new Dictionary<int, int>();
            this.currentNode = this.rootNode;
        }

        public void AddWord(int id, string word)
        {
            TrieNode node = this.rootNode;
            for (int i = 0; i < word.Length; i++)
            {
                node = node.GoNext(word[i]);
            }

            node.AddWord(id);
            this.Counts[id] = 0;
        }

        public void AddCharacter(char character)
        {
            this.currentNode = this.currentNode.GetGo(character);

            TrieNode countingNode = this.currentNode;
            while (countingNode != null)
            {
                foreach (int id in countingNode.Words)
                {
                    this.Counts[id]++;
                }

                countingNode = countingNode.GetWordLink();
            }
        }

        private class TrieNode
        {
            private char character;
            private TrieNode parent;
            private Dictionary<char, TrieNode> next;
            private Dictionary<char, TrieNode> go;
            private TrieNode suffixLink;
            private bool wordLinkProcessed;
            private TrieNode wordLink;
            private int length;
            public List<int> Words { get; set; }

            public TrieNode(char character, TrieNode parent, int length)
            {
                this.character = character;
                this.parent = parent;
                this.next = new Dictionary<char, TrieNode>();
                this.go = new Dictionary<char, TrieNode>();
                this.suffixLink = null;
                this.wordLinkProcessed = false;
                this.wordLink = null;
                this.Words = new List<int>();
                this.length = length;
            }

            public TrieNode GoNext(char character)
            {
                if (this.go.ContainsKey(character))
                {
                    return this.go[character];
                }

                TrieNode newNode = new TrieNode(character, this, this.length + 1);
                this.go[character] = newNode;
                return newNode;
            }

            public void AddWord(int wordId)
            {
                this.Words.Add(wordId);
            }

            public TrieNode GetSuffixLink()
            {
                if (this.suffixLink != null)
                {
                    return this.suffixLink;
                }

                if (this.length == 0)
                {
                    this.suffixLink = this;
                }
                else
                if (this.length == 1)
                {
                    this.suffixLink = this.parent;
                }
                else
                {
                    this.suffixLink = this.parent.GetSuffixLink().GetGo(this.character);
                }

                return this.suffixLink;
            }

            public TrieNode GetGo(char character)
            {
                if (this.go.ContainsKey(character))
                {
                    return this.go[character];
                }

                if (this.next.ContainsKey(character))
                {
                    this.go[character] = this.next[character];
                }
                else
                if (this.length == 0)
                {
                    this.go[character] = this;
                }
                else
                {
                    this.go[character] = this.GetSuffixLink().GetGo(character);
                }

                return this.go[character];
            }

            public TrieNode GetWordLink()
            {
                if (this.wordLinkProcessed)
                {
                    return this.wordLink;
                }

                this.wordLinkProcessed = true;
                this.wordLink = this.GetSuffixLink();

                while (this.wordLink.length > 0 && this.wordLink.Words.Count == 0)
                {
                    this.wordLink = this.wordLink.GetSuffixLink();
                }

                if (this.wordLink.length == 0)
                {
                    this.wordLink = null;
                }

                return this.wordLink;
            }
        }
    }
}

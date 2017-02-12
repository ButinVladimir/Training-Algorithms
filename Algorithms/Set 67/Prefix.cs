using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_67
{
    public class Prefix
    {
        const int MaxLetters = 26;
        private TrieNode rootNode;

        public Prefix()
        {
            this.rootNode = new TrieNode();
        }

        public void Add(string s)
        {
            TrieNode currentNode = this.rootNode;
            for (int i = 0; i < s.Length; i++)
            {
                currentNode = currentNode.Go(s[i]);
            }

            currentNode.Word = true;
        }

        public long Calculate()
        {
            return this.Step(this.rootNode, 0, false);
        }

        private long Step(TrieNode currentNode, long currentSum, bool isSkipped)
        {
            if (currentNode == null)
            {
                return 0;
            }

            if (currentNode.ResultSkipped != null && isSkipped)
            {
                return (long)currentNode.ResultSkipped;
            }

            if (currentNode.ResultNotSkipped != null && !isSkipped)
            {
                return (long)currentNode.ResultNotSkipped;
            }

            long result = 0;

            if (!currentNode.Word)
            {
                for (int i = 0; i < MaxLetters; i++)
                {
                    result += this.Step(currentNode.Next[i], currentSum + 'A' + i, isSkipped);
                }

                if (isSkipped)
                {
                    currentNode.ResultSkipped = result;
                }
                else
                {
                    currentNode.ResultNotSkipped = result;
                }

                return result;
            }

            for (int i = 0; i < MaxLetters; i++)
            {
                result += this.Step(currentNode.Next[i], currentSum + 'A' + i, false);
            }

            if (!isSkipped)
            {
                long skippedResult = currentSum;

                for (int i = 0; i < MaxLetters; i++)
                {
                    result += this.Step(currentNode.Next[i], currentSum + 'A' + i, true);
                }

                result = Math.Max(result, skippedResult);

                currentNode.ResultNotSkipped = result;
            }
            else
            {
                currentNode.ResultSkipped = result;
            }

            return result;
        }

        private class TrieNode
        {
            public TrieNode[] Next { get; private set; }
            public long? ResultSkipped { get; set; }
            public long? ResultNotSkipped { get; set; }
            public bool Word { get; set; }

            public TrieNode()
            {
                this.Next = new TrieNode[MaxLetters];
            }

            public TrieNode Go(char c)
            {
                int letter = c - 'A';

                if (this.Next[letter] == null)
                {
                    this.Next[letter] = new TrieNode();
                }

                return this.Next[letter];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public class TransformWord
    {
        private SortedDictionary<string, int> mappingWordId;
        private SortedDictionary<int, string> mappingIdWord;

        public TransformWord(IEnumerable<string> words)
        {
            this.mappingWordId = new SortedDictionary<string, int>();
            this.mappingIdWord = new SortedDictionary<int, string>();

            int id = 0;

            foreach (string word in words)
            {
                id++;
                this.mappingWordId[word] = id;
                this.mappingIdWord[id] = word;
            }
        }

        public int? Find(string start, string finish)
        {
            if (!this.mappingWordId.ContainsKey(start) || !this.mappingWordId.ContainsKey(finish) || start.Length != finish.Length)
            {
                return null;
            }

            int startId = this.mappingWordId[start];

            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> distance = new Dictionary<int, int>();

            distance[startId] = 0;
            queue.Enqueue(startId);
            StringBuilder sb = new StringBuilder();

            while (queue.Count > 0)
            {
                int currentId = queue.Dequeue();
                string currentWord = this.mappingIdWord[currentId];
                int currentDistance = distance[currentId];

                sb.Clear();
                sb.Append(currentWord);
                for (int position = 0; position < currentWord.Length; position++)
                {
                    for (char letter = 'a'; letter <= 'z'; letter++)
                    {
                        sb[position] = letter;

                        string nextWord = sb.ToString();
                        if (this.mappingWordId.ContainsKey(nextWord))
                        {
                            int nextWordId = this.mappingWordId[nextWord];

                            if (!distance.ContainsKey(nextWordId))
                            {
                                distance[nextWordId] = currentDistance + 1;
                                queue.Enqueue(nextWordId);
                            }
                        }
                    }

                    sb[position] = currentWord[position];
                }
            }

            int finishId = this.mappingWordId[finish];
            if (distance.ContainsKey(finishId))
            {
                return distance[finishId];
            }

            return null;
        }
    }

    [TestClass]
    public class TransformWordTest
    {
        [TestMethod]
        public void Test1()
        {
            TransformWord transform = new TransformWord(new List<string>()
            {
                "cat",
                "dog",
                "cog",
                "cot"
            });

            Assert.AreEqual(3, transform.Find("cat", "dog"));
        }

        [TestMethod]
        public void Test2()
        {
            TransformWord transform = new TransformWord(new List<string>()
            {
                "cat",
                "dog",
                "cog",
                "cot"
            });

            Assert.IsNull(transform.Find("cat", "qqq"));
        }

        [TestMethod]
        public void Test3()
        {
            TransformWord transform = new TransformWord(new List<string>()
            {
                "cat",
                "dog",
                "cog",
                "cot"
            });

            Assert.IsNull(transform.Find("cat", "asds"));
        }

        [TestMethod]
        public void Test4()
        {
            TransformWord transform = new TransformWord(new List<string>()
            {
                "cat",
                "dog",
                "cog",
                "cot",
                "qqq"
            });

            Assert.IsNull(transform.Find("cat", "qqq"));
        }

        [TestMethod]
        public void Test5()
        {
            TransformWord transform = new TransformWord(new List<string>()
            {
                "abc",
                "abd",
                "ace",
                "acd",
                "bce"
            });

            Assert.AreEqual(4, transform.Find("abc", "bce"));
        }
    }
}

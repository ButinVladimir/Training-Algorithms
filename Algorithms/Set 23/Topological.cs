using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_23
{
    public class Topological
    {
        private Dictionary<char, List<char>> ribs;
        private SortedSet<char> chars;

        public Topological()
        {
            this.ribs = new Dictionary<char, List<char>>();
            this.chars = new SortedSet<char>();
        }

        public void AddRib(char before, char after)
        {
            if (!this.ribs.ContainsKey(after))
            {
                this.ribs[after] = new List<char>();
            }

            if (!this.ribs.ContainsKey(before))
            {
                this.ribs[before] = new List<char>();
            }

            this.ribs[after].Add(before);

            chars.Add(before);
            chars.Add(after);
        }

        public string Sort()
        {
            StringBuilder sb = new StringBuilder();
            SortedSet<char> visitedChars = new SortedSet<char>();
            List<char> queue = new List<char>();

            foreach (char startSymbol in this.chars)
            {
                queue.Clear();
                this.Walk(startSymbol, queue, visitedChars);

                foreach (char symbol in queue)
                {
                    sb.Append(symbol);
                }
            }

            return sb.ToString();
        }

        private void Walk(char current, List<char> queue, SortedSet<char> visitedChars)
        {
            if (visitedChars.Contains(current))
            {
                return;
            }

            visitedChars.Add(current);

            foreach (char next in this.ribs[current])
            {
                this.Walk(next, queue, visitedChars);
            }

            queue.Add(current);
        }
    }

    [TestClass]
    public class TopologicalTest
    {
        [TestMethod]
        public void Test1()
        {
            List<Tuple<char, char>> pairs = new List<Tuple<char, char>>()
            {
                new Tuple<char, char>('a', 'b'),
                new Tuple<char, char>('a', 'c'),
                new Tuple<char, char>('c', 'b')
            };

            Topological sort = this.Prepare(pairs);
            Assert.IsTrue(this.Check(sort.Sort(), pairs));
        }

        [TestMethod]
        public void Test2()
        {
            List<Tuple<char, char>> pairs = new List<Tuple<char, char>>()
            {
                new Tuple<char, char>('a', 'A'),
                new Tuple<char, char>('A', 'b'),
                new Tuple<char, char>('b', 'q')
            };

            Topological sort = this.Prepare(pairs);
            Assert.IsTrue(this.Check(sort.Sort(), pairs));
        }

        [TestMethod]
        public void Test3()
        {
            List<Tuple<char, char>> pairs = new List<Tuple<char, char>>()
            {
                new Tuple<char, char>('a', 'A'),
                new Tuple<char, char>('a', 'B'),
                new Tuple<char, char>('a', 'C'),
                new Tuple<char, char>('A', 'd'),
                new Tuple<char, char>('B', 'd'),
                new Tuple<char, char>('C', 'd')
            };

            Topological sort = this.Prepare(pairs);
            Assert.IsTrue(this.Check(sort.Sort(), pairs));
        }

        private Topological Prepare(List<Tuple<char, char>> pairs)
        {
            Topological result = new Topological();

            foreach (var pair in pairs)
            {
                result.AddRib(pair.Item1, pair.Item2);
            }

            return result;
        }

        private bool Check(string s, List<Tuple<char, char>> pairs)
        {
            SortedSet<char> chars = new SortedSet<char>();

            foreach (var pair in pairs)
            {
                bool contains = false;

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[i] == pair.Item1 && s[j] == pair.Item2)
                        {
                            contains = true;
                        }

                        if (s[i] == pair.Item2 && s[j] == pair.Item1)
                        {
                            return false;
                        }
                    }
                }

                if (!contains)
                {
                    return false;
                }

                chars.Add(pair.Item1);
                chars.Add(pair.Item2);
            }

            if (s.Length != chars.Count)
            {
                return false;
            }

            return true;
        }
    }
}

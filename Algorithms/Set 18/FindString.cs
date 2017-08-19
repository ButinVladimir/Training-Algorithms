using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_18
{
    public class FindString
    {
        public char[,] Input { get; set; }
        public string Substring { get; set; }

        private static readonly int[] dx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        private static readonly int[] dy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };

        private Stack<State> stack;
        private SortedSet<Tuple<int, int>> visited;
        private int n;
        private int m;

        public bool Find()
        {
            this.stack = new Stack<State>();
            this.visited = new SortedSet<Tuple<int, int>>();
            this.n = this.Input.GetLength(0);
            this.m = this.Input.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (this.Substring[0] == this.Input[i, j] && this.Find(i, j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Find(int startX, int startY)
        {
            this.stack.Clear();
            this.stack.Push(new State()
            {
                X = startX,
                Y = startY,
                Direction = 0
            });

            this.visited.Clear();
            this.visited.Add(new Tuple<int, int>(startX, startY));

            return this.Process();
        }

        private bool Process()
        {
            while (this.stack.Count > 0)
            {
                if (this.stack.Count == this.Substring.Length)
                {
                    return true;
                }

                State currentState = this.stack.Peek();

                if (currentState.Direction == dx.Length)
                {
                    this.stack.Pop();
                    this.visited.Remove(new Tuple<int, int>(currentState.X, currentState.Y));

                    continue;
                }

                int nx = currentState.X + dx[currentState.Direction];
                int ny = currentState.Y + dy[currentState.Direction];
                currentState.Direction++;
                Tuple<int, int> visitedPair = new Tuple<int, int>(nx, ny);

                if (nx >= 0
                    && nx < this.n
                    && ny >= 0
                    && ny < this.m
                    && !this.visited.Contains(visitedPair)
                    && this.Substring[this.stack.Count] == this.Input[nx, ny])
                {
                    this.visited.Add(visitedPair);

                    State nextState = new State()
                    {
                        X = nx,
                        Y = ny,
                        Direction = 0
                    };

                    stack.Push(nextState);
                }
            }

            return false;
        }

        private class State
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Direction { get; set; }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class FindStringTest
    {
        [TestMethod]
        public void Test1()
        {
            char[,] input = new char[,]
            {
                { 'A', 'C', 'P', 'R', 'C' },
                { 'X', 'S', 'O', 'P', 'C' },
                { 'V', 'O', 'V', 'N', 'I' },
                { 'W', 'G', 'F', 'M', 'N' },
                { 'Q', 'A', 'T', 'I', 'T' },
            };

            string substring = "MICROSOFT";

            FindString fs = new FindString()
            {
                Input = input,
                Substring = substring
            };

            Assert.IsTrue(fs.Find());
        }

        [TestMethod]
        public void Test2()
        {
            char[,] input = new char[,]
            {
                { 'A', 'C', 'P', 'R', 'C' },
                { 'X', 'S', 'O', 'P', 'C' },
                { 'V', 'O', 'V', 'N', 'I' },
                { 'W', 'G', 'F', 'M', 'N' },
                { 'Q', 'A', 'T', 'I', 'T' },
            };

            string substring = "VOGOV";

            FindString fs = new FindString()
            {
                Input = input,
                Substring = substring
            };

            Assert.IsFalse(fs.Find());
        }
    }
}

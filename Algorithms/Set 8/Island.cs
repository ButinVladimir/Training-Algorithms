using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_8
{
    public static class Island
    {
        private const double StepModifier = 0.25;

        public static double Solve(int sx, int sy, int n, int steps)
        {
            Dictionary<State, double> currentStates = new Dictionary<State, double>();
            Dictionary<State, double> nextStates;

            currentStates.Add(new State(sx, sy), 1);

            for (int step = 0; step < steps;step++)
            {
                nextStates = new Dictionary<State, double>();

                foreach (var kv in currentStates)
                {
                    foreach (State nextState in kv.Key)
                    {
                        if (Check(nextState, n))
                        {
                            if (!nextStates.ContainsKey(nextState))
                            {
                                nextStates[nextState] = 0;
                            }

                            nextStates[nextState] += kv.Value * StepModifier;
                        }
                    }
                }

                currentStates = nextStates;
            }

            double result = 0;
            foreach (var kv in currentStates)
            {
                result += kv.Value;
            }

            return result;
        }

        private static bool Check(State state, int n)
        {
            return state.X >= 0 && state.Y >= 0 && state.X < n && state.Y < n;
        }

        private class State : IComparable<State>
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            private static readonly int[] Dx = { -1, 1, 0, 0 };
            private static readonly int[] Dy = { 0, 0, -1, 1 };

            public State(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public System.Collections.Generic.IEnumerator<State> GetEnumerator()
            {
                for (int i = 0; i < Dx.Length; i++)
                {
                    yield return new State(this.X + Dx[i], this.Y + Dy[i]);
                }
            }

            int IComparable<State>.CompareTo(State other)
            {
                int result = this.X.CompareTo(other.X);
                if (result == 0)
                {
                    result = this.Y.CompareTo(other.Y);
                }

                return result;
            }
        }
    }

    [TestClass]
    public class IslandTest
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(0.5, Island.Solve(0, 0, 2, 1));
            Assert.AreEqual(0.25, Island.Solve(0, 0, 2, 2));
        }
    }
}

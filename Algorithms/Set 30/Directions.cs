using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_30
{
    public class Directions
    {
        private List<int>[] ribs;

        private int n;

        public Directions(int n)
        {
            this.n = n;
            this.ribs = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                this.ribs[i] = new List<int>();
            }
        }

        public void AddRib(int a, int b)
        {
            this.ribs[a].Add(b);

            if (b != a)
            {
                this.ribs[b].Add(a);
            }
        }

        public List<Tuple<int, int>> Solve(int startVertex)
        {
            Queue<int> queue = new Queue<int>();
            State[] states = new State[this.n];

            for (int i = 0; i < this.n; i++)
            {
                states[i] = State.NotTouched;
            }

            states[startVertex] = State.Touched;

            queue.Enqueue(startVertex);

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                foreach (int nextVertex in this.ribs[currentVertex])
                {
                    if (states[nextVertex] == State.Processed)
                    {
                        continue;
                    }

                    if (states[nextVertex] == State.NotTouched)
                    {
                        states[currentVertex] = State.Touched;
                        queue.Enqueue(nextVertex);
                    }

                    result.Add(new Tuple<int, int>(nextVertex, currentVertex));
                }

                states[currentVertex] = State.Processed;
            }

            return result;
        }

        private enum State
        {
            NotTouched,
            Touched,
            Processed
        }
    }
}

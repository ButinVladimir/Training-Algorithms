using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_19
{
    public class MinimizeTime
    {
        public int[] Marks { get; set; }
        public int[] Times { get; set; }
        public int P { get; set; }

        private State[,] states;

        public List<int> Solve()
        {
            int n = this.Marks.Length;
            this.states = new State[n + 1, this.P + 1];

            for (int i = 0; i < n; i++)
            {
                this.states[i, Math.Min(this.P, this.Marks[i])] = new State()
                {
                    PrevState = 0,
                    PrevMark = -1,
                    Time = this.Times[i]
                };
            }

            for (int lastSum = 0; lastSum < this.P; lastSum++)
            {
                for (int lastMark = 0; lastMark < n; lastMark++)
                {
                    if (this.states[lastMark, lastSum] == null)
                    {
                        continue;
                    }

                    for (int nextMark = lastMark + 1; nextMark < n; nextMark++)
                    {
                        int nextSum = Math.Min(lastSum + this.Marks[nextMark], this.P);
                        int nextTime = this.states[lastMark, lastSum].Time + this.Times[nextMark];

                        if (this.states[nextMark, nextSum] == null)
                        {
                            this.states[nextMark, nextSum] = new State()
                            {
                                PrevState = lastSum,
                                PrevMark = lastMark,
                                Time = nextTime
                            };
                        }
                        else if (this.states[nextMark, nextSum].Time > nextTime)
                        {
                            this.states[nextMark, nextSum].Time = nextTime;
                            this.states[nextMark, nextSum].PrevState = lastSum;
                            this.states[nextMark, nextSum].PrevMark = lastMark;
                        }
                    }
                }
            }

            int mark = -1;
            int state = this.P;
            for (int i = 0; i < n; i++)
            {
                if (this.states[i, this.P] != null && (mark == -1 || this.states[i, this.P].Time < this.states[mark, this.P].Time))
                {
                    mark = i;
                }
            }

            List<int> result = new List<int>();

            while (state > 0)
            {
                result.Add(mark);
                State s = this.states[mark, state];

                mark = s.PrevMark;
                state = s.PrevState;
            }

            return result;
        }

        private class State
        {
            public int PrevState { get; set; }
            public int PrevMark { get; set; }
            public int Time { get; set; }
        }
    }
}

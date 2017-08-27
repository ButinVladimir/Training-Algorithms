using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_19
{
    public class InterestingPermutation
    {
        public int N { get; set; }
        public int K { get; set; }
        public int F { get; set; }

        private List<string> result;
        private int[] buffer;
        private bool[] inUse;

        public List<string> Solve()
        {
            this.result = new List<string>();
            this.buffer = new int[this.N];
            this.inUse = new bool[this.N];

            this.Step(0, 0);

            return this.result;
        }

        private void Step(int pos, int sum)
        {
            if (pos == N)
            {
                this.result.Add(string.Join(",", this.buffer));

                return;
            }

            for (int i = 1; i <= N; i++)
            {
                if (this.inUse[i - 1])
                {
                    continue;
                }

                if (pos >= this.K - 1 && (sum + i) % this.F == 0)
                {
                    continue;
                }

                this.buffer[pos] = i;
                this.inUse[i - 1] = true;

                int nextSum = (sum + i) % this.F;
                if (pos >= this.K - 1)
                {
                    nextSum = (nextSum - this.buffer[pos - K + 1] + this.F) % this.F;
                }
                this.Step(pos + 1, nextSum);


                this.inUse[i - 1] = false;
            }
        }
    }
}

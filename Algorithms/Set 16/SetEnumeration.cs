using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_16
{
    public class SetEnumeration
    {
        public int N { get; set; }
        public int K { get; set; }
        private LinkedList<int>[] buffer;
        private List<string> result;
        private bool[] visited;

        public List<string> Solve()
        {
            this.buffer = new LinkedList<int>[this.K];
            this.result = new List<string>();
            this.visited = new bool[this.N];

            for (int i = 0; i < this.K; i++)
            {
                this.buffer[i] = new LinkedList<int>();
            }
            this.Step(0, 0, true, this.N);

            return this.result;
        }

        private void Step(int n, int k, bool first, int left)
        {
            if (k == this.K)
            {
                if (left > 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var group in this.buffer)
                {
                    sb
                        .Append('[')
                        .Append(string.Join(",", group))
                        .Append(']');
                }

                this.result.Add(sb.ToString());

                return;
            }

            if (k != this.K - 1 && left == 0)
            {
                return;
            }

            if (n < this.N && this.visited[n])
            {
                this.Step(n + 1, k, first, left);

                return;
            }

            if (n >= this.N)
            {
                return;
            }

            this.buffer[k].AddLast(n + 1);
            this.visited[n] = true;

            this.Step(0, k + 1, true, left - 1);
            this.Step(n + 1, k, false, left - 1);

            this.buffer[k].RemoveLast();
            this.visited[n] = false;

            if (!first)
            {
                this.Step(n + 1, k, false, left);
            }
        }
    }
}


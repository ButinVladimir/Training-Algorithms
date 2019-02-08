using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public class PermutationUnique
    {
        private const int M = 256;

        private int[] count = new int[M];
        private List<string> result;
        private int n;
        private char[] buffer;

        public List<string> Solve(string s)
        {
            this.n = s.Length;
            this.buffer = new char[this.n];
            this.result = new List<string>();

            for (int i = 0; i < M; i++)
            {
                this.count[i] = 0;
            }

            foreach (char c in s)
            {
                this.count[c]++;
            }

            this.Step(0);

            return this.result;
        }

        private void Step(int position)
        {
            if (position == this.n)
            {
                this.result.Add(string.Join("", this.buffer));

                return;
            }

            for (int i = 0; i < M; i++)
            {
                if (this.count[i] > 0)
                {
                    this.buffer[position] = (char)i;
                    this.count[i]--;

                    this.Step(position + 1);

                    this.count[i]++;
                }
            }
        }
    }
}

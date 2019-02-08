using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public class PermutationUniqueDictionary
    {
        private List<string> result;
        private Dictionary<char, int> count = new Dictionary<char, int>();
        private List<char> countKeys;
        private int n;
        private char[] buffer;

        public List<string> Solve(string s)
        {
            this.n = s.Length;
            this.buffer = new char[this.n];
            this.result = new List<string>();
            this.count.Clear();

            foreach (char c in s)
            {
                int v;
                if (!this.count.TryGetValue(c, out v))
                {
                    v = 0;
                }

                this.count[c] = v + 1;
            }
            this.countKeys = this.count.Keys.ToList();

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

            foreach (char c in this.countKeys)
            {
                if (this.count[c] > 0)
                {
                    this.buffer[position] = c;
                    this.count[c]--;

                    this.Step(position + 1);

                    this.count[c]++;
                }
            }
        }
    }
}

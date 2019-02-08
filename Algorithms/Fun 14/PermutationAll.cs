using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public class PermutationAll
    {
        private List<string> result;
        private int n;
        private bool[] visited;
        private char[] buffer;
        private string s;

        public List<string> Solve(string s)
        {
            this.n = s.Length;
            this.visited = new bool[this.n];
            this.buffer = new char[this.n];
            this.s = s;
            this.result = new List<string>();

            this.Step(0);

            return result;
        }

        private void Step(int position)
        {
            if (position == this.n)
            {
                this.result.Add(string.Join("", buffer));

                return; 
            }

            for (int i = 0; i < this.n; i++)
            {
                if (!this.visited[i])
                {
                    this.visited[i] = true;
                    this.buffer[position] = s[i];

                    this.Step(position + 1);

                    this.visited[i] = false;
                }
            }
        }
    }
}

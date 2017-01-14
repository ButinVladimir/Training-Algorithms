using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_58
{
    class Amounts
    {
        private List<int> result;
        private SortedSet<Tuple<int, int>> visitedSteps;
        private int n;

        public int[] Values { get; set; }
        public int[] Counts { get; set; }

        public List<int> Solve()
        {
            this.n = Values.Length;
            if (Counts.Length != this.n)
            {
                throw new ArgumentException("Values and Counts must have same length");
            }

            for (int i = 0; i < n; i++)
            {
                if (Counts[i] <= 0)
                {
                    throw new ArgumentException("All numbers in Counts must be positive");
                }
            }

            this.result = new List<int>();
            this.visitedSteps = new SortedSet<Tuple<int, int>>();

            Step(0, 0);

            return result;
        }

        private void Step(int position, int amount)
        {
            Tuple<int, int> key = new Tuple<int, int>(position, amount);

            if (this.visitedSteps.Contains(key))
            {
                return;
            }

            visitedSteps.Add(key);

            if (position == this.n)
            {
                this.result.Add(amount);
                return;
            }

            for (int i = 0; i <= Counts[position]; i++)
            {
                Step(position + 1, amount + i * Values[position]);
            }
        }
    }
}

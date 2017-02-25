using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_35
{
    public class Restore
    {
        private bool[] visited;
        private int[] result;

        public int[] PairwiseSum { get; set; }
        public int N { get; set; }

        public int[] Solve()
        {
            Array.Sort(this.PairwiseSum);

            this.visited = new bool[this.PairwiseSum.Length];
            this.result = new int[this.N];

            for (int i = 2; i < this.N + 2 && i < this.PairwiseSum.Length; i++)
            {
                if (this.Try23(i))
                {
                    return this.result.ToArray();
                }
            }

            return null;
        }

        private bool Try23(int p23)
        {
            for (int j = 0; j < this.N; j++)
            {
                this.visited[j] = false;
            }

            this.visited[0] = true;
            this.visited[1] = true;
            this.visited[p23] = true;

            // x12 is in position 0
            // x13 is in position 1
            // x23 is in position p23

            result[0] = (this.PairwiseSum[0] + this.PairwiseSum[1] - this.PairwiseSum[p23]) / 2;
            result[1] = this.PairwiseSum[0] - result[0];
            result[2] = this.PairwiseSum[1] - result[0];

            int currentPosition = 0;
            for (int currentNumber = 3; currentNumber < this.N; currentNumber++)
            {
                while (this.visited[currentPosition])
                {
                    currentPosition++;
                }

                result[currentNumber] = this.PairwiseSum[currentPosition] - result[0];

                List<int> affectedNumbersList = new List<int>();
                for (int i = 0; i < currentNumber; i++)
                {
                    affectedNumbersList.Add(result[currentNumber] + result[i]);
                }

                int[] affectedNumbersArray = affectedNumbersList.ToArray();

                int j = 0;
                for (int i = currentPosition; i < PairwiseSum.Length && j < currentNumber; i++)
                {
                    if (this.visited[i] || this.PairwiseSum[i] != result[j] + result[currentNumber])
                    {
                        continue;
                    }

                    this.visited[i] = true;
                    j++;
                }

                if (j != currentNumber)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

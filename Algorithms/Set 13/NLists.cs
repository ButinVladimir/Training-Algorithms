using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_13
{
    public class NLists
    {
        public int N { get; set; }
        private Stack<int> currentNumbers;
        private int left;
        private List<List<int>> result;

        public List<List<int>> Solve()
        {
            this.currentNumbers = new Stack<int>();
            this.left = this.N;
            this.result = new List<List<int>>();

            this.Step(1);

            return this.result;
        }

        private void Step(int min)
        {
            if (this.left == 0)
            {
                List<int> addToResult = new List<int>();
                foreach (int v in this.currentNumbers)
                {
                    addToResult.Add(v);
                }
                addToResult.Reverse();

                this.result.Add(addToResult);
                return;
            }

            for (int i=min;i<=this.left && i < this.N;i++)
            {
                this.currentNumbers.Push(i);
                this.left -= i;

                this.Step(i);

                this.currentNumbers.Pop();
                this.left += i;
            }
        }
    }
}

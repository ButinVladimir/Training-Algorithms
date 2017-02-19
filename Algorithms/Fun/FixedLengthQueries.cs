using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class FixedLengthQueries
    {
        private int[] result;

        public int[] Numbers { get; set; }

        public void Prepare()
        {
            int n = this.Numbers.Length;

            int[] left = new int[n];
            for (int i = 0; i < n; i++)
            {
                left[i] = i - 1;

                while (left[i] >= 0 && this.Numbers[left[i]] <= this.Numbers[i])
                {
                    left[i] = left[left[i]];
                }
            }

            int[] right = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                right[i] = i + 1;

                while (right[i] < n && this.Numbers[right[i]] <= this.Numbers[i])
                {
                    right[i] = right[right[i]];
                }
            }

            this.result = new int[n];

            for (int i = 0; i < n; i++)
            {
                this.result[i] = int.MaxValue;
            }

            int d;

            for (int i = 0; i < n; i++)
            {
                d = right[i] - left[i] - 2;
                this.result[d] = Math.Min(this.result[d], this.Numbers[i]);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                this.result[i] = Math.Min(this.result[i], this.result[i + 1]);
            }
        }

        public int Answer(int d)
        {
            return this.result[d - 1];
        }
    }
}

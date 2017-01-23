using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_52
{
    class PickASet
    {
        public static List<int> Solve(int[] a)
        {
            int n = a.Length;
            int[] pred = new int[n];
            int[] length = new int[n];

            for (int i = 0; i < n; i++)
            {
                pred[i] = -1;
                length[i] = 1;
            }

            int resultFinish = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Math.Abs(i - j) >= Math.Abs(a[i] - a[j]) && length[j] + 1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        pred[i] = j;
                    }
                }

                if (length[i] > length[resultFinish])
                {
                    resultFinish = i;
                }
            }

            int position = resultFinish;
            List<int> result = new List<int>();
            while (position != -1)
            {
                result.Add(position);
                position = pred[position];
            }

            result.Reverse();

            return result;
        }
    }

    class PickASetBrute
    {
        private List<int> result;

        private LinkedList<int> buffer;

        public int[] A { get; set; }

        public List<int> Solve()
        {
            this.result = new List<int>();
            this.buffer = new LinkedList<int>();

            this.Step(0);

            return this.result;
        }

        private void Step(int position)
        {
            if (position == this.A.Length)
            {
                if (this.buffer.Count() > this.result.Count())
                {
                    this.result.Clear();
                    foreach (int selectedPosition in this.buffer)
                    {
                        this.result.Add(selectedPosition);
                    }
                }

                return;
            }

            this.Step(position + 1);

            bool can = true;
            foreach (int selectedPosition in this.buffer)
            {
                if (Math.Abs(this.A[position] - this.A[selectedPosition]) > Math.Abs(position - selectedPosition))
                {
                    can = false;
                    break;
                }
            }

            if (can)
            {
                this.buffer.AddLast(position);
                this.Step(position + 1);
                this.buffer.RemoveLast();
            }
        }
    }

    class TestSetGenerator
    {
        private static Random random;

        static TestSetGenerator()
        {
            random = new Random();
        }

        public static int[] Generate(int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength);

            int[] a = new int[length];
            for (int i = 0; i < length; i++)
            {
                a[i] = random.Next();
            }

            return a;
        }
    }
}

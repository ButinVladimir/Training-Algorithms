using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_26
{
    public class Sum
    {
        public int[] X { get; set; }
        public int[] Y { get; set; }
        public int[] A { get; private set; }
        public int Result { get; private set; }

        public void Solve()
        {
            int n = this.X.Length;
            int[] x = new int[n];
            int[] y = new int[n];
            this.A = new int[n];

            Comparer comparerX = new Comparer() { A = this.X };
            Comparer comparerY = new Comparer() { A = this.Y };

            for (int i = 0; i < n; i++)
            {
                x[i] = i;
                y[i] = i;
            }
            Array.Sort(x, comparerX);
            Array.Sort(y, comparerY);
            Array.Reverse(y);

            this.Result = 0;
            for (int i = 0; i < n; i++)
            {
                this.A[x[i]] = y[i];
            }

            for (int i = 0; i < n; i++)
            {
                this.Result += this.X[i] * this.Y[this.A[i]];
            }
        }

        public void SolveBruteForce()
        {
            int n = this.X.Length;
            bool[] selected = new bool[n];
            int[] permutation = new int[n];
            this.A = new int[n];

            this.Result = 0;

            for (int i = 0; i < n; i++)
            {
                this.Result += this.X[i] * this.Y[i];
                this.A[i] = i;
            }

            this.SolveBruteForce(0, selected, permutation);
        }

        private void SolveBruteForce(int position, bool[] selected, int[] permutation)
        {
            if (position == this.X.Length)
            {
                int result = 0;

                for (int i = 0; i < this.X.Length; i++)
                {
                    result += this.X[i] * this.Y[permutation[i]];
                }

                if (result < this.Result)
                {
                    this.Result = result;

                    for (int i = 0; i < this.X.Length; i++)
                    {
                        this.A[i] = permutation[i];
                    }
                }

                return;
            }

            for (int i = 0; i < this.X.Length; i++)
            {
                if (selected[i] != true)
                {
                    selected[i] = true;
                    permutation[position] = i;
                    this.SolveBruteForce(position + 1, selected, permutation);
                    selected[i] = false;
                }
            }
        }

        private class Comparer : IComparer<int>
        {
            public int[] A { get; set; }
            int IComparer<int>.Compare(int x, int y)
            {
                return A[x].CompareTo(A[y]);
            }
        }
    }
}

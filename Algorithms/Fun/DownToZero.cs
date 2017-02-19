using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    public class DownToZero
    {
        private const int MaxL = 1000001;

        public int[] Result { get; private set; }

        public void Prepare()
        {
            this.Result = new int[MaxL];
            for (int i = 0; i < MaxL; i++)
            {
                this.Result[i] = i;
            }

            for (int i = 0; i < MaxL - 1; i++)
            {
                this.Result[i + 1] = Math.Min(this.Result[i] + 1, this.Result[i + 1]);

                for (int j = 2; j <= i && i * j < MaxL; j++)
                {
                    this.Result[i * j] = Math.Min(this.Result[i * j], this.Result[i] + 1);
                }
            }
        }

        public int Answer(int n)
        {
            return this.Result[n];
        }
    }
}

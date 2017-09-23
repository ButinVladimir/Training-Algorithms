using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public class MagicSquare
    {
        public int[,] InputSquare { get; set; }

        private int[,] square;
        private bool[] appearances;
        int result = 100000000;

        public int Solve()
        {
            this.appearances = new bool[9];
            this.square = new int[3, 3];
            int sum;

            for (this.square[0, 0] = 1; this.square[0, 0] <= 9; this.square[0, 0]++)
            {
                for (this.square[0, 1] = 1; this.square[0, 1] <= 9; this.square[0, 1]++)
                {
                    for (this.square[0, 2] = 1; this.square[0, 2] <= 9; this.square[0, 2]++)
                    {
                        for (this.square[1, 1] = 1; this.square[1, 1] <= 9; this.square[1, 1]++)
                        {
                            sum = this.square[0, 0] + this.square[0, 1] + this.square[0, 2];
                            this.square[2, 2] = sum - this.square[1, 1] - this.square[0, 0];
                            this.square[1, 2] = sum - this.square[2, 2] - this.square[0, 2];
                            this.square[2, 1] = sum - this.square[1, 1] - this.square[0, 1];
                            this.square[2, 0] = sum - this.square[2, 1] - this.square[2, 2];
                            this.square[1, 0] = sum - this.square[1, 1] - this.square[1, 2];

                            if (this.Check())
                            {
                                this.Update();
                            }
                        }
                    }
                }
            }

            return this.result;
        }

        private bool Check()
        {
            for (int i = 0; i < 9; i++)
            {
                appearances[i] = false;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.square[i, j] <= 0 || this.square[i, j] > 9)
                    {
                        return false;
                    }

                    if (this.appearances[this.square[i, j] - 1])
                    {
                        return false;
                    }

                    this.appearances[this.square[i, j] - 1] = true;
                }
            }

            int sum = this.square[0, 0] + this.square[0, 1] + this.square[0, 2];
            for (int i = 0; i < 3; i++)
            {
                if (sum != this.square[i, 0] + this.square[i, 1] + this.square[i, 2])
                {
                    return false;
                }
                if (sum != this.square[0, i] + this.square[1, i] + this.square[2, i])
                {
                    return false;
                }
            }

            if (sum != this.square[0,0] + this.square[1,1] + this.square[2,2])
            {
                return false;
            }

            if (sum != this.square[2, 0] + this.square[1, 1] + this.square[0, 2])
            {
                return false;
            }

            return true;
        }

        private void Update()
        {
            int diff = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    diff += Math.Abs(this.square[i, j] - this.InputSquare[i, j]);
                }
            }

            result = Math.Min(result, diff);
        }
    }
}

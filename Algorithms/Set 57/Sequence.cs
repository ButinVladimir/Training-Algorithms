using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_57
{
    class Sequence
    {
        private const int Size = 2;

        private static long[,] sampleMatrix;
        private long[,] currentMatrix;
        private long[,] nextMatrix;

        public long M { get; set; }
        public long K { get; set; }
        public long X0 { get; set; }
        public long Y0 { get; set; }

        static Sequence()
        {
            sampleMatrix = new long[Size, Size]
            {
                { 1, 1 },
                { 1, 0 }
            };
        }

        public Tuple<long, long> Solve()
        {
            this.nextMatrix = new long[Size, Size];

            this.Step(K);

            return new Tuple<long, long>(
                    (this.currentMatrix[0, 0] * X0 % M + this.currentMatrix[0, 1] * Y0 % M) % M,
                    (this.currentMatrix[1, 0] * X0 % M + this.currentMatrix[1, 1] * Y0 % M) % M
                );
        }

        private void Step(long k)
        {
            if (k == 0)
            {
                this.currentMatrix = new long[2, 2] {
                    { 1, 0 },
                    { 0, 1 }
                };

                return;
            }

            Step(k / 2);

            MultiplyMatrix(this.currentMatrix, this.currentMatrix);
            CopyMatrix(this.nextMatrix, this.currentMatrix);

            if (k % 2 == 1)
            {
                MultiplyMatrix(this.currentMatrix, sampleMatrix);
                CopyMatrix(this.nextMatrix, this.currentMatrix);
            }
        }

        private void ClearMatrix(long[,] matrix)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        private void MultiplyMatrix(long[,] leftMatrix, long[,] rightMatrix)
        {
            this.ClearMatrix(this.nextMatrix);

            for (int k = 0; k < Size; k++)
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        this.nextMatrix[i, j] = (this.nextMatrix[i, j] + leftMatrix[i, k] * rightMatrix[k, j] % M) % M;
                    }
                }
            }
        }

        private void CopyMatrix(long[,] srcMatrix, long[,] destMatrix)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    destMatrix[i, j] = srcMatrix[i, j];
                }
            }
        }
    }
}

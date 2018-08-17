using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public class GridSearch
    {
        private HashComputers[] hashComputers;

        public GridSearch()
        {
            this.hashComputers = new HashComputers[]
            {
                new HashComputers(1000000007, 11),
                new HashComputers(1000000007, 13)
            };
        }

        public bool Search(string[] pattern, string[] grid)
        {
            int[,] patternConverted = ConvertToIntMatrix(pattern);
            int[,] gridConverted = ConvertToIntMatrix(grid);

            long[][,] patternHash = new long[this.hashComputers.Length][,];
            long[][,] gridHash = new long[this.hashComputers.Length][,];

            int patternRows = pattern.Length;
            int patternColumns = pattern[0].Length;

            for (int k = 0; k < this.hashComputers.Length; k++)
            {
                patternHash[k] = this.hashComputers[k].ComputeHash(patternConverted, patternColumns);
                gridHash[k] = this.hashComputers[k].ComputeHash(gridConverted, patternColumns);
            }

            int gridRows = grid.Length;
            int gridColumns = grid[0].Length;
            bool same;

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridColumns; j++)
                {
                    same = true;
                    for (int k = 0; k < this.hashComputers.Length && same; k++)
                    {
                        same = same && this.hashComputers[k].Compare(patternHash[k], gridHash[k], i, j, patternRows, patternColumns);
                    }

                    if (same)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int[,] ConvertToIntMatrix(string[] matrix)
        {
            int[,] matrixConverted = new int[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrixConverted[i, j] = (int)matrix[i][j] - '0';
                }
            }

            return matrixConverted;
        }

        private class HashComputers
        {
            private const int powersLength = 1000001;

            private long mod;
            private long p;
            private long[] powers;

            public HashComputers(long mod, long p)
            {
                this.mod = mod;
                this.p = p;
                this.powers = new long[powersLength];
                this.powers[0] = 1;

                for (int i = 1; i < powersLength; i++)
                {
                    this.powers[i] = (this.powers[i - 1] * this.p) % this.mod;
                }
            }

            public long[,] ComputeHash(int[,] matrix, int patternColumns)
            {
                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);
                long[,] hash = new long[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        hash[i, j] = this.powers[i * patternColumns + j] * matrix[i, j] % this.mod;

                        if (i > 0)
                        {
                            hash[i, j] = (hash[i, j] + hash[i - 1, j]) % this.mod;
                        }
                        if (j > 0)
                        {
                            hash[i, j] = (hash[i, j] + hash[i, j - 1]) % this.mod;
                        }
                        if (i > 0 && j > 0)
                        {
                            hash[i, j] = (hash[i, j] + this.mod - hash[i - 1, j - 1]) % this.mod;
                        }
                    }
                }

                return hash;
            }

            public bool Compare(long[,] patternHash, long[,] gridHash, int startRow, int startColumn, int patternRows, int patternColumns)
            {
                int lastRow = startRow + patternRows - 1;
                int lastColumn = startColumn + patternColumns - 1;
                if (lastRow >= gridHash.GetLength(0) || lastColumn >= gridHash.GetLength(1))
                {
                    return false;
                }

                long patternHashValue = patternHash[patternRows - 1, patternColumns - 1] * this.powers[startRow * patternColumns + startColumn] % this.mod;

                long gridHashValue = gridHash[lastRow, lastColumn];
                if (startRow > 0)
                {
                    gridHashValue = (gridHashValue + this.mod - gridHash[startRow - 1, lastColumn]) % this.mod;
                }
                if (startColumn > 0)
                {
                    gridHashValue = (gridHashValue + this.mod - gridHash[lastRow, startColumn - 1]) % this.mod;
                }
                if (startRow > 0 && startColumn > 0)
                {
                    gridHashValue = (gridHashValue + gridHash[startRow - 1, startColumn - 1]) % this.mod;
                }

                return patternHashValue == gridHashValue;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public class CrosswordPuzzle
    {
        int m, n;
        private char[,] field;
        private string[] words;
        private bool[] wordsUsed;
        private int[,] taken;
        private List<Tuple<int, int>> positions;

        public CrosswordPuzzle(string[] field, string[] words)
        {
            this.m = field.Length;
            this.n = field[0].Length;

            this.field = new char[m, n];
            for (int i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    this.field[i, j] = field[i][j];
                }
            }

            this.words = words;
            this.wordsUsed = new bool[this.words.Length];
            this.taken = new int[m, n];
        }

        public char[,] Solve()
        {
            this.Step(0);

            return this.field;
        }

        public bool Step(int wordIndex)
        {
            if (wordIndex == this.words.Length)
            {
                return true;
            }

            int left, right;
            bool isFit = false;
            for (int i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    if (!IsBorder(this.field[i, j]) && (i == 0 || j == 0 || IsBorder(this.field[i - 1, j]) || IsBorder(this.field[i, j - 1])))
                    {
                        for (left = i; left > 0 && !IsBorder(this.field[left - 1, j]); left--) ;
                        for (right = i; right < this.m - 1 && !IsBorder(this.field[right + 1, j]); right++) ;

                        if (right - left + 1 == this.words[wordIndex].Length)
                        {
                            isFit = true;
                            for (int k = left; k <= right; k++)
                            {
                                if (this.field[k, j] != '-' && this.field[k, j] != this.words[wordIndex][k - left])
                                {
                                    isFit = false;
                                }
                            }

                            if (isFit)
                            {
                                for (int k = left; k <= right; k++)
                                {
                                    this.field[k, j] = this.words[wordIndex][k - left];
                                    this.taken[k, j]++;
                                }

                                if (this.Step(wordIndex + 1))
                                {
                                    return true;
                                }

                                for (int k = left; k <= right; k++)
                                {
                                    this.taken[k, j]--;
                                    if (this.taken[k, j] == 0)
                                    {
                                        this.field[k, j] = '-';
                                    }
                                }
                            }
                        }

                        for (left = j; left > 0 && !IsBorder(this.field[i, left - 1]); left--) ;
                        for (right = j; right < this.n - 1 && !IsBorder(this.field[i, right + 1]); right++) ;

                        if (right - left + 1 == this.words[wordIndex].Length)
                        {
                            isFit = true;
                            for (int k = left; k <= right; k++)
                            {
                                if (this.field[i, k] != '-' && this.field[i, k] != this.words[wordIndex][k - left])
                                {
                                    isFit = false;
                                }
                            }

                            if (isFit)
                            {
                                for (int k = left; k <= right; k++)
                                {
                                    this.field[i, k] = this.words[wordIndex][k - left];
                                    this.taken[i, k]++;
                                }

                                if (this.Step(wordIndex + 1))
                                {
                                    return true;
                                }

                                for (int k = left; k <= right; k++)
                                {
                                    this.taken[i, k]--;
                                    if (this.taken[i, k] == 0)
                                    {
                                        this.field[i, k] = '-';
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static bool IsBorder(char c)
        {
            return c == '+' || c == 'X';
        }
    }
}

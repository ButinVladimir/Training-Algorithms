using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public class BearSteadyGene
    {
        private string input;
        private int n;
        private int properCount;
        private int[] cnt = new int[4];
        private int[,] prefix, suffix;

        public BearSteadyGene(string input)
        {
            this.input = input;
            this.n = this.input.Length;
            this.properCount = this.n / 4;

            this.prefix = new int[4, this.n];
            for (int i = 0; i < this.n; i++)
            {
                if (i > 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        this.prefix[j, i] = this.prefix[j, i - 1];
                    }
                }
                this.prefix[MapCharToInt(this.input[i]), i]++;
            }

            this.suffix = new int[4, this.n];
            for (int i = this.n - 1; i >= 0; i--)
            {
                if (i < this.n - 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        this.suffix[j, i] = this.suffix[j, i + 1];
                    }
                }
                this.suffix[MapCharToInt(this.input[i]), i]++;
            }
        }

        public int Solve()
        {
            int result = -1;
            int buffer;

            bool valid = true;
            for (int i = 0; i < 4; i++)
            {
                if (this.suffix[i, 0] != this.properCount)
                {
                    valid = false;
                }
            }

            if (valid)
            {
                return 0;
            }

            for (int start = 0; start < this.n; start++)
            {
                buffer = this.Find(start);
                if (buffer != -1 && (result == -1 || result > buffer))
                {
                    result = buffer;
                }
            }

            return result;
        }

        private int Find(int start)
        {
            if (!this.Can(start, this.n))
            {
                return -1;
            }

            int step = this.n - start;
            int nextEnd;
            int end = start;
            while (step > 0)
            {
                nextEnd = end + step;
                if (nextEnd > this.n)
                {
                    step /= 2;
                }
                else if (!this.Can(start, nextEnd))
                {
                    end = nextEnd;
                }
                else
                {
                    step /= 2;
                }
            }

            return end - start + 1;
        }

        private bool Can(int start, int end)
        {
            for (int i = 0; i < 4; i++)
            {
                this.cnt[i] = 0;
            }

            if (start > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    this.cnt[i] += this.prefix[i, start - 1];
                }
            }

            if (end < this.n)
            {
                for (int i = 0; i < 4; i++)
                {
                    this.cnt[i] += this.suffix[i, end];
                }
            }

            int left = 0;
            for (int i = 0; i < 4; i++)
            {
                if (this.cnt[i] > this.properCount)
                {
                    return false;
                }

                left += this.properCount - this.cnt[i];
            }

            return left <= (end - start);
        }

        private static int MapCharToInt(char c)
        {
            switch (c)
            {
                case 'C':
                    return 0;
                case 'G':
                    return 1;
                case 'A':
                    return 2;
                case 'T':
                    return 3;
            }

            return -1;
        }
    }
}

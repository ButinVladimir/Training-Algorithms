using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

//using Algorithms.Fun;

class Solution
{
    private class Tokenizer
    {
        private string currentString = null;

        private string[] tokens = null;

        private int tokenNumber = 0;

        private static readonly char[] Separators = { ' ' };

        public T NextToken<T>(Func<string, T> parser)
        {
            return parser(this.GetNextToken());
        }

        public string NextToken()
        {
            return this.GetNextToken();
        }

        public int NextInt()
        {
            return this.NextToken(int.Parse);
        }

        public long NextLong()
        {
            return this.NextToken(long.Parse);
        }

        private string GetNextToken()
        {
            if (this.currentString == null || this.tokenNumber == this.tokens.Length)
            {
                this.currentString = this.GetNextString();

                while (this.currentString != null && this.currentString.Equals(string.Empty))
                {
                    this.currentString = this.GetNextString();
                }

                if (this.currentString == null)
                {
                    throw new Exception("End of input");
                }

                this.tokens = this.currentString.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                this.tokenNumber = 0;
            }

            return this.tokens[this.tokenNumber++];
        }

        private string GetNextString()
        {
            string content = Console.ReadLine();
            if (content == null)
            {
                return null;
            }

            return content.Trim();
        }
    }

    static void Main()
    {
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        int q = tokenizer.NextInt();

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
        }

        FixedLengthQueries flq = new FixedLengthQueries() { Numbers = a };
        flq.Prepare();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(flq.Answer(tokenizer.NextInt()));
        }

        //writer.Close();
    }

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
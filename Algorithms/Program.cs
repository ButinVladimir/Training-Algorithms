using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

//using Algorithms.Set_66;

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
        long[] amount = new long[n];

        for (int i = 0; i < n; i++)
        {
            amount[i] = tokenizer.NextLong();
        }

        Console.WriteLine(Plants.Solve(amount));

        //writer.Close();
    }

    class Plants
    {
        public static int Solve(long[] amount)
        {
            int n = amount.Length;
            int[] link = new int[n];
            int[] length = new int[n];

            link[0] = -1;
            length[0] = 0;

            int prev, currentLength;

            for (int current = 1; current < n; current++)
            {
                prev = current - 1;
                currentLength = 0;
                while (prev >= 0 && amount[prev] >= amount[current])
                {
                    currentLength = Math.Max(currentLength, length[prev]);
                    prev = link[prev];
                }

                if (prev == -1)
                {
                    currentLength = 0;
                }
                else
                {
                    currentLength++;
                }

                link[current] = prev;
                length[current] = currentLength;
            }

            int result = length[0];
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, length[i]);
            }

            return result;
        }
    }
}
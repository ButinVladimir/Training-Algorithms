using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Algorithms.Set_41;

public class Program
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

    public static void Main()
    {
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        Console.SetOut(writer);

        //Tokenizer tokenizer = new Tokenizer();

        //int tests = tokenizer.NextInt();
        //string s;
        //for (int test = 1; test <= tests; test++)
        //{
        //    Console.WriteLine("Case #{0}: {1}", test, Pancakes.Solve(tokenizer.NextToken()));
        //}

        int j = 50;
        Console.WriteLine("Case #1:");
        Jam jam = new Jam()
        {
            N = 16,
            J = j
        };

        long[,] result = jam.Solve();
        for (int i = 0; i < j; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                Console.Write(string.Format("{0} ", result[i, k]));
            }
            Console.WriteLine();
        }

        writer.Close();
    }
}
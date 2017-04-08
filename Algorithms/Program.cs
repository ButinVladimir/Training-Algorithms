using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
using Algorithms.Set_70;

public class Solution
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

        public double NextDouble()
        {
            return this.NextToken(double.Parse);
        }

        public decimal NextDecimal()
        {
            return this.NextToken(decimal.Parse);
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
        StreamReader reader = new StreamReader(File.OpenRead("input.txt"));
        Console.SetIn(reader);

        StreamWriter writer = File.CreateText("output.txt");
        Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();
        int tests = tokenizer.NextInt();
        long n, k;
        for (int test = 1; test <= tests; test++)
        {
            n = tokenizer.NextLong();
            k = tokenizer.NextLong();
            //Tuple<int, int> resultBrute = Bathroom.Solve(n, k);
            //Tuple<long, long> result = Bathroom.SolveMed(n, k);
            Tuple<long, long> result = Bathroom.SolveHard(n, k);

            Console.WriteLine("Case #{0}: {1} {2}", test, result.Item1, result.Item2);
            //Console.WriteLine("Case #{0}: {1}", test, result.Item1 == resultHard.Item1 && result.Item2 == resultHard.Item2);
        }

        writer.Close();
    }
}
using System;
using System.Collections.Generic;
using System.IO;

using Algorithms.Set_52;

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
/*
        Console.SetIn(new StreamReader(File.Open("input.txt", FileMode.Open)));

        Tokenizer tokenizer = new Tokenizer();
        int n = tokenizer.NextInt();
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
        }
*/

        for (int test = 0; test < 100; test++)
        {
            int[] a = TestSetGenerator.Generate(1, 30);
            Console.WriteLine("Test");
            Console.WriteLine(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(string.Format("{0} ", a[i]));
            }
            Console.WriteLine();

            List<int> result = PickASet.Solve(a);
            Console.WriteLine("Result");
            OutputResult(result);

            PickASetBrute brute = new PickASetBrute() { A = a };
            List<int> bruteResult = brute.Solve();
            Console.WriteLine("Brute force result");
            OutputResult(bruteResult);

            Console.WriteLine(result.Count != bruteResult.Count ? "WA\n" : "OK\n");
            if (result.Count != bruteResult.Count)
            {
                Console.WriteLine("An error found");
                return;
            }
        }
    }

    private static void OutputResult(List<int> result)
    {
        Console.WriteLine(result.Count);
        foreach (int position in result)
        {
            Console.Write(string.Format("{0} ", position + 1));
        }

        Console.WriteLine();
    }
}
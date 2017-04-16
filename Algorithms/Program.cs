using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_24;

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
        //StreamReader reader = new StreamReader(File.OpenRead("input.txt"));
        //Console.SetIn(reader);

        //StreamWriter writer = File.CreateText("output.txt");
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        string[] input = new string[n];
        for (int i = 0; i < n; i++)
        {
            input[i] = tokenizer.NextToken();
        }

        Console.WriteLine(Char2.Solve(input));

        //writer.Close();
    }

    public static class Char2
    {
        public const int Alp = 26;

        public static int Solve(string[] input)
        {
            int[] one = new int[Alp];
            int[,] two = new int[Alp, Alp];
            bool[] was = new bool[Alp];
            int count, p1, p2;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < Alp; j++)
                {
                    was[j] = false;
                }
                count = 0;

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (!was[input[i][j] - 'a'])
                    {
                        was[input[i][j] - 'a'] = true;
                        count++;
                    }

                    if (count > 2)
                    {
                        break;
                    }
                }

                if (count == 1)
                {
                    for (int j = 0; j < Alp; j++)
                    {
                        if (was[j])
                        {
                            one[j] += input[i].Length;
                        }
                    }
                }

                if (count == 2)
                {
                    p1 = 0;
                    while (!was[p1])
                    {
                        p1++;
                    }

                    p2 = p1 + 1;
                    while (!was[p2])
                    {
                        p2++;
                    }

                    two[p1, p2] += input[i].Length;
                }
            }

            for (int i = 0; i < Alp; i++)
            {
                for (int j = i + 1; j < Alp; j++)
                {
                    two[i, j] += one[i] + one[j];
                }
            }

            int max = 0;
            for (int i = 0; i < Alp; i++)
            {
                for (int j = i + 1; j < Alp; j++)
                {
                    max = Math.Max(max, two[i, j]);
                }
            }

            return max;
        }
    }
}
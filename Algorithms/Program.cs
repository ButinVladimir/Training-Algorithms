using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_21;

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

        public char NextChar()
        {
            return this.NextToken(char.Parse);
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
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
        }

        Console.WriteLine(Fractions.Solve(a));

        //writer.Close();
    }

    public static class Fractions
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            int min = a[0];

            for (int i = 0; i < a.Length; i++)
            {
                result += a[i];
                min = Math.Min(min, a[i]);
            }

            int currentResult;
            bool can;

            for (int divider = 1; divider <= min; divider++)
            {
                currentResult = 0;
                can = true;

                for (int i = 0; i < a.Length; i++)
                {
                    int l = a[i] / divider;

                    while (l > 0 && a[i] / l <= divider)
                    {
                        l--;
                    }

                    while (l == 0 || a[i] / l > divider)
                    {
                        l++;
                    }

                    if (a[i] / l == divider)
                    {
                        currentResult += l;
                    }
                    else
                    {
                        can = false;
                        break;
                    }
                }

                if (can)
                {
                    result = Math.Min(result, currentResult);
                }
            }

            return result;
        }
    }
}
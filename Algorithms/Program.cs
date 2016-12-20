using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
//using Algorithms.Set_62;

class SquareBrackets
{
    public int[] OpenedPositions { get; set; }
    public int N { get; set; }


    public int Solve()
    {
        int n2 = N * 2;
        int[,] result = new int[n2 + 1, N + 1];

        for (int i = 1; i <= N; i++)
        {
            result[n2, i] = 0;
        }
        result[n2, 0] = 1;

        for (int position = n2 - 1; position >= 0; position--)
        {
            for (int opened = 0; opened <= N; opened++)
            {
                result[position, opened] = 0;

                if (opened > 0 && !OpenedPositions.Contains(position))
                {
                    result[position, opened] += result[position + 1, opened - 1];
                }

                if (opened < N)
                {
                    result[position, opened] += result[position + 1, opened + 1];
                }
            }
        }

        return result[0, 0];
    }
}

public class Program
{
    private class Tokenizer
    {
        private string currentString = null;
        private string[] tokens;
        private int tokenNumber;
        private char[] separators;

        public Tokenizer()
        {
            currentString = null;
            tokens = null;
            tokenNumber = 0;
            separators = new char[] { ' ' };
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

        public string NextToken()
        {
            if (currentString == null || tokenNumber == tokens.Length)
            {
                currentString = GetNextString();
                while (currentString != null && currentString.Equals(string.Empty))
                {
                    currentString = GetNextString();
                }

                if (currentString == null)
                {
                    return null;
                }

                tokens = currentString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                tokenNumber = 0;
            }

            return tokens[tokenNumber++];
        }
    }

    public static void Main()
    {
        Tokenizer tokenizer = new Tokenizer();

        int testCount = Convert.ToInt32(tokenizer.NextToken());
        for (int t = 0; t < testCount; t++)
        {
            int n = Convert.ToInt32(tokenizer.NextToken());
            int k = Convert.ToInt32(tokenizer.NextToken());
            int[] openedPositions = new int[k];

            for (int i = 0; i < k; i++)
            {
                openedPositions[i] = Convert.ToInt32(tokenizer.NextToken()) - 1;
            }

            SquareBrackets brackets = new SquareBrackets();
            brackets.N = n;
            brackets.OpenedPositions = openedPositions;
            Console.WriteLine(brackets.Solve());
        }
    }
}
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Algorithms.Set_51;

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

        string input = "------A<B<D>><S---";

        KeyLogger logger = new KeyLogger();
        for (int i = 0; i < input.Length; i++)
        {
            logger.NextCharacter(input[i]);
        }

        Console.WriteLine(logger.ToString());
    }
}
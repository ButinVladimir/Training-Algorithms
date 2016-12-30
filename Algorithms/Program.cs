using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Algorithms.Set_42;

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

        Dictionary<int, string> words = new Dictionary<int, string>();
        words.Add(0, "aca");
        words.Add(1, "ac");
        words.Add(2, "ca");
        words.Add(3, "a");
        words.Add(4, "a");
        words.Add(5, "c");
        words.Add(6, "c");
        words.Add(7, "cat");
        words.Add(8, "hello");
        words.Add(9, "world");

        CountingWords problem = new CountingWords();
        foreach (var word in words)
        {
            problem.AddWord(word.Key, word.Value);
        }

        string text = "acacabcatghhellomvnsdb";
        for (int i = 0; i < text.Length; i++)
        {
            problem.AddCharacter(text[i]);
        }

        foreach(var word in problem.Counts)
        {
            Console.WriteLine("Word: '{0}' - Count: {1}", words[word.Key], word.Value);
        }

    }
}
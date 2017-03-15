using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//using Algorithms.Set_69;

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
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();
        int n = tokenizer.NextInt();

        string[] result = MelodiousPassword.Solve(n);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }

        //writer.Close();
    }

    public class MelodiousPassword
    {
        private static readonly char[] vowels = { 'e', 'u', 'i', 'o', 'a' };
        private static readonly char[] consonants = { 'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

        public static string[] Solve(int n)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();

            FillList(n, false, sb, result);
            FillList(n, true, sb, result);
            return result.ToArray();
        }

        private static void FillList(int n, bool vowel, StringBuilder sb, List<string> result)
        {
            if (n == 0)
            {
                result.Add(sb.ToString());
                return;
            }

            char[] letters = vowel ? vowels : consonants;

            for (int i = 0; i < letters.Length; i++)
            {
                sb.Append(letters[i]);
                FillList(n - 1, !vowel, sb, result);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
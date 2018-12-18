using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_12;

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

        public ulong NextULong()
        {
            return this.NextToken(ulong.Parse);
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
        //using (StreamReader reader = new StreamReader(File.OpenRead("input.txt")))
        //{
        // Console.SetIn(reader);

        //    using (StreamWriter writer = File.CreateText("output.txt"))
        //    {
        //        Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        string s = tokenizer.NextToken();
        int q = tokenizer.NextInt();

        MaximumPalindromes mp = new MaximumPalindromes(s);

        for (int i = 0; i < q; i++)
        {
            int l = tokenizer.NextInt();
            int r = tokenizer.NextInt();

            Console.WriteLine(mp.Query(l, r));
        }

        //    }
        //}
    }

    public class MaximumPalindromes
    {
        private const int MC = 26;
        private const long mod = 1000000000 + 7;
        private static long[] factorials;
        private static long[] reverses;

        private string s;
        private long[,] charCount;
        private long[] currentCharCount;
        private long maxLen;
        private long middleCnt;

        static MaximumPalindromes()
        {
            const int N = 100001;
            factorials = new long[N];
            reverses = new long[N];

            factorials[0] = 1;
            for (int i = 1; i < N; i++)
            {
                factorials[i] = (factorials[i - 1] * i) % mod;
            }

            for (int i = 0; i < N; i++)
            {
                reverses[i] = Reverse(factorials[i]);
            }
        }

        public MaximumPalindromes(string s)
        {
            this.s = s;
            this.charCount = new long[MC, this.s.Length + 1];
            this.currentCharCount = new long[MC];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < MC; j++)
                {
                    this.charCount[j, i + 1] = this.charCount[j, i];
                }
                this.charCount[s[i] - 'a', i + 1]++;
            }
        }

        public long Query(int l, int r)
        {
            this.maxLen = 0;
            this.middleCnt = 0;
            long result = 1;

            for (int i = 0; i < MC; i++)
            {
                this.currentCharCount[i] = this.charCount[i, r] - this.charCount[i, l - 1];
                if (this.currentCharCount[i] % 2 == 1)
                {
                    this.middleCnt++;
                }
                this.currentCharCount[i] /= 2;
                this.maxLen += this.currentCharCount[i];
            }

            if (this.middleCnt > 0)
            {
                result *= this.middleCnt;
            }

            for (int i = 0; i < MC; i++)
            {
                result = (result * factorials[this.maxLen]) % mod;
                result = (result * reverses[this.currentCharCount[i]]) % mod;
                result = (result * reverses[this.maxLen - this.currentCharCount[i]]) % mod;

                this.maxLen -= this.currentCharCount[i];
            }

            return result;
        }

        private static long Reverse(long a)
        {
            long x, y;
            Gcd(a, mod, out x, out y);

            return x;
        }

        private static void Gcd(long a, long b, out long x, out long y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;

                return;
            }

            long x0, y0;
            Gcd(b % a, a, out x0, out y0);
            y = x0;
            x = (mod + y0 - ((b / a) * x0) % mod) % mod;
        }
    }
}

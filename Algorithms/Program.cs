using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

//using Algorithms.Set_68;

class Solution
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

    static void Main()
    {
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        long w = tokenizer.NextLong();
        long h = tokenizer.NextLong();

        long xc = tokenizer.NextLong();
        long yc = tokenizer.NextLong();
        long r = tokenizer.NextLong();

        long x1 = tokenizer.NextLong();
        long y1 = tokenizer.NextLong();
        long x3 = tokenizer.NextLong();
        long y3 = tokenizer.NextLong();

        string[] result = CircleSquare.Solve(w, h, xc, yc, r, x1, y1, x3, y3);

        for (int i = 0; i < h; i++)
        {
            Console.WriteLine(result[i]);
        }

        //writer.Close();
    }

    public class CircleSquare
    {
        public static string[] Solve(long w, long h, long xc, long yc, long r, long x1, long y1, long x3, long y3)
        {
            string[] result = new string[h];
            StringBuilder sb = new StringBuilder();

            bool add;
            long r2 = r * r;

            for (long y = 0; y < h; y++)
            {
                sb.Clear();
                for (long x = 0; x < w; x++)
                {
                    add = false;

                    if (Distance(xc, yc, x, y) <= r2)
                    {
                        add = true;
                    }

                    if (CheckSquareAngle(x, y, x1, y1, x3, y3) && CheckSquareAngle(x, y, x3, y3, x1, y1))
                    {
                        add = true;
                    }

                    sb.Append(add ? '#' : '.');
                }

                result[y] = sb.ToString();
            }

            return result;
        }

        private static bool CheckSquareAngle(long x, long y, long x1, long y1, long x3, long y3)
        {
            long mult = (x - x1) * (x3 - x1) + (y - y1) * (y3 - y1);
            if (mult < 0)
            {
                return false;
            }

            long left = 2 * mult * mult;
            long right = Distance(x1, y1, x, y) * Distance(x1, y1, x3, y3);
            return left >= right;
        }

        private static long Distance(long x1, long y1, long x2, long y2)
        {
            long dx = x2 - x1;
            long dy = y2 - y1;

            return dx * dx + dy * dy;
        }
    }
}
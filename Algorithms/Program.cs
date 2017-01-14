using System;
//using Algorithms.Set_58;

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

    class Potions
    {
        public long N { get; set; } // We need to brew N potions
        public int M { get; set; } // Amount of spells of first type
        public int K { get; set; } // Amount of spells of second type
        public long X { get; set; } // Initial brewing speed
        public long S { get; set; } // Mana points

        public long[] A { get; set; } // New brewing speed after first type spell was casted
        public long[] B { get; set; } // Cost of spell of first type

        public long[] C { get; set; } // Amount of potions which will be immediately created
        public long[] D { get; set; } // Cost of spell of second type

        public long Solve()
        {
            long result = Math.Max(0, N - this.FindMaxPotions(S)) * X;

            for (int i = 0; i < M; i++)
            {
                if (S >= B[i])
                {
                    result = Math.Min(result, Math.Max(0, N - this.FindMaxPotions(S - B[i])) * A[i]);
                }
            }

            return result;
        }

        private long FindMaxPotions(long points)
        {
            long result = 0;
            long current = -1;
            long step = K;
            long next;

            while (step > 0)
            {
                next = current + step;

                if (next >= 0 && next < K && C[next] >= result && D[next] <= points)
                {
                    result = C[next];
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return result;
        }
    }

    public static void Main()
    {
        Tokenizer tokenizer = new Tokenizer();
        Potions potions = new Potions();

        potions.N = Convert.ToInt64(tokenizer.NextToken());
        potions.M = Convert.ToInt32(tokenizer.NextToken());
        potions.K = Convert.ToInt32(tokenizer.NextToken());

        potions.X = Convert.ToInt64(tokenizer.NextToken());
        potions.S = Convert.ToInt64(tokenizer.NextToken());

        potions.A = new long[potions.M];
        for (int i = 0; i < potions.M; i++)
        {
            potions.A[i] = Convert.ToInt64(tokenizer.NextToken());
        }

        potions.B = new long[potions.M];
        for (int i = 0; i < potions.M; i++)
        {
            potions.B[i] = Convert.ToInt64(tokenizer.NextToken());
        }

        potions.C = new long[potions.K];
        for (int i = 0; i < potions.K; i++)
        {
            potions.C[i] = Convert.ToInt64(tokenizer.NextToken());
        }

        potions.D = new long[potions.K];
        for (int i = 0; i < potions.K; i++)
        {
            potions.D[i] = Convert.ToInt64(tokenizer.NextToken());
        }

        Console.WriteLine(potions.Solve());
    }
}
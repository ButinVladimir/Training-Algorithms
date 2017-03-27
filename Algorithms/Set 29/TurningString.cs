using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_29
{
    public static class TurningString
    {
        private static Dictionary<string, int> values;

        static TurningString()
        {
            values = new Dictionary<string, int>()
            {
                { "zero", 0 },
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
                { "ten", 10 },
                { "eleven", 11 },
                { "twelve", 12 },
                { "thirteen", 13 },
                { "fourteen", 14 },
                { "fifteen", 15 },
                { "sixeen", 16 },
                { "seventeen", 17 },
                { "eighteen", 18 },
                { "nineteen", 19 },
                { "twenty", 20 },
                { "thirty", 30 },
                { "fourty", 40 },
                { "fifty", 50 },
                { "sixty", 60 },
                { "seventy", 70 },
                { "eighty", 80 },
                { "ninety", 90 },
                { "hundreds", 100 },
                { "hundred", 100 },
                { "thousands", 1000 },
                { "thousand", 1000 },
                { "millions", 1000000 },
                { "million", 1000000 },
            };
        }

        public static int Solve(string input)
        {
            string[] words = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().ToLowerInvariant())
                .ToArray();

            int result = 0;
            int currentWordValue;
            int currentBlockValue = 0;

            for (int i = 0; i < words.Length; i++)
            {
                currentWordValue = values[words[i]];

                if (currentWordValue < 100)
                {
                    currentBlockValue += currentWordValue;
                }
                else if (currentWordValue == 100)
                {
                    currentBlockValue = 100 * Math.Max(currentBlockValue, 1);
                }
                else
                {
                    result += currentWordValue * Math.Max(currentBlockValue, 1);
                    currentBlockValue = 0;
                }
            }

            result += currentBlockValue;

            return result;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_35
{
    public class Split
    {
        private const int MaxLength = 25;
        private const string Format = "({0}/{1})";

        public static List<String> SplitMessage(string text)
        {
            int min = text.Length / MaxLength;
            string[] words = text.Split(' ');
            int max = words.Length;

            List<string> result = new List<string>();

            int step = max - min + 1;
            int current = min - 1;

            while (step > 0)
            {
                if (current + step <= max && SplitWithFixedParts(words, current + step, result))
                {
                    step /= 2;
                }
                else
                {
                    current += step;
                }
            }

            return result;
        }

        private static bool SplitWithFixedParts(string[] words, int maxParts, List<string> result)
        {
            result.Clear();

            StringBuilder sb = new StringBuilder();
            int currentWord = 0;
            bool space;
            int currentLength;
            string partString;

            for (int i = 0; i < maxParts; i++)
            {
                if (currentWord == words.Length)
                {
                    break;
                }

                space = false;
                partString = string.Format(Format, i + 1, maxParts);
                currentLength = partString.Length;
                sb.Clear();

                for (; currentWord < words.Length; currentWord++)
                {
                    if (currentLength + (space ? 1 : 0) + words[currentWord].Length <= MaxLength)
                    {
                        if (space)
                        {
                            sb.Append(' ');
                            currentLength++;
                        }

                        sb.Append(words[currentWord]);
                        currentLength += words[currentWord].Length;

                        space = true;
                    }
                    else
                    {
                        break;
                    }
                }

                sb.Append(partString);
                result.Add(sb.ToString());
            }

            return currentWord == words.Length;
        }
    }
}

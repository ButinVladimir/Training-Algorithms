using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class TheFullCountingSort
    {
        public static string Solve(Tuple<int, string>[] input)
        {
            int n = input.Length;
            int n2 = n / 2;
            SortedDictionary<int, List<string>> words = new SortedDictionary<int, List<string>>();

            for (int i = 0; i < n; i++)
            {
                List<string> wordsByCode;
                if (!words.TryGetValue(input[i].Item1, out wordsByCode))
                {
                    wordsByCode = new List<string>();
                    words[input[i].Item1] = wordsByCode;
                }

                wordsByCode.Add(i < n2 ? "-" : input[i].Item2);
            }

            List<string> allWords = new List<string>();
            foreach (var mappedWords in words)
            {
                allWords.AddRange(mappedWords.Value);
            }

            return string.Join(" ", allWords);
        }
    }
}

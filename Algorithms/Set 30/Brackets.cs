using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_30
{
    public class Brackets
    {
        private static Dictionary<char, char> ClosingChars;

        private static SortedSet<char> OpeningChars;

        static Brackets()
        {
            ClosingChars = new Dictionary<char, char>()
            {
                { '>', '<' },
                { '}', '{' },
                { ']', '[' },
                { ')', '(' },
            };

            OpeningChars = new SortedSet<char>() { '<', '{', '[', '(' };
        }

        public static int Solve(string s)
        {
            int n = s.Length;
            int[] links = new int[n];

            int currentLink = -1;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                if (OpeningChars.Contains(s[i]))
                {
                    links[i] = currentLink;
                    currentLink = i;
                }
                else
                {
                    if (currentLink == -1)
                    {
                        return -1;
                    }

                    if (s[currentLink] != ClosingChars[s[i]])
                    {
                        result++;
                    }

                    currentLink = links[currentLink];
                }
            }

            if (currentLink != -1)
            {
                return -1;
            }

            return result;
        }
    }
}

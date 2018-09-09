using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public class BalancedBracket
    {
        private int characterNumber = 0;
        private Dictionary<char, int> openingCharacters = new Dictionary<char, int>();
        private Dictionary<char, int> closingCharacters = new Dictionary<char, int>();

        public void AddCharacters(char openingCharacter, char closingCharacter)
        {
            this.characterNumber++;
            this.openingCharacters.Add(openingCharacter, this.characterNumber);
            this.closingCharacters.Add(closingCharacter, this.characterNumber);
        }

        public bool Check(string s)
        {
            if (s.Length % 2 != 0)
            {
                return false;
            }

            Stack<int> stack = new Stack<int>();
            int value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (this.openingCharacters.TryGetValue(s[i], out value))
                {
                    stack.Push(value);
                }
                else if (this.closingCharacters.TryGetValue(s[i], out value))
                {
                    if (stack.Count == 0 || stack.Peek() != value)
                    {
                        return false;
                    }

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}

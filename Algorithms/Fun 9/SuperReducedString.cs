using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class SuperReducedString
    {
        public static string Solve(string input)
        {
            StringBuilder sb = new StringBuilder();
            bool notSame = true;
            while (notSame)
            {
                sb.Clear();
                char c = input[0];
                int l = 1;
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i] == c)
                    {
                        l++;
                    }
                    else
                    {
                        if (l % 2 == 1)
                        {
                            sb.Append(c);
                        }

                        c = input[i];
                        l = 1;
                    }
                }

                if (l % 2 == 1)
                {
                    sb.Append(c);
                }

                string newInput = sb.ToString();
                if (newInput.Length == 0)
                {
                    newInput = "Empty String";
                }

                notSame = !newInput.Equals(input);
                input = newInput;
            }

            return input;
        }
    }
}

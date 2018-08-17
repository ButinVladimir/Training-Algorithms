using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class StringConstruction
    {
        public static int Solve(string s)
        {
            HashSet<char> charSet = new HashSet<char>();
            foreach (char c in s)
            {
                charSet.Add(c);
            }

            return charSet.Count;
        }
    }
}

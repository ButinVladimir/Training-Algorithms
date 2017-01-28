using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_41
{
    class Pancakes
    {
        const char Happy = '+';
        const char Blank = '-';

        public static int Solve(string s)
        {
            int position = s.Length - 1;
            bool flipped = false;
            bool need = false;
            int result = 0;

            while (position >= 0)
            {
                need = (s[position] == Blank) ^ flipped;              

                if (need)
                {
                    result++;
                    flipped = !flipped;
                }

                position--;
            }

            return result;
        }
    }
}

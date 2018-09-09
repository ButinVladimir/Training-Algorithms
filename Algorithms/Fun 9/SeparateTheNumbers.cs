using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class SeparateTheNumbers
    {
        public static BigInteger Solve(string s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                string substring = s.Substring(0, i);
                if (substring[0] == '0')
                {
                    return -1;
                }

                BigInteger initNumber = BigInteger.Parse(substring);
                if (Check(s, i, initNumber))
                {
                    return initNumber;
                }
            }

            return -1;
        }

        public static bool Check(string s, int pos, BigInteger initNumber)
        {
            while (pos != s.Length)
            {
                initNumber++;
                string convertedNumber = initNumber.ToString();

                if (pos + convertedNumber.Length > s.Length)
                {
                    return false;
                }

                if (!s.Substring(pos, convertedNumber.Length).Equals(convertedNumber))
                {
                    return false;
                }

                pos += convertedNumber.Length;
            }

            return true;
        }
    }
}

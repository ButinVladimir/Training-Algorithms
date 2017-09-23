using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class TimeInWords
    {
        public static string Solve(int h, int m)
        {
            if (m == 0)
            {
                return Transform(h) + " " + Transform(m);
            }

            if (m == 1)
            {
                return Transform(m) + " minute past " + Transform(h);
            }
            else if (m > 1 && m != 15 && m < 30)
            {
                return Transform(m) + " minutes past " + Transform(h);
            }
            else if (m == 15 || m == 30)
            {
                return Transform(m) + " past " + Transform(h);
            }
            else if (m > 30 && m < 59 && m != 45)
            {
                return Transform(60 - m) + " minutes to " + Transform(h + 1);
            }
            else if (m == 59)
            {
                return Transform(60 - m) + " minute to " + Transform(h + 1);
            }
            else
            {
                return Transform(60 - m) + " to " + Transform(h + 1);
            }
        }

        public static string Transform(int value)
        {
            if (value <= 0)
            {
                return "o' clock";
            }

            if (value >= 30)
            {
                return "half";
            }

            string result = "";
            if (value <= 9 || value >= 20)
            {
                if (value >= 20 && value <= 29)
                {
                    result += "twenty";
                    value -= 20;

                    if (value > 0)
                    {
                        result += " ";
                    }
                }

                switch (value)
                {
                    case 1: result += "one"; break;
                    case 2: result += "two"; break;
                    case 3: result += "three"; break;
                    case 4: result += "four"; break;
                    case 5: result += "five"; break;
                    case 6: result += "six"; break;
                    case 7: result += "seven"; break;
                    case 8: result += "eight"; break;
                    case 9: result += "nine"; break;
                }
            }
            else
            {
                switch (value)
                {
                    case 10: result += "ten"; break;
                    case 11: result += "eleven"; break;
                    case 12: result += "twelve"; break;
                    case 13: result += "thirteen"; break;
                    case 14: result += "fourteen"; break;
                    case 15: result += "quarter"; break;
                    case 16: result += "sixteen"; break;
                    case 17: result += "seventeen"; break;
                    case 18: result += "eighteen"; break;
                    case 19: result += "nineteen"; break;
                }
            }

            return result;
        }
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Mail;


public class Program
{
    public static UInt64 Power(UInt64 a, UInt64 b, ref UInt64 mod)
    {
        if (b == 0)
        {
            return 1;
        }

        if (b == 1)
        {
            return a % mod;
        }

        UInt64 c = Power(a, b / 2, ref mod);
        c = (c * c) % mod;
        if (b % 2 == 1)
        {
            c = (c * a) % mod;
        }

        return c;
    }

    public static void Main()
    {
        string s;
        string[] words;
        char[] delimiters = new char[] { ' ' };

        UInt64 a, b, c, mod = 10000;
        while ((s = Console.ReadLine()) != null)
        {
            s = s.Trim();
            words = s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            a = Convert.ToUInt64(words[0]);
            b = Convert.ToUInt64(words[2]);

            switch (words[1][0])
            {
                case '+':
                    c = (a + b) % mod;
                    break;
                case '*':
                    c = (a * b) % mod;
                    break;
                case '^':
                    c = Power(a, b, ref mod);
                    break;
                default:
                    c = 0;
                    break;
            }
            Console.WriteLine(c);
        }
    }
}
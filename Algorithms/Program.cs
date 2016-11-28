using System;
using System.Linq;
using System.Net;
using System.Net.Mail;


public class Program
{
    public static bool Solve(int n, int[] a)
    {
        bool[] was = new bool[n];
        was[a[n - 1]] = true;

        int c;

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                c = a[i] + a[i] - a[j];
                if (c >= 0 && c < n && was[c])
                {
                    return true;
                }
            }

            was[a[i]] = true;
        }

        return false;
    }

    public static void Main()
    {
        string s;
        while (true)
        {
            s = Console.ReadLine().Trim();
            if (s == "0")
            {
                return;
            }

            int[] a = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(x => Convert.ToInt32(x)).ToArray();
            if (Solve(a.Length, a) == true)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine("yes");
            }
        }
    }
}
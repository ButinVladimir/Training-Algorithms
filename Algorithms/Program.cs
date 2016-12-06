using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

public class CPCRC1
{
    private const long TEN = 10;
    private const long DIGITS_SUM = 0 + 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9;

    public static long Solve(long number)
    {
        if (number == 0)
        {
            return 0;
        }

        long multiplier = 1;
        long rightPart = 0;
        long result = 0;
        long digit;

        while (number > 0)
        {
            digit = number % TEN;
            number /= TEN;

            if (number > 0)
            {
                result += DIGITS_SUM * number * multiplier;
            }

            for (long i = 0; i < digit; i++)
            {
                result += i * multiplier;
            }

            result += digit * (rightPart + 1);

            rightPart += multiplier * digit;
            multiplier *= TEN;
        }

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        long[] numbers;
        char[] delimiters = new char[] { ' ' };
        long result;

        while (true)
        {
            numbers = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt64(x)).ToArray();
            if (numbers[0] == -1 && numbers[1] == -1)
            {
                break;
            }

            result = CPCRC1.Solve(numbers[1]);
            if (numbers[0] > 0)
            {
                result -= CPCRC1.Solve(numbers[0] - 1);
            }

            Console.WriteLine("{0}", result);
        }
    }
}
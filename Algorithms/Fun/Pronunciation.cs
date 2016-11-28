using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Pronunciation
    {
        const string AND = "and";
        static private Dictionary<int, string> dict = new Dictionary<int, string>();

        static Pronunciation()
        {
            dict.Add(0, "zero");
            dict.Add(1, "one");
            dict.Add(2, "two");
            dict.Add(3, "three");
            dict.Add(4, "four");
            dict.Add(5, "five");
            dict.Add(6, "six");
            dict.Add(7, "seven");
            dict.Add(8, "eight");
            dict.Add(9, "nine");
            dict.Add(10, "ten");
            dict.Add(11, "eleven");
            dict.Add(12, "twelve");
            dict.Add(13, "thirteen");
            dict.Add(14, "fourteen");
            dict.Add(15, "fifteen");
            dict.Add(16, "sixteen");
            dict.Add(17, "seventeen");
            dict.Add(18, "eighteen");
            dict.Add(19, "nineteen");
            dict.Add(20, "twenty");
            dict.Add(30, "thirty");
            dict.Add(40, "fourty");
            dict.Add(50, "fifty");
            dict.Add(60, "sixty");
            dict.Add(70, "seventy");
            dict.Add(80, "eighty");
            dict.Add(90, "ninty");
            dict.Add(100, "hundred");
            dict.Add(1000, "thousand");
            dict.Add(1000000, "million");
        }

        static private void AddToArray(string[] array, string value, ref int position)
        {
            array[position] = value;
            position++;
        }

        static public string BuildString(int number)
        {
            string[] array = new string[200];
            if (number == 0)
            {
                return dict[0];
            }

            int mult = 1, remainder, position = 0, hundredRemainder, hundredAmount;
            while (number > 0)
            {
                remainder = number % 1000;
                number /= 1000;

                if (mult > 1 && remainder > 0)
                {
                    AddToArray(array, dict[mult], ref position);
                }

                hundredRemainder = remainder % 100;
                hundredAmount = remainder / 100;

                if (hundredRemainder % 100 > 0)
                {
                    if (hundredRemainder < 20)
                    {
                        AddToArray(array, dict[hundredRemainder], ref position);
                    }
                    else
                    {
                        AddToArray(array, dict[hundredRemainder % 10], ref position);
                        AddToArray(array, dict[(hundredRemainder / 10) * 10], ref position);
                    }

                    if (mult == 1 && (number > 0 || hundredAmount > 0))
                    {
                        AddToArray(array, AND, ref position);
                    }
                }

                if (hundredAmount > 0)
                {
                    AddToArray(array, dict[100], ref position);
                    AddToArray(array, dict[hundredAmount], ref position);
                }

                mult *= 1000;
            }

            Array.Reverse(array, 0, position);
            return String.Join(" ", array);
        }
    }
}

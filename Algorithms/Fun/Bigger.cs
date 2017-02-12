using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Bigger
    {
        public static string Solve(string input)
        {

            int position = input.Length - 2;
            while (position >= 0 && input[position] >= input[position + 1])
            {
                position--;
            }

            if (position == -1)
            {
                return "no answer";
            }

            char[] inputArray = input.ToCharArray();

            int swap = position;
            for (int i=position + 1;i<input.Length;i++)
            {
                if (input[i] > input[position] && (swap == position || input[i] < input[swap]))
                {
                    swap = i;
                }
            }

            char buffer = inputArray[position];
            inputArray[position] = inputArray[swap];
            inputArray[swap] = buffer;

            Array.Sort(inputArray, position + 1, input.Length - position - 1);

            StringBuilder sb = new StringBuilder();
            sb.Append(inputArray);
            return sb.ToString();
        }
    }
}

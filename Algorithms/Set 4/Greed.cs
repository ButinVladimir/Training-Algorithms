using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_4
{
    public static class Kata
    {
        public static int Score(int[] dice)
        {
            int[] values = new int[7];

            for (int i = 0; i < dice.Length; i++)
            {
                values[dice[i]]++;
            }

            int result = 0;

            for (int i = 2; i < 7; i++)
            {
                if (values[i] >= 3)
                {
                    values[i] -= 3;
                    result += i * 100;
                }
            }

            if (values[1] >= 3)
            {
                values[1] -= 3;
                result += 1000;
            }

            result += 100 * values[1] + 50 * values[5];

            return result;
        }
    }
}

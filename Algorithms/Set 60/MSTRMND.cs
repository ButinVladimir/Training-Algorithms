using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_60
{
    class MSTRMND
    {
        const int LENGTH = 4;
        const int CORRECT = 1;
        const int INCORRECT = -1;
        const int NUMBER_MIN = 1;
        const int NUMBER_MAX = 6;
        const string SEPARATOR = " ";
        private static char[] separatorArray = { ' ' };

        public static void Solve()
        {
            int[] guess = new int[LENGTH], answers = new int[LENGTH];
            bool correct;

            for (int i = 0; i < LENGTH; i++)
            {
                answers[i] = INCORRECT;
            }

            for (int number = NUMBER_MIN; number <= NUMBER_MAX; number++)
            {
                correct = true;
                for (int i = 0; i < LENGTH; i++)
                {
                    if (answers[i] != CORRECT)
                    {
                        guess[i] = number;
                        correct = false;
                    }
                }
                if (correct)
                {
                    return;
                }

                Console.WriteLine(string.Join(SEPARATOR, guess.Select(x => x.ToString()).ToArray()));
                Console.Out.Flush();

                answers = Console.ReadLine().Split(separatorArray).Select(x => Convert.ToInt32(x.Trim())).ToArray();
            }
        }
    }
}

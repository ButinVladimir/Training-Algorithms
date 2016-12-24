using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_46
{
    class Deck
    {
        const int SEVEN = 7;
        public static double Solve(int[] values, double[] probabilities)
        {
            int n = values.Length;
            if (probabilities.Length != n)
            {
                throw new ArgumentException("values and probabilities should have same length");
            }

            for (int i = 0; i < n; i++)
            {
                if (probabilities[i] < 0 || probabilities[i] > 1)
                {
                    throw new ArgumentException(string.Format("Probability {0} should be between 0 and 1", i));
                }

                if (values[i] < 0)
                {
                    throw new ArgumentException(string.Format("Value {0} should be non-negative", i));
                }
            }

            double[] oldResult = new double[SEVEN];
            double[] newResult = new double[SEVEN];
            for (int i = 1; i < SEVEN; i++)
            {
                oldResult[i] = 0;
            }
            oldResult[0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < SEVEN; j++)
                {
                    newResult[j] = 0;
                }

                for (int j = 0; j < SEVEN; j++)
                {
                    newResult[(j + values[i]) % 7] += oldResult[j] * probabilities[i];
                    newResult[j] += oldResult[j] * (1 - probabilities[i]);
                }

                for (int j = 0; j < SEVEN; j++)
                {
                    oldResult[j] = newResult[j];
                }
            }

            return oldResult[0];
        }
    }
}

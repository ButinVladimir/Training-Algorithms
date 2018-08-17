using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class ClimbingTheLeaderboard
    {
        public static int[] Solve(int[] score, int[] alice)
        {
            List<int> uniquesList = new List<int>();
            uniquesList.Add(score[0]);
            int prev = score[0];

            for (int i = 1; i < score.Length; i++)
            {
                if (score[i] != prev)
                {
                    uniquesList.Add(score[i]);
                    prev = score[i];
                }
            }
            int[] uniques = uniquesList.ToArray();
            int[] result = new int[alice.Length];

            int step, position, nextPosition;
            for (int i = 0; i < alice.Length; i++)
            {
                step = uniques.Length;
                position = -1;
                while (step > 0)
                {
                    nextPosition = position + step;
                    if (nextPosition < uniques.Length && uniques[nextPosition] >= alice[i])
                    {
                        position = nextPosition;
                    }
                    else
                    {
                        step /= 2;
                    }
                }

                if (position == -1)
                {
                    result[i] = 1;
                }
                else if (uniques[position] == alice[i])
                {
                    result[i] = position + 1;
                }
                else
                {
                    result[i] = position + 2;
                }
            }

            return result;
        }
    }
}

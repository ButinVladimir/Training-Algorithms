using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_30
{
    public static class Poker
    {
        public static Result Check(int[] values)
        {
            if (values.Length != 5)
            {
                throw new ArgumentException("Invalid values length");
            }

            Array.Sort(values);

            if (CheckFullHouse(values))
            {
                return Result.FullHouse;
            }

            if (CheckFour(values))
            {
                return Result.FourOfKind;
            }

            if (CheckTwoPairs(values))
            {
                return Result.TwoPairs;
            }

            if (CheckThree(values))
            {
                return Result.Three;
            }

            if (CheckPair(values))
            {
                return Result.Pair;
            }

            return Result.Nothing;
        }

        private static bool CheckPair(int[] values)
        {
            for (int i = 0; i < 4; i++)
            {
                if (values[i] == values[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckThree(int[] values)
        {
            for (int i = 0; i < 3; i++)
            {
                if (values[i] == values[i + 2])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckFour(int[] values)
        {
            for (int i = 0; i < 2; i++)
            {
                if (values[i] == values[i + 3])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckTwoPairs(int[] values)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = i + 2; j < 4; j++)
                {
                    if (values[i] == values[i + 1] && values[j] == values[j + 1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckFullHouse(int[] values)
        {
            return (values[0] == values[1] && values[2] == values[4]) 
                || (values[0] == values[2] && values[3] == values[4]);
        }

        public enum Result
        {
            Nothing,
            Pair,
            Three,
            TwoPairs,
            FourOfKind,
            FullHouse
        }
    }
}

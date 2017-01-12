namespace Algorithms.Set_63
{
    public class Square
    {
        public static long Solve(long number)
        {
            long result = 1;
            bool add;

            for (long x = 2; x * x <= number; x++)
            {
                add = false;

                while (number % x == 0)
                {
                    add = !add;
                    number /= x;
                }

                if (add)
                {
                    result *= x;
                }
            }

            if (number != 1)
            {
                result *= number;
            }

            return result;
        }
    }
}
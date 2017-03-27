namespace Algorithms.Set_29
{
    using System;

    public static class Random200
    {
        private static Random randomGen;

        static Random200()
        {
            randomGen = new Random();
        }

        public static int F200()
        {
            int l = 0;
            int r = 200;
            int m;

            while (l < r)
            {
                m = (l + r) / 2;
                if (F1() == 0)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l;
        }

        private static int F1()
        {
            return randomGen.Next() % 2;
        }
    }
}
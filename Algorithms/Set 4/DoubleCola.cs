using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_4
{
    public class Line
    {
        public static string WhoIsNext(string[] names, long n)
        {
            long multiplier = 1;

            while (n > 0)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (n <= multiplier)
                    {
                        return names[i];
                    }

                    n -= multiplier;
                }

                multiplier *= 2;
            }

            return "";
        }
    }
}

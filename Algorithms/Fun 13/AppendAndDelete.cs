using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class AppendAndDelete
    {
        public static bool Solve(string source, string dest, int k)
        {
            if (k >= source.Length + dest.Length)
            {
                return true;
            }

            int commonPrefix = 0;

            for (commonPrefix = 0; commonPrefix < source.Length && commonPrefix < dest.Length && source[commonPrefix] == dest[commonPrefix]; commonPrefix++) ;

            int required = (source.Length - commonPrefix) + (dest.Length - commonPrefix);

            return (k >= required) && ((k - required) % 2 == 0);
        }
    }
}

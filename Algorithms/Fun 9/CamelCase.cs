using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class CamelCase
    {
        public static int Solve(string s)
        {
            return s.Where(c => char.IsUpper(c)).Count() + 1;
        }
    }
}

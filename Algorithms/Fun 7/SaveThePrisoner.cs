using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class SaveThePrisoner
    {
        public static int Solve(int n, int m, int s)
        {
            m = (m - 1) % n;
            return (s - 1 + m) % n + 1;
        }
    }
}

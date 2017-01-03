using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKey = System.Tuple<int, int>;

namespace Algorithms.Set_59
{
    class Permutations
    {
        private static Dictionary<DKey, long> calculatedResults;

        static Permutations()
        {
            calculatedResults = new Dictionary<DKey, long>();
        }

        public static long Solve(int n, int k)
        {
            if (n == 1 && k > 0 || k < 0)
            {
                return 0;
            }
            if (n == 1 && k == 0)
            {
                return 1;
            }

            DKey key = new DKey(n, k);
            if (calculatedResults.ContainsKey(key))
            {
                return calculatedResults[key];
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Solve(n - 1, k - i);
            }

            calculatedResults[key] = result;
            return result;
        }
    }
}

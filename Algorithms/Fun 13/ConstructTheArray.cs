using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class ConstructTheArray
    {
        private const long mod = 1000000000 + 7;

        public static long Solve(long n, long k, long x)
        {
            if (x == 1)
            {
                return SolveCase(n, k);
            }

            return SolveCase(n, k, x);
        }

        private static long SolveCase(long n, long k)
        {
            long[] state = { 1, 0 };
            long[] newState = { 0, 0 };
            for (int i = 0; i < n - 1; i++)
            {
                newState[0] = state[1];
                newState[1] = (state[0] * (k - 1) % mod + state[1] * (k - 2) % mod) % mod;
                Array.Copy(newState, state, 2);
            }

            return state[0];
        }

        private static long SolveCase(long n, long k, long x)
        {
            long[] state = { 1, 0, 0 };
            long[] newState = { 0, 0, 0 };
            for (int i = 0; i < n - 1; i++)
            {
                newState[0] = (state[1] + state[2]) % mod;
                newState[1] = (state[0] + state[2]) % mod;
                newState[2] = ((state[0] * (k - 2) % mod + state[1] * (k - 2) % mod) % mod + state[2] * (k - 3) % mod) % mod;
                Array.Copy(newState, state, 3);
            }

            return state[1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class GridChallenge
    {
        public static bool Solve(int n, string[] s)
        {
            char[][] letters = new char[n][];
            for (int i = 0; i < n; i++)
            {
                letters[i] = s[i].ToCharArray();
            }

            for (int i = 0; i < n; i++)
            {
                Array.Sort(letters[i]);
            }

            bool valid = true;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    valid = valid && letters[i][j] <= letters[i][j + 1] && letters[i][j] <= letters[i + 1][j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                valid = valid && letters[n - 1][i] <= letters[n - 1][i + 1] && letters[i][n - 1] <= letters[i + 1][n - 1];
            }

            return valid;
        }
    }
}

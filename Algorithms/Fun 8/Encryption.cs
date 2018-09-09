using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class Encryption
    {
        public static string Solve(string text)
        {
            string spacelessText = string.Join("", text.Split(' '));
            int l = 0;
            while (l * l < spacelessText.Length)
            {
                l++;
            }

            l--;

            int rows, cols;
            if (l * (l + 1) >= spacelessText.Length)
            {
                rows = l;
                cols = l + 1;
            }
            else
            {
                rows = l + 1;
                cols = l + 1;
            }

            char[,] cipher = new char[rows, cols];
            for (int i = 0; i < spacelessText.Length; i++)
            {
                cipher[i / cols, i % cols] = spacelessText[i];
            }

            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (cipher[i, j] != 0)
                    {
                        sb.Append(cipher[i, j]);
                    }
                }

                if (j != cols - 1)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}

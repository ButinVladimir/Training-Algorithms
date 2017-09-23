using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class PdfViewer
    {
        public static int Solve(int[] a, string word)
        {
            int h = 0;
            for (int i = 0; i < word.Length; i++)
            {
                h = Math.Max(h, a[word[i] - 'a']);
            }

            return h * word.Length;
        }
    }
}

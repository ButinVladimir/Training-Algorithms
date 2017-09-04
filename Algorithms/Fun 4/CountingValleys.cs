using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class CountingValleys
    {
        public static int Solve(string s)
        {
            int level = 0;
            int result = 0;

            for (int i=0;i<s.Length;i++)
            {
                if (s[i]=='U')
                {
                    level++;
                }
                else
                {
                    level--;

                    if (level ==-1)
                    {
                        result++;
                    }
                }                
            }

            return result;
        }
    }
}

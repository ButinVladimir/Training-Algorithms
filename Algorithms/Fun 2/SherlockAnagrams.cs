using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class SherlockAnagrams
    {
        public static int Solve(string s)
        {
            int[] cnt = new int[256];
            int result = 0;
            bool can = false;

            for (int left1 = 0; left1 < s.Length; left1++)
            {
                for (int left2 = left1 + 1; left2 < s.Length; left2++)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        cnt[c] = 0;
                    }

                    for (int length = 0; left2 + length < s.Length; length++)
                    {
                        cnt[s[left1 + length]]++;
                        cnt[s[left2 + length]]--;

                        can = true;
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (cnt[c] != 0)
                            {
                                can = false;
                                break;
                            }
                        }

                        if (can)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }
    }
}

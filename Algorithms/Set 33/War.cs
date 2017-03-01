using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_33
{
    public class War
    {
        public static int Solve(string needle, string haystack)
        {
            int[] pref = new int[needle.Length];

            pref[0] = 0;
            int currentPref = 0;

            for (int i = 1; i < needle.Length; i++)
            {
                while (currentPref > 0 && needle[i] != needle[currentPref])
                {
                    currentPref = pref[currentPref - 1];
                }

                if (needle[i] == needle[currentPref])
                {
                    currentPref++;
                }

                pref[i] = currentPref;
            }

            int result = 0;
            currentPref = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                while (currentPref > 0 && haystack[i] != needle[currentPref])
                {
                    currentPref = pref[currentPref - 1];
                }

                if (haystack[i] == needle[currentPref])
                {
                    currentPref++;
                }

                if (currentPref == needle.Length)
                {
                    currentPref = 0;
                    result++;
                }
            }

            return result;
        }
    }
}

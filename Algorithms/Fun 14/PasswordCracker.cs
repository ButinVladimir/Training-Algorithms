using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class PasswordCracker
    {
        public static string Solve(string[] passwords, string login)
        {
            int[] next = new int[login.Length];
            for (int start = login.Length - 1; start >= 0; start--)
            {
                next[start] = -1;
                foreach (string password in passwords)
                {
                    if (start + password.Length > login.Length)
                    {
                        continue;
                    }

                    bool can = true;
                    for (int i = 0; i < password.Length && can; i++)
                    {
                        if (login[start + i] != password[i])
                        {
                            can = false;
                        }
                    }

                    if (can && (start + password.Length == login.Length || next[start + password.Length] != -1))
                    {
                        next[start] = password.Length;
                        break;
                    }
                }
            }

            if (next[0] == -1)
            {
                return "WRONG PASSWORD";
            }

            List<string> parts = new List<string>();
            for (int pos = 0; pos < login.Length; pos += next[pos])
            {
                parts.Add(login.Substring(pos, next[pos]));
            }

            return string.Join(" ", parts);
        }
    }
}

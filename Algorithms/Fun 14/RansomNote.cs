using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class RansomNote
    {
        public static bool Solve(string[] magazine, string[] note)
        {
            Array.Sort(magazine);
            Array.Sort(note);

            int magazinePosition = 0;
            int notePosition = 0;
            for (notePosition = 0; notePosition < note.Length && magazinePosition < magazine.Length; notePosition++)
            {
                while (magazinePosition < magazine.Length && magazine[magazinePosition].CompareTo(note[notePosition]) < 0)
                {
                    magazinePosition++;
                }

                if (magazinePosition < magazine.Length && magazine[magazinePosition].CompareTo(note[notePosition]) == 0)
                {
                    magazinePosition++;
                }
                else
                {
                    return false;
                }
            }

            return notePosition == note.Length;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class TimeConversion
    {
        public static string Solve(string input)
        {
            int hours = Convert.ToInt32(input.Substring(0, 2));
            string minutesAndSeconds = input.Substring(2, 6);
            bool pm = input.Substring(8, 2).ToUpper() == "PM";

            if (!pm && hours == 12)
            {
                hours = 0;
            }
            else if (pm && hours != 12)
            {
                hours += 12;
            }

            return hours.ToString("D2") + minutesAndSeconds;
        }
    }
}

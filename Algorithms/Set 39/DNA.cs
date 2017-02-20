using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_39
{
    public class DNA
    {
        private static Dictionary<long, char> numberToCharMapping;
        private static Dictionary<char, long> charToNumberMapping;

        static DNA()
        {
            numberToCharMapping = new Dictionary<long, char>()
            {
                { 0, 'A' },
                { 1, 'C' },
                { 2, 'G' },
                { 3, 'T' }
            };

            charToNumberMapping = new Dictionary<char, long>()
            {
                { 'A', 0 },
                { 'C', 1 },
                { 'G', 2 },
                { 'T', 3 }
            };
        }

        public static IList<string> Solve(string s)
        {
            List<string> result = new List<string>();

            if (s.Length <= 10)
            {
                return result;
            }

            long value = 0;
            long mult = 1;
            for (int i = 0; i < 10; i++)
            {
                value += mult * charToNumberMapping[s[i]];

                if (i < 9)
                {
                    mult *= 4;
                }
            }

            SortedSet<long> sequences = new SortedSet<long>() { value };
            SortedSet<long> duplicates = new SortedSet<long>();

            for (int i = 11; i < s.Length; i++)
            {
                value /= 4;
                value += mult * charToNumberMapping[s[i]];

                if (sequences.Contains(value))
                {
                    duplicates.Add(value);
                }
                else
                {
                    sequences.Add(value);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var duplicate in duplicates)
            {
                sb.Clear();

                value = duplicate;
                for (int i = 0; i < 10; i++)
                {
                    sb.Append(numberToCharMapping[value % 4]);
                    value /= 4;
                }

                result.Add(sb.ToString());
            }

            return result;
        }
    }
}

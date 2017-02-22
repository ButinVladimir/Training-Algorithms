using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_68
{
    public class BigSorting
    {
        public static string[] Sort(string[] strings)
        {
            BigInteger[] numbers = strings.Select(x => BigInteger.Parse(x)).ToArray();
            Array.Sort(numbers);
            return numbers.Select(x => x.ToString()).ToArray();
        }
    }
}

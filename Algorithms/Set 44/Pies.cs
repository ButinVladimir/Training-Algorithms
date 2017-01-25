using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_44
{
    public class Pies
    {
        public static int GetMaxSlices(List<int> pieSlices, int nPeople) 
        {      
            int max = 0;
            foreach (int pieSlice in pieSlices)
            {
                max = Math.Max(max, pieSlice);
            }
            
            int current = 0;
            int next = 0;
            int step = max;
            
            while (step > 0)
            {
                next = current + step;

                if (CheckAmount(pieSlices, max, nPeople, next))
                {
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return current;
        }

        private static bool CheckAmount(IEnumerable<int> slices, int max, int nPeople, int amount)
        {
            if (amount <= 0 || amount > max)
            {
                return false;
            }

            long result = 0;
            foreach (int slice in slices)
            {
                result += slice / amount;

                if (result >= nPeople)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

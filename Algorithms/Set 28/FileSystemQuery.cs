using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public abstract class FileSystemQuery
    {
        protected int GetKthValue(int k, List<FileSystem> fileSystems)
        {
            if (fileSystems.Count == 0)
            {
                throw new Exception("No systems were added");
            }

            int fullCount = 0;
            foreach(FileSystem system in fileSystems)
            {
                fullCount += system.GetCount();
            }
            
            if (k < 1 || k > fullCount)
            {
                throw new IndexOutOfRangeException();
            }

            int min = this.GetMin() - 1;
            int max = this.GetMax();

            int current = min;
            int step = max - min;
            int next;

            while (step > 0)
            {
                next = current + step;

                if (this.GetLesserOrEqual(next) < k)
                {
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return current + 1;
        }

        protected abstract int GetMin();

        protected abstract int GetMax();

        protected abstract int GetLesserOrEqual(int value);
    }
}

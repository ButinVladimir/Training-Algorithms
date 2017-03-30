using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public class SortedFileSystemQuery : FileSystemQuery
    {
        private List<SortedFileSystem> fileSystems = new List<SortedFileSystem>();

        public void AddFileSystem(SortedFileSystem system)
        {
            this.fileSystems.Add(system);
        }

        public int GetKthValue(int k)
        {
            return this.GetKthValue(k, this.fileSystems.ConvertAll(x => (FileSystem)x).ToList<FileSystem>());
        }

        protected override int GetMin()
        {
            int min = 0;
            bool was = false;

            foreach (SortedFileSystem system in this.fileSystems)
            {
                if (!was || system.GetValue(0) < min)
                {
                    was = true;
                    min = system.GetValue(0);
                }
            }

            return min;
        }

        protected override int GetMax()
        {
            int max = 0;
            bool was = false;

            foreach (SortedFileSystem system in this.fileSystems)
            {
                if (!was || system.GetValue(system.GetCount() - 1) > max)
                {
                    was = true;
                    max = system.GetValue(system.GetCount() -1);
                }
            }

            return max;
        }

        protected override int GetLesserOrEqual(int value)
        {
            int count = 0;

            foreach (SortedFileSystem system in this.fileSystems)
            {
                int current = -1;
                int step = system.GetCount();
                int next;

                while (step > 0)
                {
                    next = current + step;

                    if (next >= 0 && next < system.GetCount() && system.GetValue(next) <= value)
                    {
                        current = next;
                    }
                    else
                    {
                        step /= 2;
                    }
                }

                count += current + 1;
            }

            return count;
        }
    }
}

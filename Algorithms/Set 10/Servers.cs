using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_10
{
    public class Servers
    {
        public int[] ServerLimits { get; set; }
        public int[] TaskNeeds { get; set; }

        private Dictionary<Tuple<int, long>, bool> IntermediateResults;

        public bool Solve()
        {
            this.IntermediateResults = new Dictionary<Tuple<int, long>, bool>();
            long mask = (1 << this.TaskNeeds.Length) - 1;

            return Solve(0, mask);
        }

        private bool Solve(int currentServer, long mask)
        {
            if (mask == 0)
            {
                return true;
            }

            if (currentServer >= this.ServerLimits.Length && mask > 0)
            {
                return false;
            }

            Tuple<int, long> key = new Tuple<int, long>(currentServer, mask);

            if (this.IntermediateResults.ContainsKey(key))
            {
                return this.IntermediateResults[key];
            }

            bool value = false;
            int neededCapacity;
            for (long submask = mask; submask > 0 && !value; submask = (submask - 1) & mask)
            {
                neededCapacity = 0;

                for (int i = 0; i < this.TaskNeeds.Length; i++)
                {
                    if (((1 << i) & submask) > 0)
                    {
                        neededCapacity += this.TaskNeeds[i];
                    }
                }

                if (neededCapacity <= this.ServerLimits[currentServer])
                {
                    value = value || Solve(currentServer + 1, mask - submask);
                }
            }

            value = value || (Solve(currentServer + 1, mask));

            this.IntermediateResults[key] = value;

            return value;
        }
    }

    [TestClass]
    public class ServersTest
    {
        [TestMethod]
        public void Solve()
        {
            Servers servers = new Servers()
            {
                ServerLimits = new int[] { 8, 16, 8, 32 },
                TaskNeeds = new int[] { 18, 4, 8, 4, 6, 6, 8, 8 }
            };

            Assert.IsTrue(servers.Solve());
        }

        [TestMethod]
        public void Solves()
        {
            Servers servers = new Servers()
            {
                ServerLimits = new int[] { 1, 3 },
                TaskNeeds = new int[] { 4 }
            };

            Assert.IsFalse(servers.Solve());
        }

        [TestMethod]
        public void Solves3()
        {
            Servers servers = new Servers()
            {
                ServerLimits = new int[] { 40, 50, 60, 70, 90 },
                TaskNeeds = new int[] { 20, 15, 42, 66, 5, 23, 55, 23 }
            };

            Assert.IsTrue(servers.Solve());
        }
    }
}

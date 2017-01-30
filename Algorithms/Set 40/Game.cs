using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_40
{
    public enum Player
    {
        Kumar,
        Rajesh
    }

    class Game
    {
        private Dictionary<Tuple<long, Player>, bool> states;

        public Game(long[] kumarMoves, long[] rajeshMoves)
        {
            this.KumarMoves = kumarMoves;
            this.RajeshMoves = rajeshMoves;
            this.states = new Dictionary<Tuple<long, Player>, bool>();
        }

        public long[] KumarMoves { get; private set; }

        public long[] RajeshMoves { get; private set; }

        public Player Solve(long caps)
        {
            return this.Move(caps, Player.Kumar) ? Player.Kumar : Player.Rajesh;
        }

        private bool Move(long caps, Player player)
        {
            if (caps <= 0)
            {
                return false;
            }

            bool value;
            Tuple<long, Player> key = new Tuple<long, Player>(caps, player);

            if (this.states.TryGetValue(key, out value))
            {
                return value;
            }

            value = false;

            long[] moves = player == Player.Kumar ? this.KumarMoves : this.RajeshMoves;
            Player nextPlayer = player == Player.Kumar ? Player.Rajesh : Player.Kumar;

            foreach (long move in moves)
            {
                if (!this.Move(caps - move, nextPlayer))
                {
                    value = true;
                }
            }

            this.states[key] = value;

            return value;
        }
    }
}

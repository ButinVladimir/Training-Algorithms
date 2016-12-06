namespace Algorithms.Set_61
{
    public class CANDY
    {
        public static long Solve(int n, long[] packets)
        {
            long total = 0;
            
            foreach (var packet in packets)
            {
                total += packet;
            }

            if ((total % n) != 0)
            {
                return -1;
            }

            long result = 0, middle = total / n;
            foreach (var packet in packets)
            {
                if (packet > middle)
                {
                    result += packet - middle;
                }
            }

            return result;
        }
    }
}
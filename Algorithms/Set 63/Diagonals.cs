namespace Algorithms.Set_63
{
    using System.Collections;
    using System.Collections.Generic;

    public class Diagonals
    {
        public static IList<string> Solve(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int x, y;

            List<string> result = new List<string>();
            List<string> buffer = new List<string>();

            for (int d = 0; d < n + m - 1; d++)
            {
                buffer.Clear();
                x = n - 1 - d;
                y = 0;

                if (x < 0)
                {
                    y = -x;
                    x = 0;
                }

                while (x < n && y < m)
                {
                    buffer.Add(matrix[x,y].ToString());
                    x++;
                    y++;
                }

                result.Add(string.Join(" ", buffer));
            }

            return result;
        }
    }
}
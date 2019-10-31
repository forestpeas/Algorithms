namespace Algorithms.LeetCode
{
    /* 739. Daily Temperatures
     * 
     * Given a list of daily temperatures T, return a list such that, for each day in the input,
     * tells you how many days you would have to wait until a warmer temperature. If there is no
     * future day for which this is possible, put 0 instead.
     * 
     * For example, given the list of temperatures T = [73, 74, 75, 71, 69, 72, 76, 73], your output
     * should be [1, 1, 4, 2, 1, 1, 0, 0].
     * 
     * Note: The length of temperatures will be in the range [1, 30000]. Each temperature will be an
     * integer in the range [30, 100].
     */
    public class DailyTemperaturesSolution
    {
        public int[] DailyTemperatures(int[] T)
        {
            // We can avoid some unnecessary compares. For example, let i go from right to left:
            // [5, 7, 6, 1, 2, 3, 4, 8]
            //        ↑
            //        i
            // We have to compare 6 with 1, 2, 3, 4, 8 each.
            // [5, 7, 6, 1, 2, 3, 4, 8]
            //     ↑
            //     i
            // Now we just need to compare 7 with 6, then 7 with 8 (jump over all the numbers smaller than 6).
            int[] result = new int[T.Length];

            for (int i = T.Length - 1; i >= 0; i--)
            {
                int j = i + 1;
                while (j < T.Length && T[j] <= T[i])
                {
                    if (result[j] > 0) j += result[j];
                    else j = T.Length;
                }
                result[i] = j < T.Length ? j - i : 0;
            }

            return result;
        }
    }
}

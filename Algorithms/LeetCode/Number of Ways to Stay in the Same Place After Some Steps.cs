namespace Algorithms.LeetCode
{
    /* 1269. Number of Ways to Stay in the Same Place After Some Steps
     * 
     * You have a pointer at index 0 in an array of size arrLen. At each step, you can move 1 position
     * to the left, 1 position to the right in the array or stay in the same place  (The pointer should
     * not be placed outside the array at any time).
     * 
     * Given two integers steps and arrLen, return the number of ways such that your pointer still at
     * index 0 after exactly steps steps.
     * 
     * Since the answer may be too large, return it modulo 10^9 + 7.
     * 
     * Example 1:
     * 
     * Input: steps = 3, arrLen = 2
     * Output: 4
     * Explanation: There are 4 differents ways to stay at index 0 after 3 steps.
     * Right, Left, Stay
     * Stay, Right, Left
     * Right, Stay, Left
     * Stay, Stay, Stay
     * 
     * Example 2:
     * 
     * Input: steps = 2, arrLen = 4
     * Output: 2
     * Explanation: There are 2 differents ways to stay at index 0 after 2 steps
     * Right, Left
     * Stay, Stay
     * 
     * Example 3:
     * 
     * Input: steps = 4, arrLen = 2
     * Output: 8
     */
    public class Number_of_Ways_to_Stay_in_the_Same_Place_After_Some_Steps
    {
        public int NumWays(int steps, int arrLen)
        {
            // dp[i,j] is the number of ways to reach arr[j] after i steps.
            // We can reach arr[j] either from arr[j-1] or arr[j] or arr[j+1].
            // dp[i,j] = dp[i-1,j-1] + dp[i-1,j] + dp[i-1,j+1].
            // To avoid "negative index", we can add a fake column with all zeroes in the left.
            // 0 1 0 0 0
            // 0 1 1 0 0
            // 0 2 2 1 0
            // 0 4 5 3 1
            // ...
            long[] dp = new long[arrLen + 2];
            dp[1] = 1;

            for (int step = 1; step <= steps; step++)
            {
                long last = 0;
                for (int i = 1; i <= arrLen; i++)
                {
                    long tmp = dp[i];
                    dp[i] = last + dp[i] + dp[i + 1];
                    dp[i] = dp[i] % 1000000007;
                    if (dp[i] == 0) break;
                    last = tmp;
                }
            }

            return (int)dp[1];
        }
    }
}

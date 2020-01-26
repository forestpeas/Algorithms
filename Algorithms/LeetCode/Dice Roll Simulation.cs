using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1223. Dice Roll Simulation
     * 
     * A die simulator generates a random number from 1 to 6 for each roll. You introduced a constraint to the generator such that
     * it cannot roll the number i more than rollMax[i] (1-indexed) consecutive times. 
     * Given an array of integers rollMax and an integer n, return the number of distinct sequences that can be obtained with exact
     * n rolls.
     * Two sequences are considered different if at least one element differs from each other. Since the answer may be too large,
     * return it modulo 10^9 + 7.
     * 
     * Example 1:
     * 
     * Input: n = 2, rollMax = [1,1,2,2,2,3]
     * Output: 34
     * Explanation: There will be 2 rolls of die, if there are no constraints on the die, there are 6 * 6 = 36 possible combinations.
     * In this case, looking at rollMax array, the numbers 1 and 2 appear at most once consecutively, therefore sequences (1,1) and
     * (2,2) cannot occur, so the final answer is 36-2 = 34.
     * 
     * Example 2:
     * 
     * Input: n = 2, rollMax = [1,1,1,1,1,1]
     * Output: 30
     * 
     * Example 3:
     * 
     * Input: n = 3, rollMax = [1,1,1,2,2,3]
     * Output: 181
     */
    public class Dice_Roll_Simulation
    {
        public int DieSimulator(int n, int[] rollMax)
        {
            // dp[i][j] is the the number of distinct sequences that ends with j.
            // For example, suppose the max consecutive times for 1 is 2.
            //          1  2  3  4  5  6
            // dp[i-3]: a
            // dp[i-2]: b
            // dp[i-1]: c
            // dp[i]:   d
            // a,b,c,d are numbers from the die. If d is 1, then b and c cannot both be 1,
            // so we must exclude all "branches" where b and c are fixed as 1, in this
            // case, it does not include the case where a is also 1, it only includes
            // dp[i-3][2] ~ dp[i-3][6].
            long mod = 1000000007;
            long[][] dp = new long[n][];
            dp[0] = new long[6] { 1, 1, 1, 1, 1, 1 };
            for (int i = 1; i < n; i++)
            {
                dp[i] = new long[6];
                long sum = dp[i - 1].Sum();
                for (int j = 0; j < 6; j++)
                {
                    dp[i][j] = sum % mod;
                    if (i - rollMax[j] == 0) dp[i][j]--;
                    if (i - rollMax[j] - 1 >= 0)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (k == j) continue;
                            dp[i][j] -= dp[i - rollMax[j] - 1][k];
                            if (dp[i][j] < 0) dp[i][j] += mod;
                        }
                    }
                }
            }

            return (int)(dp[n - 1].Sum() % mod);
        }
    }
}

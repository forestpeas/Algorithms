namespace Algorithms.LeetCode
{
    /* 1259. Handshakes That Don't Cross
     * 
     * You are given an even number of people num_people that stand around a circle and each person
     * shakes hands with someone else, so that there are num_people / 2 handshakes total.
     * Return the number of ways these handshakes could occur such that none of the handshakes cross.
     * 
     * Since this number could be very big, return the answer mod 10^9 + 7
     * 
     * https://leetcode.com/problems/handshakes-that-dont-cross
     */
    public class Handshakes_That_Don_t_Cross
    {
        public int NumberOfWays(int num_people)
        {
            // Let the first person shake hands with 2,4,6,8,...Each time the circle is divided into
            // two sub-problems. Let dp[i] be the answer of i people.
            // dp[n] = dp[0] * dp[n-2] + dp[2] * dp[n-4] + dp[4] * dp[n-6] + ... + dp[n-2] * dp[0]
            // Silimar to the Catalan Number.
            int mod = 1000000007;
            long[] dp = new long[num_people + 1];
            dp[0] = 1;
            for (int i = 2; i <= num_people; i += 2)
            {
                for (int j = 0; j <= i - 2; j += 2)
                {
                    dp[i] += (dp[j] * dp[i - 2 - j]) % mod;
                    dp[i] = dp[i] % mod;
                }
            }
            return (int)dp[num_people];
        }
    }
}

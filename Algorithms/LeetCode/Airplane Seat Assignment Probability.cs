namespace Algorithms.LeetCode
{
    /* 1227. Airplane Seat Assignment Probability
     * 
     * n passengers board an airplane with exactly n seats. The first passenger has lost the ticket and picks a seat randomly. But after that, the rest of passengers will:
     * 
     * Take their own seat if it is still available, 
     * Pick other seats randomly when they find their seat occupied 
     * What is the probability that the n-th person can get his own seat?
     * 
     * Example 1:
     * 
     * Input: n = 1
     * Output: 1.00000
     * Explanation: The first person can only get the first seat.
     * 
     * Example 2:
     * 
     * Input: n = 2
     * Output: 0.50000
     * Explanation: The second person has a probability of 0.5 to get the second seat (when first person gets the first seat).
     */
    public class Airplane_Seat_Assignment_Probability
    {
        // Inspired by https://leetcode.com/problems/airplane-seat-assignment-probability/discuss/407781/Proof-by-mathematical-induction-that-answer-is-12-when-n-greater-2.
        // 1/n is the probability of the first person taking his own seat (the first seat).
        // 1/n is the probability of the first person taking the second seat. In this case,
        // the second person has the same choices as the first person (n=n-1).
        // 1/n is the probability of the first person taking the third seat. In this case,
        // the second person has only one choice: taking his own seat (the second seat),
        // but the third person has the same choices as the first person(n=n-2).
        // ...
        // So P(n) = 1/n + 1/n*(P(n-1)+P(n-2)+P(n-3)+...+P(2)), n > 2
        public double NthPersonGetsNthSeat1(int n)
        {
            double[] dp = new double[n + 1];
            dp[1] = 1.0;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = 1.0 / i;
                for (int j = i - 1; j >= 2; j--)
                {
                    dp[i] += 1.0 / i * dp[j];
                }
            }

            return dp[n];
        }

        public double NthPersonGetsNthSeat(int n)
        {
            // (n-2)/2 is the probability of the first person taking a seat other than the
            // first and the last. But I don't really understand this solution. It seems like
            // that it assumes the conclusion(all answers except n=1 are the same) first.
            if (n == 1) return 1.0;
            return 1.0 / n + (n - 2.0) / n * NthPersonGetsNthSeat(n - 1);
        }

        public double NthPersonGetsNthSeat3(int n)
        {
            // We can list all cases when n=3,n=4,n=5, and find the answer are all 0.5.
            // We can prove it by mathematical induction.
            return n == 1 ? 1.0 : 0.5;
        }
    }
}

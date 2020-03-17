namespace Algorithms.LeetCode
{
    /* 1359. Count All Valid Pickup and Delivery Options
     * 
     * Given n orders, each order consist in pickup and delivery services. 
     * 
     * Count all valid pickup/delivery possible sequences such that delivery(i)
     * is always after of pickup(i). 
     * 
     * Since the answer may be too large, return it modulo 10^9 + 7.
     * 
     * Example 1:
     * 
     * Input: n = 1
     * Output: 1
     * Explanation: Unique order (P1, D1), Delivery 1 always is after of Pickup 1.
     * 
     * Example 2:
     * 
     * Input: n = 2
     * Output: 6
     * Explanation: All possible orders: 
     * (P1,P2,D1,D2), (P1,P2,D2,D1), (P1,D1,P2,D2), (P2,P1,D1,D2), (P2,P1,D2,D1) and (P2,D2,P1,D1).
     * This is an invalid order (P1,D2,P2,D1) because Pickup 2 is after of Delivery 2.
     * Example 3:
     * 
     * Input: n = 3
     * Output: 90
     */
    public class Count_All_Valid_Pickup_and_Delivery_Options
    {
        private const int mod = 1000000007;

        public int CountOrders(int n)
        {
            // Let F(n) be the answer.
            // Assume we have F(3) and we want to know F(4).
            // Let's take one sequence from "F(1,2,3)", now we can put P4 in the front,
            // and insert D4 in any position of the sequence, and the number of these
            // positions is (n - 1) * 2 + 1. Likewise, we can also put P3 in the front,
            // and insert D4 in any position of a sequence from "F(1,2,4)". So, we need
            // to multiply the result by n.
            // F(n) = F(n-1)*(2n-1)*n
            if (n == 1) return 1;
            long result = (long)CountOrders(n - 1) * ((n - 1) * 2 + 1) * n;
            return (int)(result % mod);
        }
    }
}

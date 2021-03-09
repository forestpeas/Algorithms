namespace Algorithms.LeetCode
{
    /* 633. Sum of Square Numbers
     * 
     * Given a non-negative integer c, decide whether there're two integers a and b such that a2 + b2 = c.
     * 
     * Example 1:
     * 
     * Input: c = 5
     * Output: true
     * Explanation: 1 * 1 + 2 * 2 = 5
     * 
     * Example 2:
     * 
     * Input: c = 3
     * Output: false
     * 
     * Example 3:
     * 
     * Input: c = 4
     * Output: true
     * 
     * Example 4:
     * 
     * Input: c = 2
     * Output: true
     * 
     * Example 5:
     * 
     * Input: c = 1
     * Output: true
     */
    public class Sum_of_Square_Numbers
    {
        public bool JudgeSquareSum(int c)
        {
            for (long i = 0; i * i <= c; i++)
            {
                if (IsPerfectSquare((int)(c - i * i))) return true;
            }
            return false;
        }

        public bool IsPerfectSquare(int num)
        {
            // 367. Valid Perfect Square
            int lo = 0;
            int hi = 46341; // Sqrt(int.MaxValue) + 1
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int square = mid * mid;
                if (square > num)
                {
                    hi = mid;
                }
                else if (square < num)
                {
                    lo = mid + 1;
                }
                else return true;
            }
            return false;
        }
    }
}

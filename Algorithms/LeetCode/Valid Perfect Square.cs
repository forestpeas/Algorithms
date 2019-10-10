namespace Algorithms.LeetCode
{
    /* 367. Valid Perfect Square
     * 
     * Given a positive integer num, write a function which returns True if num is a perfect square else False.
     * 
     * Note: Do not use any built-in library function such as sqrt.
     * 
     * Example 1:
     * 
     * Input: 16
     * Output: true
     * 
     * Example 2:
     * 
     * Input: 14
     * Output: false
     */
    public class ValidPerfectSquare
    {
        public bool IsPerfectSquare(int num)
        {
            // Almost exactly the same as "69. Sqrt(x)".
            if (num <= 0) return false;

            int lo = 1;
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

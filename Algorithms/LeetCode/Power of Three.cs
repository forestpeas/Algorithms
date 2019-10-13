namespace Algorithms.LeetCode
{
    /* 326. Power of Three
     * 
     * Given an integer, write a function to determine if it is a power of three.
     * 
     * Example 1:
     * 
     * Input: 27
     * Output: true
     * 
     * Example 2:
     * 
     * Input: 0
     * Output: false
     * 
     * Example 3:
     * 
     * Input: 9
     * Output: true
     * 
     * Example 4:
     * 
     * Input: 45
     * Output: false
     * 
     * Follow up:
     * Could you do it without using any loop / recursion?
     */
    public class PowerOfThree
    {
        public bool IsPowerOfThree(int n)
        {
            // From "Approach 4: Integer Limitations" of https://leetcode.com/articles/power-of-three/.
            // 1162261467 is 3^19, the max power of three that an integer can represent.(3^20 > int.MaxValue)
            // What are the numbers that are divisible by 3^19?
            // 3 * 3 * 3 *...*3 / ?
            // The denominator can only be 3, or 3 * 3, or 3 * 3 * 3,...
            // which are 3^1, 3^2, 3^3, 3^4,...,3^19.
            // Another approach: Convert to base 3 string representation and check whether it matches "10*".
            // (Think about "Power of 10" in decimal.)
            return n > 0 && 1162261467 % n == 0;
        }
    }
}

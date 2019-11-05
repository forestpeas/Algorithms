namespace Algorithms.LeetCode
{
    /* 258. Add Digits
     * 
     * Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
     * 
     * Example:
     * 
     * Input: 38
     * Output: 2 
     * Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. 
     *              Since 2 has only one digit, return it.
     * 
     * Follow up:
     * Could you do it without any loop/recursion in O(1) runtime?
     */
    public class AddDigitsSolution
    {
        public int AddDigits(int num)
        {
            // Inspired by https://leetcode.com/problems/add-digits/discuss/68580/Accepted-C%2B%2B-O(1)-time-O(1)-space-1-Line-Solution-with-Detail-Explanations
            // The results occur periodically :
            //  input: 1 2 3 4 5 6 7 8 9 10 11 12 13 ...       19 20 21...
            // output: 1 2 3 4 5 6 7 8 9 1  2  3  4  5 6 7 8 9 1  2  3 ....
            if (num == 0) return 0;
            return num % 9 == 0 ? 9 : num % 9;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 357. Count Numbers with Unique Digits
     * 
     * Given a non-negative integer n, count all numbers with unique digits, x, where 0 ≤ x < 10^n.
     * 
     * Example:
     * 
     * Input: 2
     * Output: 91 
     * Explanation: The answer should be the total numbers in the range of 0 ≤ x < 100, 
     *              excluding 11,22,33,44,55,66,77,88,99
     * 
     * Constraints:
     * 0 <= n <= 8
     */
    public class Count_Numbers_with_Unique_Digits
    {
        public int CountNumbersWithUniqueDigits(int n)
        {
            // Let f(k) = count of numbers with unique digits with length equals k.
            // With the knowledge of combinations, we have 9 choices in the first digit, and 8 choices
            // in the second digit...
            // f(1) = 10
            // f(2) = 9 * 9
            // f(3) = 9 * 9 * 8
            // f(k) = 9 * 9 * 8 * ... (9 - n + 2)
            if (n == 0) return 1;
            int res = 10, fk = 9, k = 9;
            while (k >= 9 - n + 2)
            {
                fk *= k;
                res += fk;
                k--;
            }
            return res;
        }
    }
}

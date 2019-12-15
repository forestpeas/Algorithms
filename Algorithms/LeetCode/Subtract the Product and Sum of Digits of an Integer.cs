namespace Algorithms.LeetCode
{
    /* 1281. Subtract the Product and Sum of Digits of an Intege
     * 
     * Given an integer number n, return the difference between the product of its
     * digits and the sum of its digits.
     * 
     * Example 1:
     * 
     * Input: n = 234
     * Output: 15 
     * Explanation: 
     * Product of digits = 2 * 3 * 4 = 24 
     * Sum of digits = 2 + 3 + 4 = 9 
     * Result = 24 - 9 = 15
     * 
     * Example 2:
     * 
     * Input: n = 4421
     * Output: 21
     * Explanation: 
     * Product of digits = 4 * 4 * 2 * 1 = 32 
     * Sum of digits = 4 + 4 + 2 + 1 = 11 
     * Result = 32 - 11 = 21
     */
    public class Subtract_the_Product_and_Sum_of_Digits_of_an_Integer
    {
        public int SubtractProductAndSum(int n)
        {
            var str = n.ToString();
            int p = 1;
            int s = 0;
            foreach (char c in str)
            {
                int digit = c - '0';
                p *= digit;
                s += digit;
            }
            return p - s;
        }
    }
}

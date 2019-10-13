namespace Algorithms.LeetCode
{
    /* 306. Additive Number
     * 
     * Additive number is a string whose digits can form additive sequence.
     * 
     * A valid additive sequence should contain at least three numbers. Except for the first two numbers, each
     * subsequent number in the sequence must be the sum of the preceding two.
     * 
     * Given a string containing only digits '0'-'9', write a function to determine if it's an additive number.
     * 
     * Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.
     * 
     * Example 1:
     * 
     * Input: "112358"
     * Output: true
     * Explanation: The digits can form an additive sequence: 1, 1, 2, 3, 5, 8. 
     *              1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
     * 
     * Example 2:
     * 
     * Input: "199100199"
     * Output: true
     * Explanation: The additive sequence is: 1, 99, 100, 199. 
     *              1 + 99 = 100, 99 + 100 = 199
     * 
     * Constraints:
     * num consists only of digits '0'-'9'.
     * 1 <= num.length <= 35
     * 
     * Follow up:
     * How would you handle overflow for very large input integers?
     */
    public class AdditiveNumber
    {
        public bool IsAdditiveNumber(string num)
        {
            // Just try all possibilities for the first two numbers and check whether the rest fits.
            // Because if we try other possibilities for the other numbers, we will break the rule.
            // The only numbers that we can change without breaking the rule are the first two.
            // Use BigInteger to handle overflow for very large input integers.
            long n1 = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (i > 0 && n1 == 0) break; // No leading zeroes.
                n1 = n1 * 10 + (num[i] - '0');
                long n2 = 0;
                for (int j = i + 1; j < num.Length; j++)
                {
                    if (j > i + 1 && n2 == 0) break; // No leading zeroes.
                    n2 = n2 * 10 + (num[j] - '0');
                    if (IsAdditiveNumber(num, j + 1, n1, n2)) return true;
                }
            }

            return false;
        }

        private bool IsAdditiveNumber(string num, int i, long n1, long n2)
        {
            if (i >= num.Length) return false; // At least three numbers.

            while (i < num.Length)
            {
                long sum = n1 + n2;
                string sumStr = sum.ToString();
                if (i + sumStr.Length > num.Length) return false;
                if (num.Substring(i, sumStr.Length) != sumStr) return false;

                i += sumStr.Length;
                n1 = n2;
                n2 = sum;
            }

            return true;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 371. Sum of Two Integers
     * 
     * Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.
     * 
     * Example 1:
     * 
     * Input: a = 1, b = 2
     * Output: 3
     * 
     * Example 2:
     * 
     * Input: a = -2, b = 3
     * Output: 1
     */
    public class SumOfTwoIntegers
    {
        public int GetSum(int a, int b)
        {
            // If we want to add 2 bits:
            //   | 0 1
            // -------
            // 0 | 0 1
            // 1 | 1 0
            // This is exactly XOR, except that 1 + 1 results in a carry.
            // So (a ^ b )is "a plus b without carry", and we have to save
            // the carry bits using & operator.
            // For example:
            // a = 0001, b = 0011
            // a = 0010, b = 0010 // Now a contains the sum without carry, b only contains the carry bits.
            // a = 0100, b = 0000 // No more carry.
            // Fortunately, this also works for negatives because negatives are represented as two's complement
            // and two's complement is designed to add integers in the same way regardless of positive or negative. 
            while (b != 0)
            {
                int carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }

            return a;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 476. Number Complement
     * 
     * Given a positive integer num, output its complement number. The complement
     * strategy is to flip the bits of its binary representation.
     * 
     * Example 1:
     * 
     * Input: num = 5
     * Output: 2
     * Explanation: The binary representation of 5 is 101 (no leading zero bits),
     * and its complement is 010. So you need to output 2.
     * 
     * Example 2:
     * 
     * Input: num = 1
     * Output: 0
     * Explanation: The binary representation of 1 is 1 (no leading zero bits),
     * and its complement is 0. So you need to output 0.
     */
    public class Number_Complement
    {
        public int FindComplement(int num)
        {
            // Remove the leading 1's from ~num.
            int complement = ~num;
            int mask = 1 << 31;
            while ((complement & mask) != 0)
            {
                complement &= ~mask;
                mask >>= 1;
            }
            return complement;
        }
    }
}

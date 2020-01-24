namespace Algorithms.LeetCode
{
    /* 342. Power of Four
     * 
     * Given an integer (signed 32 bits), write a function to check whether it is a power of 4.
     * 
     * Example 1:
     * 
     * Input: 16
     * Output: true
     * 
     * Example 2:
     * 
     * Input: 5
     * Output: false
     * 
     * Follow up: Could you solve it without loops/recursion?
     */
    public class Power_of_Four
    {
        public bool IsPowerOfFour(int num)
        {
            // Power of 4 only have one '1' bit in their binary representation and are in the odd positions.
            return num > 0 && (num & (num - 1)) == 0 && (num & 0b01010101010101010101010101010101) != 0;
        }
    }
}

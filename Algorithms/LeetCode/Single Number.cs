namespace Algorithms.LeetCode
{
    /* 136. Single Number
     * 
     * Given a non-empty array of integers, every element appears twice except for one. Find that single one.
     * 
     * Note:
     * Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
     * 
     * Example 1:
     * 
     * Input: [2,2,1]
     * Output: 1
     * 
     * Example 2:
     * 
     * Input: [4,1,2,1,2]
     * Output: 4
     */
    public class SingleNumberSolution
    {
        public int SingleNumber(int[] nums)
        {
            // XOR a number with itself is 0, and XOR is commutative, and XOR a number with 0 is itself.
            // So two same numbers will cancel out.
            int result = 0;
            foreach (int num in nums)
            {
                result = result ^ num;
            }
            return result;
        }
    }
}

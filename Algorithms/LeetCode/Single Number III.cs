namespace Algorithms.LeetCode
{
    /* 260. Single Number III
     * 
     * Given an array of numbers nums, in which exactly two elements appear only once and all
     * the other elements appear exactly twice. Find the two elements that appear only once.
     * 
     * Example:
     * 
     * Input:  [1,2,1,3,2,5]
     * Output: [3,5]
     * 
     * Note:
     * The order of the result is not important. So in the above example, [5, 3] is also correct.
     * Your algorithm should run in linear runtime complexity. Could you implement it using only
     * constant space complexity?
     */
    public class SingleNumberIII
    {
        public int[] SingleNumber(int[] nums)
        {
            // I think the solution is very tricky.
            // Example：nums = [1,2,1,3,2,5], result is [3,5].
            // 3 = 011
            // 5 = 101
            // 3 ^ 5 = 110
            // This means the second bit of 3 and 5 is different.
            // All the numbers whose second bit is 1:
            // 2 = 010
            // 3 = 011
            // 2 = 010
            // All the numbers whose second bit is 0:
            // 1 = 001
            // 1 = 001
            // 5 = 101
            // I don't know if this solution can be generalized to "N numbers appears only once", maybe not.
            int a = 0, b = 0;// These are the two distinct numbers.
            int aXorb = 0;
            foreach (int num in nums)
            {
                aXorb ^= num;
            }

            int oneSetBit = aXorb & -aXorb; // A little trick to get the rightmost bit "1".
            foreach (int num in nums)
            {
                if ((num & oneSetBit) == 0)
                {
                    a ^= num;
                }
                else
                {
                    b ^= num;
                }
            }
            return new int[] { a, b };
        }
    }
}

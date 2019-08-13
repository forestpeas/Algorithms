namespace Algorithms.LeetCode
{
    /* 268. Missing Number
     * 
     * Given an array containing n distinct numbers taken from 0, 1, 2, ..., n,
     * find the one that is missing from the array.
     * 
     * Example 1:
     * 
     * Input: [3,0,1]
     * Output: 2
     * 
     * Example 2:
     * 
     * Input: [9,6,4,2,3,5,7,0,1]
     * Output: 8
     * 
     * Note:
     * Your algorithm should run in linear runtime complexity.
     * Could you implement it using only constant extra space complexity?
     */
    public class MissingNumberSolution
    {
        public int MissingNumber(int[] nums)
        {
            // Calculate sum=0+1+2+3+...+n
            int sum = (1 + nums.Length) * nums.Length / 2;
            int total = 0;
            foreach (int num in nums)
            {
                total += num;
            }
            return sum - total;
        }
    }
}

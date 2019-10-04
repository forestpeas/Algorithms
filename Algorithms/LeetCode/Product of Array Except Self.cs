namespace Algorithms.LeetCode
{
    /* 238. Product of Array Except Self
     * 
     * Given an array nums of n integers where n > 1,  return an array output such that output[i]
     * is equal to the product of all the elements of nums except nums[i].
     * 
     * Example:
     * 
     * Input:  [1,2,3,4]
     * Output: [24,12,8,6]
     * Note: Please solve it without division and in O(n).
     * 
     * Follow up:
     * Could you solve it with constant space complexity? (The output array does not count as extra
     * space for the purpose of space complexity analysis.)
     */
    public class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            // For example, nums is:
            // 2, 3, 4, 5
            // First we calculate from left: left[i] = nums[0] * nums[1] * ... * nums[i - 1]
            // 1, 2, 6, 24
            // Then we calculate from right: right[i] = nums[i + 1] * nums[i + 2] * ... * nums[length - 1]
            // 60, 20, 5, 1
            // So result[i] = left[i] * right[i]
            // 60, 40, 30, 24
            int[] result = new int[nums.Length];
            result[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            int productFromRight = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= productFromRight;
                productFromRight *= nums[i];
            }

            return result;
        }
    }
}

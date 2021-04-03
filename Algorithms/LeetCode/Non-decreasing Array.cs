namespace Algorithms.LeetCode
{
    /* 665. Non-decreasing Array
     * 
     * Given an array nums with n integers, your task is to check if it could become non-decreasing by
     * modifying at most one element.
     * 
     * We define an array is non-decreasing if nums[i] <= nums[i + 1] holds for every i (0-based) such
     * that (0 <= i <= n - 2).
     * 
     * Example 1:
     * 
     * Input: nums = [4,2,3]
     * Output: true
     * Explanation: You could modify the first 4 to 1 to get a non-decreasing array.
     * 
     * Example 2:
     * 
     * Input: nums = [4,2,1]
     * Output: false
     * Explanation: You can't get a non-decreasing array by modify at most one element.
     */
    public class Non_decreasing_Array
    {
        public bool CheckPossibility(int[] nums)
        {
            int modified = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (modified++ > 0) return false;
                    if (i - 1 < 0 || nums[i - 1] <= nums[i + 1]) nums[i] = nums[i + 1];
                    else nums[i + 1] = nums[i];
                }
            }
            return true;
        }

        public bool CheckPossibility2(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return Check(i) || Check(i + 1);
                }
            }
            return true;

            bool Check(int exclude)
            {
                int prev = int.MinValue;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == exclude) continue;
                    if (nums[i] < prev)
                    {
                        return false;
                    }
                    prev = nums[i];
                }
                return true;
            }
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 41. First Missing Positive
     * 
     * Given an unsorted integer array, find the smallest missing positive integer.
     * 
     * Example 1:
     * 
     * Input: [1,2,0]
     * Output: 3
     * Example 2:
     * 
     * Input: [3,4,-1,1]
     * Output: 2
     * Example 3:
     * 
     * Input: [7,8,9,11,12]
     * Output: 1
     * Note:
     * 
     * Your algorithm should run in O(n) time and uses constant extra space.
     */
    public class FirstMissingPositiveSolution
    {
        // Your runtime beats 99.56 % of csharp submissions.
        // Your memory usage beats 25.76 % of csharp submissions.
        public int FirstMissingPositive(int[] nums)
        {
            // Because the description requires us to use constant space, we have to use the input array
            // to record some progress.
            // We put every number in its "appropriate" position, that is, put i in nums[i - 1].
            // For example, we put 4 in nums[3], 3 in nums[2].
            // After that, the first "inappropriate" number's position is the expected result.
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (num <= nums.Length && (num - 1) != i)
                {
                    while (num <= nums.Length && num > 0)
                    {
                        int next = nums[num - 1];
                        if (next == num) break;
                        nums[num - 1] = num;
                        num = next;
                    }
                }
            }

            int j = 0;
            for (; j < nums.Length; j++)
            {
                if (nums[j] - 1 != j)
                {
                    return j + 1;
                }
            }
            return j + 1;
        }
    }
}

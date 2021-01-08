using System.Linq;

namespace Algorithms.LeetCode
{
    /* 503. Next Greater Element II
     * 
     * Given a circular array (the next element of the last element is the first element of the array),
     * print the Next Greater Number for every element. The Next Greater Number of a number x is the
     * first greater number to its traversing-order next in the array, which means you could search
     * circularly to find its next greater number. If it doesn't exist, output -1 for this number.
     * 
     * Example 1:
     * Input: [1,2,1]
     * Output: [2,-1,2]
     * Explanation: The first 1's next greater number is 2; 
     * The number 2 can't find next greater number; 
     * The second 1's next greater number needs to search circularly, which is also 2.
     */
    public class Next_Greater_Element_II
    {
        public int[] NextGreaterElements(int[] nums)
        {
            // Find the max number first, and the rest is the same as "739. Daily Temperatures".
            if (nums.Length == 0) return new int[0];
            int max = int.MinValue, maxId = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxId = i;
                }
            }

            int[] res = new int[nums.Length];
            res[maxId] = -1;
            for (int i = maxId == 0 ? nums.Length - 1 : maxId - 1; i != maxId;)
            {
                int j = (i + 1) % nums.Length;
                while (j != maxId + 1 && j >= 0 && nums[j] <= nums[i])
                {
                    j = res[j];
                }
                res[i] = j;
                i = i == 0 ? nums.Length - 1 : i - 1;
            }
            return res.Select(i => i >= 0 ? nums[i] : -1).ToArray();
        }
    }
}

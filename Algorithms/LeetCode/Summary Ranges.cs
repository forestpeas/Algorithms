using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 228. Summary Ranges
     * 
     * Given a sorted integer array without duplicates, return the summary of its ranges.
     * 
     * Example 1:
     * 
     * Input:  [0,1,2,4,5,7]
     * Output: ["0->2","4->5","7"]
     * Explanation: 0,1,2 form a continuous range; 4,5 form a continuous range.
     * 
     * Example 2:
     * 
     * Input:  [0,2,3,4,6,8,9]
     * Output: ["0","2->4","6","8->9"]
     * Explanation: 2,3,4 form a continuous range; 8,9 form a continuous range.
     */
    public class SummaryRangesSolution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length < 1) return new string[0];

            var result = new List<string>();
            string range = nums[0].ToString();
            int start = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i + 1 == nums.Length || nums[i + 1] != nums[i] + 1)
                {
                    if (nums[i] != start) range = range + "->" + nums[i];
                    result.Add(range);
                    if (i + 1 == nums.Length) break;
                    range = nums[i + 1].ToString();
                    start = nums[i + 1];
                }
            }

            return result;
        }
    }
}

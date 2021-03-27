using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 659. Split Array into Consecutive Subsequences
     * 
     * Given an integer array nums that is sorted in ascending order, return true if and only if
     * you can split it into one or more subsequences such that each subsequence consists of
     * consecutive integers and has a length of at least 3.  
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,3,3,4,5]
     * Output: true
     * Explanation:
     * You can split them into two consecutive subsequences : 
     * 1, 2, 3
     * 3, 4, 5
     * 
     * Example 2:
     * 
     * Input: nums = [1,2,3,3,4,4,5,5]
     * Output: true
     * Explanation:
     * You can split them into two consecutive subsequences : 
     * 1, 2, 3, 4, 5
     * 3, 4, 5
     * 
     * Example 3:
     * 
     * Input: nums = [1,2,3,4,4,5]
     * Output: false
     */
    public class Split_Array_into_Consecutive_Subsequences
    {
        public bool IsPossible(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                counts[num] = counts.GetValueOrDefault(num) + 1;
            }

            // endCounts[num] means the number of created sequences that end with "num"
            // first we try to put a number to the end of a created sequence. If there
            // is no such appropriate sequence, we create a new sequence.
            var endCounts = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (counts[num] == 0) continue;
                counts[num]--;
                if (endCounts.GetValueOrDefault(num - 1) > 0)
                {
                    endCounts[num - 1]--;
                    endCounts[num] = endCounts.GetValueOrDefault(num) + 1;
                }
                else if (counts.GetValueOrDefault(num + 1) > 0 && counts.GetValueOrDefault(num + 2) > 0)
                {
                    counts[num + 1]--;
                    counts[num + 2]--;
                    endCounts[num + 2] = endCounts.GetValueOrDefault(num + 2) + 1;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}

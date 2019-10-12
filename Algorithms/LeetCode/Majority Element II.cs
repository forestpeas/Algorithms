using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 229. Majority Element II
     *
     * Given an integer array of size n, find all elements that appear more than ⌊n/3⌋ times.
     * 
     * Note: The algorithm should run in linear time and in O(1) space.
     * 
     * Example 1:
     * 
     * Input: [3,2,3]
     * Output: [3]
     * Example 2:
     * 
     * Input: [1,1,1,3,3,2,2,2]
     * Output: [1,2]
     */
    public class MajorityElementII
    {
        public IList<int> MajorityElement(int[] nums)
        {
            // A mathematical extension of the Boyer-Moore Voting Algorithm of "169. Majority Element".
            // The numbers with the same value are a team, each number votes for its own team. At any
            // time, there can be only 2 candidates for the final win. If a number's team is a candidate,
            // it can upvote it by 1. If a number's team is not a candidate, it can downvote both candidates
            // by 1. If a candidate's vote becomes 0, the next number can take it over.
            // I think why this algorithm works is a matter of mathematical problem and needs further proof.
            int count1 = 0;
            int candidate1 = 0;
            int count2 = 0;
            int candidate2 = 1;

            foreach (int num in nums)
            {
                if (num == candidate1) count1++;
                else if (num == candidate2) count2++;
                else
                {
                    if (count1 == 0)
                    {
                        candidate1 = num;
                        count1 = 1;
                    }
                    else if (count2 == 0)
                    {
                        candidate2 = num;
                        count2 = 1;
                    }
                    else
                    {
                        count1--;
                        count2--;
                    }
                }
            }

            var result = new List<int>();
            count1 = 0;
            count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1) count1++;
                else if (num == candidate2) count2++;
            }
            if (count1 > nums.Length / 3) result.Add(candidate1);
            if (count2 > nums.Length / 3) result.Add(candidate2);
            return result;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 169. Majority Element
     * 
     * Given an array of size n, find the majority element. The majority element is the element
     * that appears more than n/2 times.
     * 
     * You may assume that the array is non-empty and the majority element always exist in the array.
     * 
     * Example 1:
     * 
     * Input: [3,2,3]
     * Output: 3
     * 
     * Example 2:
     * 
     * Input: [2,2,1,1,1,2,2]
     * Output: 2
     */
    public class MajorityElementSolution
    {
        public int MajorityElement(int[] nums)
        {
            // From "Approach 6: Boyer-Moore Voting Algorithm" of https://leetcode.com/articles/majority-element/.
            // Short summary: 
            // When count is 0, discard all the previously visited elements and select the current element
            // as the candidate. We always discard more(or equal) minority elements than majority elements.
            // Examples:
            // When majority element is 7: [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
            // When majority element is 5: [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 5, 5, 5, 5]
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }

            return candidate;
        }
    }
}

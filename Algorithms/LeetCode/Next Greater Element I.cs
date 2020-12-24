using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 496. Next Greater Element I
     * 
     * You are given two arrays (without duplicates) nums1 and nums2 where nums1’s elements
     * are subset of nums2. Find all the next greater numbers for nums1's elements in the
     * corresponding places of nums2.
     * 
     * The Next Greater Number of a number x in nums1 is the first greater number to its
     * right in nums2. If it does not exist, output -1 for this number.
     * 
     * Example 1:
     * Input: nums1 = [4,1,2], nums2 = [1,3,4,2].
     * Output: [-1,3,-1]
     * Explanation:
     *     For number 4 in the first array, you cannot find the next greater number for it
     *     in the second array, so output -1.
     *     For number 1 in the first array, the next greater number for it in the second 
     *     array is 3.
     *     For number 2 in the first array, there is no next greater number for it in the
     *     second array, so output -1.
     *     
     * Example 2:
     * Input: nums1 = [2,4], nums2 = [1,2,3,4].
     * Output: [3,-1]
     * Explanation:
     *     For number 2 in the first array, the next greater number for it in the second 
     *     array is 3.
     *     For number 4 in the first array, there is no next greater number for it in the
     *     second array, so output -1.
     */
    public class Next_Greater_Element_I
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            // same as "739. Daily Temperatures"
            var map = new Dictionary<int, int>();
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                int j = i + 1;
                while (j < nums2.Length && nums2[j] <= nums2[i])
                {
                    if (map[nums2[j]] > 0) j = map[nums2[j]];
                    else break;
                }
                map.Add(nums2[i], j);
            }

            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                int pos2 = map[nums1[i]];
                res[i] = pos2 == nums2.Length ? -1 : nums2[pos2];
            }
            return res;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 349. Intersection of Two Arrays
     * 
     * Given two arrays, write a function to compute their intersection.
     * 
     * Example 1:
     * 
     * Input: nums1 = [1,2,2,1], nums2 = [2,2]
     * Output: [2]
     * 
     * Example 2:
     * 
     * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
     * Output: [9,4]
     * Note:
     * 
     * Each element in the result must be unique.
     * The result can be in any order.
     */
    public class IntersectionOfTwoArrays
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>(nums1);
            var result = new HashSet<int>();
            foreach (int num in nums2)
            {
                if (set1.Contains(num))
                {
                    result.Add(num);
                }
            }
            return result.ToArray();
        }
    }
}

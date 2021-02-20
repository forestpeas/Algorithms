namespace Algorithms.LeetCode
{
    /* 540. Single Element in a Sorted Array
     * 
     * You are given a sorted array consisting of only integers where every element
     * appears exactly twice, except for one element which appears exactly once.
     * Find this single element that appears only once.
     * 
     * Follow up: Your solution should run in O(log n) time and O(1) space.
     * 
     * Example 1:
     * 
     * Input: nums = [1,1,2,3,3,4,4,8,8]
     * Output: 2
     * Example 2:
     * 
     * Input: nums = [3,3,7,7,10,11,11]
     * Output: 10
     */
    public class Single_Element_in_a_Sorted_Array
    {
        public int SingleNonDuplicate(int[] nums)
        {
            int lo = 0, hi = nums.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] == nums[mid - 1])
                {
                    mid--;
                }
                else if (nums[mid] != nums[mid + 1])
                {
                    return nums[mid];
                }
                if (mid % 2 == 0) // number of elements from index 0 to mid-1
                {
                    lo = mid + 2;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return nums[lo];
        }

        public int SingleNonDuplicate2(int[] nums)
        {
            int res = 0;
            foreach (int num in nums)
            {
                res ^= num;
            }
            return res;
        }
    }
}

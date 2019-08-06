namespace Algorithms.LeetCode
{
    /* 27. Remove Element
     * 
     * Given an array nums and a value val, remove all instances of that value in-place and return the new length.
     * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
     * The order of elements can be changed. It doesn't matter what you leave beyond the new length.
     * 
     * Example 1:
     * 
     * Given nums = [3,2,2,3], val = 3,
     * Your function should return length = 2, with the first two elements of nums being 2.
     * It doesn't matter what you leave beyond the returned length.
     * 
     * Example 2:
     * 
     * Given nums = [0,1,2,2,3,0,4,2], val = 2,
     * Your function should return length = 5, with the first five elements of nums containing 0, 1, 3, 0, and 4.
     * Note that the order of those five elements can be arbitrary.
     * It doesn't matter what values are set beyond the returned length.
     */
    public class RemoveElementSolution
    {
        public int RemoveElement(int[] nums, int val)
        {
            // Similar to "problem 26. Remove Duplicates from Sorted Array"
            // Two Pointers - i is the slow-runner and j is the fast-runner.
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i++] = nums[j];
                }
            }
            return i;
        }

        // Consider when nums=[4,1,2,3,5],val=4.
        // Also notice that "the order of elements can be changed".
        // So we can just let nums[0] = nums[4], thus getting [5,1,2,3,5].
        // This can avoid many copy operations.
        public int RemoveElementWhenTargetIsRare(int[] nums, int val)
        {
            int i = 0;
            int n = nums.Length;
            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[n - 1];
                    n--;
                }
                else
                {
                    i++;
                }
            }
            return n;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 283. Move Zeroes
     * 
     * Given an array nums, write a function to move all 0's to the end of it while
     * maintaining the relative order of the non-zero elements.
     * 
     * Example:
     * 
     * Input: [0,1,0,3,12]
     * Output: [1,3,12,0,0]
     * 
     * Note:
     * You must do this in-place without making a copy of the array.
     * Minimize the total number of operations.
     */
    public class MoveZeroesSolution
    {
        public void MoveZeroes(int[] nums)
        {
            // Move all the non-zero numbers to the beginning, then fill the end with 0.
            // Example : 1,0,2,0,0,5 -> 1,2,5,0,0,5 -> 1,2,5,0,0,0
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            for (; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        public void MoveZeroes2(int[] nums)
        {
            // Approach 2
            // i is the slow-runner, j is the fast-runner.
            // When we encounter the first 0, we set i point to this 0, and continue moving j forword.
            // When j encounters a non-zero, swap i and j, and "i++" so that i points to the next 0
            // ready to be swapped in the future.
            // Example 1: 1,0,2,3,4,5 -> 1,2,0,3,4,5 -> 1,2,3,0,4,5 -> 1,2,3,4,0,5 -> 1,2,3,4,5,0
            // Example 2: 1,0,0,0,4,5 -> 1,4,0,0,0,5 -> 1,4,5,0,0,0
            int i = 0, j = 0;
            while (j < nums.Length)
            {
                if (nums[j] != 0)
                {
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                    i++;
                }

                j++;
            }
        }
    }
}

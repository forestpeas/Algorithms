namespace Algorithms.LeetCode
{
    /* 75. Sort Colors
     * 
     * Given an array with n objects colored red, white or blue, sort them in-place so that 
     * objects of the same color are adjacent, with the colors in the order red, white and blue.
     * Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
     * Note: You are not suppose to use the library's sort function for this problem.
     * 
     * Follow up:
     * A rather straight forward solution is a two-pass algorithm using counting sort.
     * First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number 
     * of 0's, then 1's and followed by 2's.
     * Could you come up with a one-pass algorithm using only constant space?
     * 
     * Example:
     * 
     * Input: [2,0,2,1,1,0]
     * Output: [0,0,1,1,2,2]
     */
    public class SortColorsSolution
    {
        public void SortColors(int[] nums)
        {
            // The idea is that we throw "0"s to the start and throw "2"s to the end.
            // When "0" is met, we swap it with the leftmost "1". For example:
            // [0,1,1,1,1,0] becomes:
            // [0,0,1,1,1,1]
            int end = nums.Length - 1; // points to a candidate to swap with a "2"
            int start = -1; // points to the leftmost "1"
            for (int i = 0; i <= end;)
            {
                if (nums[i] == 0)
                {
                    if (start != -1)
                    {
                        nums[i] = 1;
                        nums[start] = 0;
                        start++;
                    }
                    i++;
                }
                else if (nums[i] == 1)
                {
                    if (start == -1) start = i;
                    i++;
                }
                else // nums[i] == 2
                {
                    while (end >= 0 && nums[end] == 2)
                    {
                        end--;
                    }
                    if (end > i)
                    {
                        nums[i] = nums[end];
                        nums[end] = 2;
                    }
                    end--;
                }
            }
        }
    }
}

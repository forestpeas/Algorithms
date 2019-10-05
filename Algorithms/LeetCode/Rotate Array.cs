namespace Algorithms.LeetCode
{
    /* 189. Rotate Array
     * 
     * Given an array, rotate the array to the right by k steps, where k is non-negative.
     * 
     * Example 1:
     * 
     * Input: [1,2,3,4,5,6,7] and k = 3
     * Output: [5,6,7,1,2,3,4]
     * Explanation:
     * rotate 1 steps to the right: [7,1,2,3,4,5,6]
     * rotate 2 steps to the right: [6,7,1,2,3,4,5]
     * rotate 3 steps to the right: [5,6,7,1,2,3,4]
     * 
     * Example 2:
     * 
     * Input: [-1,-100,3,99] and k = 2
     * Output: [3,99,-1,-100]
     * Explanation: 
     * rotate 1 steps to the right: [99,-1,-100,3]
     * rotate 2 steps to the right: [3,99,-1,-100]
     * 
     * Note:
     * Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
     * Could you do it in-place with O(1) extra space?
     */
    public class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            // Similar to the solution of "151. Reverse Words in a String".
            // Reverse the whole "string" and then reverse each "word" (as for this problem, there are 2 words).
            // For example: 
            // Input: [1,2,3,4,5,6,7] and k = 3
            //         ------- -----
            //          word1  word2
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        public void Rotate2(int[] nums, int k)
        {
            // To ensure O(1) space, store the original value of nums[i] before assigning
            // the corresponding nums[i'] to nums[i], and the stored value should be put
            // into its corresponding correct position next.
            // See https://leetcode.com/media/original_images/189_Rotate_Array.png.
            k = k % nums.Length;
            int count = 0;
            for (int start = 0; count < nums.Length; start++)
            {
                int current = start;
                int prev = nums[start];
                do
                {
                    int next = (current + k) % nums.Length;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                    count++;
                } while (start != current);
            }
        }
    }
}

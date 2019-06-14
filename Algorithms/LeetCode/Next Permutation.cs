namespace Algorithms.LeetCode
{
    /* 31. Next Permutation
     * 
     * Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
     * If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).
     * 
     * The replacement must be in-place and use only constant extra memory.
     * 
     * Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
     * 
     * 1,2,3 → 1,3,2
     * 3,2,1 → 1,2,3
     * 1,1,5 → 1,5,1
     */
    public class NextPermutationSolution
    {
        // Your runtime beats 57.61 % of csharp submissions.
        // Your memory usage beats 62.79 % of csharp submissions.
        public void NextPermutation(int[] nums)
        {
            /* 1234
             * 1243
             * 1324
             * 1342
             * 1423
             * 1432 
             * 2134
             * 2143
             * 2314
             * 2341
             * 2413
             * 2431 -> 3421 -> 3124
             * 3124
             * 3142
             * 3214
             * 3241
             * 3412
             * 3421
             * 4123
             * 4132
             * 4213
             * 4231
             * 4312
             * 4321
             */
            if (nums.Length < 2) return;

            // Find the first ascending pair from right to left
            int i = nums.Length - 2;
            int value = 0; // nums[i]'s value
            for (; i >= 0; i--)
            {
                if (nums[i + 1] > nums[i])
                {
                    value = nums[i];
                    break;
                }
            }

            // Find the next larger element to nums[i]
            if (i >= 0)
            {
                for (int j = nums.Length - 1; ; j--)
                {
                    if (nums[j] > value)
                    {
                        Swap(nums, i, j);
                        break;
                    }
                }
            }

            // Reverse from nums[i + 1] to the end
            int lo = i + 1, hi = nums.Length - 1;
            while (lo < hi)
            {
                Swap(nums, lo++, hi--);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}

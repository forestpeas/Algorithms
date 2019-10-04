namespace Algorithms.LeetCode
{
    /* 493. Reverse Pairs
     * 
     * Given an array nums, we call (i, j) an important reverse pair if i < j and nums[i] > 2*nums[j].
     * 
     * You need to return the number of important reverse pairs in the given array.
     * 
     * Example1:
     * 
     * Input: [1,3,2,3,1]
     * Output: 2
     * 
     * Example2:
     * 
     * Input: [2,4,3,5,1]
     * Output: 3
     * 
     * Note:
     * The length of the given array will not exceed 50,000.
     * All the numbers in the input array are in the range of 32-bit integer.
     */
    public class ReversePairsSolution
    {
        public int ReversePairs(int[] nums)
        {
            // Inspired by https://leetcode.com/problems/reverse-pairs/discuss/97268/General-principles-behind-problems-similar-to-%22Reverse-Pairs%22
            // The fundamental idea: break down the array and solve for the subproblems, and how to merge the subproblems.
            return MergeSort(nums, new int[nums.Length], 0, nums.Length - 1);
        }

        private int MergeSort(int[] nums, int[] aux, int lo, int hi)
        {
            if (lo >= hi) return 0;
            int mid = lo + (hi - lo) / 2;
            int result = MergeSort(nums, aux, lo, mid) + MergeSort(nums, aux, mid + 1, hi);

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = nums[k];
            }

            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) nums[k] = aux[j++];
                else if (j > hi) nums[k] = aux[i++];
                else if (aux[i] < aux[j]) nums[k] = aux[i++];
                else nums[k] = aux[j++];
            }

            // The rest except the following is the standard mergesort.
            // j is the maximum index such that nums[i] > 2 * nums[j].
            // ∵ nums[i] > 2 * nums[j]
            // ∵ nums[j - 1] < nums[j]
            // ∴ nums[i] > 2 * nums[j - 1]
            i = lo;
            j = mid + 1;
            for (; i <= mid; i++)
            {
                while (j <= hi && aux[i] > 2L * aux[j]) j++;
                result += j - (mid + 1); // The number of elements in [mid + 1, j].
            }

            return result;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 303. Range Sum Query - Immutable
     * 
     * Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
     * 
     * Example:
     * Given nums = [-2, 0, 3, -5, 2, -1]
     * 
     * sumRange(0, 2) -> 1
     * sumRange(2, 5) -> -1
     * sumRange(0, 5) -> -3
     * 
     * Note:
     * You may assume that the array does not change.
     * There are many calls to sumRange function.
     */
    public class NumArray
    {
        private readonly int[] _sums;

        public NumArray(int[] nums)
        {
            _sums = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                _sums[i + 1] = _sums[i] + nums[i];
            }
        }

        public int SumRange(int i, int j)
        {
            return _sums[j + 1] - _sums[i];
        }
    }
}

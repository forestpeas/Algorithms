using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 307. Range Sum Query - Mutable
     * 
     * Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
     * 
     * The update(i, val) function modifies nums by updating the element at index i to val.
     * 
     * Example:
     * 
     * Given nums = [1, 3, 5]
     * 
     * sumRange(0, 2) -> 9
     * update(1, 2)
     * sumRange(0, 2) -> 8
     * 
     * Note:
     * The array is only modifiable by the update function.
     * You may assume the number of calls to update and sumRange function is distributed evenly.
     */
    public class Range_Sum_Query_Mutable
    {
        // Segment Tree. Use recursion to guarantee the property: 
        // For each node reprensenting a range [i,j], i and j are indexes of nums. let mid = (i + j) / 2,
        // its left child's range is [i,mid], its right child's range is [mid+1,j].
        // (I've tried an iterative one, but it doesn't always guarantee this, such as when n = 5.)
        // tree[0] is not used, tree[i]'s left child is tree[2*i], and right child is tree[2*i+1].
        // This is similar to heap.
        public class NumArray
        {
            private readonly int n;
            private readonly int[] tree;

            public NumArray(int[] nums)
            {
                if (nums.Length < 1) return;
                n = nums.Length;
                tree = new int[n * 4 + 1];
                BuildTree(1, nums, 0, n - 1);
            }

            private void BuildTree(int treeIdx, int[] nums, int lo, int hi)
            {
                if (lo == hi)
                {
                    tree[treeIdx] = nums[lo];
                    return;
                }

                int mid = lo + (hi - lo) / 2;
                BuildTree(2 * treeIdx, nums, lo, mid);
                BuildTree(2 * treeIdx + 1, nums, mid + 1, hi);
                tree[treeIdx] = tree[2 * treeIdx] + tree[2 * treeIdx + 1];
            }

            public void Update(int i, int val)
            {
                Update(1, i, val, 0, n - 1);
            }

            private void Update(int treeIdx, int i, int val, int lo, int hi)
            {
                if (lo == hi)
                {
                    tree[treeIdx] = val;
                    return;
                }

                int mid = lo + (hi - lo) / 2;
                if (i > mid) Update(treeIdx * 2 + 1, i, val, mid + 1, hi);
                else Update(treeIdx * 2, i, val, lo, mid);

                tree[treeIdx] = tree[treeIdx * 2] + tree[treeIdx * 2 + 1];
            }

            public int SumRange(int i, int j)
            {
                return SumRange(1, 0, n - 1, i, j);
            }

            private int SumRange(int treeIdx, int lo, int hi, int i, int j)
            {
                if (lo > hi || i > j) return 0;
                if (i == lo && j == hi) return tree[treeIdx];

                int mid = lo + (hi - lo) / 2;
                if (i > mid) return SumRange(treeIdx * 2 + 1, mid + 1, hi, i, j);
                else if (j <= mid) return SumRange(treeIdx * 2, lo, mid, i, j);

                int leftSum = SumRange(treeIdx * 2, lo, mid, i, mid);
                int rightSum = SumRange(treeIdx * 2 + 1, mid + 1, hi, mid + 1, j);
                return leftSum + rightSum;
            }
        }

        public class NumArray2
        {
            private readonly int[] _nums;
            private readonly FenwickTree _fenwick;

            public NumArray2(int[] nums)
            {
                _nums = nums;
                _fenwick = new FenwickTree(nums);
            }

            public void Update(int i, int val)
            {
                _fenwick.Add(i, val - _nums[i]);
                _nums[i] = val;
            }

            public int SumRange(int i, int j)
            {
                return _fenwick.RangeSum(i, j);
            }
        }
    }
}

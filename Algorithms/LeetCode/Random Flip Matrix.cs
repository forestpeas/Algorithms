using System;

namespace Algorithms.LeetCode
{
    /* 519. Random Flip Matrix
     * 
     * You are given the number of rows n_rows and number of columns n_cols of a 2D
     * binary matrix where all values are initially 0. Write a function flip which
     * chooses a 0 value uniformly at random, changes it to 1, and then returns the
     * position [row.id, col.id] of that value. Also, write a function reset which
     * sets all values back to 0. Try to minimize the number of calls to system's
     * Math.random() and optimize the time and space complexity.
     * 
     * Note:
     * 
     * 1 <= n_rows, n_cols <= 10000
     * 0 <= row.id < n_rows and 0 <= col.id < n_cols
     * flip will not be called when the matrix has no 0 values left.
     * the total number of calls to flip and reset will not exceed 1000.
     * 
     * Example 1:
     * 
     * Input: 
     * ["Solution","flip","flip","flip","flip"]
     * [[2,3],[],[],[],[]]
     * Output: [null,[0,1],[1,2],[1,0],[1,1]]
     * 
     * Example 2:
     * 
     * Input: 
     * ["Solution","flip","flip","reset","flip"]
     * [[1,2],[],[],[],[]]
     * Output: [null,[0,0],[0,1],null,[0,0]]
     */
    public class Random_Flip_Matrix
    {
        // Fisher-Yates algorithm. Similar to "384. Shuffle an Array".
        public class Solution
        {
            private readonly Random random = new Random();
            private readonly int[] nums;
            private readonly int m;
            private readonly int n;
            private int idx = 0;

            public Solution(int n_rows, int n_cols)
            {
                m = n_rows;
                n = n_cols;
                nums = new int[m * n];
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = i;
                }
            }

            public int[] Flip()
            {
                Swap(idx, random.Next(idx, nums.Length));
                int x = nums[idx++];
                return new int[] { x / n, x % n }; // Map from 1-d to 2-d.
            }

            public void Reset()
            {
                idx = 0;
            }

            private void Swap(int i, int j)
            {
                int tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
            }
        }
    }
}

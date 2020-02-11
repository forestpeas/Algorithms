using System;

namespace Algorithms.LeetCode
{
    /* 1340. Jump Game V
     * 
     * Given an array of integers arr and an integer d. In one step you can jump from index i to index:
     *     i + x where: i + x < arr.length and 0 < x <= d.
     *     i - x where: i - x >= 0 and 0 < x <= d.
     * In addition, you can only jump from index i to index j if arr[i] > arr[j] and arr[i] > arr[k] for
     * all indices k between i and j (More formally min(i, j) < k < max(i, j)).
     * You can choose any index of the array and start jumping. Return the maximum number of indices you can visit.
     * Notice that you can not jump outside of the array at any time.
     * 
     * Example 1:
     * 
     * https://leetcode.com/problems/jump-game-v/
     * Input: arr = [6,4,14,6,8,13,9,7,10,6,12], d = 2
     * Output: 4
     * Explanation: You can start at index 10. You can jump 10 --> 8 --> 6 --> 7 as shown.
     * Note that if you start at index 6 you can only jump to index 7. You cannot jump to index 5 because 13 > 9.
     * You cannot jump to index 4 because index 5 is between index 4 and 6 and 13 > 9.
     * Similarly You cannot jump from index 3 to index 2 or index 1.
     * 
     * Example 2:
     * 
     * Input: arr = [3,3,3,3,3], d = 3
     * Output: 1
     * Explanation: You can start at any index. You always cannot jump to any index.
     * 
     * Example 3:
     * 
     * Input: arr = [7,6,5,4,3,2,1], d = 1
     * Output: 7
     * Explanation: Start at index 0. You can visit all the indicies. 
     * 
     * Example 4:
     * 
     * Input: arr = [7,1,7,1,7,1], d = 2
     * Output: 2
     * 
     * Example 5:
     * 
     * Input: arr = [66], d = 1
     * Output: 1
     */
    public class Jump_Game_V
    {
        public int MaxJumps(int[] arr, int d)
        {
            // mem[i] is the maximum number of indices we can visit starting from i.
            int[] mem = new int[arr.Length];
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Jump(i);
                result = Math.Max(result, mem[i]);
            }
            return result;

            void Jump(int i)
            {
                if (mem[i] != 0) return;
                mem[i] = 1;
                for (int x = 1; x <= d && i + x < arr.Length && arr[i + x] < arr[i]; x++)
                {
                    Jump(i + x);
                    mem[i] = Math.Max(mem[i], 1 + mem[i + x]);
                }

                for (int x = 1; x <= d && i - x >= 0 && arr[i - x] < arr[i]; x++)
                {
                    Jump(i - x);
                    mem[i] = Math.Max(mem[i], 1 + mem[i - x]);
                }
            }
        }
    }
}

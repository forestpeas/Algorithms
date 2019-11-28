using System;

namespace Algorithms.LeetCode
{
    /* 1246. Palindrome Removal
     * 
     * Given an integer array arr, in one move you can select a palindromic subarray arr[i],
     * arr[i+1], ..., arr[j] where i <= j, and remove that subarray from the given array.
     * Note that after removing a subarray, the elements on the left and on the right of that
     * subarray move to fill the gap left by the removal.
     * 
     * Return the minimum number of moves needed to remove all numbers from the array.
     * 
     * Example 1:
     * 
     * Input: arr = [1,2]
     * Output: 2
     * 
     * Example 2:
     * 
     * Input: arr = [1,3,4,1,5]
     * Output: 3
     * Explanation: Remove [4] then remove [1,3,1] then remove [5].
     * 
     * Constraints:
     * 1 <= arr.length <= 100
     * 1 <= arr[i] <= 20
     */
    public class Palindrome_Removal
    {
        public int MinimumMoves(int[] arr)
        {
            // dp[j, i] is the answer to arr[j...i].
            int[,] dp = new int[arr.Length + 1, arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                dp[i, i] = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    dp[j, i] = 1 + dp[j + 1, i]; // Delete arr[j].
                    if (arr[j] == arr[j + 1]) dp[j, i] = Math.Min(dp[j, i], 1 + dp[j + 2, i]); // Delete arr[j,j+1].
                    for (int k = j + 2; k <= i; k++)
                    {
                        if (arr[j] == arr[k])
                        {
                            // arr[j] and arr[k] can be deleted together with the last move of [j + 1, k - 1].
                            dp[j, i] = Math.Min(dp[j, i], dp[j + 1, k - 1] + dp[k + 1, i]);
                        }
                    }
                }
            }

            return dp[0, arr.Length - 1];
        }
    }
}

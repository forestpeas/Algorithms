using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 474. Ones and Zeroes
     * 
     * You are given an array of binary strings strs and two integers m and n.
     * 
     * Return the size of the largest subset of strs such that there are at most m 0's and n 1's in the subset.
     * 
     * A set x is a subset of a set y if all elements of x are also elements of y.
     * 
     * Example 1:
     * 
     * Input: strs = ["10","0001","111001","1","0"], m = 5, n = 3
     * Output: 4
     * Explanation: The largest subset with at most 5 0's and 3 1's is {"10", "0001", "1", "0"}, so the answer is 4.
     * Other valid but smaller subsets include {"0001", "1"} and {"10", "1", "0"}.
     * {"111001"} is an invalid subset because it contains 4 1's, greater than the maximum of 3.
     * 
     * Example 2:
     * 
     * Input: strs = ["10","0","1"], m = 1, n = 1
     * Output: 2
     * Explanation: The largest subset is {"0", "1"}, so the answer is 2.
     */
    public class Ones_and_Zeroes
    {
        public int FindMaxForm(string[] strs, int m, int n)
        {
            return Helper(0, m, n, strs, new int[strs.Length, m + 1, n + 1]);
        }

        private int Helper(int i, int m, int n, string[] strs, int[,,] mem)
        {
            if (i == strs.Length) return 0;
            if (mem[i, m, n] != 0) return mem[i, m, n];
            int res = 0;
            int zeroNum = strs[i].Where(c => c == '0').Count();
            int oneNum = strs[i].Length - zeroNum;
            if (m >= zeroNum && n >= oneNum)
            {
                res = 1 + Helper(i + 1, m - zeroNum, n - oneNum, strs, mem);
            }
            res = Math.Max(res, Helper(i + 1, m, n, strs, mem));
            mem[i, m, n] = res;
            return res;
        }
    }
}

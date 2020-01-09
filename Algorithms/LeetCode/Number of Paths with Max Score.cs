using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1301. Number of Paths with Max Score
     * 
     * You are given a square board of characters. You can move on the board starting at the bottom
     * right square marked with the character 'S'.
     * 
     * You need to reach the top left square marked with the character 'E'. The rest of the squares
     * are labeled either with a numeric character 1, 2, ..., 9 or with an obstacle 'X'. In one move
     * you can go up, left or up-left (diagonally) only if there is no obstacle there.
     * 
     * Return a list of two integers: the first integer is the maximum sum of numeric characters you
     * can collect, and the second is the number of such paths that you can take to get that maximum
     * sum, taken modulo 10^9 + 7.
     * 
     * In case there is no path, return [0, 0].
     *  
     * Example 1:
     * 
     * Input: board = ["E23","2X2","12S"]
     * Output: [7,1]
     * 
     * Example 2:
     * 
     * Input: board = ["E12","1X1","21S"]
     * Output: [4,2]
     * 
     * Example 3:
     * 
     * Input: board = ["E11","XXX","11S"]
     * Output: [0,0]
     */
    public class Number_of_Paths_with_Max_Score
    {
        public int[] PathsWithMaxScore(IList<string> board)
        {
            int mod = 1000000007;
            int m = board.Count;
            int n = board[0].Length;
            int[,] maxSums = new int[m + 1, n + 1]; // maximum score so far.
            int[,] pathNums = new int[m + 1, n + 1]; // number of paths with the maximum score.
            pathNums[m, n] = 1;
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (board[i][j] == 'X') continue;
                    int max = Math.Max(maxSums[i + 1, j + 1], Math.Max(maxSums[i + 1, j], maxSums[i, j + 1]));
                    int score = (board[i][j] == 'S' || board[i][j] == 'E') ? 0 : (board[i][j] - '0');
                    maxSums[i, j] = score + max;
                    if (maxSums[i + 1, j + 1] == max)
                    {
                        pathNums[i, j] += pathNums[i + 1, j + 1] % mod;
                        pathNums[i, j] %= mod;
                    }
                    if (maxSums[i + 1, j] == max)
                    {
                        pathNums[i, j] += pathNums[i + 1, j] % mod;
                        pathNums[i, j] %= mod;
                    }
                    if (maxSums[i, j + 1] == max)
                    {
                        pathNums[i, j] += pathNums[i, j + 1] % mod;
                        pathNums[i, j] %= mod;
                    }
                }
            }

            if (pathNums[0, 0] == 0) return new int[] { 0, 0 };
            return new int[] { maxSums[0, 0], pathNums[0, 0] };
        }
    }
}

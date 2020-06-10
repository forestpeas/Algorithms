using System;

namespace Algorithms.LeetCode
{
    /* 375. Guess Number Higher or Lower II
     * 
     * We are playing the Guess Game. The game is as follows:
     * 
     * I pick a number from 1 to n. You have to guess which number I picked.
     * 
     * Every time you guess wrong, I'll tell you whether the number I picked is higher or lower.
     * 
     * However, when you guess a particular number x, and you guess wrong, you pay $x. You win the
     * game when you guess the number I picked.
     * 
     * https://leetcode.com/problems/guess-number-higher-or-lower-ii/discuss/84762/Improve-the-Question-and-Example/166225
     */
    public class Guess_Number_Higher_or_Lower_II
    {
        public int GetMoneyAmount(int n)
        {
            int[,] mem = new int[n + 1, n + 1];
            return F(0, n);

            int F(int l, int r)
            {
                if (l >= r) return 0;
                if (mem[l, r] != 0) return mem[l, r];
                int res = int.MaxValue;
                for (int i = l; i <= r; i++)
                {
                    int candidate = i + Math.Max(F(l, i - 1), F(i + 1, r));
                    res = Math.Min(res, candidate);
                }

                mem[l, r] = res;
                return res;
            }
        }
    }
}

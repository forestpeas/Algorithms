using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 464. Can I Win
     * 
     * In the "100 game" two players take turns adding, to a running total, any integer from 1 to 10.
     * The player who first causes the running total to reach or exceed 100 wins.
     * 
     * What if we change the game so that players cannot re-use integers?
     * 
     * For example, two players might take turns drawing from a common pool of numbers from 1 to 15
     * without replacement until they reach a total >= 100.
     * 
     * Given two integers maxChoosableInteger and desiredTotal, return true if the first player to
     * move can force a win, otherwise return false. Assume both players play optimally.
     * 
     * Example 1:
     * 
     * Input: maxChoosableInteger = 10, desiredTotal = 11
     * Output: false
     * Explanation:
     * No matter which integer the first player choose, the first player will lose.
     * The first player can choose an integer from 1 up to 10.
     * If the first player choose 1, the second player can only choose integers from 2 up to 10.
     * The second player will win by choosing 10 and get a total = 11, which is >= desiredTotal.
     * Same with other integers chosen by the first player, the second player will always win.
     * 
     * Example 2:
     * 
     * Input: maxChoosableInteger = 10, desiredTotal = 0
     * Output: true
     * 
     * Example 3:
     * 
     * Input: maxChoosableInteger = 10, desiredTotal = 1
     * Output: true
     */
    public class Can_I_Win
    {
        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            // Both players cannot win if the maximum sum is less than the desired total.
            if (((1 + maxChoosableInteger) * maxChoosableInteger / 2) < desiredTotal) return false;
            var mem = new Dictionary<string, bool>();
            return Helper(true, new bool[maxChoosableInteger + 1], desiredTotal);

            // Returning true means the first player is destined to win, and returning
            // false means the second player is destined to win.
            // marked[i] means the number i cannot be chosen.
            bool Helper(bool firstPlayer, bool[] marked, int target)
            {
                string key = new string(marked.Select(m => m ? '1' : '0').ToArray());
                if (mem.TryGetValue(key, out bool res)) return res;
                int max = GetMaxNum(marked);
                if (max >= target) return firstPlayer ? true : false;
                for (int i = 1; i < marked.Length; i++)
                {
                    if (marked[i]) continue;
                    marked[i] = true;
                    bool next = Helper(!firstPlayer, marked, target - i);
                    marked[i] = false;
                    if (firstPlayer)
                    {
                        // If the "next" sub-problem destines the first player to win,
                        // then the first player shall choose i to reach this sub-problem.
                        if (next)
                        {
                            mem.Add(key, true);
                            return true;
                        }
                    }
                    else
                    {
                        if (!next)
                        {
                            mem.Add(key, false);
                            return false;
                        }
                    }
                }
                return firstPlayer ? false : true;
            }

            int GetMaxNum(bool[] marked)
            {
                for (int i = marked.Length - 1; i >= 1; i--)
                {
                    if (!marked[i]) return i;
                }
                throw new InvalidOperationException(); // Cannot reach here.
            }
        }
    }
}

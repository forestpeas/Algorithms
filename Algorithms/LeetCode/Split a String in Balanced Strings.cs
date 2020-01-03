namespace Algorithms.LeetCode
{
    /* 1221. Split a String in Balanced Strings
     * 
     * Balanced strings are those who have equal quantity of 'L' and 'R' characters.
     * Given a balanced string s split it in the maximum amount of balanced strings.
     * Return the maximum amount of splitted balanced strings.
     * 
     * Example 1:
     * 
     * Input: s = "RLRRLLRLRL"
     * Output: 4
     * Explanation: s can be split into "RL", "RRLL", "RL", "RL", each substring contains same number of 'L' and 'R'.
     * 
     * Example 2:
     * 
     * Input: s = "RLLLLRRRLR"
     * Output: 3
     * Explanation: s can be split into "RL", "LLLRRR", "LR", each substring contains same number of 'L' and 'R'.
     * 
     * Example 3:
     * 
     * Input: s = "LLLLRRRR"
     * Output: 1
     * Explanation: s can be split into "LLLLRRRR".
     * 
     * Example 4:
     * 
     * Input: s = "RLRRRLLRLL"
     * Output: 2
     * Explanation: s can be split into "RL", "RRRLLRLL", since each substring contains an equal number of 'L' and 'R'
     */
    public class Split_a_String_in_Balanced_Strings
    {
        public int BalancedStringSplit(string s)
        {
            int result = 0;
            int count = 0;
            foreach (char c in s)
            {
                if (c == 'L') count++;
                else count--;

                if (count == 0) result++;
            }
            return result;
        }
    }
}

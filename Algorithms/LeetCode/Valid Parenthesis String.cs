using System;

namespace Algorithms.LeetCode
{
    /* 678. Valid Parenthesis String
     * 
     * Given a string s containing only three types of characters: '(', ')' and '*', return true
     * if s is valid.
     * 
     * The following rules define a valid string:
     * 
     *     Any left parenthesis '(' must have a corresponding right parenthesis ')'.
     *     Any right parenthesis ')' must have a corresponding left parenthesis '('.
     *     Left parenthesis '(' must go before the corresponding right parenthesis ')'.
     *     '*' could be treated as a single right parenthesis ')' or a single left parenthesis
     *     '(' or an empty string "".
     * 
     * Example 1:
     * 
     * Input: s = "()"
     * Output: true
     * 
     * Example 2:
     * 
     * Input: s = "(*)"
     * Output: true
     * 
     * Example 3:
     * 
     * Input: s = "(*))"
     * Output: true
     */
    public class Valid_Parenthesis_String
    {
        public bool CheckValidString(string s)
        {
            // example: *)((**
            int[] counts = new int[s.Length];
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(') count--;
                else if (s[i] == ')') count++;

                if (count < 0) count = 0;
                counts[i] = count;
            }

            count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                }
                else if (s[i] == ')')
                {
                    count--;
                    if (count < 0) return false;
                }
                else
                {
                    if (count > counts[i])
                    {
                        count--; // let '*' be ')'
                    }
                    else if (count < counts[i])
                    {
                        count++; // let '*' be '('
                    }
                }
            }
            return count == 0;
        }

        public bool CheckValidString2(string s)
        {
            int lo = 0, hi = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    hi++;
                    lo++;
                }
                else if (c == ')')
                {
                    hi--;
                    lo = Math.Max(lo - 1, 0);
                    if (hi < 0) return false;
                }
                else
                {
                    hi++;
                    lo = Math.Max(lo - 1, 0);
                }
            }
            return lo == 0;
        }
    }
}

using System.Text;

namespace Algorithms.LeetCode
{
    /* 1249. Minimum Remove to Make Valid Parentheses
     * 
     * Given a string s of '(' , ')' and lowercase English characters. 
     * 
     * Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that
     * the resulting parentheses string is valid and return any valid string.
     * 
     * Example 1:
     * 
     * Input: s = "lee(t(c)o)de)"
     * Output: "lee(t(c)o)de"
     * Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.
     * 
     * Example 2:
     * 
     * Input: s = "a)b(c)d"
     * Output: "ab(c)d"
     * 
     * Example 3:
     * 
     * Input: s = "))(("
     * Output: ""
     * Explanation: An empty string is also valid.
     * 
     * Example 4:
     * 
     * Input: s = "(a(b(c)d)"
     * Output: "a(b(c)d)"
     * 
     * Constraints:
     * 
     * 1 <= s.length <= 10^5
     * s[i] is one of  '(' , ')' and lowercase English letters.
     */
    public class Minimum_Remove_to_Make_Valid_Parentheses
    {
        public string MinRemoveToMakeValid(string s)
        {
            // Similar to "301. Remove Invalid Parentheses".
            char[] str = s.ToCharArray();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(') count++;
                else if (str[i] == ')')
                {
                    if (count == 0) str[i] = '#'; // Mark that this character should be removed.
                    else count--;
                }
            }

            count = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ')') count++;
                else if (str[i] == '(')
                {
                    if (count == 0) str[i] = '#';
                    else count--;
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (char c in str)
            {
                if (c != '#') result.Append(c);
            }
            return result.ToString();
        }
    }
}

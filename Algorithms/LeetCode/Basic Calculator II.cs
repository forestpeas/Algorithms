using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 227. Basic Calculator II
     * 
     * Implement a basic calculator to evaluate a simple expression string.
     * 
     * The expression string contains only non-negative integers, +, -, *, / operators and
     * empty spaces . The integer division should truncate toward zero.
     * 
     * Example 1:
     * 
     * Input: "3+2*2"
     * Output: 7
     * 
     * Example 2:
     * 
     * Input: " 3/2 "
     * Output: 1
     * 
     * Example 3:
     * 
     * Input: " 3+5 / 2 "
     * Output: 5
     * 
     * Note:
     * You may assume that the given expression is always valid.
     * Do not use the eval built-in library function.
     */
    public class BasicCalculatorII
    {
        public int Calculate(string s)
        {
            // Every number has a corresponding prefix operator.
            var nums = new List<StringBuilder>() { new StringBuilder() };
            var ops = new List<char>() { '+' };
            foreach (char c in s)
            {
                if (c == ' ') continue;
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    ops.Add(c);
                    nums.Add(new StringBuilder());
                }
                else
                {
                    nums[nums.Count - 1].Append(c);
                }
            }

            int result = 0;
            int last = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                int num = int.Parse(nums[i].ToString());
                char op = ops[i];
                if (op == '+')
                {
                    result += num;
                }
                else if (op == '-')
                {
                    num = -num;
                    result += num;
                }
                else
                {
                    num = (op == '*') ? last * num : last / num;
                    // last num was incorrectly added, so we restore result to the state before last was added.
                    result = result - last;
                    result += num;
                }
                last = num;
            }
            return result;
        }
    }
}

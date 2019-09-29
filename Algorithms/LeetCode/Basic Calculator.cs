using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 224. Basic Calculator
     * 
     * Implement a basic calculator to evaluate a simple expression string.
     * 
     * The expression string may contain open ( and closing parentheses ),
     * the plus + or minus sign -, non-negative integers and empty spaces .
     * 
     * Example 1:
     * 
     * Input: "1 + 1"
     * Output: 2
     * 
     * Example 2:
     * 
     * Input: " 2-1 + 2 "
     * Output: 3
     * 
     * Example 3:
     * 
     * Input: "(1+(4+5+2)-3)+(6+8)"
     * Output: 23
     * 
     * Note:
     * You may assume that the given expression is always valid.
     * Do not use the eval built-in library function.
     */
    public class BasicCalculator
    {
        public int Calculate(string s)
        {
            var stack = new Stack<int>();
            int operand = 0;
            int result = 0;
            int sign = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    // Numbers may contain more than one digit.
                    operand = 10 * operand + (s[i] - '0');
                }
                else if (s[i] == '+' || s[i] == '-')
                {
                    // If we encounter an operator, it means the last operand has been formed
                    // and can be put into result.
                    result += sign * operand;

                    operand = 0; // Reset for the next operand.
                    sign = s[i] == '+' ? 1 : -1; // Save the current sign for the next operand.
                }
                else if (s[i] == '(')
                {
                    // A '(' can only appear after a '+' or '-', so sign is ready for the result
                    // of the expression within this parenthesis.
                    // Now we are going to calculate the expression within this parenthesis,
                    // so save the current calculated result for future use.
                    stack.Push(result);
                    stack.Push(sign);

                    sign = 1;
                    result = 0;
                }
                else if (s[i] == ')')
                {
                    result += sign * operand; // Calculate the last number within this parenthesis.
                    result *= stack.Pop(); // sign corresponding to the result within this parenthesis.
                    result += stack.Pop(); // result before the corresponding '('.
                    operand = 0;
                }
            }
            return result + (sign * operand);
        }
    }
}

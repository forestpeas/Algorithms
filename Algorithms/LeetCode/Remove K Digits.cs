using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 402. Remove K Digits
     * 
     * Given a non-negative integer num represented as a string, remove k digits from the number so that the
     * new number is the smallest possible.
     * 
     * Note:
     * The length of num is less than 10002 and will be ≥ k.
     * The given num does not contain any leading zero.
     * Example 1:
     * 
     * Input: num = "1432219", k = 3
     * Output: "1219"
     * Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
     * 
     * Example 2:
     * 
     * Input: num = "10200", k = 1
     * Output: "200"
     * Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.
     * 
     * Example 3:
     * 
     * Input: num = "10", k = 2
     * Output: "0"
     * Explanation: Remove all the digits from the number and it is left with nothing which is 0.
     */
    public class RemoveKDigits
    {
        public string RemoveKdigits(string num, int k)
        {
            // Our first priority is to remove the most significant digit, our second goal
            // is to remove the largest possible digit. For example:
            // 321118, remove 3, then 2.
            // 231118, remove 3, then 2.
            // We can observe a pattern that whenever we meet a digit that is less than the
            // the previous digit, we should discard the previous digit.
            var stack = new Stack<char>(); // stack's top element is the previous digit.
            foreach (char c in num)
            {
                while (k > 0 && stack.Count != 0 && c < stack.Peek())
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(c);
            }

            while (k-- > 0) stack.Pop(); // Cases like "11111" or "12345".
            char[] result = new char[stack.Count];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }
            // Remove leading zeroes.
            int startIdx = 0;
            while (startIdx < result.Length && result[startIdx] == '0')
            {
                startIdx++;
            }
            if (startIdx == result.Length) return "0";
            return new string(result, startIdx, result.Length - startIdx);
        }
    }
}

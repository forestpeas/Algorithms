using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 241. Different Ways to Add Parentheses
     * 
     * Given a string of numbers and operators, return all possible results from computing all the
     * different possible ways to group numbers and operators. The valid operators are +, - and *.
     * 
     * Example 1:
     * 
     * Input: "2-1-1"
     * Output: [0, 2]
     * Explanation: 
     * ((2-1)-1) = 0 
     * (2-(1-1)) = 2
     * 
     * Example 2:
     * 
     * Input: "2*3-4*5"
     * Output: [-34, -14, -10, -10, 10]
     * Explanation: 
     * (2*(3-(4*5))) = -34 
     * ((2*3)-(4*5)) = -14 
     * ((2*(3-4))*5) = -10 
     * (2*((3-4)*5)) = -10 
     * (((2*3)-4)*5) = 10
     */
    public class DifferentWaysToAddParentheses
    {
        public IList<int> DiffWaysToCompute(string input)
        {
            // Recursion(divide and conquer).
            // We can also use a hash map to avoid repeated computation of the same input string.
            IList<int> result = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    IList<int> left = DiffWaysToCompute(input.Substring(0, i));
                    IList<int> right = DiffWaysToCompute(input.Substring(i + 1));
                    foreach (int item1 in left)
                    {
                        foreach (int item2 in right)
                        {
                            if (input[i] == '+') result.Add(item1 + item2);
                            else if (input[i] == '-') result.Add(item1 - item2);
                            else result.Add(item1 * item2);
                        }
                    }
                }
            }

            if (result.Count == 0) result.Add(int.Parse(input));
            return result;
        }
    }
}

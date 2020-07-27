using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 282. Expression Add Operators
     * 
     * Given a string that contains only digits 0-9 and a target value, return all possibilities to add
     * binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.
     * 
     * Example 1:
     * 
     * Input: num = "123", target = 6
     * Output: ["1+2+3", "1*2*3"]
     * 
     * Example 2:
     * 
     * Input: num = "232", target = 8
     * Output: ["2*3+2", "2+3*2"]
     * 
     * Example 3:
     * 
     * Input: num = "105", target = 5
     * Output: ["1*0+5","10-5"]
     * 
     * Example 4:
     * 
     * Input: num = "00", target = 0
     * Output: ["0+0", "0-0", "0*0"]
     * 
     * Example 5:
     * 
     * Input: num = "3456237490", target = 9191
     * Output: []
     * 
     * Constraints:
     * 
     * 0 <= num.length <= 10
     * num only contain digits.
     */
    public class Expression_Add_Operators
    {
        public IList<string> AddOperators(string num, int target)
        {
            if (num.Length == 0) return new string[0];
            return Traverse(0, 0, 1, num[0] - '0');

            IList<string> Traverse(int i, long value, long multiplier, long currNum)
            {
                // Search for all possibilities. In each gap between digits, we have 4 choices:
                // add a '+', or add a '-', or add a '*', or add nothing.
                // "value" is the expression value that we can determine so far. If we choose to
                // add a '+' or '-', the value can be determined and updated. But if we choose to
                // add a '*', we must save the product in another variable "multiplier", because
                // the priority of '*' is higher and there may be more '*'s next. If we choose to
                // add nothing, only "currNum" is updated.
                // In each iteration, we deal with the gap between num[i] and num[i+1], "currNum"
                // is the number that ends with the digit num[i].
                var res = new List<string>();
                if (i == num.Length - 1)
                {
                    value += multiplier * currNum;
                    if (value == target) res.Add(num[i].ToString());
                    return res;
                }

                int digit = num[i + 1] - '0';
                var exps = Traverse(i + 1, value + multiplier * currNum, 1, digit);
                foreach (var exp in exps) res.Add($"{num[i]}+{exp}");

                exps = Traverse(i + 1, value + multiplier * currNum, -1, digit);
                foreach (var exp in exps) res.Add($"{num[i]}-{exp}");

                exps = Traverse(i + 1, value, multiplier * currNum, digit);
                foreach (var exp in exps) res.Add($"{num[i]}*{exp}");

                if (currNum == 0) return res; // Numbers cannot start with '0'.
                exps = Traverse(i + 1, value, multiplier, currNum * 10 + digit);
                foreach (var exp in exps) res.Add($"{num[i]}{exp}");

                return res;
            }
        }
    }
}

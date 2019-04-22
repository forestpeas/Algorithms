using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class GenerateParentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            Backtrack(result, "", 0, 0, n);
            return result;

            void Backtrack(List<string> list, string str, int open, int close, int max)
            {
                if (str.Length == max * 2)
                {
                    list.Add(str);
                    return;
                }

                if (open < max)
                {
                    Backtrack(list, str + "(", open + 1, close, max);
                }
                if (close < open)
                {
                    Backtrack(list, str + ")", open, close + 1, max);
                }
            }
        }
    }
}

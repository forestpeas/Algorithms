using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 40. Combination Sum II
     * Given a collection of candidate numbers (candidates) and a target number (target), 
     * find all unique combinations in candidates where the candidate numbers sums to target.
     * Each number in candidates may only be used once in the combination.
     * 
     * Note:
     *     All numbers (including target) will be positive integers.
     *     The solution set must not contain duplicate combinations.
     * 
     * Example 1:
     * 
     * Input: candidates = [10,1,2,7,6,1,5], target = 8,
     * A solution set is:
     * [
     *   [1, 7],
     *   [1, 2, 5],
     *   [2, 6],
     *   [1, 1, 6]
     * ]
     * 
     * Example 2:
     * 
     * Input: candidates = [2,5,2,1,2], target = 5,
     * A solution set is:
     * [
     *   [1,2,2],
     *   [5]
     * ]
     */
    public class CombinationSumII
    {
        // Your runtime beats 57.89 % of csharp submissions.
        // Your memory usage beats 29.96 % of csharp submissions.
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            // Similar to "39. Combination Sum".
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            var stack = new Stack<int>();
            int sum = 0;
            int i = 0;
            while (true)
            {
                while (i >= candidates.Length)
                {
                    if (stack.Count == 0) return result;
                    i = stack.Pop();
                    sum -= candidates[i];
                    do
                    {
                        i++;
                    } while (i < candidates.Length && candidates[i] == candidates[i - 1]);
                }

                for (; sum < target && i < candidates.Length; i++)
                {
                    sum += candidates[i];
                    stack.Push(i);
                }

                if (sum == target)
                {
                    result.Add(stack.Select(j => candidates[j]).ToArray());
                }

                sum -= candidates[stack.Pop()];

                if (stack.Count == 0) return result;
                i = stack.Pop();
                sum -= candidates[i];
                do
                {
                    i++;
                } while (i < candidates.Length && candidates[i] == candidates[i - 1]);
            }
        }
    }
}

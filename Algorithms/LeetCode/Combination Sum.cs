using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 39. Combination Sum
     * Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), 
     * find all unique combinations in candidates where the candidate numbers sums to target.
     * The same repeated number may be chosen from candidates unlimited number of times.
     * 
     * Note:
     *     All numbers (including target) will be positive integers.
     *     The solution set must not contain duplicate combinations.
     * 
     * Example 1:
     * 
     * Input: candidates = [2,3,6,7], target = 7,
     * A solution set is:
     * [
     *   [7],
     *   [2,2,3]
     * ]
     * 
     * Example 2:
     * 
     * Input: candidates = [2,3,5], target = 8,
     * A solution set is:
     * [
     *   [2,2,2,2],
     *   [2,3,3],
     *   [3,5]
     * ]
     */
    public class CombinationSumSolution
    {
        // Your runtime beats 45.24 % of csharp submissions.
        // Your memory usage beats 31.81 % of csharp submissions.
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            // Backtracking
            // For example: candidates = [2,3,6,7], target = 7
            // "stack" will go through the following procedures:
            // 2222
            // 223
            // 233
            // 26
            // 333
            // 36
            // 66
            // 7
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
                    i++;
                }

                do
                {
                    sum += candidates[i];
                    stack.Push(i);
                } while (sum < target);

                if (sum == target)
                {
                    result.Add(stack.Select(j => candidates[j]).ToArray());
                }

                sum -= candidates[stack.Pop()];

                // Pop again because there is no need to replace the last element with a bigger one.
                if (stack.Count == 0) return result;
                i = stack.Pop();
                sum -= candidates[i];
                i++;
            }
        }
    }
}

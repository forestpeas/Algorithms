using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1237. Find Positive Integer Solution for a Given Equation
     * 
     * Given a function  f(x, y) and a value z, return all positive integer pairs x and y where f(x,y) == z.
     * 
     * The function is constantly increasing, i.e.:
     * 
     * f(x, y) < f(x + 1, y)
     * f(x, y) < f(x, y + 1)
     * 
     * The function interface is defined like this: 
     * 
     * interface CustomFunction {
     * public:
     *   // Returns positive integer f(x, y) for any given positive integer x and y.
     *   int f(int x, int y);
     * };
     * 
     * For custom testing purposes you're given an integer function_id and a target z as input, where
     * function_id represent one function from an secret internal list, on the examples you'll know only
     * two functions from the list.  
     * 
     * You may return the solutions in any order.
     * 
     * Example 1:
     * 
     * Input: function_id = 1, z = 5
     * Output: [[1,4],[2,3],[3,2],[4,1]]
     * Explanation: function_id = 1 means that f(x, y) = x + y
     * Example 2:
     * 
     * Input: function_id = 2, z = 5
     * Output: [[1,5],[5,1]]
     * Explanation: function_id = 2 means that f(x, y) = x * y
     * 
     * Constraints:
     * 
     * 1 <= function_id <= 9
     * 1 <= z <= 100
     * It's guaranteed that the solutions of f(x, y) == z will be on the range 1 <= x, y <= 1000
     * It's also guaranteed that f(x, y) will fit in 32 bit signed integer if 1 <= x, y <= 1000
     */
    public class Find_Positive_Integer_Solution_for_a_Given_Equation
    {
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            // Inspired by https://leetcode.com/problems/find-positive-integer-solution-for-a-given-equation/discuss/414249/JavaC%2B%2BPython-O(X%2BY)
            // The problem is essentially the same as "240. Search a 2D Matrix II".
            int x = 1000, y = 1;
            var result = new List<IList<int>>();
            while (x >= 1 && y <= 1000)
            {
                if (z < customfunction.f(x, y))
                {
                    x--;
                }
                else if (z > customfunction.f(x, y))
                {
                    y++;
                }
                else result.Add(new int[] { x--, y++ });
            }
            return result;
        }

        public IList<IList<int>> FindSolution2(CustomFunction customfunction, int z)
        {
            // Monotonicity leads to binary search.
            var result = new List<IList<int>>();
            for (int x = 1; x <= 1000; x++)
            {
                int lo = 1, hi = 1001;
                while (lo < hi)
                {
                    int y = lo + (hi - lo) / 2;
                    if (customfunction.f(x, y) > z)
                    {
                        hi = y;
                    }
                    else if (customfunction.f(x, y) < z)
                    {
                        lo = y + 1;
                    }
                    else
                    {
                        result.Add(new int[] { x, y });
                        break;
                    }
                }
            }

            return result;
        }
    }

    public interface CustomFunction
    {
        // Returns positive integer f(x, y) for any given positive integer x and y.
        int f(int x, int y);
    };
}

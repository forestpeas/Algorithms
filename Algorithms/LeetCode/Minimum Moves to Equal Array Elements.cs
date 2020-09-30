using System.Linq;

namespace Algorithms.LeetCode
{
    /* 453. Minimum Moves to Equal Array Elements
     * 
     * Given a non-empty integer array of size n, find the minimum number of moves required
     * to make all array elements equal, where a move is incrementing n - 1 elements by 1.
     * 
     * Example:
     * 
     * Input:
     * [1,2,3]
     * 
     * Output:
     * 3
     * 
     * Explanation:
     * Only three moves are needed (remember each move increments two elements):
     * 
     * [1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
     */
    public class Minimum_Moves_to_Equal_Array_Elements
    {
        public int MinMoves(int[] nums)
        {
            // Think if nums as an histogram, we need to make all numbers relatively on the
            // same level. So incrementing n - 1 elements by 1 is equivalent to decrementing
            // one single element by 1, so we just need to make every number drop to "min".
            int min = nums.Min();
            int res = 0;
            foreach (int num in nums)
            {
                res += num - min;
            }
            return res;
        }
    }
}

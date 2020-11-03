using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 473. Matchsticks to Square
     * 
     * Remember the story of Little Match Girl? By now, you know exactly what matchsticks
     * the little match girl has, please find out a way you can make one square by using
     * up all those matchsticks. You should not break any stick, but you can link them up,
     * and each matchstick must be used exactly one time.
     * 
     * Your input will be several matchsticks the girl has, represented with their stick
     * length. Your output will either be true or false, to represent whether you could
     * make one square using all the matchsticks the little match girl has.
     * 
     * Example 1:
     * Input: [1,1,2,2,2]
     * Output: true
     * 
     * Explanation: You can form a square with length 2, one side of the square came two
     * sticks with length 1.
     * 
     * Example 2:
     * Input: [3,3,3,3,4]
     * Output: false
     * 
     * Explanation: You cannot find a way to form a square with all the matchsticks.
     */
    public class Matchsticks_to_Square
    {
        public bool Makesquare(int[] nums)
        {
            // Try all possibilities.
            int sum = nums.Sum();
            if (sum == 0 || sum % 4 != 0) return false;
            int target = sum / 4;
            nums = nums.OrderByDescending(n => n).ToArray(); // Try larger numbers first to "return false" earlier.
            return helper(0, new int[4]);

            bool helper(int idx, int[] sums)
            {
                if (idx == nums.Length)
                {
                    return sums[0] == target && sums[1] == target && sums[2] == target;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (sums[i] + nums[idx] > target) continue;
                    sums[i] += nums[idx];
                    if (helper(idx + 1, sums)) return true;
                    sums[i] -= nums[idx];
                }
                return false;
            }
        }

        public bool Makesquare2(int[] nums)
        {
            bool[] marked = new bool[nums.Length];
            int sum = nums.Sum();
            if (sum % 4 != 0) return false;
            int target = sum / 4;
            Array.Sort(nums);
            return Helper(0, 0);

            bool Helper(int count, int length)
            {
                int prev = -1;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (marked[i]) continue;
                    if (length + nums[i] > target) continue;
                    if (nums[i] == prev) continue;
                    marked[i] = true;
                    if (length + nums[i] == target)
                    {
                        if (count == 2) return true;
                        if (Helper(count + 1, 0)) return true;
                    }
                    else
                    {
                        if (Helper(count, length + nums[i])) return true;
                    }
                    marked[i] = false;
                    prev = nums[i];
                }
                return false;
            }
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 414. Third Maximum Number
     * 
     * Given a non-empty array of integers, return the third maximum number in this array.
     * If it does not exist, return the maximum number. The time complexity must be in O(n).
     * 
     * Example 1:
     * Input: [3, 2, 1]
     * 
     * Output: 1
     * 
     * Explanation: The third maximum is 1.
     * 
     * Example 2:
     * Input: [1, 2]
     * 
     * Output: 2
     * 
     * Explanation: The third maximum does not exist, so the maximum (2) is returned instead.
     * 
     * Example 3:
     * Input: [2, 2, 3, 1]
     * 
     * Output: 1
     * 
     * Explanation: Note that the third maximum here means the third maximum distinct number.
     * Both numbers with value 2 are both considered as second maximum.
     */
    public class Third_Maximum_Number
    {
        public int ThirdMax(int[] nums)
        {
            long minValue = int.MinValue - 1L;
            long max = minValue, secondMax = minValue, thirdMax = minValue;
            foreach (int num in nums)
            {
                if (num > max)
                {
                    thirdMax = secondMax;
                    secondMax = max;
                    max = num;
                }
                else if (num > secondMax)
                {
                    if (num == max) continue;
                    thirdMax = secondMax;
                    secondMax = num;
                }
                else if (num > thirdMax)
                {
                    if (num == secondMax) continue;
                    thirdMax = num;
                }
            }

            return thirdMax != minValue ? (int)thirdMax : (int)max;
        }
    }
}

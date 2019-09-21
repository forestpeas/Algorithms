using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 179. Largest Number
     * 
     * Given a list of non negative integers, arrange them such that they form the largest number.
     * 
     * Example 1:
     * 
     * Input: [10,2]
     * Output: "210"
     * 
     * Example 2:
     * 
     * Input: [3,30,34,5,9]
     * Output: "9534330"
     * 
     * Note: The result may be very large, so you need to return a string instead of an integer.
     */
    public class LargestNumberSolution
    {
        public string LargestNumber(int[] nums)
        {
            // For example, 9 is "bigger" than 34, 3 is "bigger" than 30...
            string[] numsAsStr = nums.Select(n => n.ToString()).ToArray();
            Array.Sort(numsAsStr, (x, y) => (y + x).CompareTo(x + y));
            string result = string.Join("", numsAsStr);
            return result.StartsWith('0') ? "0" : result;
        }
    }
}

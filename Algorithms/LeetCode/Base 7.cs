namespace Algorithms.LeetCode
{
    /* 504. Base 7
     * 
     * Given an integer, return its base 7 string representation.
     * 
     * Example 1:
     * Input: 100
     * Output: "202"
     * 
     * Example 2:
     * Input: -7
     * Output: "-10"
     */
    public class Base_7
    {
        public string ConvertToBase7(int num)
        {
            if (num < 0) return "-" + ConvertToBase7(-num);
            if (num < 7) return num.ToString();
            return ConvertToBase7(num / 7) + (num % 7);
        }
    }
}

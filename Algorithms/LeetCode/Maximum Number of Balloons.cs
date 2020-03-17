using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1189. Maximum Number of Balloons
     * 
     * Given a string text, you want to use the characters of text to form as many instances of the word "balloon"
     * as possible.
     * 
     * You can use each character in text at most once. Return the maximum number of instances that can be formed.
     * 
     * Example 1:
     * 
     * Input: text = "nlaebolko"
     * Output: 1
     * 
     * Example 2:
     * 
     * Input: text = "loonbalxballpoon"
     * Output: 2
     * 
     * Example 3:
     * 
     * Input: text = "leetcode"
     * Output: 0
     */
    public class Maximum_Number_of_Balloons
    {
        public int MaxNumberOfBalloons(string text)
        {
            var counts = new Dictionary<char, int>();
            foreach (char c in "balon")
            {
                counts[c] = 0;
            }

            foreach (char c in text)
            {
                if (c == 'b' || c == 'a' || c == 'n') counts[c] += 2;
                else if (c == 'l' || c == 'o') counts[c]++;
            }

            return counts.Values.Min() / 2;
        }
    }
}

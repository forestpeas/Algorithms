using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1374. Generate a String With Characters That Have Odd Counts
     * 
     * Given an integer n, return a string with n characters such that each character in such string occurs an odd number of times.
     * 
     * The returned string must contain only lowercase English letters. If there are multiples valid strings, return any of them.  
     * 
     * Example 1:
     * 
     * Input: n = 4
     * Output: "pppz"
     * Explanation: "pppz" is a valid string since the character 'p' occurs three times and the character 'z' occurs once.
     * Note that there are many other valid strings such as "ohhh" and "love".
     * 
     * Example 2:
     * 
     * Input: n = 2
     * Output: "xy"
     * Explanation: "xy" is a valid string since the characters 'x' and 'y' occur once. Note that there are many other valid
     * strings such as "ag" and "ur".
     * 
     * Example 3:
     * 
     * Input: n = 7
     * Output: "holasss"
     */
    public class Generate_a_String_With_Characters_That_Have_Odd_Counts
    {
        public string GenerateTheString(int n)
        {
            if (n % 2 == 0)
            {
                return new string(Enumerable.Repeat('a', n - 1).ToArray()) + "b";
            }
            else
            {
                return new string(Enumerable.Repeat('a', n).ToArray());
            }
        }
    }
}

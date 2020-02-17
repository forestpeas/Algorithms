using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1347. Minimum Number of Steps to Make Two Strings Anagram
     * 
     * Given two equal-size strings s and t. In one step you can choose any character of t and replace it with
     * another character.
     * 
     * Return the minimum number of steps to make t an anagram of s.
     * 
     * An Anagram of a string is a string that contains the same characters with a different (or the same) ordering.
     * 
     * Example 1:
     * 
     * Input: s = "bab", t = "aba"
     * Output: 1
     * Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.
     * 
     * Example 2:
     * 
     * Input: s = "leetcode", t = "practice"
     * Output: 5
     * Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters to make t anagram of s.
     */
    public class Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram
    {
        public int MinSteps(string s, string t)
        {
            int[] count = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']--;
                count[t[i] - 'a']++;
            }

            // The sum of negatives and positives must be the same.
            return count.Where(x => x > 0).Sum();
        }
    }
}

using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 242. Valid Anagram
     * 
     * Given two strings s and t , write a function to determine if t is an anagram of s.
     * 
     * Example 1:
     * 
     * Input: s = "anagram", t = "nagaram"
     * Output: true
     * 
     * Example 2:
     * 
     * Input: s = "rat", t = "car"
     * Output: false
     * 
     * Note:
     * You may assume the string contains only lowercase alphabets.
     * 
     * Follow up:
     * What if the inputs contain unicode characters? How would you adapt your solution to such case?
     */
    public class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] counts = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a']++;
                counts[t[i] - 'a']--;
            }
            foreach (int count in counts)
            {
                if (count != 0) return false;
            }
            return true;
        }

        public bool IsAnagramUnicode(string s, string t)
        {
            // If the inputs contain unicode characters, just replace the array with a hash map.
            if (s.Length != t.Length) return false;
            var counts = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a'] = counts.GetValueOrDefault(s[i] - 'a') + 1;
                counts[t[i] - 'a'] = counts.GetValueOrDefault(t[i] - 'a') - 1;
            }
            if (counts.Keys.Count != counts.Keys.Count) return false;
            foreach (int count in counts.Values)
            {
                if (count != 0) return false;
            }
            return true;
        }
    }
}

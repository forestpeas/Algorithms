using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 49. Group Anagrams
     * 
     * Given an array of strings, group anagrams together.
     * 
     * Example:
     * 
     * Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
     * Output:
     * [
     *   ["ate","eat","tea"],
     *   ["nat","tan"],
     *   ["bat"]
     * ]
     * 
     * Note:
     * 
     * All inputs will be in lowercase.
     * The order of your output does not matter.
     */
    public class GroupAnagramsSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // Or use integer as key and use 26 prime numbers to calculate the key：
            // int[] primes = {2, 3, 5, 7, 11, 13, 17, 19,...}
            // For example: word = "eat", key = primes['e' - 'a'] * primes['a' - 'a'] * primes['t' - 'a']
            // Because of the nature of prime numbers, we can be sure that every word in the same anagram group
            // will result in the same key.
            var map = new Dictionary<string, List<string>>();
            foreach (string str in strs)
            {
                int[] anagramLetters = new int[26];
                foreach (char letter in str)
                {
                    anagramLetters[letter - 'a']++;
                }
                string key = string.Join(',', anagramLetters);
                if (map.TryGetValue(key, out var list))
                {
                    list.Add(str);
                }
                else
                {
                    map.Add(key, new List<string>() { str });
                }
            }
            return new List<IList<string>>(map.Values);
        }
    }
}

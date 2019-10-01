﻿using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 387. First Unique Character in a String
     * 
     * Given a string, find the first non-repeating character in it and return it's index.
     * If it doesn't exist, return -1.
     * 
     * Examples:
     * 
     * s = "leetcode"
     * return 0.
     * 
     * s = "loveleetcode",
     * return 2.
     * 
     * Note: You may assume the string contain only lowercase letters.
     */
    public class FirstUniqueCharacterInAString
    {
        public int FirstUniqChar(string s)
        {
            var counter = new Dictionary<char, int>();
            foreach (char c in s)
            {
                counter[c] = counter.GetValueOrDefault(c) + 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (counter[s[i]] == 1) return i;
            }

            return -1;
        }
    }
}

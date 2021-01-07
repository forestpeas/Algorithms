using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 500. Keyboard Row
     * 
     * Given a List of words, return the words that can be typed using letters
     * of alphabet on only one row's of American keyboard like the image below.
     * https://leetcode.com/problems/keyboard-row/
     *  
     * Example:
     * 
     * Input: ["Hello", "Alaska", "Dad", "Peace"]
     * Output: ["Alaska", "Dad"]
     * 
     * Note:
     * 
     * You may use one character in the keyboard more than once.
     * You may assume the input string will only contain letters of alphabet.
     */
    public class Keyboard_Row
    {
        public string[] FindWords(string[] words)
        {
            char[][] keyboard = new char[][]
            {
                new char[]{'q','w','e','r','t','y','u','i','o','p'},
                new char[]{ 'a','s','d','f','g','h','j','k','l'},
                new char[]{'z','x','c','v','b','n','m' },
            };
            var res = new List<string>();
            foreach (var w in words)
            {
                var word = w.ToLower();
                int row = keyboard[0].Contains(word[0]) ? 0 : keyboard[1].Contains(word[0]) ? 1 : 2;
                if (word.All(c => keyboard[row].Contains(c)))
                {
                    res.Add(w);
                }
            }
            return res.ToArray();
        }
    }
}

﻿using System.Linq;

namespace Algorithms.LeetCode
{
    /* 520. Detect Capital
     * 
     * Given a word, you need to judge whether the usage of capitals in it is right or not.
     * 
     * We define the usage of capitals in a word to be right when one of the following cases holds:
     * 
     * All letters in this word are capitals, like "USA".
     * All letters in this word are not capitals, like "leetcode".
     * Only the first letter in this word is capital, like "Google".
     * Otherwise, we define that this word doesn't use capitals in a right way. 
     * 
     * Example 1:
     * 
     * Input: "USA"
     * Output: True
     *  
     * Example 2:
     * 
     * Input: "FlaG"
     * Output: False
     *  
     * Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters.
     */
    public class Detect_Capital
    {
        public bool DetectCapitalUse(string word)
        {
            int countUpper = word.Where(c => char.IsUpper(c)).Count();
            if (countUpper == word.Length)
            {
                return true;
            }
            if (countUpper == 0)
            {
                return true;
            }
            if (char.IsUpper(word[0]) && countUpper == 1)
            {
                return true;
            }
            return false;
        }
    }
}

using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 17. Letter Combinations of a Phone Number
     * 
     * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
     * A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
     * 
     * 2 => abc
     * 3 => def
     * 4 => ghi
     * 5 => jkl
     * 6 => mno
     * 7 => pqrs
     * 8 => tuv
     * 9 => wxyz
     * 
     * Example:
     * Input: "23"
     * Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
     * 
     * Note:
     * Although the above answer is in lexicographical order, your answer could be in any order you want.
     */
    public class LetterCombinationsOfAPhoneNumber
    {
        // Your runtime beats 74.25 % of csharp submissions.
        // Your memory usage beats 56.63 % of csharp submissions.
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length < 1) return new List<string>();

            var map = new Dictionary<char, string[]>
            {
                ['2'] = new string[3] { "a", "b", "c" },
                ['3'] = new string[3] { "d", "e", "f" },
                ['4'] = new string[3] { "g", "h", "i" },
                ['5'] = new string[3] { "j", "k", "l" },
                ['6'] = new string[3] { "m", "n", "o" },
                ['7'] = new string[4] { "p", "q", "r", "s" },
                ['8'] = new string[3] { "t", "u", "v" },
                ['9'] = new string[4] { "w", "x", "y", "z" }
            };

            string[] combinations = map[digits[0]];
            for (int i = 1; i < digits.Length; i++)
            {
                char digit = digits[i];
                string[] currentCombinations = combinations;
                combinations = new string[currentCombinations.Length * map[digit].Length];
                int j = 0;
                foreach (string letter in map[digit])
                {
                    foreach (string combination in currentCombinations)
                    {
                        combinations[j] = combination + letter;
                        j++;
                    }
                }
            }
            return new List<string>(combinations);
        }
    }
}

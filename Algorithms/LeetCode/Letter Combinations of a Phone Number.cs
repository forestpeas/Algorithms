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

            var combinations = new List<string>() { string.Empty };
            foreach (char digit in digits)
            {
                var mappings = map[digit];
                // Cartesian product.
                var newCombinations = new List<string>(combinations.Count * mappings.Length);
                foreach (string letter in mappings)
                {
                    foreach (string combination in combinations)
                    {
                        newCombinations.Add(combination + letter);
                    }
                }
                combinations = newCombinations;
            }
            return combinations;
        }
    }
}

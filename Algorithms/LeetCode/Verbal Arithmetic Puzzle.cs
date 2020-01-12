using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1307. Verbal Arithmetic Puzzle
     * 
     * Given an equation, represented by words on left side and the result on right side.
     * 
     * You need to check if the equation is solvable under the following rules:
     * 
     *     Each character is decoded as one digit (0 - 9).
     *     Every pair of different characters they must map to different digits.
     *     Each words[i] and result are decoded as one number without leading zeros.
     *     Sum of numbers on left side (words) will equal to the number on right side (result). 
     * 
     * Return True if the equation is solvable otherwise return False.
     * 
     * Example 1:
     * 
     * Input: words = ["SEND","MORE"], result = "MONEY"
     * Output: true
     * Explanation: Map 'S'-> 9, 'E'->5, 'N'->6, 'D'->7, 'M'->1, 'O'->0, 'R'->8, 'Y'->'2'
     * Such that: "SEND" + "MORE" = "MONEY" ,  9567 + 1085 = 10652
     * 
     * Example 2:
     * 
     * Input: words = ["SIX","SEVEN","SEVEN"], result = "TWENTY"
     * Output: true
     * Explanation: Map 'S'-> 6, 'I'->5, 'X'->0, 'E'->8, 'V'->7, 'N'->2, 'T'->1, 'W'->'3', 'Y'->4
     * Such that: "SIX" + "SEVEN" + "SEVEN" = "TWENTY" ,  650 + 68782 + 68782 = 138214
     * 
     * Example 3:
     * 
     * Input: words = ["THIS","IS","TOO"], result = "FUNNY"
     * Output: true
     * 
     * Example 4:
     * 
     * Input: words = ["LEET","CODE"], result = "POINT"
     * Output: false
     */
    public class Verbal_Arithmetic_Puzzle
    {
        public bool IsSolvable(string[] words, string result)
        {
            // Brute-force, also backtracking.
            var set = new HashSet<char>();
            foreach (char c in result) set.Add(c);
            foreach (string w in words) foreach (char c in w) set.Add(c);

            char[] chars = set.ToArray();
            var starts = new HashSet<char>(words.Select(w => w[0])) { result[0] };
            bool[] chosenNums = new bool[10];
            int[] map = new int[256];
            return Backtrack(0);

            bool Backtrack(int i)
            {
                if (i == chars.Length)
                {
                    int sum = words.Select(w => WordToNum(w)).Sum();
                    return sum == WordToNum(result);
                }

                for (int digit = 0; digit <= 9; digit++)
                {
                    if (digit == 0 && starts.Contains(chars[i])) continue;
                    if (chosenNums[digit]) continue;
                    chosenNums[digit] = true;
                    map[chars[i]] = digit;
                    if (Backtrack(i + 1)) return true;
                    chosenNums[digit] = false;
                }

                return false;
            }

            int WordToNum(string word)
            {
                int num = 0;
                foreach (char c in word) num = num * 10 + map[c];
                return num;
            }
        }
    }
}

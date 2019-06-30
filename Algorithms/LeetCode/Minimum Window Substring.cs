using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 76. Minimum Window Substring
     * 
     * Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
     * 
     * Example 1:
     * 
     * Input: S = "ADOBECODEBANC", T = "ABC"
     * Output: "BANC"
     * 
     * Example 2:
     * 
     * Input: S = "aaa", T = "aa"
     * Output: "aa"
     * 
     * Note:
     * If there is no such window in S that covers all characters in T, return the empty string "".
     * If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
     */
    public class MinimumWindowSubstring
    {
        public string MinWindow(string s, string t)
        {
            var charCounts = new Dictionary<char, int>();
            var requiredCounts = new Dictionary<char, int>();
            foreach (var character in t)
            {
                charCounts[character] = 0;
                if (requiredCounts.TryGetValue(character, out int count))
                {
                    requiredCounts[character] = count + 1;
                }
                else requiredCounts[character] = 1;
            }

            var queue = new Queue<int>();
            int totalChars = charCounts.Count;
            int charsSoFar = 0;
            int i = 0;
            for (; i < s.Length; i++)
            {
                if (charCounts.TryGetValue(s[i], out int count))
                {
                    charCounts[s[i]] = ++count;
                    queue.Enqueue(i);
                    if (count == requiredCounts[s[i]]) charsSoFar++;
                    if (charsSoFar == totalChars) break;
                }
            }
            if (charsSoFar != totalChars) return string.Empty;
            if (queue.Count == 0) return string.Empty;
            char c = s[queue.Peek()];
            int countOfC = charCounts[c];
            while (countOfC > requiredCounts[c])
            {
                charCounts[c] = countOfC - 1;
                queue.Dequeue();
                c = s[queue.Peek()];
                countOfC = charCounts[c];
            }

            i++;
            int startIndex = queue.Peek();
            int subStringLength = i - startIndex;
            for (; i < s.Length; i++)
            {
                if (charCounts.TryGetValue(s[i], out int count))
                {
                    charCounts[s[i]] = count + 1;
                    queue.Enqueue(i);
                    if (s[queue.Peek()] == s[i])
                    {
                        c = s[queue.Peek()];
                        countOfC = charCounts[c];
                        while (countOfC > requiredCounts[c])
                        {
                            charCounts[c] = countOfC - 1;
                            queue.Dequeue();
                            c = s[queue.Peek()];
                            countOfC = charCounts[c];
                        }
                        int newSubStringLength = i - queue.Peek() + 1;
                        if (newSubStringLength < subStringLength)
                        {
                            subStringLength = newSubStringLength;
                            startIndex = queue.Peek();
                        }
                    }
                }
            }
            return s.Substring(startIndex, subStringLength);
        }
    }
}

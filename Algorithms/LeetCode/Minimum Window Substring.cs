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
            // Check each character in "s". If a character is in "t", put it in a queue.
            // Repeat the process until we find enough characters. Now we have a potential answer.
            // Continue the process until we find a character that is equal to the head of the queue.
            // So we can surely remove the first character from the queue and maybe some more.
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
            RemoveChars(queue, charCounts, requiredCounts, s);

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
                        RemoveChars(queue, charCounts, requiredCounts, s);
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

        private void RemoveChars(Queue<int> queue, Dictionary<char, int> charCounts, Dictionary<char, int> requiredCounts, string s)
        {
            char queueFirstChar = s[queue.Peek()];
            int queueFirstCharCount = charCounts[queueFirstChar];
            while (queueFirstCharCount > requiredCounts[queueFirstChar])
            {
                charCounts[queueFirstChar] = queueFirstCharCount - 1;
                queue.Dequeue();
                queueFirstChar = s[queue.Peek()];
                queueFirstCharCount = charCounts[queueFirstChar];
            }
        }
    }
}

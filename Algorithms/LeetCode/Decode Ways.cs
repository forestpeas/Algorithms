namespace Algorithms.LeetCode
{
    /* 91. Decode Ways
     * 
     * A message containing letters from A-Z is being encoded to numbers using the following mapping:
     * 'A' -> 1
     * 'B' -> 2
     * ...
     * 'Z' -> 26
     * Given a non-empty string containing only digits, determine the total number of ways to decode it.
     * 
     * Example 1:
     * 
     * Input: "12"
     * Output: 2
     * Explanation: It could be decoded as "AB" (1 2) or "L" (12).
     * 
     * Example 2:
     * 
     * Input: "226"
     * Output: 3
     * Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
     */
    public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            // Here are some test cases that make the problem description more clear:
            // s = "01", output = 0
            // s = "10", output = 1 (ways: 10)
            // s = "101", ouput = 1 (ways: 10 and 1)
            //
            // The idea is similar to "Problem 70. Climbing Stairs".
            int lastLast = 1;
            int last = s[0] == '0' ? 0 : 1;
            for (int i = 1; i < s.Length; i++)
            {
                // See if we can "take 2 steps once".
                int tmp = 0;
                if (s[i - 1] == '0') tmp = 0;
                else if ((s[i - 1] == '1') || (s[i - 1] == '2' && s[i] < '7')) tmp = lastLast;

                int current = (s[i] == '0' ? 0 : last) + tmp;
                lastLast = last;
                last = current;
            }
            return last;
        }
    }
}

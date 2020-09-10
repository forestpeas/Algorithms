using System.Text;

namespace Algorithms.LeetCode
{
    /* 423. Reconstruct Original Digits from English
     * 
     * Given a non-empty string containing an out-of-order English representation of digits 0-9,
     * output the digits in ascending order.
     * 
     * Note:
     * Input contains only lowercase English letters.
     * Input is guaranteed to be valid and can be transformed to its original digits. That means
     * invalid inputs such as "abc" or "zerone" are not permitted.
     * Input length is less than 50,000.
     * 
     * Example 1:
     * Input: "owoztneoer"
     * Output: "012"
     * 
     * Example 2:
     * Input: "fviefuro"
     * Output: "45"
     */
    public class Reconstruct_Original_Digits_from_English
    {
        public string OriginalDigits(string s)
        {
            // from https://leetcode.com/problems/reconstruct-original-digits-from-english/discuss/91207/one-pass-O(n)-JAVA-Solution-Simple-and-Clear
            // Because the input is always valid, we can count the unique letter of each word.
            int[] count = new int[10];
            foreach (char c in s)
            {
                if (c == 'z') count[0]++; // 0 is the only letter that contains 'z'.
                if (c == 'w') count[2]++; // 2 is the only letter that contains 'w'.
                if (c == 'x') count[6]++; // 6 is the only letter that contains 'x'.
                if (c == 's') count[7]++; // 7 and 6 contains 's'.
                if (c == 'g') count[8]++; // 8 is the only letter that contains 'g'.
                if (c == 'u') count[4]++; // 4 is the only letter that contains 'u'.
                if (c == 'f') count[5]++; // 5 and 4 contains 'f'.
                if (c == 'h') count[3]++; // 3 and 8 contains 'h'.
                if (c == 'i') count[9]++; // 9, 8, 5 and 6 contains 'i'.
                if (c == 'o') count[1]++; // 1, 0, 2 and 4 contains 'o'.
            }

            count[7] -= count[6];
            count[5] -= count[4];
            count[3] -= count[8];
            count[9] = count[9] - count[8] - count[5] - count[6];
            count[1] = count[1] - count[0] - count[2] - count[4];
            var sb = new StringBuilder();
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    sb.Append(i);
                }
            }
            return sb.ToString();
        }
    }
}

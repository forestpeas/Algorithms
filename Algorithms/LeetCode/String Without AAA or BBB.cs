using System.Text;

namespace Algorithms.LeetCode
{
    /* 984. String Without AAA or BBB
     * 
     * Given two integers A and B, return any string S such that:
     * 
     * S has length A + B and contains exactly A 'a' letters, and exactly B 'b' letters;
     * The substring 'aaa' does not occur in S;
     * The substring 'bbb' does not occur in S.
     * 
     * Example 1:
     * 
     * Input: A = 1, B = 2
     * Output: "abb"
     * Explanation: "abb", "bab" and "bba" are all correct answers.
     * 
     * Example 2:
     * 
     * Input: A = 4, B = 1
     * Output: "aabaa" 
     * 
     * Note:
     * 
     * 0 <= A <= 100
     * 0 <= B <= 100
     * It is guaranteed such an S exists for the given A and B.
     */
    public class String_Without_AAA_or_BBB
    {
        public string StrWithout3a3b(int A, int B, char a = 'a', char b = 'b')
        {
            // Fill the slots. Easier version of "1405. Longest Happy String".
            if (B > A) return StrWithout3a3b(B, A, 'b', 'a');
            int slots = (A + 1) / 2 - 1;
            int extras = B - slots;
            var res = new StringBuilder();
            for (int i = 0; i < slots; i++)
            {
                res.Append(a);
                res.Append(a);
                res.Append(b);
                if (extras > 0)
                {
                    res.Append(b);
                    extras--;
                }
            }
            res.Append(a);
            if (A % 2 == 0) res.Append(a);
            if (extras == 1)
            {
                res.Append(b);
            }
            else if (extras == 2)
            {
                res.Append(b);
                res.Append(b);
            }

            return res.ToString();
        }
    }
}

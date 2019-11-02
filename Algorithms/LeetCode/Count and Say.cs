using System.Text;

namespace Algorithms.LeetCode
{
    /* 38. Count and Say
     * 
     * The count-and-say sequence is the sequence of integers with the first five terms as following:
     * 
     * 1.     1
     * 2.     11
     * 3.     21
     * 4.     1211
     * 5.     111221
     * 1 is read off as "one 1" or 11.
     * 11 is read off as "two 1s" or 21.
     * 21 is read off as "one 2, then one 1" or 1211.
     * (Every term is generated from the last term.)
     * 
     * Given an integer n where 1 ≤ n ≤ 30, generate the nth term of the count-and-say sequence.
     * 
     * Note: Each term of the sequence of integers will be represented as a string.
     */
    public class CountAndSaySolution
    {
        public string CountAndSay(int n)
        {
            // Just implement the description straightforward.
            string s = "1";
            for (int i = 2; i <= n; i++)
            {
                int count = 1;
                StringBuilder sb = new StringBuilder();
                for (int j = 1; j < s.Length; j++)
                {
                    if (s[j] == s[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(s[j - 1]);
                        count = 1;
                    }
                }
                sb.Append(count);
                sb.Append(s[s.Length - 1]);
                s = sb.ToString();
            }
            return s;
        }
    }
}

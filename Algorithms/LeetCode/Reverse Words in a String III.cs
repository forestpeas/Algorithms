namespace Algorithms.LeetCode
{
    /* 557. Reverse Words in a String III
     * 
     * Given a string, you need to reverse the order of characters in each word within
     * a sentence while still preserving whitespace and initial word order.
     * 
     * Example 1:
     * Input: "Let's take LeetCode contest"
     * Output: "s'teL ekat edoCteeL tsetnoc"
     * 
     * Note: In the string, each word is separated by single space and there will not
     * be any extra space in the string.
     */
    public class Reverse_Words_in_a_String_III
    {
        public string ReverseWords(string s)
        {
            char[] arr = s.ToCharArray();
            int start = 0;
            for (int i = 0; i <= s.Length; i++)
            {
                if (i == s.Length || arr[i] == ' ')
                {
                    Reverse(arr, start, i - 1);
                    start = i + 1;
                }
            }
            return new string(arr);
        }

        private void Reverse(char[] arr, int start, int end)
        {
            while (start < end)
            {
                char tmp = arr[start];
                arr[start] = arr[end];
                arr[end] = tmp;
                start++;
                end--;
            }
        }
    }
}

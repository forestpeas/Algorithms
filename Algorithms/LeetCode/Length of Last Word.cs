namespace Algorithms.LeetCode
{
    /* 58. Length of Last Word
     * 
     * Given a string s consists of upper/lower-case alphabets and empty space characters ' ',
     * return the length of last word in the string.
     * 
     * If the last word does not exist, return 0.
     * 
     * Note: A word is defined as a character sequence consists of non-space characters only.
     * 
     * Example:
     * 
     * Input: "Hello World"
     * Output: 5
     */
    public class LengthOfLastWordSolution
    {
        public int LengthOfLastWord(string s)
        {
            int result = 0;
            int i = s.Length - 1;
            while (i >= 0 && s[i] == ' ')
            {
                i--;
            }
            while (i >= 0 && s[i] != ' ')
            {
                result++;
                i--;
            }
            return result;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 345. Reverse Vowels of a String
     * 
     * Write a function that takes a string as input and reverse only the vowels of a string.
     * 
     * Example 1:
     * 
     * Input: "hello"
     * Output: "holle"
     * 
     * Example 2:
     * 
     * Input: "leetcode"
     * Output: "leotcede"
     */
    public class Reverse_Vowels_of_a_String
    {
        public string ReverseVowels(string s)
        {
            char[] str = s.ToCharArray();
            int lo = 0, hi = s.Length - 1;
            while (lo < hi)
            {
                if (!IsVowel(str[lo])) lo++;
                else if (!IsVowel(str[hi])) hi--;
                else Swap(str, lo++, hi--);
            }
            return new string(str);
        }

        private bool IsVowel(char c)
        {
            c = char.ToLower(c);
            if (c == 'a' || c == 'o' || c == 'e' || c == 'i' || c == 'u') return true;
            return false;
        }

        private void Swap(char[] str, int i, int j)
        {
            char tmp = str[i];
            str[i] = str[j];
            str[j] = tmp;
        }
    }
}

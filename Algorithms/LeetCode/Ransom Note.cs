namespace Algorithms.LeetCode
{
    /* 383. Ransom Note
     * 
     * Given an arbitrary ransom note string and another string containing letters
     * from all the magazines, write a function that will return true if the ransom
     * note can be constructed from the magazines ; otherwise, it will return false.
     * 
     * Each letter in the magazine string can only be used once in your ransom note.
     * 
     * Note:
     * You may assume that both strings contain only lowercase letters.
     * 
     * canConstruct("a", "b") -> false
     * canConstruct("aa", "ab") -> false
     * canConstruct("aa", "aab") -> true
     */
    public class Ransom_Note
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] letters = new int[256];
            foreach (char c in magazine) letters[c]++;
            foreach (char c in ransomNote)
            {
                if (letters[c]-- == 0) return false;
            }
            return true;
        }
    }
}

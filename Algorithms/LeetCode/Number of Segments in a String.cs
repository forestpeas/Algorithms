namespace Algorithms.LeetCode
{
    /* 434. Number of Segments in a String
     * 
     * Count the number of segments in a string, where a segment is defined to be a contiguous
     * sequence of non-space characters.
     * 
     * Example:
     * 
     * Input: "Hello, my name is John"
     * Output: 5
     */
    public class Number_of_Segments_in_a_String
    {
        public int CountSegments(string s)
        {
            // Similar to "419. Battleships in a Board".
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ' && (i - 1 < 0 || s[i - 1] == ' ')) result++;
            }
            return result;
        }

        public int CountSegments2(string s)
        {
            return s.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

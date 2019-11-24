namespace Algorithms.LeetCode
{
    /* 1247. Minimum Swaps to Make Strings Equal
     * 
     * You are given two strings s1 and s2 of equal length consisting of letters "x" and "y" only.
     * Your task is to make these two strings equal to each other. You can swap any two characters
     * that belong to different strings, which means: swap s1[i] and s2[j].
     * 
     * Return the minimum number of swaps required to make s1 and s2 equal, or return -1 if it is
     * impossible to do so.
     * 
     * Example 1:
     * 
     * Input: s1 = "xx", s2 = "yy"
     * Output: 1
     * Explanation: 
     * Swap s1[0] and s2[1], s1 = "yx", s2 = "yx".
     * 
     * Example 2: 
     * 
     * Input: s1 = "xy", s2 = "yx"
     * Output: 2
     * Explanation: 
     * Swap s1[0] and s2[0], s1 = "yy", s2 = "xx".
     * Swap s1[0] and s2[1], s1 = "xy", s2 = "xy".
     * Note that you can't swap s1[0] and s1[1] to make s1 equal to "yx", cause we can only swap chars in
     * different strings.
     * 
     * Example 3:
     * 
     * Input: s1 = "xx", s2 = "xy"
     * Output: -1
     * 
     * Example 4:
     * 
     * Input: s1 = "xxyyxyxyxx", s2 = "xyyxyxxxyx"
     * Output: 4
     *  
     * Constraints:
     * 
     * 1 <= s1.length, s2.length <= 1000
     * s1, s2 only contain 'x' or 'y'.
     */
    public class Minimum_Swaps_to_Make_Strings_Equal
    {
        public int MinimumSwap(string s1, string s2)
        {
            // Try to pair ("xx", "yy") as much as possible, because it only needs 1 swap.
            // If there is a ("xy", "yx") left, we need 2 swaps.
            // For example:
            // s1 = xyxx
            // s2 = yxyy
            // First pair ("s1[0]+s1[2]", "s2[0]+s2[2]").
            // Then pair ("s1[1]+s1[3]", "s2[1]+s2[3]").
            int result = 0;
            int countX = 0;
            int countY = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i]) continue;
                if (s1[i] == 'x')
                {
                    countX++;
                    if (countX == 2)
                    {
                        result++;
                        countX = 0;
                    }
                }
                else
                {
                    countY++;
                    if (countY == 2)
                    {
                        result++;
                        countY = 0;
                    }
                }
            }

            if (countX == 0 && countY == 0) return result;
            if (countX == 1 && countY == 1) return result + 2;
            return -1;
        }
    }
}

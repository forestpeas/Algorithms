using System;

namespace Algorithms.LeetCode
{
    /* 1320. Minimum Distance to Type a Word Using Two Fingers
     * 
     * https://leetcode.com/problems/minimum-distance-to-type-a-word-using-two-fingers/
     */
    public class Minimum_Distance_to_Type_a_Word_Using_Two_Fingers
    {
        public int MinimumDistance(string word)
        {
            // 0 - 25 represents A - Z respectively. 26 represents the initial state.
            // Each time we have two choices, either use the left or right finger to
            // type the letter.
            int[,,] mem = new int[27, 27, word.Length];
            return MinimumDistance(0, 26, 26);

            int MinimumDistance(int pos, int left, int right)
            {
                if (pos == word.Length) return 0;
                if (mem[left, right, pos] != 0) return mem[left, right, pos];

                int to = word[pos] - 'A';
                mem[left, right, pos] = Math.Min(Cost(left, to) + MinimumDistance(pos + 1, to, right),
                    Cost(right, to) + MinimumDistance(pos + 1, left, to));
                return mem[left, right, pos];
            }
        }

        private int Cost(int from, int to)
        {
            if (from == 26) return 0;
            return Math.Abs(from / 6 - to / 6) + Math.Abs((from % 6) - (to % 6));
        }
    }
}

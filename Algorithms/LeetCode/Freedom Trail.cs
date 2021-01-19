using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 514. Freedom Trail
     * 
     * https://leetcode.com/problems/freedom-trail/
     * In the video game Fallout 4, the quest "Road to Freedom" requires players to reach
     * a metal dial called the "Freedom Trail Ring", and use the dial to spell a specific
     * keyword in order to open the door.
     * 
     * Given a string ring, which represents the code engraved on the outer ring and another
     * string key, which represents the keyword needs to be spelled. You need to find the
     * minimum number of steps in order to spell all the characters in the keyword.
     * 
     * Initially, the first character of the ring is aligned at 12:00 direction. You need to
     * spell all the characters in the string key one by one by rotating the ring clockwise
     * or anticlockwise to make each character of the string key aligned at 12:00 direction
     * and then by pressing the center button.
     * 
     * At the stage of rotating the ring to spell the key character key[i]:
     * 
     * You can rotate the ring clockwise or anticlockwise one place, which counts as 1 step.
     * The final purpose of the rotation is to align one of the string ring's characters at
     * the 12:00 direction, where this character must equal to the character key[i].
     * If the character key[i] has been aligned at the 12:00 direction, you need to press the
     * center button to spell, which also counts as 1 step. After the pressing, you could begin
     * to spell the next character in the key (next stage), otherwise, you've finished all the
     * spelling.
     */
    public class Freedom_Trail
    {
        public int FindRotateSteps(string ring, string key)
        {
            // reference: https://leetcode.com/problems/freedom-trail/discuss/98902/Concise-Java-DP-Solution/103038
            var pos = new Dictionary<char, List<int>>();
            for (int i = 0; i < ring.Length; i++)
            {
                if (pos.TryGetValue(ring[i], out var list))
                {
                    list.Add(i);
                }
                else
                {
                    pos.Add(ring[i], new List<int>() { i });
                }
            }

            var state = new Dictionary<int, int>() { [0] = 0 };
            foreach (char c in key)
            {
                var nextState = new Dictionary<int, int>();
                foreach (int j in pos[c])
                {
                    nextState[j] = int.MaxValue;
                    foreach (int i in state.Keys)
                    {
                        nextState[j] = Math.Min(nextState[j], Dist(i, j) + state[i]);
                    }
                }
                state = nextState;
            }
            return state.Values.Min() + key.Length;

            int Dist(int i, int j)
            {
                return Math.Min(Math.Abs(i - j), ring.Length - Math.Abs(i - j));
            }
        }
    }
}

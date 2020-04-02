using System;

namespace Algorithms.LeetCode
{
    /* 1375. Bulb Switcher III
     * 
     * There is a room with n bulbs, numbered from 1 to n, arranged in a row from left to right. Initially,
     * all the bulbs are turned off.
     * 
     * At moment k (for k from 0 to n - 1), we turn on the light[k] bulb. A bulb change color to blue only
     * if it is on and all the previous bulbs (to the left) are turned on too.
     * 
     * Return the number of moments in which all turned on bulbs are blue.
     * 
     * Example 1:
     * https://leetcode.com/problems/bulb-switcher-iii/
     * Input: light = [2,1,3,5,4]
     * Output: 3
     * Explanation: All bulbs turned on, are blue at the moment 1, 2 and 4.
     */
    public class Bulb_Switcher_III
    {
        public int NumTimesAllBlue(int[] lights)
        {
            // https://leetcode.com/problems/bulb-switcher-iii/discuss/532538/JavaC%2B%2BPython-Straight-Forward-O(1)-Space
            // rightMostOn is the number of the rightmost light that is on.
            // (i + 1) is the total number of lights that is on so far. 
            int rightMostOn = 0, res = 0;
            for (int i = 0; i < lights.Length; i++)
            {
                rightMostOn = Math.Max(rightMostOn, lights[i]);
                if (rightMostOn == (i + 1)) res++;
            }
            return res;
        }

        public int NumTimesAllBlue2(int[] lights)
        {
            // First time try.
            bool[] onOff = new bool[lights.Length + 1];
            bool[] blue = new bool[lights.Length + 1];
            blue[0] = true;
            int rightMostOn = 0;
            int result = 0;
            foreach (int l in lights)
            {
                onOff[l] = true;
                rightMostOn = Math.Max(rightMostOn, l);
                if (blue[l - 1])
                {
                    int i = l - 1;
                    while (i + 1 <= lights.Length && onOff[i + 1])
                    {
                        blue[i + 1] = true;
                        i++;
                    }

                    if (i == rightMostOn) result++;
                }
            }
            return result;
        }
    }
}

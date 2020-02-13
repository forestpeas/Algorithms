using System;

namespace Algorithms.LeetCode
{
    /* 1344. Angle Between Hands of a Clock
     * 
     * Given two numbers, hour and minutes. Return the smaller angle (in sexagesimal units)
     * formed between the hour and the minute hand.
     * 
     * https://leetcode.com/problems/angle-between-hands-of-a-clock/
     * 
     * Example 1:
     * 
     * Input: hour = 12, minutes = 30
     * Output: 165
     * 
     * Constraints:
     *     1 <= hour <= 12
     *     0 <= minutes <= 59
     *     Answers within 10^-5 of the actual value will be accepted as correct.
     */
    public class Angle_Between_Hands_of_a_Clock
    {
        public double AngleClock(int hour, int minutes)
        {
            if (hour == 12) hour = 0;
            // Convert hour and minutes to sexagesimal units.
            double h = hour * 30;
            double m = minutes * 6;
            h += m / 360 * 30;
            double angle = Math.Abs(m - h);
            return Math.Min(angle, 360 - angle);
        }
    }
}

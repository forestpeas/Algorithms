using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 401. Binary Watch
     * 
     * A binary watch has 4 LEDs on the top which represent the hours (0-11), and the 6 LEDs
     * on the bottom represent the minutes (0-59).
     * 
     * Each LED represents a zero or one, with the least significant bit on the right.
     * Given a non-negative integer n which represents the number of LEDs that are currently on,
     * return all possible times the watch could represent.
     * 
     * https://leetcode.com/problems/binary-watch/
     */
    public class Binary_Watch
    {
        public IList<string> ReadBinaryWatch(int num)
        {
            // Check all possible numbers.
            var result = new List<string>();
            for (int hour = 0; hour <= 11; hour++)
            {
                for (int minute = 0; minute <= 59; minute++)
                {
                    if (NumberOfOneBits(hour) + NumberOfOneBits(minute) == num)
                    {
                        result.Add($"{hour}:{string.Format("{0:00}", minute)}");
                    }
                }
            }
            return result;
        }

        public IList<string> ReadBinaryWatch2(int num)
        {
            // Improve on the above soluton.
            var hours = new List<int>[num + 1];
            for (int hour = 0; hour <= 11; hour++)
            {
                int bits = NumberOfOneBits(hour);
                if (bits <= num)
                {
                    if (hours[bits] == null) hours[bits] = new List<int>();
                    hours[bits].Add(hour);
                }
            }

            var minutes = new List<int>[num + 1];
            for (int minute = 0; minute <= 59; minute++)
            {
                int bits = NumberOfOneBits(minute);
                if (bits <= num)
                {
                    if (minutes[bits] == null) minutes[bits] = new List<int>();
                    minutes[bits].Add(minute);
                }
            }

            var result = new List<string>();
            for (int i = 0; i <= num; i++)
            {
                foreach (int hour in hours[i] ?? Enumerable.Empty<int>())
                {
                    foreach (int minute in minutes[num - i] ?? Enumerable.Empty<int>())
                    {
                        result.Add($"{hour}:{string.Format("{0:00}", minute)}");
                    }
                }
            }
            return result;
        }

        private int NumberOfOneBits(int n)
        {
            return NumberOf1Bits.HammingWeight((uint)n);
        }
    }
}

using System;

namespace Algorithms.LeetCode
{
    /* 1256. Encode Number
     * 
     * https://leetcode.com/problems/encode-number/
     */
    public class Encode_Number
    {
        public string Encode(int num)
        {
            // The binary representation of 1,2,3,4,5...
            // 1
            // 10
            // 11
            // 100
            // 101
            // 110
            // 111
            // 1000
            // Compared to the table given, there is only a "1" on the left that is redundant.
            return Convert.ToString(num + 1, 2).Substring(1);
        }

        public string Encode2(int num)
        {
            // Count from 0, until we reach a j-digit largest number.
            if (num == 0) return "";
            int i = 1; // 1,2,4,8,16...
            int j = 0; // 0,1,2,3,4...
            while (true)
            {
                if (num >= i) num -= i;
                else
                {
                    string s = Convert.ToString(num, 2);
                    // Pad 0 so that the length of s is j.
                    int tmp = s.Length;
                    for (int k = 0; k < j - tmp; k++)
                    {
                        s = "0" + s;
                    }
                    return s;
                }

                i = i * 2;
                j++;
            }
        }
    }
}

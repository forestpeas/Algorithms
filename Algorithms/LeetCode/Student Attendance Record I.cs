﻿namespace Algorithms.LeetCode
{
    /* 551. Student Attendance Record I
     * 
     * You are given a string representing an attendance record for a student. The record only contains the
     * following three characters:
     * 'A' : Absent.
     * 'L' : Late.
     * 'P' : Present.
     * A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or
     * more than two continuous 'L' (late).
     * 
     * You need to return whether the student could be rewarded according to his attendance record.
     * 
     * Example 1:
     * Input: "PPALLP"
     * Output: True
     * 
     * Example 2:
     * Input: "PPALLL"
     * Output: False
     */
    public class Student_Attendance_Record_I
    {
        public bool CheckRecord(string s)
        {
            int a = 0, l = 0;
            foreach (char c in s)
            {
                if (c == 'L')
                {
                    l++;
                    if (l > 2) return false;
                    continue;
                }
                l = 0;
                if (c == 'A')
                {
                    a++;
                    if (a > 1) return false;
                }
            }
            return true;
        }
    }
}

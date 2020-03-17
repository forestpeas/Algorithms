using System;

namespace Algorithms.LeetCode
{
    /* 1360. Number of Days Between Two Dates
     * 
     * Write a program to count the number of days between two dates.
     * 
     * The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.
     * 
     * Example 1:
     * 
     * Input: date1 = "2019-06-29", date2 = "2019-06-30"
     * Output: 1
     * 
     * Example 2:
     * 
     * Input: date1 = "2020-01-15", date2 = "2019-12-31"
     * Output: 15
     */
    public class Number_of_Days_Between_Two_Dates
    {
        public int DaysBetweenDates(string date1, string date2)
        {
            DateTime d1 = DateTime.ParseExact(date1, "yyyy-MM-dd", null);
            DateTime d2 = DateTime.ParseExact(date2, "yyyy-MM-dd", null);
            return Convert.ToInt32(Math.Abs((d2 - d1).TotalDays));
        }
    }
}

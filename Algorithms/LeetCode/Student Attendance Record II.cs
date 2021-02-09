namespace Algorithms.LeetCode
{
    /* 552. Student Attendance Record II
     * 
     * Given a positive integer n, return the number of all possible attendance records with length n,
     * which will be regarded as rewardable. The answer may be very large, return it after mod 109 + 7.
     * 
     * A student attendance record is a string that only contains the following three characters:
     * 
     * 'A' : Absent.
     * 'L' : Late.
     * 'P' : Present.
     * A record is regarded as rewardable if it doesn't contain more than one 'A' (absent) or more than
     * two continuous 'L' (late).
     * 
     * Example 1:
     * Input: n = 2
     * Output: 8 
     * Explanation:
     * There are 8 records with length 2 will be regarded as rewardable:
     * "PP" , "AP", "PA", "LP", "PL", "AL", "LA", "LL"
     * Only "AA" won't be regarded as rewardable owing to more than one absent times. 
     */
    public class Student_Attendance_Record_II
    {
        public int CheckRecord(int n)
        {
            // a = count of records that contain 'A' and don't end with 'L'
            // al = count of records that contain 'A' and end with 'L'
            // all = count of records that contain 'A' and end with 'LL'
            // p = count of records that don't contain 'A' and don't end with 'L'
            // pl = count of records that don't contain 'A' and end with 'L'
            // pll = count of records that don't contain 'A' and end with 'LL'
            long a = 1, al = 0, all = 0, p = 1, pl = 1, pll = 0;
            int mod = 1000000007;
            while (--n > 0)
            {
                long a_next = a + al + all + p + pl + pll;
                long al_next = a;
                long all_next = al;
                long p_next = p + pl + pll;
                long pl_next = p;
                long pll_next = pl;

                a = a_next % mod;
                al = al_next % mod;
                all = all_next % mod;
                p = p_next % mod;
                pl = pl_next % mod;
                pll = pll_next % mod;
            }
            return (int)((a + al + all + p + pl + pll) % mod);
        }
    }
}

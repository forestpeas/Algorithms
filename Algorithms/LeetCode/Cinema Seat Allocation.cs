using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1386. Cinema Seat Allocation
     * 
     * https://leetcode.com/problems/cinema-seat-allocation/
     */
    public class Cinema_Seat_Allocation
    {
        public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            // Just check all possible cases.
            var reserved = new Dictionary<int, List<int>>();
            foreach (int[] reservedSeat in reservedSeats)
            {
                if (!reserved.ContainsKey(reservedSeat[0])) reserved.Add(reservedSeat[0], new List<int>());
                reserved[reservedSeat[0]].Add(reservedSeat[1]);
            }

            int res = 2 * n;
            foreach (var seats in reserved.Values)
            {
                // Can be optimized by bit manipulation.
                int count = 0;
                if (new int[] { 2, 3, 4, 5 }.All(s => !seats.Contains(s))) count++;
                if (new int[] { 6, 7, 8, 9 }.All(s => !seats.Contains(s))) count++;
                if (count == 2) continue;
                else if (count == 1) res -= 1;
                else if (new int[] { 4, 5, 6, 7 }.All(s => !seats.Contains(s))) res -= 1;
                else res -= 2;
            }
            return res;
        }
    }
}

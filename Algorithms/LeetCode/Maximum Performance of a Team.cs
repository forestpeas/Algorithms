using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1383. Maximum Performance of a Team
     * 
     * There are n engineers numbered from 1 to n and two arrays: speed and efficiency, where speed[i] and
     * efficiency[i] represent the speed and efficiency for the i-th engineer respectively. Return the
     * maximum performance of a team composed of at most k engineers, since the answer can be a huge number,
     * return this modulo 10^9 + 7.
     * 
     * The performance of a team is the sum of their engineers' speeds multiplied by the minimum efficiency
     * among their engineers. 
     * 
     * Example 1:
     * 
     * Input: n = 6, speed = [2,10,3,1,5,8], efficiency = [5,4,3,9,7,2], k = 2
     * Output: 60
     * Explanation: 
     * We have the maximum performance of the team by selecting engineer 2 (with speed=10 and efficiency=4)
     * and engineer 5 (with speed=5 and efficiency=7). That is, performance = (10 + 5) * min(4, 7) = 60.
     * 
     * Example 2:
     * 
     * Input: n = 6, speed = [2,10,3,1,5,8], efficiency = [5,4,3,9,7,2], k = 3
     * Output: 68
     * Explanation:
     * This is the same example as the first but k = 3. We can select engineer 1, engineer 2 and engineer 5
     * to get the maximum performance of the team. That is, performance = (2 + 10 + 5) * min(5, 4, 7) = 68.
     * 
     * Example 3:
     * 
     * Input: n = 6, speed = [2,10,3,1,5,8], efficiency = [5,4,3,9,7,2], k = 4
     * Output: 72
     */
    public class Maximum_Performance_of_a_Team
    {
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            // For each efficiency e, if e is the minimum efficiency in the result, then the
            // corresponding maximum sum of speeds should be the sum of the k(or less than k)
            // highest speeds among the engineers with efficiencies equal or greater than e.
            // So we can sort the engineers by their efficiencies in decreasing order, and use
            // a priority queue to keep track of the k highest speeds.
            Engineer[] engineers = new Engineer[n];
            for (int i = 0; i < n; i++)
            {
                engineers[i] = new Engineer(speed[i], efficiency[i]);
            }

            Array.Sort(engineers, comparer: Comparer<Engineer>.Create((a, b) => b.efficiency - a.efficiency));
            var pq = new PriorityQueue<int>(Comparer<int>.Create((x, y) => y - x));
            long result = 0, speedSum = 0;
            foreach (var engineer in engineers)
            {
                if (pq.Count < k)
                {
                    pq.Add(engineer.speed);
                    speedSum += engineer.speed;
                }
                else if (engineer.speed > pq.PeekTop())
                {
                    speedSum -= pq.DeleteTop();
                    pq.Add(engineer.speed);
                    speedSum += engineer.speed;
                }

                result = Math.Max(result, speedSum * engineer.efficiency);
            }

            return (int)(result % 1000000007L);
        }

        private class Engineer
        {
            public int speed;
            public int efficiency;
            public Engineer(int s, int e)
            {
                speed = s;
                efficiency = e;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1235. Maximum Profit in Job Scheduling
     * 
     * https://leetcode.com/problems/maximum-profit-in-job-scheduling/
     */
    public class MaximumProfitInJobScheduling
    {
        private class Job
        {
            public int startTime;
            public int endTime;
            public int profit;
            public Job(int s, int e, int p)
            {
                startTime = s;
                endTime = e;
                profit = p;
            }
        }

        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            // 1. Sort by startTime.
            // 2. dp[i] is the max profit starting from jobs[i] to the end.
            // 3. From right to left, binary search job[i].endTime in the sorted startTime array
            // in order to find the first non-overlapping job[j] with job[i].
            Job[] jobs = new Job[startTime.Length];
            for (int i = 0; i < jobs.Length; i++) jobs[i] = new Job(startTime[i], endTime[i], profit[i]);

            Array.Sort(jobs, Comparer<Job>.Create((x, y) => x.startTime - y.startTime));
            startTime = jobs.Select(j => j.startTime).ToArray();
            int[] dp = new int[jobs.Length + 1];
            for (int i = dp.Length - 2; i >= 0; i--)
            {
                int j = Array.BinarySearch(startTime, jobs[i].endTime);
                if (j < 0) j = ~j;
                // Either take or not take jobs[i].
                int currProfit = jobs[i].profit + dp[j];
                if (currProfit > dp[i + 1])
                {
                    dp[i] = currProfit;
                    // In case jobs[i+1],jobs[i+2]...are equal to jobs[i] in startTime.
                    for (int k = i; k < jobs.Length - 1 && jobs[k].startTime == jobs[k + 1].startTime; k++)
                    {
                        dp[k + 1] = currProfit;
                    }
                }
                else dp[i] = dp[i + 1];
            }

            return dp[0];
        }
    }
}

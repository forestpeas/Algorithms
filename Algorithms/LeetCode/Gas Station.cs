﻿namespace Algorithms.LeetCode
{
    /* 134. Gas Station
     * 
     * There are N gas stations along a circular route, where the amount of gas at station i is gas[i].
     * You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to
     * its next station (i+1). You begin the journey with an empty tank at one of the gas stations.
     * Return the starting gas station's index if you can travel around the circuit once in the clockwise
     * direction, otherwise return -1.
     * 
     * Note:
     * If there exists a solution, it is guaranteed to be unique.
     * Both input arrays are non-empty and have the same length.
     * Each element in the input arrays is a non-negative integer.
     * 
     * Example 1:
     * 
     * Input: 
     * gas  = [1,2,3,4,5]
     * cost = [3,4,5,1,2]
     * 
     * Output: 3
     * 
     * Explanation:
     * Start at station 3 (index 3) and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
     * Travel to station 4. Your tank = 4 - 1 + 5 = 8
     * Travel to station 0. Your tank = 8 - 2 + 1 = 7
     * Travel to station 1. Your tank = 7 - 3 + 2 = 6
     * Travel to station 2. Your tank = 6 - 4 + 3 = 5
     * Travel to station 3. The cost is 5. Your gas is just enough to travel back to station 3.
     * Therefore, return 3 as the starting index.
     * 
     * Example 2:
     * 
     * Input: 
     * gas  = [2,3,4]
     * cost = [3,4,3]
     * 
     * Output: -1
     * 
     * Explanation:
     * You can't start at station 0 or 1, as there is not enough gas to travel to the next station.
     * Let's start at station 2 and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
     * Travel to station 0. Your tank = 4 - 3 + 2 = 3
     * Travel to station 1. Your tank = 3 - 3 + 3 = 3
     * You cannot travel back to station 2, as it requires 4 unit of gas but you only have 3.
     * Therefore, you can't travel around the circuit once no matter where you start.
     */
    public class GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            // Let diff = gas[i] - cost[i], for example:
            // gas  = [1, 2, 3, 4, 5]
            // cost = [3, 4, 5, 1, 2]
            // diff = -2 -2 -2  3  3
            // The question becomes: find a position in diff such that the accumulative sum
            // in the clockwise direction is always non-negative. For example, starting from
            // index 3, the accumulative sum are 3, 6, 4, 2, 0. If the accumulative sum becomes
            // negative, we reset it to 0. If it becomes non-negative from negative, we record
            // the current index. As long as the total sum is positive, diff[0] to diff[result - 1]
            // should also satisfy the requirement if we start from diff[result].
            int sum = 0; // total sum
            int currentSum = 0; // accumulative sum
            int result = 0;
            int i = 0;
            for (; i < gas.Length; i++)
            {
                int diff = gas[i] - cost[i];
                sum += diff;
                currentSum += diff;
                if (currentSum < 0)
                {
                    currentSum = 0;
                    result = i + 1;
                }
            }

            if (sum < 0) return -1;
            return result;
        }
    }
}
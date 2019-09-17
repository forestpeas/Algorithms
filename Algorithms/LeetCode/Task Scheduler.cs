using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 621. Task Scheduler
     * 
     * Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different
     * letters represent different tasks. Tasks could be done without original order. Each task could be done
     * in one interval. For each interval, CPU could finish one task or just be idle.
     * 
     * However, there is a non-negative cooling interval n that means between two same tasks, there must be at
     * least n intervals that CPU are doing different tasks or just be idle.
     * 
     * You need to return the least number of intervals the CPU will take to finish all the given tasks.
     * 
     * Example:
     * 
     * Input: tasks = ["A","A","A","B","B","B"], n = 2
     * Output: 8
     * Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.
     * 
     * Note:
     * The number of tasks is in the range [1, 10000].
     * The integer n is in the range [0, 100].
     */
    public class TaskScheduler
    {
        public int LeastInterval(char[] tasks, int n)
        {
            // From the example above, we can see that even B's count is 2 or 1, the output stays the same.
            // So maybe we can construct a "maximum ouput" first, for example:
            // tasks = ["A","A","A","B","B"], n = 2
            // "A" appears the maximum number of times, so we construct this ouput:
            // A -> idle -> idle -> A -> idle -> idle -> A
            // Then insert each "B" to each corresponding "idle":
            // A -> B -> idle -> A -> B -> idle -> A
            var taskCounter = new Dictionary<char, int>();
            foreach (char task in tasks)
            {
                taskCounter[task] = taskCounter.GetValueOrDefault(task) + 1;
            }

            // maxCountNum = how many kind of tasks has the "maxCount".
            // For example: tasks = ["A","A","A","B","B","B"], n = 2
            // "A" and "B" both appear 3 times, so maxCountNum = 2.
            // In this case, we have to add another B to the end:
            // A -> B -> idle -> A -> B -> idle -> A -> B
            int maxCount = 0;
            int maxCountNum = 0;
            foreach (var item in taskCounter)
            {
                char task = item.Key;
                int count = item.Value;
                if (count > maxCount)
                {
                    maxCount = count;
                    maxCountNum = 1;
                }
                else if (count == maxCount)
                {
                    maxCountNum++;
                }
            }

            // maxCount = 3 "A"
            // (maxCount - 1) * n = intervals between these "A"
            // maxCountNum - 1 = extra item if maxCountNum > 1
            int result = maxCount + (maxCount - 1) * n + (maxCountNum - 1);
            // In some cases, the result can be smaller than tasks.Length
            // because "n" is too small. For example:
            // tasks = ["A","A","A","B","B","C"], n = 1
            // We will get 5 because: 
            // A -> idle -> A -> idle -> A
            // A -> B -> A -> B -> A
            // In these cases, we only have to insert the extra tasks in this way:
            // A -> B -> C -> A -> B -> A
            // which means there is always a way to execute the tasks without any idles.
            return Math.Max(result, tasks.Length);
        }
    }
}

using Algorithms.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1792. Maximum Average Pass Ratio
     * 
     * There is a school that has classes of students and each class will be having a final exam.
     * You are given a 2D integer array classes, where classes[i] = [passi, totali]. You know
     * beforehand that in the ith class, there are totali total students, but only passi number
     * of students will pass the exam.
     * 
     * You are also given an integer extraStudents. There are another extraStudents brilliant
     * students that are guaranteed to pass the exam of any class they are assigned to. You want
     * to assign each of the extraStudents students to a class in a way that maximizes the average
     * pass ratio across all the classes.
     * 
     * The pass ratio of a class is equal to the number of students of the class that will pass
     * the exam divided by the total number of students of the class. The average pass ratio is
     * the sum of pass ratios of all the classes divided by the number of the classes.
     * 
     * Return the maximum possible average pass ratio after assigning the extraStudents students.
     * Answers within 10-5 of the actual answer will be accepted.  
     * 
     * Example 1:
     * 
     * Input: classes = [[1,2],[3,5],[2,2]], extraStudents = 2
     * Output: 0.78333
     * Explanation: You can assign the two extra students to the first class. The average pass
     * ratio will be equal to (3/4 + 3/5 + 2/2) / 3 = 0.78333.
     * 
     * Example 2:
     * 
     * Input: classes = [[2,4],[3,9],[4,5],[2,10]], extraStudents = 4
     * Output: 0.53485
     */
    public class Maximum_Average_Pass_Ratio
    {
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            var pq = new PriorityQueue<int[]>(Comparer<int[]>.Create((x, y) => GetDiff(x).CompareTo(GetDiff(y))));
            foreach (int[] c in classes)
            {
                pq.Add(c);
            }

            while (extraStudents > 0)
            {
                int[] maxDiffClass = pq.DeleteTop();
                maxDiffClass[0] += 1;
                maxDiffClass[1] += 1;
                pq.Add(maxDiffClass);
                extraStudents--;
            }
            return classes.Select(c => (double)c[0] / c[1]).Sum() / classes.Length;

            static double GetDiff(int[] c)
            {
                return ((double)c[0] + 1) / (c[1] + 1) - (double)c[0] / c[1];
            }
        }

        public double MaxAverageRatio2(int[][] classes, int extraStudents)
        {
            // same as above, but won't get TLE, because there is no need to re-calculate ratio every time
            // when doing compare in priority queue
            var rClasses = classes.Select(c => new double[] { c[0], c[1], GetDiff(c[0], c[1]) }).ToArray();
            var pq = new PriorityQueue<double[]>(Comparer<double[]>.Create((x, y) => x[2].CompareTo(y[2])));
            foreach (double[] c in rClasses)
            {
                pq.Add(c);
            }

            while (extraStudents > 0)
            {
                double[] maxDiffClass = pq.DeleteTop();
                maxDiffClass[0] += 1;
                maxDiffClass[1] += 1;
                maxDiffClass[2] = GetDiff(maxDiffClass[0], maxDiffClass[1]);
                pq.Add(maxDiffClass);
                extraStudents--;
            }
            return rClasses.Select(c => c[0] / c[1]).Sum() / rClasses.Length;

            static double GetDiff(double m, double n)
            {
                return (m + 1) / (n + 1) - m / n;
            }
        }
    }
}

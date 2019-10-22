using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 406. Queue Reconstruction by Height
     * 
     * Suppose you have a random list of people standing in a queue. Each person is described by
     * a pair of integers (h, k), where h is the height of the person and k is the number of people
     * in front of this person who have a height greater than or equal to h. Write an algorithm to
     * reconstruct the queue.
     * 
     * Note:
     * The number of people is less than 1,100.
     * 
     *  
     * Example
     * 
     * Input:
     * [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
     * 
     * Output:
     * [[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]
     */
    public class QueueReconstructionByHeight
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            // My first attempt based on shortest to tallest sort.
            // The shortest person should be directly placed to its k position, because any other
            // position would cause there to be more higher people than k. No matter how the
            // rest of the people are placed later, they won't affect this first one(its k will
            // always be valid).
            // Now the first one's position is fixed, consider the rest of the positions as a
            // virtual array. The virtual indexes do not include the fixed positions.
            Array.Sort(people, Comparer<int[]>.Create((x, y) => x[0] - y[0]));
            int[][] result = new int[people.Length][];
            for (int i = 0; i < people.Length; i++)
            {
                int j = 0;
                for (int k = 0; k <= people[i][1]; j++)
                {
                    // Check whether the position is available (empty) and take the k-th available
                    // position. Note the corner case where heights are equal.
                    if (result[j] == null || result[j][0] == people[i][0]) k++;
                }

                result[j - 1] = people[i];
            }

            return result;
        }

        public int[][] ReconstructQueue1(int[][] people)
        {
            // Same idea based on tallest to shortest sort, but code is more concise.
            var sortedPeople = people.OrderByDescending(p => p[0]).ThenBy(p => p[1]);
            var result = new List<int[]>();
            foreach (var person in sortedPeople)
            {
                result.Insert(person[1], person);
            }
            return result.ToArray();
        }
    }
}

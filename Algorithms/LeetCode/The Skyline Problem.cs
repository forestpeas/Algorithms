using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 218. The Skyline Problem
     * 
     * A city's skyline is the outer contour of the silhouette formed by all the buildings in that city
     * when viewed from a distance. Now suppose you are given the locations and height of all the buildings
     * as shown on a cityscape photo (Figure A), write a program to output the skyline formed by these
     * buildings collectively (Figure B).
     * 
     * https://leetcode.com/problems/the-skyline-problem/
     */
    public class TheSkylineProblem
    {
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            // Inspired by https://leetcode.com/problems/the-skyline-problem/discuss/61279/My-C++-code-using-one-priority-queue-(812-ms)/126604
            // In each iteration, the pair (pos, height) is a potential key point in the result. When a building
            // is added to the pq (priority queue), if it becomes the new highest building in the pq, its L (left
            // x coordinate) and H (height) should be a key point. When a highest building (let's call it B-max)
            // is removed from the pq, its R (right x coordinate) and the next highest building's H should be a
            // key point, but first we need to remove those that are "overshadowed" by B-max, that is, those whose
            // R and H are both less than B-max. When should we remove the highest building? When building[i] is
            // completely non-overlapping with B-max, that is, when buildings[i].L > pq.PeekTop().R, otherwise
            // the height which pairs with B-max's R is not certain yet (Think about it with pictures in your head).
            // When removing, if there are buildings in pq that have the same height, PeekTop() should return the
            // rightmost one because the left ones are already "useless". We should think about different cases
            // with a picture in our head or draw it on a paper.
            var result = new List<IList<int>>();
            var pq = new PriorityQueue<int[]>(Comparer<int[]>.Create((x, y) => x[2] != y[2] ? x[2] - y[2] : x[1] - y[1]));
            int i = 0;
            while (i < buildings.Length || !pq.IsEmpty)
            {
                int pos, height; // A potential key point in the result.

                // When adding to pq, we can obtain a potential key point with the building's L.
                // When removing from pq, we can obtain a potential key point with the building's R.
                // If buildings[i] overlaps with pq.PeekTop(), add it to pq, else remove from pq.
                if (i < buildings.Length && (pq.IsEmpty || buildings[i][0] <= pq.PeekTop()[1]))
                {
                    pos = buildings[i][0];
                    // Wait until the highest building is added if their L are all equal.
                    while (i < buildings.Length && buildings[i][0] == pos) pq.Add(buildings[i++]);
                    height = pq.PeekTop()[2];
                }
                else
                {
                    pos = pq.PeekTop()[1];
                    // Remove all the buidlings that are "overshadowed" by this highest building.
                    while (!pq.IsEmpty && pq.PeekTop()[1] <= pos) pq.DeleteTop();
                    height = pq.IsEmpty ? 0 : pq.PeekTop()[2];
                }

                // Check whether the new height becomes the new highest when adding. After all,
                // there can never be 2 consecutive same heights in the result.
                if (result.Count == 0 || result[result.Count - 1][1] != height)
                {
                    result.Add(new int[] { pos, height });
                }
            }

            return result;
        }
    }
}

using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1257. Smallest Common Region
     * 
     * You are given some lists of regions where the first region of each list includes all other regions
     * in that list.
     * Naturally, if a region X contains another region Y then X is bigger than Y.
     * Given two regions region1, region2, find out the smallest region that contains both of them.
     * If you are given regions r1, r2 and r3 such that r1 includes r3, it is guaranteed there is no r2 such
     * that r2 includes r3.
     * It's guaranteed the smallest region exists.
     * 
     * Example 1:
     * 
     * Input:
     * regions = [["Earth","North America","South America"],
     * ["North America","United States","Canada"],
     * ["United States","New York","Boston"],
     * ["Canada","Ontario","Quebec"],
     * ["South America","Brazil"]],
     * region1 = "Quebec",
     * region2 = "New York"
     * Output: "North America"
     * 
     * Constraints:
     * 2 <= regions.length <= 10^4
     * region1 != region2
     * All strings consist of English letters and spaces with at most 20 letters.
     */
    public class Smallest_Common_Region
    {
        public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
        {
            // Similar to "Find the Lowest Common Ancestor of a Tree".
            var parents = new Dictionary<string, string>();
            foreach (var list in regions)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    parents[list[i]] = list[0];
                }
            }

            // "Path" of region1 and region2.
            var r1 = new HashSet<string>() { region1 };
            var r2 = new HashSet<string>() { region2 };
            while (true)
            {
                if (region1 == region2) return region1;

                if (!parents.ContainsKey(region1)) parents[region1] = region1; // root
                if (!parents.ContainsKey(region2)) parents[region2] = region2; // root
                string parent1 = parents[region1];
                string parent2 = parents[region2];
                if (r1.Contains(parent2)) return parent2;
                if (r2.Contains(parent1)) return parent1;

                r1.Add(parent1);
                r2.Add(parent2);
                region1 = parent1;
                region2 = parent2;
            }
        }
    }
}

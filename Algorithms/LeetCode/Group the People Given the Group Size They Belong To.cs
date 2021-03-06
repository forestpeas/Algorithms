﻿using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1282. Group the People Given the Group Size They Belong To
     * 
     * There are n people whose IDs go from 0 to n - 1 and each person belongs exactly to one group.
     * Given the array groupSizes of length n telling the group size each person belongs to, return
     * the groups there are and the people's IDs each group includes.
     * 
     * You can return any solution in any order and the same applies for IDs. Also, it is guaranteed
     * that there exists at least one solution. 
     * 
     * Example 1:
     * 
     * Input: groupSizes = [3,3,3,3,3,1,3]
     * Output: [[5],[0,1,2],[3,4,6]]
     * Explanation: 
     * Other possible solutions are [[2,1,6],[5],[0,4,3]] and [[5],[0,6,2],[4,3,1]].
     * 
     * Example 2:
     * 
     * Input: groupSizes = [2,1,3,3,3,2]
     * Output: [[1],[0,5],[2,3,4]]
     */
    public class Group_the_People_Given_the_Group_Size_They_Belong_To
    {
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var result = new List<IList<int>>();
            var map = new Dictionary<int, List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                int size = groupSizes[i];
                if (!map.ContainsKey(size) || map[size] == null) map[size] = new List<int>();
                map[size].Add(i);
                if (map[size].Count == size)
                {
                    result.Add(map[size]);
                    map[size] = null;
                }
            }
            return result;
        }
    }
}

using System;

namespace Algorithms.LeetCode
{
    /* 546. Remove Boxes
     * 
     * You are given several boxes with different colors represented by different positive numbers.
     * 
     * You may experience several rounds to remove boxes until there is no box left. Each time you
     * can choose some continuous boxes with the same color (i.e., composed of k boxes, k >= 1),
     * remove them and get k * k points.
     * 
     * Return the maximum points you can get.
     * 
     * Example 1:
     * 
     * Input: boxes = [1,3,2,2,2,3,4,3,1]
     * Output: 23
     * Explanation:
     * [1, 3, 2, 2, 2, 3, 4, 3, 1] 
     * ----> [1, 3, 3, 4, 3, 1] (3*3=9 points) 
     * ----> [1, 3, 3, 3, 1] (1*1=1 points) 
     * ----> [1, 1] (3*3=9 points) 
     * ----> [] (2*2=4 points)
     * 
     * Example 2:
     * 
     * Input: boxes = [1,1,1]
     * Output: 9
     * 
     * Example 3:
     * 
     * Input: boxes = [1]
     * Output: 1
     */
    public class Remove_Boxes
    {
        public int RemoveBoxes(int[] boxes)
        {
            // from https://leetcode.com/problems/remove-boxes/discuss/101310/Java-top-down-and-bottom-up-DP-solutions
            int n = boxes.Length;
            int[,,] mem = new int[n, n, n + 1];
            return F(0, n - 1, 1);

            int F(int i, int j, int k)
            {
                if (i > j) return 0;
                if (mem[i, j, k] > 0) return mem[i, j, k];

                // we should save res to mem["starting_i", j, "starting_k"] instead of mem[i, j, k]
                // because next time we reach a same sub-problem, we will get the same
                // "starting i and k", and we want to return directly with mem[i, j, k]
                int starting_i = i, starting_k = k;
                while (i + 1 <= j && boxes[i + 1] == boxes[i])
                {
                    i++;
                    k++;
                }

                int res = k * k + F(i + 1, j, 1);

                for (int m = i + 1; m <= j; m++)
                {
                    if (boxes[m] == boxes[i])
                    {
                        res = Math.Max(res, F(i + 1, m - 1, 1) + F(m, j, k + 1));
                    }
                }

                mem[starting_i, j, starting_k] = res;
                return res;
            }
        }
    }
}

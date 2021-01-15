using Algorithms.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 508. Most Frequent Subtree Sum
     * 
     * Given the root of a tree, you are asked to find the most frequent subtree sum. The subtree
     * sum of a node is defined as the sum of all the node values formed by the subtree rooted at
     * that node (including the node itself). So what is the most frequent subtree sum value? If
     * there is a tie, return all the values with the highest frequency in any order.
     * 
     * Examples 1
     * Input:
     * 
     *   5
     *  /  \
     * 2   -3
     * return [2, -3, 4], since all the values happen only once, return all of them in any order.
     * 
     * Examples 2
     * Input:
     * 
     *   5
     *  /  \
     * 2   -5
     * return [2], since 2 happens twice, however -5 only occur once.
     */
    public class Most_Frequent_Subtree_Sum
    {
        public int[] FindFrequentTreeSum(TreeNode root)
        {
            if (root == null) return new int[0];
            var sumFreq = new Dictionary<int, int>();
            GetSum(root);
            var maxFreq = sumFreq.Values.Max();
            return sumFreq.Where(s => s.Value == maxFreq).Select(s => s.Key).ToArray();

            int GetSum(TreeNode node)
            {
                if (node == null) return 0;
                int sum = node.val + GetSum(node.left) + GetSum(node.right);
                sumFreq[sum] = sumFreq.GetValueOrDefault(sum) + 1;
                return sum;
            }
        }
    }
}

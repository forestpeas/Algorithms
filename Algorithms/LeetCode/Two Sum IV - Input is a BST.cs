using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 653. Two Sum IV - Input is a BST
     * 
     * Given the root of a Binary Search Tree and a target number k, return true if there exist two
     * elements in the BST such that their sum is equal to the given target.
     */
    public class Two_Sum_IV_Input_is_a_BST
    {
        public bool FindTarget(TreeNode root, int k)
        {
            var nums = new List<int>();
            Dfs(root);
            return TwoSum(nums, k);

            void Dfs(TreeNode node)
            {
                if (node == null) return;
                Dfs(node.left);
                nums.Add(node.val);
                Dfs(node.right);
            }
        }

        private bool TwoSum(List<int> numbers, int target)
        {
            // from "167. Two Sum II - Input array is sorted"
            int lo = 0, hi = numbers.Count - 1;
            while (lo < hi)
            {
                if (numbers[lo] + numbers[hi] > target)
                {
                    hi--;
                }
                else if (numbers[lo] + numbers[hi] < target)
                {
                    lo++;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}

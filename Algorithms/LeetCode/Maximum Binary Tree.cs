using Algorithms.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 654. Maximum Binary Tree
     * 
     * You are given an integer array nums with no duplicates. A maximum binary tree can be built
     * recursively from nums using the following algorithm:
     *     Create a root node whose value is the maximum value in nums.
     *     Recursively build the left subtree on the subarray prefix to the left of the maximum value.
     *     Recursively build the right subtree on the subarray suffix to the right of the maximum value.
     * 
     * Return the maximum binary tree built from nums.
     * https://leetcode.com/problems/maximum-binary-tree/
     */
    public class Maximum_Binary_Tree
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            // O(n) solution inspired by https://leetcode.com/problems/maximum-binary-tree/discuss/106156/Java-worst-case-O(N)-solution/143674
            var stack = new Stack<TreeNode>();
            for (int i = 0; i < nums.Length; i++)
            {
                TreeNode curr = new TreeNode(nums[i]);
                while (stack.Count != 0 && stack.Peek().val < nums[i])
                {
                    curr.left = stack.Pop();
                }
                if (stack.Count != 0)
                {
                    stack.Peek().right = curr;
                }
                stack.Push(curr);
            }

            return stack.Last();
        }

        public TreeNode ConstructMaximumBinaryTree2(int[] nums)
        {
            return Build(0, nums.Length - 1);

            TreeNode Build(int start, int end)
            {
                if (start > end) return null;
                int maxIdx = start;
                for (int i = start; i <= end; i++)
                {
                    if (nums[i] > nums[maxIdx])
                    {
                        maxIdx = i;
                    }
                }

                return new TreeNode(nums[maxIdx])
                {
                    left = Build(start, maxIdx - 1),
                    right = Build(maxIdx + 1, end)
                };
            }
        }
    }
}

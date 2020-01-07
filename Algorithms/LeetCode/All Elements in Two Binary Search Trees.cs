using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1305. All Elements in Two Binary Search Trees
     * 
     * Given two binary search trees root1 and root2.
     * Return a list containing all the integers from both trees sorted in ascending order.
     */
    public class All_Elements_in_Two_Binary_Search_Trees
    {
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var result = new List<int>();
            var list1 = BstToList(root1);
            var list2 = BstToList(root2);
            int n = Math.Max(list1.Count, list2.Count);
            int i = 0, j = 0;
            while (i < list1.Count || j < list2.Count)
            {
                if (i >= list1.Count) result.Add(list2[j++]);
                else if (j >= list2.Count) result.Add(list1[i++]);
                else if (list1[i] < list2[j]) result.Add(list1[i++]);
                else result.Add(list2[j++]);
            }
            return result;
        }

        private IList<int> BstToList(TreeNode root)
        {
            var result = new List<int>();
            if (root != null) TraverseCore(root);
            return result;

            void TraverseCore(TreeNode node)
            {
                if (node.left != null) TraverseCore(node.left);
                result.Add(node.val);
                if (node.right != null) TraverseCore(node.right);
            }
        }
    }
}

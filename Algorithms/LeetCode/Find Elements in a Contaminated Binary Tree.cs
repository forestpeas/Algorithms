using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1261. Find Elements in a Contaminated Binary Tree
     * 
     * Given a binary tree with the following rules:
     * root.val == 0
     * If treeNode.val == x and treeNode.left != null, then treeNode.left.val == 2 * x + 1
     * If treeNode.val == x and treeNode.right != null, then treeNode.right.val == 2 * x + 2
     * 
     * Now the binary tree is contaminated, which means all treeNode.val have been changed to -1.
     * You need to first recover the binary tree and then implement the FindElements class:
     * FindElements(TreeNode* root) Initializes the object with a contamined binary tree, you need
     * to recover it first.
     * bool find(int target) Return if the target value exists in the recovered binary tree.
     * 
     * https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/
     */
    public class FindElements
    {
        private readonly TreeNode _root;

        public FindElements(TreeNode root)
        {
            root.val = 1;
            BuildTree(root);
            _root = root;
        }

        private void BuildTree(TreeNode root)
        {
            if (root.left != null)
            {
                root.left.val = 2 * root.val + 1;
                BuildTree(root.left);
            }
            if (root.right != null)
            {
                root.right.val = 2 * root.val + 2;
                BuildTree(root.right);
            }
        }

        public bool Find(int target)
        {
            if (target == 0) return true;
            return FindTarget(target) != null;
        }

        private TreeNode FindTarget(int target)
        {
            if (target == 0) return _root;
            if (target % 2 == 1)
            {
                TreeNode node = FindTarget(target / 2);
                if (node != null) return node.left;
                else return null;
            }
            else
            {
                target = target - 2;
                TreeNode node = FindTarget(target / 2);
                if (node != null) return node.right;
                else return null;
            }
        }
    }
}

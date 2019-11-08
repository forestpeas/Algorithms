using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 655. Print Binary Tree
     * 
     * Print a binary tree in an m*n 2D string array following these rules:
     * 
     * The row number m should be equal to the height of the given binary tree.
     * The column number n should always be an odd number.
     * The root node's value (in string format) should be put in the exactly middle
     * of the first row it can be put. The column and the row where the root node belongs
     * will separate the rest space into two parts (left-bottom part and right-bottom part).
     * You should print the left subtree in the left-bottom part and print the right subtree
     * in the right-bottom part. The left-bottom part and the right-bottom part should have
     * the same size. Even if one subtree is none while the other is not, you don't need to
     * print anything for the none subtree but still need to leave the space as large as that
     * for the other subtree. However, if two subtrees are none, then you don't need to leave
     * space for both of them.
     * Each unused space should contain an empty string "".
     * Print the subtrees following the same rules.
     * Example 1:
     * Input:
     *      1
     *     /
     *    2
     * Output:
     * [["", "1", ""],
     *  ["2", "", ""]]
     *  
     * Example 2:
     * Input:
     *      1
     *     / \
     *    2   3
     *     \
     *      4
     * Output:
     * [["", "", "", "1", "", "", ""],
     *  ["", "2", "", "", "", "3", ""],
     *  ["", "", "4", "", "", "", ""]]
     *  
     * Example 3:
     * Input:
     *       1
     *      / \
     *     2   5
     *    / 
     *   3 
     *  / 
     * 4 
     * Output:
     * 
     * [["",  "",  "", "",  "", "", "", "1", "",  "",  "",  "",  "", "", ""]
     *  ["",  "",  "", "2", "", "", "", "",  "",  "",  "",  "5", "", "", ""]
     *  ["",  "3", "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]
     *  ["4", "",  "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]]
     *  
     * Note: The height of binary tree is in the range of [1, 10].
     */
    public class PrintBinaryTree
    {
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            if (root == null) return null;

            int height = GetHeight(root);
            var result = new List<IList<string>>();
            int colNum = 1;
            while (height-- > 0) colNum *= 2;
            int level = colNum / 2;
            var positions = new List<int> { level - 1 };
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var row = new string[colNum - 1];
                Array.Fill(row, string.Empty);
                result.Add(row);
                var nextPositions = new List<int>();
                int i = 0;
                int size = queue.Count;
                while (size-- > 0)
                {
                    var node = queue.Dequeue();
                    int pos = positions[i++];
                    row[pos] = node.val.ToString();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                        nextPositions.Add(pos - level / 2);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        nextPositions.Add(pos + level / 2);
                    }
                }

                positions = nextPositions;
                level = level / 2;
            }

            return result;
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
    }
}

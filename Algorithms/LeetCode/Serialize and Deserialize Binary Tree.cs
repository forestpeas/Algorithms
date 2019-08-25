using Algorithms.DataStructures;
using System;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 297. Serialize and Deserialize Binary Tree
     * 
     * Serialization is the process of converting a data structure or object into a sequence of
     * bits so that it can be stored in a file or memory buffer, or transmitted across a network
     * connection link to be reconstructed later in the same or another computer environment.
     * 
     * Design an algorithm to serialize and deserialize a binary tree. There is no restriction on
     * how your serialization/deserialization algorithm should work. You just need to ensure that
     * a binary tree can be serialized to a string and this string can be deserialized to the
     * original tree structure.
     * 
     * Example: 
     * 
     * You may serialize the following tree:
     * 
     *     1
     *    / \
     *   2   3
     *      / \
     *     4   5
     * 
     * as "[1,2,3,null,null,4,5]"
     * 
     * Clarification: The above format is the same as how LeetCode serializes a binary tree. You do
     * not necessarily need to follow this format, so please be creative and come up with different
     * approaches yourself.
     */
    public class Codec
    {
        // Use preorder traversal. For example:
        //
        //    1
        //   / \
        //  2   3
        //     / \
        //    4   5
        //
        // The tree above becomes: "1,2,#,#,3,4,#,#,5,#,#".
        // When deserializing, we can build the tree from root.
        // And the order in the string is exactly the order we can build the tree with preorder traversal.
        public string serialize(TreeNode root)
        {
            var stringBuilder = new StringBuilder();
            Serialize(root, stringBuilder);
            return stringBuilder.ToString();
        }

        private void Serialize(TreeNode root, StringBuilder stringBuilder)
        {
            if (root == null)
            {
                stringBuilder.Append("#").Append(",");
                return;
            }
            stringBuilder.Append(root.val).Append(",");
            Serialize(root.left, stringBuilder);
            Serialize(root.right, stringBuilder);
        }

        public TreeNode deserialize(string data)
        {
            var vals = data.Split(',', StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            return Deserialize();

            TreeNode Deserialize()
            {
                string val = vals[i++];
                if (val == "#") return null;
                return new TreeNode(int.Parse(val))
                {
                    left = Deserialize(),
                    right = Deserialize()
                };
            }
        }
    }
}

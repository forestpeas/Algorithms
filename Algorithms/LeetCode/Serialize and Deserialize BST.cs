using Algorithms.DataStructures;
using System;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 449. Serialize and Deserialize BST
     * 
     * Serialization is the process of converting a data structure or object into a sequence of bits so
     * that it can be stored in a file or memory buffer, or transmitted across a network connection link
     * to be reconstructed later in the same or another computer environment.
     * 
     * Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on
     * how your serialization/deserialization algorithm should work. You just need to ensure that a binary
     * search tree can be serialized to a string and this string can be deserialized to the original tree
     * structure.
     * 
     * The encoded string should be as compact as possible.
     */
    public class Serialize_and_Deserialize_BST
    {
        // Similar to "297. Serialize and Deserialize Binary Tree" except that we can
        // take advantage of the BST property while deserializing, so we don't need
        // to save the null values in the serialized string.
        public class Codec
        {
            public string serialize(TreeNode root)
            {
                var stringBuilder = new StringBuilder();
                Serialize(root, stringBuilder);
                return stringBuilder.ToString();
            }

            private void Serialize(TreeNode root, StringBuilder stringBuilder)
            {
                if (root == null) return;
                stringBuilder.Append(root.val).Append(",");
                Serialize(root.left, stringBuilder);
                Serialize(root.right, stringBuilder);
            }

            public TreeNode deserialize(string data)
            {
                var vals = data.Split(',', StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                return Deserialize(int.MinValue, int.MaxValue);

                TreeNode Deserialize(int lower, int upper)
                {
                    if (i == vals.Length) return null;
                    int val = int.Parse(vals[i]);
                    if (val < lower || val > upper) return null;
                    i++;
                    return new TreeNode(val)
                    {
                        left = Deserialize(lower, val),
                        right = Deserialize(val, upper)
                    };
                }
            }
        }
    }
}

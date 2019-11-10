namespace Algorithms.LeetCode
{
    /* 331. Verify Preorder Serialization of a Binary Tree
     * 
     * One way to serialize a binary tree is to use pre-order traversal. When we encounter a non-null node,
     * we record the node's value. If it is a null node, we record using a sentinel value such as #.
     * 
     *      _9_
     *     /   \
     *    3     2
     *   / \   / \
     *  4   1  #  6
     * / \ / \   / \
     * # # # #   # #
     * For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#",
     * where # represents a null node.
     * 
     * Given a string of comma separated values, verify whether it is a correct preorder traversal
     * serialization of a binary tree. Find an algorithm without reconstructing the tree.
     * 
     * Each comma separated value in the string must be either an integer or a character '#' representing
     * null pointer.
     * 
     * You may assume that the input format is always valid, for example it could never contain two consecutive
     * commas such as "1,,3".
     * 
     * Example 1:
     * 
     * Input: "9,3,4,#,#,1,#,#,2,#,6,#,#"
     * Output: true
     * 
     * Example 2:
     * 
     * Input: "1,#"
     * Output: false
     * 
     * Example 3:
     * 
     * Input: "9,#,#,1"
     * Output: false
     */
    public class VerifyPreorderSerializationOfBinaryTree
    {
        public bool IsValidSerialization(string preorder)
        {
            // Similar to the deserialization part of "297. Serialize and Deserialize Binary Tree"
            string[] p = preorder.Split(',');
            if (p.Length % 2 == 0) return false;
            int i = 0;
            return Validate() && i == p.Length;

            bool Validate()
            {
                if (i == p.Length) return false;
                if (p[i++] == "#") return true;
                if (!Validate()) return false;
                if (!Validate()) return false;
                return true;
            }
        }

        public bool IsValidSerialization2(string preorder)
        {
            // Inspired by https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/discuss/78551/7-lines-Easy-Java-Solution
            // When we encounter an outdegree, increase the counter.
            // When we encounter an indegree, decrease the counter.
            // The total number of indegrees and outdegrees should be the same.
            string[] nodes = preorder.Split(',');
            int count = 1;
            foreach (string node in nodes)
            {
                if (--count < 0) return false; // 1 parent
                if (node != "#") count += 2; // 2 children
            }
            return count == 0;
        }
    }
}

namespace Algorithms.LeetCode
{
    /* 558. Logical OR of Two Binary Grids Represented as Quad-Trees
     * 
     * A Binary Matrix is a matrix in which all the elements are either 0 or 1.
     * 
     * Given quadTree1 and quadTree2. quadTree1 represents a n * n binary matrix and quadTree2
     * represents another n * n binary matrix. 
     * 
     * Return a Quad-Tree representing the n * n binary matrix which is the result of logical
     * bitwise OR of the two binary matrixes represented by quadTree1 and quadTree2.
     * 
     * https://leetcode.com/problems/logical-or-of-two-binary-grids-represented-as-quad-trees/
     */
    public class Logical_OR_of_Two_Binary_Grids_Represented_as_Quad_Trees
    {
        public Node Intersect(Node quadTree1, Node quadTree2)
        {
            if (quadTree1.isLeaf && quadTree2.isLeaf)
            {
                quadTree1.val |= quadTree2.val;
                return quadTree1;
            }

            if (quadTree1.isLeaf) Split(quadTree1);
            if (quadTree2.isLeaf) Split(quadTree2);

            // "merge" four nodes with the same value into one
            Intersect(quadTree1.topLeft, quadTree2.topLeft);
            Intersect(quadTree1.topRight, quadTree2.topRight);
            Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
            Intersect(quadTree1.bottomRight, quadTree2.bottomRight);

            bool sameLeaves =
                    quadTree1.topLeft.isLeaf &&
                    quadTree1.topRight.isLeaf &&
                    quadTree1.bottomLeft.isLeaf &&
                    quadTree1.bottomRight.isLeaf &&
                    quadTree1.topLeft.val == quadTree1.topRight.val &&
                    quadTree1.topRight.val == quadTree1.bottomLeft.val &&
                    quadTree1.bottomLeft.val == quadTree1.bottomRight.val;

            if (sameLeaves)
            {
                quadTree1.isLeaf = true;
                quadTree1.val = quadTree1.topLeft.val;
                quadTree1.topLeft = quadTree1.topRight = quadTree1.bottomLeft = quadTree1.bottomRight = null;
            }
            return quadTree1;
        }

        private void Split(Node quadTree)
        {
            quadTree.topLeft = new Node() { val = quadTree.val, isLeaf = true };
            quadTree.topRight = new Node() { val = quadTree.val, isLeaf = true };
            quadTree.bottomLeft = new Node() { val = quadTree.val, isLeaf = true };
            quadTree.bottomRight = new Node() { val = quadTree.val, isLeaf = true };
            quadTree.isLeaf = false;
        }

        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node() { }
            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }
    }
}

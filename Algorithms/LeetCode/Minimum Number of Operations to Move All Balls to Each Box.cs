namespace Algorithms.LeetCode
{
    /* 1769. Minimum Number of Operations to Move All Balls to Each Box
     * 
     * You have n boxes. You are given a binary string boxes of length n, where boxes[i] is '0'
     * if the ith box is empty, and '1' if it contains one ball.
     * 
     * In one operation, you can move one ball from a box to an adjacent box. Box i is adjacent
     * to box j if abs(i - j) == 1. Note that after doing so, there may be more than one ball
     * in some boxes.
     * 
     * Return an array answer of size n, where answer[i] is the minimum number of operations
     * needed to move all the balls to the ith box.
     * 
     * Each answer[i] is calculated considering the initial state of the boxes.
     * 
     * Example 1:
     * 
     * Input: boxes = "110"
     * Output: [1,1,3]
     * Explanation: The answer for each box is as follows:
     * 1) First box: you will have to move one ball from the second box to the first box in one
     * operation.
     * 2) Second box: you will have to move one ball from the first box to the second box in one
     * operation.
     * 3) Third box: you will have to move one ball from the first box to the third box in two
     * operations, and move one ball from the second box to the third box in one operation.
     * 
     * Example 2:
     * 
     * Input: boxes = "001011"
     * Output: [11,8,5,4,3,4]
     */
    public class Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box
    {
        public int[] MinOperations(string boxes)
        {
            // assume all balls are move to boxes[0]
            int rightNum = 0, rightSum = 0;
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i] == '1')
                {
                    rightNum++;
                    rightSum += i;
                }
            }

            int leftNum = 0, leftSum = 0;
            int[] res = new int[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                res[i] = leftSum + rightSum;
                if (boxes[i] == '1')
                {
                    leftNum++;
                    rightNum--;
                }
                leftSum += leftNum; // all the boxes from left need to move one step further
                rightSum -= rightNum; // boxes moved left and now move right, the distance cancels out
            }
            return res;
        }
    }
}

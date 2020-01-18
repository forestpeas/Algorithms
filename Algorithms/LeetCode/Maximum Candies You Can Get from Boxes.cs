using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1298. Maximum Candies You Can Get from Boxes
     * 
     * Given n boxes, each box is given in the format [status, candies, keys, containedBoxes] where:
     * status[i]: an integer which is 1 if box[i] is open and 0 if box[i] is closed.
     * candies[i]: an integer representing the number of candies in box[i].
     * keys[i]: an array contains the indices of the boxes you can open with the key in box[i].
     * containedBoxes[i]: an array contains the indices of the boxes found in box[i].
     * 
     * You will start with some boxes given in initialBoxes array. You can take all the candies in any open box and you can use the keys
     * in it to open new boxes and you also can use the boxes you find in it.
     * 
     * Return the maximum number of candies you can get following the rules above.
     * 
     * Example 1:
     * 
     * Input: status = [1,0,1,0], candies = [7,5,4,100], keys = [[],[],[1],[]], containedBoxes = [[1,2],[3],[],[]], initialBoxes = [0]
     * Output: 16
     * Explanation: You will be initially given box 0. You will find 7 candies in it and boxes 1 and 2. Box 1 is closed and you don't have
     * a key for it so you will open box 2. You will find 4 candies and a key to box 1 in box 2.
     * In box 1, you will find 5 candies and box 3 but you will not find a key to box 3 so box 3 will remain closed.
     * Total number of candies collected = 7 + 4 + 5 = 16 candy.
     */
    public class Maximum_Candies_You_Can_Get_from_Boxes
    {
        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            // Just simulate the process. There can be duplicate keys.
            int n = status.Length;
            bool[] opened = new bool[n];
            bool[] toBeOpened = new bool[n];
            var queue = new Queue<int>();
            foreach (int box in initialBoxes)
            {
                if (status[box] == 1) queue.Enqueue(box);
                else toBeOpened[box] = true;
            }

            int result = 0;
            while (queue.TryDequeue(out int box))
            {
                if (opened[box]) continue;
                result += candies[box];
                opened[box] = true;

                foreach (int key in keys[box])
                {
                    if (opened[key]) continue;
                    if (toBeOpened[key]) queue.Enqueue(key);
                    else status[key] = 1;
                }

                foreach (int subBox in containedBoxes[box])
                {
                    if (status[subBox] == 1) queue.Enqueue(subBox);
                    else toBeOpened[subBox] = true;
                }
            }

            return result;
        }
    }
}

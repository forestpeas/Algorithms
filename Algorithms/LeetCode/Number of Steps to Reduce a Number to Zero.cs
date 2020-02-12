namespace Algorithms.LeetCode
{
    /* 1342. Number of Steps to Reduce a Number to Zero
     * 
     * Given a non-negative integer num, return the number of steps to reduce it to zero. If the current
     * number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it.
     */
    public class Number_of_Steps_to_Reduce_a_Number_to_Zero
    {
        public int NumberOfSteps(int num)
        {
            int result = 0;
            while (num != 0)
            {
                result++;
                if (num % 2 == 0) num = num / 2;
                else num = num - 1;
            }
            return result;
        }
    }
}

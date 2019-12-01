namespace Algorithms.LeetCode
{
    /* 390. Elimination Game
     * 
     * There is a list of sorted integers from 1 to n. Starting from left to right, remove
     * the first number and every other number afterward until you reach the end of the list.
     * 
     * Repeat the previous step again, but this time from right to left, remove the right most
     * number and every other number from the remaining numbers.
     * 
     * We keep repeating the steps again, alternating left to right and right to left, until
     * a single number remains.
     * 
     * Find the last number that remains starting with a list of length n.
     * 
     * Example:
     * 
     * Input:
     * n = 9,
     * 1 2 3 4 5 6 7 8 9
     * 2 4 6 8
     * 2 6
     * 6
     * 
     * Output:
     * 6
     */
    public class Elimination_Game
    {
        public int LastRemaining(int n)
        {
            // Think of n as the total number of numbers so far.
            int diff = 1; // The difference between two adjacent numbers so far.
            int first = 1; // The first number of the sequence so far.
            bool toggle = true;
            while (n > 1)
            {
                if (toggle) // If we go from right to left, the first number is always removed.
                {
                    first = first + diff;
                }
                else // If we go from right to left, the first number only gets removed when n is odd.
                {
                    if (n % 2 != 0) first = first + diff;
                }

                n = n / 2; // After removal, n will always be n / 2 no matter n is odd or even.
                diff = diff * 2;
                toggle = !toggle;
            }
            return first;
        }
    }
}

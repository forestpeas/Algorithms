namespace Algorithms.LeetCode
{
    /* 400. Nth Digit
     * 
     * Find the n-th digit of the infinite integer sequence 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...
     * 
     * Note:
     * n is positive and will fit within the range of a 32-bit signed integer (n < 231).
     * 
     * Example 1:
     * 
     * Input:
     * 3
     * 
     * Output:
     * 3
     * 
     * Example 2:
     * 
     * Input:
     * 11
     * 
     * Output:
     * 0
     * 
     * Explanation:
     * The 11th digit of the sequence 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ... is a 0, which is part
     * of the number 10.
     */
    public class Nth_Digit
    {
        public int FindNthDigit(int n)
        {
            int i = 1; // 1,2,3,4...the total number of digits of j
            int j = 1; // 1,10,100,1000...
            while (true)
            {
                // Numbers with 2 digits are 10 ~ 99, 90 in total.
                // Numbers with 3 digit are 100 ~ 999, 900 in total.
                // ...
                // We need to find the number that n corresponds to.
                // For example, if n corresponds to a digit in 102, j = 100, (n - 1) / i = 2,
                // which means the third number starting from 100, that is 102. 
                if (int.MaxValue / (9 * i) + 1 <= j || n <= (long)(j * 9 * i)) break;
                n = n - j * 9 * i;
                i++;
                j = j * 10;
            }

            int num = j + (n - 1) / i; // number that n corresponds to
            int pos = (n - 1) % i + 1; // the pos-th position from left to right
            while (true)
            {
                int digit = num % 10;
                if (i-- == pos) return digit;
                num = num / 10;
            }
        }
    }
}

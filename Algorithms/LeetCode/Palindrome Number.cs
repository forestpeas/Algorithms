namespace Algorithms.LeetCode
{
    /* 9. Palindrome Number
     * 
     * Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
     * 
     * Example 1:
     * Input: 121
     * Output: true
     * 
     * Example 2:
     * Input: -121
     * Output: false
     * Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
     * 
     * Example 3:
     * Input: 10
     * Output: false
     * Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
     * 
     * Follow up:
     * Coud you solve it without converting the integer to a string?
     */
    public class PalindromeNumberSolution
    {
        // Your runtime beats 61.57 % of csharp submissions.
        // Your memory usage beats 49.73 % of csharp submissions.
        public bool IsPalindrome(int x)
        {
            // Special cases:
            // When x < 0, x is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome,
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            // Almost the same as problem 7: Reverse Integer.
            int originNumber = x;
            int revertedNumber = 0;
            while (x != 0)
            {
                int leastSignificantDigit = x % 10;
                if (revertedNumber > int.MaxValue / 10
                    || (revertedNumber == int.MaxValue / 10 && leastSignificantDigit > 7))
                {
                    return false;
                }
                revertedNumber = revertedNumber * 10 + leastSignificantDigit;
                x = x / 10;
            }
            return revertedNumber == originNumber;
        }

        // Your runtime beats 98.85 % of csharp submissions.
        // Your memory usage beats 67.38 % of csharp submissions.
        public bool OfficialSolution(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            // Only revert half of the int number. The reverse of the last half of the palindrome should be the same as
            // the first half of the number, if the number is a palindrome. When the original number is less than the
            // reversed number, it means we've processed half of the number digits.
            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // When the length is an odd number, we can get rid of the middle digit by revertedNumber/10
            // For example when the input is 12321, at the end of the while loop we get x = 12, revertedNumber = 123,
            // since the middle digit doesn't matter in palidrome(it will always equal to itself), we can simply get rid of it.
            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
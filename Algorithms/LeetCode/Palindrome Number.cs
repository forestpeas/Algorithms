namespace Algorithms.LeetCode
{
    public class PalindromeNumberSolution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            // almost the same as problem 7: Reverse Integer
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
    }
}
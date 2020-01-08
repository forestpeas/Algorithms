namespace Algorithms.LeetCode
{
    /* 405. Convert a Number to Hexadecimal
     * 
     * Given an integer, write an algorithm to convert it to hexadecimal. For negative integer,
     * two’s complement method is used.
     * 
     * Note:
     * 
     * All letters in hexadecimal (a-f) must be in lowercase.
     * The hexadecimal string must not contain extra leading 0s. If the number is zero, it is represented by
     * a single zero character '0'; otherwise, the first character in the hexadecimal string will not be the
     * zero character.
     * The given number is guaranteed to fit within the range of a 32-bit signed integer.
     * You must not use any method provided by the library which converts/formats the number to hex directly.
     * 
     * Example 1:
     * Input:
     * 26
     * Output:
     * "1a"
     * 
     * Example 2:
     * Input:
     * -1
     * Output:
     * "ffffffff"
     */
    public class Convert_a_Number_to_Hexadecimal
    {
        public string ToHex(int num)
        {
            uint n = (uint)num;
            var result = string.Empty;
            while (n != 0)
            {
                uint digit = n % 16;
                if (digit >= 10) result = (char)('a' + (digit - 10)) + result;
                else result = (char)('0' + digit) + result;

                n = n / 16;
            }

            return result.Length == 0 ? "0" : result;
        }
    }
}

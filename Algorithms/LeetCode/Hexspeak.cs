namespace Algorithms.LeetCode
{
    /* 1271. Hexspeak
     * 
     * A decimal number can be converted to its Hexspeak representation by first converting it
     * to an uppercase hexadecimal string, then replacing all occurrences of the digit 0 with
     * the letter O, and the digit 1 with the letter I.  Such a representation is valid if and
     * only if it consists only of the letters in the set {"A", "B", "C", "D", "E", "F", "I", "O"}.
     * 
     * Given a string num representing a decimal integer N, return the Hexspeak representation
     * of N if it is valid, otherwise return "ERROR".
     * 
     * Example 1:
     * 
     * Input: num = "257"
     * Output: "IOI"
     * Explanation:  257 is 101 in hexadecimal.
     * 
     * Example 2:
     * 
     * Input: num = "3"
     * Output: "ERROR"
     */
    public class Hexspeak
    {
        public string ToHexspeak(string num)
        {
            string hex = long.Parse(num).ToString("X");
            char[] arr = hex.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '0') arr[i] = 'O';
                else if (arr[i] == '1') arr[i] = 'I';
                else if (char.IsDigit(arr[i])) return "ERROR";
            }
            return new string(arr);
        }
    }
}

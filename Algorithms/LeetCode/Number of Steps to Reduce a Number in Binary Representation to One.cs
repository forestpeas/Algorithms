namespace Algorithms.LeetCode
{
    /* 1404. Number of Steps to Reduce a Number in Binary Representation to One
     * 
     * Given a number s in their binary representation. Return the number of steps to reduce
     * it to 1 under the following rules:
     * 
     * If the current number is even, you have to divide it by 2.
     * 
     * If the current number is odd, you have to add 1 to it.
     * 
     * It's guaranteed that you can always reach to one for all testcases.
     * 
     * Example 1:
     * 
     * Input: s = "1101"
     * Output: 6
     * Explanation: "1101" corressponds to number 13 in their decimal representation.
     * Step 1) 13 is odd, add 1 and obtain 14. 
     * Step 2) 14 is even, divide by 2 and obtain 7.
     * Step 3) 7 is odd, add 1 and obtain 8.
     * Step 4) 8 is even, divide by 2 and obtain 4.  
     * Step 5) 4 is even, divide by 2 and obtain 2. 
     * Step 6) 2 is even, divide by 2 and obtain 1.  
     * 
     * Example 2:
     * 
     * Input: s = "10"
     * Output: 1
     * Explanation: "10" corressponds to number 2 in their decimal representation.
     * Step 1) 2 is even, divide by 2 and obtain 1.  
     * 
     * Example 3:
     * 
     * Input: s = "1"
     * Output: 0
     * 
     * Constraints:
     * 
     * 1 <= s.length <= 500
     * s consists of characters '0' or '1'
     * s[0] == '1'
     */
    public class Number_of_Steps_to_Reduce_a_Number_in_Binary_Representation_to_One
    {
        public int NumSteps(string s)
        {
            // Division by two is the same as removing the rightmost 0.
            // Adding one is the same as changing all the ones to zeros (from right to left)
            // until you meet a zero.
            int res = 0;
            bool addOne = false;
            for (int i = s.Length - 1; i > 0; i--) // s[0] is always '1'.
            {
                if (s[i] == '0')
                {
                    res += addOne ? 2 : 1; // 2 means change 0 to 1 and remove this bit.
                }
                else
                {
                    res++;
                    addOne = true;
                }
            }
            if (addOne) res += 2;
            return res;
        }

        public int NumSteps2(string s)
        {
            // First submission.
            char[] binary = s.ToCharArray();
            int res = 0;
            for (int i = s.Length - 1; i > 0;)
            {
                if (binary[i] == '0')
                {
                    i--;
                    res++;
                }
                else
                {
                    res++;
                    while (i >= 0 && binary[i] == '1')
                    {
                        i--;
                        res++;
                    }
                    if (i >= 0) binary[i] = '1';
                }
            }
            return res;
        }
    }
}

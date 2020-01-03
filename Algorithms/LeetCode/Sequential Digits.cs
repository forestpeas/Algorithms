using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1291. Sequential Digits
     * 
     * An integer has sequential digits if and only if each digit in the number is one more than the previous digit.
     * 
     * Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.
     * 
     * Example 1:
     * 
     * Input: low = 100, high = 300
     * Output: [123,234]
     * Example 2:
     * 
     * Input: low = 1000, high = 13000
     * Output: [1234,2345,3456,4567,5678,6789,12345]
     */
    public class Sequential_Digits
    {
        public IList<int> SequentialDigits(int low, int high)
        {
            int lowDigits = 0;
            int lo = low;
            while (lo != 0)
            {
                lowDigits++;
                lo = lo / 10;
            }

            int highDigits = 0;
            int hi = high;
            while (hi != 0)
            {
                highDigits++;
                hi = hi / 10;
            }

            var result = new List<int>();
            for (int digitNum = lowDigits; digitNum <= highDigits; digitNum++)
            {
                for (int i = 1; i <= 10 - digitNum; i++)
                {
                    int num = 0;
                    for (int j = i; j < i + digitNum; j++)
                    {
                        num *= 10;
                        num += j;
                    }

                    if (num >= low && num <= high) result.Add(num);
                }
            }

            return result;
        }
    }
}

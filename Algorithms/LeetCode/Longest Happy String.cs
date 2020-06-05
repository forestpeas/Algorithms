using System.Linq;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 1405. Longest Happy String
     * 
     * A string is called happy if it does not have any of the strings 'aaa', 'bbb' or 'ccc'
     * as a substring.
     *
     * Given three integers a, b and c, return any string s, which satisfies following conditions:
     *
     * s is happy and longest possible.
     * s contains at most a occurrences of the letter 'a', at most b occurrences of the letter 'b'
     * and at most c occurrences of the letter 'c'.
     * s will only contain 'a', 'b' and 'c' letters.
     * If there is no such string s return the empty string "".
     * 
     * Example 1:
     * 
     * Input: a = 1, b = 1, c = 7
     * Output: "ccaccbcc"
     * Explanation: "ccbccacc" would also be a correct answer.
     * 
     * Example 2:
     * 
     * Input: a = 2, b = 2, c = 1
     * Output: "aabbc"
     * 
     * Example 3:
     * 
     * Input: a = 7, b = 1, c = 0
     * Output: "aabaa"
     * Explanation: It's the only correct answer in this case.
     * 
     * Constraints:
     * 
     * 0 <= a, b, c <= 100
     * a + b + c > 0
     */
    public class Longest_Happy_String
    {
        public string LongestDiverseString(int a, int b, int c)
        {
            // Find the maximum number, then we need to fill the slots with the other
            // two minor number of letters.
            // for example:

            // a = 11, b = 2, c = 3
            // aa   aa   aa   aa   aa   a
            //    ↑    ↑    ↑    ↑    ↑    ↑
            //  slot  slot slot slot slot slot

            // Our goal is 1. fill as many slots as possible.
            //             2. while satisfying the first goal, let each slot contain
            //                as many letters as possible.
            // Case 1: 
            // Even if we fill each slot with only one letter, we still can't fill all
            // the slots. For example:
            // aa b aa c aa   aa   aa

            // Case 2:
            // At least one of minor1 and minor2 is enough for all the slots, and we can
            // put the extra letters (number minus slots) in any slots. For example, b is
            // enough: 
            // aa bbcc aa b aa b
            //     ↑
            // one extra 'b' (4 - 3)
            Item[] items = new Item[] { new Item('a', a), new Item('b', b), new Item('c', c) };
            items = items.OrderBy(i => i.number).ToArray();
            Item major = items[2], minor1 = items[1], minor2 = items[0];
            int slots = (major.number + 1) / 2; // System.Math.Ceiling
            var res = new StringBuilder();
            for (int i = 1; i <= slots; i++) // i is the "slot number"
            {
                res.Append(major.letter);
                if (i <= major.number - slots) res.Append(major.letter); // in case number is odd.

                if (minor1.number + minor2.number <= slots)
                {
                    // Case 1
                    if (i > minor1.number + minor2.number) break; // no more minor
                    if (i <= minor1.number) res.Append(minor1.letter);
                    else res.Append(minor2.letter);
                }
                else
                {
                    // Case 2
                    if (i > minor1.number && i > minor2.number) break; // no more minor

                    if (i <= minor1.number)
                    {
                        res.Append(minor1.letter);
                        if (i <= minor1.number - slots) res.Append(minor1.letter);
                    }
                    if (i <= minor2.number)
                    {
                        res.Append(minor2.letter);
                        if (i <= minor2.number - slots) res.Append(minor2.letter);
                    }
                }
            }

            return res.ToString();
        }

        public class Item
        {
            public char letter;
            public int number;
            public Item(char l, int n)
            {
                letter = l;
                number = n;
            }
        }
    }
}

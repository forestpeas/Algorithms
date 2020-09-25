using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.LeetCode
{
    /* 451. Sort Characters By Frequency
     * 
     * Given a string, sort it in decreasing order based on the frequency of characters.
     * 
     * Example 1:
     * 
     * Input:
     * "tree"
     * 
     * Output:
     * "eert"
     * 
     * Explanation:
     * 'e' appears twice while 'r' and 't' both appear once.
     * So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
     * 
     * Example 2:
     * 
     * Input:
     * "cccaaa"
     * 
     * Output:
     * "cccaaa"
     * 
     * Explanation:
     * Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
     * Note that "cacaca" is incorrect, as the same characters must be together.
     * 
     * Example 3:
     * 
     * Input:
     * "Aabb"
     * 
     * Output:
     * "bbAa"
     * 
     * Explanation:
     * "bbaA" is also a valid answer, but "Aabb" is incorrect.
     * Note that 'A' and 'a' are treated as two different characters.
     */
    public class Sort_Characters_By_Frequency
    {
        public string FrequencySort(string s)
        {
            var count = new int[128];
            foreach (char c in s) count[c]++;

            var bucket = new List<char>[s.Length + 1];
            for (int i = 0; i < count.Length; i++)
            {
                if (bucket[count[i]] == null) bucket[count[i]] = new List<char>();
                bucket[count[i]].Add((char)i);
            }

            var res = new StringBuilder();
            for (int i = bucket.Length - 1; i > 0; i--)
            {
                if (bucket[i] != null)
                {
                    foreach (char c in bucket[i])
                    {
                        for (int j = 0; j < i; j++) res.Append(c);
                    }
                }
            }
            return res.ToString();
        }

        public string FrequencySort2(string s)
        {
            var count = new CharCount[128];
            var list = new List<CharCount>();
            foreach (char c in s)
            {
                if (count[c] == null)
                {
                    count[c] = new CharCount(c, 1);
                    list.Add(count[c]);
                }
                else
                {
                    count[c].count++;
                }
            }

            var res = new StringBuilder();
            foreach (var item in list.OrderByDescending(i => i.count))
            {
                for (int i = 0; i < item.count; i++)
                {
                    res.Append(item.character);
                }
            }
            return res.ToString();
        }

        public class CharCount
        {
            public char character;
            public int count;
            public CharCount(char character, int count)
            {
                this.character = character;
                this.count = count;
            }
        }
    }
}

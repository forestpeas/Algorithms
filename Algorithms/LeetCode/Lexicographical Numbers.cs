using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 386. Lexicographical Numbers
     * 
     * Given an integer n, return 1 - n in lexicographical order.
     * For example, given 13, return: [1,10,11,12,13,2,3,4,5,6,7,8,9].
     * 
     * Please optimize your algorithm to use less time and space. The input size may be as large as 5,000,000.
     */
    public class Lexicographical_Numbers
    {
        public IList<int> LexicalOrder(int n)
        {
            // Observe the pattern.
            // 1
            // 10
            // 100
            // 101
            // 102
            // 103
            // ...
            // 109
            // 11
            // 110
            // ...
            // 199
            // 2
            // 20
            // 200
            // ...
            var result = new List<int>();
            int num = 1;
            while (result.Count < n)
            {
                // Try to put as many zeroes as possible to the end of the number.
                while (num <= n)
                {
                    result.Add(num);
                    num = num * 10;
                }
                num = num / 10;

                // Increment the number until a carry.
                while (true)
                {
                    num++;
                    if (num % 10 == 0) break;
                    if (num <= n) result.Add(num);
                }

                // Try to remove as many zeroes as possible from the end of the number.
                while (num % 10 == 0)
                {
                    num = num / 10;
                }
            }

            return result;
        }

        public IList<int> LexicalOrder2(int n)
        {
            var res = new List<int>();
            PreorderTraverse(0);
            return res;

            void PreorderTraverse(int node)
            {
                if (node != 0) res.Add(node);
                for (int i = 0; i <= 9; i++)
                {
                    long child = node * 10 + i;
                    if (child == 0) continue; // the root is 0, its first child should be 1.
                    if (child > n) break;
                    PreorderTraverse((int)child);
                }
            }
        }

        public IList<int> LexicalOrder3(int n)
        {
            return Enumerable.Range(1, n).OrderBy(i => i.ToString()).ToArray();
        }
    }
}

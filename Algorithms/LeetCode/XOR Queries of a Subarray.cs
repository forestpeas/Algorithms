using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1310. XOR Queries of a Subarray
     * 
     * Given the array arr of positive integers and the array queries where queries[i] = [Li, Ri], for each query i compute the
     * XOR of elements from Li to Ri (that is, arr[Li] xor arr[Li+1] xor ... xor arr[Ri] ). Return an array containing the result
     * for the given queries.  
     * 
     * Example 1:
     * 
     * Input: arr = [1,3,4,8], queries = [[0,1],[1,2],[0,3],[3,3]]
     * Output: [2,7,14,8] 
     * Explanation: 
     * The binary representation of the elements in the array are:
     * 1 = 0001 
     * 3 = 0011 
     * 4 = 0100 
     * 8 = 1000 
     * The XOR values for queries are:
     * [0,1] = 1 xor 3 = 2 
     * [1,2] = 3 xor 4 = 7 
     * [0,3] = 1 xor 3 xor 4 xor 8 = 14 
     * [3,3] = 8
     * 
     * Example 2:
     * 
     * Input: arr = [4,8,2,10], queries = [[2,3],[1,3],[0,0],[0,3]]
     * Output: [8,0,4,4]
     */
    public class XOR_Queries_of_a_Subarray
    {
        public int[] XorQueries(int[] arr, int[][] queries)
        {
            // Similar to prefix sum.
            int[] prefixXor = new int[arr.Length];
            prefixXor[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prefixXor[i] = arr[i] ^ prefixXor[i - 1];
            }

            var result = new List<int>();
            foreach (var q in queries)
            {
                if (q[0] == 0) result.Add(prefixXor[q[1]]);
                else result.Add(prefixXor[q[1]] ^ prefixXor[q[0] - 1]);
            }

            return result.ToArray();
        }
    }
}

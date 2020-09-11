using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 433. Minimum Genetic Mutation
     * 
     * A gene string can be represented by an 8-character long string, with choices from "A", "C", "G", "T".
     * 
     * Suppose we need to investigate about a mutation (mutation from "start" to "end"), where ONE mutation
     * is defined as ONE single character changed in the gene string.
     * 
     * For example, "AACCGGTT" -> "AACCGGTA" is 1 mutation.
     * 
     * Also, there is a given gene "bank", which records all the valid gene mutations. A gene must be in the
     * bank to make it a valid gene string.
     * 
     * Now, given 3 things - start, end, bank, your task is to determine what is the minimum number of mutations
     * needed to mutate from "start" to "end". If there is no such a mutation, return -1.
     * 
     * Note:
     * 
     * Starting point is assumed to be valid, so it might not be included in the bank.
     * If multiple mutations are needed, all mutations during in the sequence must be valid.
     * You may assume start and end string is not the same.
     * 
     * Example 1:
     * 
     * start: "AACCGGTT"
     * end:   "AACCGGTA"
     * bank: ["AACCGGTA"]
     * 
     * return: 1
     * 
     * Example 2:
     * 
     * start: "AACCGGTT"
     * end:   "AAACGGTA"
     * bank: ["AACCGGTA", "AACCGCTA", "AAACGGTA"]
     * 
     * return: 2
     * 
     * Example 3:
     * 
     * start: "AAAAACCC"
     * end:   "AACCCCCC"
     * bank: ["AAAACCCC", "AAACCCCC", "AACCCCCC"]
     * 
     * return: 3
     */
    public class Minimum_Genetic_Mutation
    {
        public int MinMutation(string start, string end, string[] bank)
        {
            // Construct a standard graph first and then find the minimum path using BFS.
            var nodes = new Dictionary<string, Node>();
            foreach (var item in bank) nodes[item] = new Node();

            Node src = nodes.GetValueOrDefault(start), target = nodes.GetValueOrDefault(end);
            if (target == null) return -1;
            if (src == null)
            {
                src = new Node();
                nodes.Add(start, src);
            }

            bank = nodes.Keys.ToArray();
            for (int i = 0; i < bank.Length; i++)
            {
                for (int j = i + 1; j < bank.Length; j++)
                {
                    if (DiffOneChar(bank[i], bank[j]))
                    {
                        nodes[bank[i]].adj.Add(nodes[bank[j]]);
                        nodes[bank[j]].adj.Add(nodes[bank[i]]);
                    }
                }
            }

            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(src);
            int res = 0;
            while (queue.Count != 0)
            {
                res++;
                int length = queue.Count;
                while (--length >= 0)
                {
                    var node = queue.Dequeue();
                    foreach (var neighbor in node.adj)
                    {
                        if (neighbor == target) return res;
                        if (visited.Add(neighbor)) queue.Enqueue(neighbor);
                    }
                }
            }
            return -1;
        }

        private bool DiffOneChar(string s1, string s2)
        {
            bool foundDiff = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDiff) return false;
                    foundDiff = true;
                }
            }
            return foundDiff;
        }

        private class Node
        {
            public List<Node> adj = new List<Node>();
        }
    }
}

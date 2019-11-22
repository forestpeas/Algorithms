using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 332. Reconstruct Itinerary
     * 
     * Given a list of airline tickets represented by pairs of departure and arrival airports [from, to],
     * reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus,
     * the itinerary must begin with JFK.
     * 
     * Note:
     * 
     * If there are multiple valid itineraries, you should return the itinerary that has the smallest
     * lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller
     * lexical order than ["JFK", "LGB"].
     * All airports are represented by three capital letters (IATA code).
     * You may assume all tickets form at least one valid itinerary.
     * 
     * Example 1:
     * 
     * Input: [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
     * Output: ["JFK", "MUC", "LHR", "SFO", "SJC"]
     * 
     * Example 2:
     * 
     * Input: [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
     * Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
     * Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"].
     *              But it is larger in lexical order.
     */
    public class Reconstruct_Itinerary
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            // Inspired by https://leetcode.com/problems/reconstruct-itinerary/discuss/78768/Short-Ruby-Python-Java-C%2B%2B
            // Choose a path (edge) and delete this path so that we won't go through the same path again.
            // If we get stuck, we must be at the end node, backtrack to where we started and choose another path
            // (if there is one) and this path will definitely lead us back to our starting node otherwise there
            // will be two end nodes.
            var graph = new Dictionary<string, PriorityQueue<string>>();
            foreach (var ticket in tickets)
            {
                if (!graph.ContainsKey(ticket[0]))
                {
                    graph.Add(ticket[0], new PriorityQueue<string>(Comparer<string>.Create((x, y) => y.CompareTo(x))));
                }
                graph[ticket[0]].Add(ticket[1]);
            }

            var result = new List<string>();
            Visit("JFK");
            result.Reverse();
            return result;

            void Visit(string src)
            {
                while (graph.ContainsKey(src) && graph[src].Count != 0)
                {
                    Visit(graph[src].DeleteTop());
                }
                result.Add(src);
            }
        }
    }
}

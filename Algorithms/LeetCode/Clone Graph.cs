using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 133. Clone Graph
     * 
     * Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph.
     * Each node in the graph contains a val (int) and a list (List[Node]) of its neighbors.
     * https://leetcode.com/problems/clone-graph/
     * 
     * Note:
     * The number of nodes will be between 1 and 100.
     * The undirected graph is a simple graph, which means no repeated edges and no self-loops in the graph.
     * Since the graph is undirected, if node p has node q as neighbor, then node q must have node p as neighbor too.
     * You must return the copy of the given node as a reference to the cloned graph.
     */
    public class CloneGraphSolution
    {
        public Node CloneGraph(Node node)
        {
            // BFS solution. Use a dictionary to map old node to new node.
            if (node == null) return null;
            Node copy = new Node(node.val, new List<Node>());
            var map = new Dictionary<Node, Node>() { { node, copy } };
            var queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                Node oldNode = queue.Dequeue();
                Node newNode = map[oldNode];

                foreach (Node oldNeighbor in oldNode.neighbors)
                {
                    if (!map.TryGetValue(oldNeighbor, out Node newNeighbor))
                    {
                        newNeighbor = new Node(oldNeighbor.val, new List<Node>());
                        map.Add(oldNeighbor, newNeighbor);
                        queue.Enqueue(oldNeighbor);
                    }
                    newNode.neighbors.Add(newNeighbor);
                }
            }
            return copy;
        }

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node() { }
            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
    }
}

﻿namespace Algorithms.LeetCode
{
    /* 430. Flatten a Multilevel Doubly Linked List
     * 
     * You are given a doubly linked list which in addition to the next and previous pointers, it could
     * have a child pointer, which may or may not point to a separate doubly linked list. These child
     * lists may have one or more children of their own, and so on, to produce a multilevel data structure,
     * as shown in the example below.
     * 
     * Flatten the list so that all the nodes appear in a single-level, doubly linked list. You are given
     * the head of the first level of the list.
     * 
     * Example:
     * 
     * Input:
     *  1---2---3---4---5---6--NULL
     *          |
     *          7---8---9---10--NULL
     *              |
     *              11--12--NULL
     * 
     * Output:
     * 1-2-3-7-8-11-12-9-10-4-5-6-NULL
     */
    public class Flatten_a_Multilevel_Doubly_Linked_List
    {
        public class Solution
        {
            public Node Flatten(Node head)
            {
                if (head == null) return null;
                FlattenCore(head);
                return head;
            }

            // Returns the tail of the flattened list.
            private Node FlattenCore(Node head)
            {
                // Test case:
                // 1---2---3---4---5---6--NULL
                // |           |
                // 7---8       9---10
                Node node = head;
                while (true)
                {
                    if (node.next == null && node.child == null) return node;
                    if (node.child == null)
                    {
                        node = node.next;
                        continue;
                    }

                    Node tail = FlattenCore(node.child);
                    Node next = node.next;
                    node.next = node.child;
                    node.child.prev = node;
                    node.child = null;
                    tail.next = next;
                    if (next != null) next.prev = tail;

                    node = tail;
                }
            }
        }

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node() { }
            public Node(int _val, Node _prev, Node _next, Node _child)
            {
                val = _val;
                prev = _prev;
                next = _next;
                child = _child;
            }
        }
    }
}

using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 237. Delete Node in a Linked List
     * 
     * Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
     */
    public class DeleteNodeInLinkedList
    {
        public void DeleteNode(ListNode node)
        {
            // Replace node's value with the value of its next node, then delete the next node.
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}

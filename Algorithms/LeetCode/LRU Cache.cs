using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 146. LRU Cache
     * 
     * Design and implement a data structure for Least Recently Used (LRU) cache.
     * It should support the following operations: get and put.
     * 
     * get(key) - Get the value (will always be positive) of the key if the key
     * exists in the cache, otherwise return -1.
     * 
     * put(key, value) - Set or insert the value if the key is not already present.
     * When the cache reached its capacity, it should invalidate the least recently
     * used item before inserting a new item.
     * 
     * The cache is initialized with a positive capacity.
     * 
     * Follow up:
     * Could you do both operations in O(1) time complexity?
     * 
     * Example:
     * 
     * LRUCache cache = new LRUCache( 2);
     * cache.put(1, 1);
     * cache.put(2, 2);
     * cache.get(1);       // returns 1
     * cache.put(3, 3);    // evicts key 2
     * cache.get(2);       // returns -1 (not found)
     * cache.put(4, 4);    // evicts key 1
     * cache.get(1);       // returns -1 (not found)
     * cache.get(3);       // returns 3
     * cache.get(4);       // returns 4
     */
    public class LRUCache
    {
        // We can maintain a list. Every time an element is accessed, put it to the head
        // of the list. When the cache reaches its capacity, delete the element from the
        // tail of the list. We can use a linked list because deleting and inserting are
        // all O(1) operations.
        private class ListNode
        {
            public int Key { get; }
            public int Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode Previous { get; set; }

            public ListNode(int key, int value, ListNode next, ListNode previous)
            {
                Key = key;
                Value = value;
                Next = next;
                Previous = previous;
            }
        }

        private readonly Dictionary<int, ListNode> _dictionary = new Dictionary<int, ListNode>();
        private ListNode _head = null;
        private ListNode _tail = null;
        private readonly int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (_dictionary.TryGetValue(key, out ListNode node))
            {
                MoveToHead(node);
                return node.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_dictionary.TryGetValue(key, out ListNode node))
            {
                node.Value = value;
                MoveToHead(node);
            }
            else
            {
                node = new ListNode(key, value, _head, null);
                if (_head != null) _head.Previous = node;
                if (_tail == null) _tail = node;
                _head = node;
                _dictionary.Add(key, node);
                if (_dictionary.Count > _capacity)
                {
                    _dictionary.Remove(_tail.Key);
                    _tail = _tail.Previous;
                    _tail.Next = null;
                }
            }
        }

        private void MoveToHead(ListNode node)
        {
            if (node == _tail && _head != _tail)
            {
                _tail = node.Previous;
            }

            if (node != _head)
            {
                node.Previous.Next = node.Next;
                if (node.Next != null) node.Next.Previous = node.Previous;
                node.Next = _head;
                node.Previous = null;
                _head.Previous = node;
                _head = node;
            }
        }
    }
}

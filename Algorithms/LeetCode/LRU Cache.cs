using System;
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
        // We can maintain a list. Every time an element is accessed, move it to the head
        // of the list. When the cache reaches its capacity, remove the element from the
        // tail of the list. We can use a linked list because deleting and inserting are
        // all O(1) operations. Similar to LinkedHashMap in Java.
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Item>> _dict = new Dictionary<int, LinkedListNode<Item>>();
        private readonly LinkedList<Item> _list = new LinkedList<Item>();

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (_dict.TryGetValue(key, out var node))
            {
                _list.Remove(node);
                _list.AddFirst(node);
                return node.Value.Val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_dict.TryGetValue(key, out var node))
            {
                node.Value.Val = value;
                _list.Remove(node);
                _list.AddFirst(node);
            }
            else
            {
                if (_dict.Count >= _capacity)
                {
                    _dict.Remove(_list.Last.Value.Key);
                    _list.RemoveLast();
                }

                _list.AddFirst(new Item() { Key = key, Val = value });
                _dict.Add(key, _list.First);
            }
        }

        private class Item
        {
            public int Key { get; set; }

            public int Val { get; set; }
        }
    }

    public class LRUCache2
    {
        // Implement the linked list ourselves.
        // Initialize _head and _tail to two dummy nodes. Always add a new node right after
        // _head, and remove the node right before _tail. In this way, we don't have to deal
        // with special cases such as removing the head or tail.
        private class ListNode
        {
            public int Key { get; }
            public int Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode Prev { get; set; }

            public ListNode(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly Dictionary<int, ListNode> _cache = new Dictionary<int, ListNode>();
        private ListNode _head;
        private ListNode _tail;
        private readonly int _capacity;

        public LRUCache2(int capacity)
        {
            if (capacity < 1) throw new ArgumentOutOfRangeException();
            _capacity = capacity;
            _head = new ListNode(0, 0);
            _tail = new ListNode(0, 0);
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public int Get(int key)
        {
            if (_cache.TryGetValue(key, out ListNode node))
            {
                MoveToHead(node);
                return node.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out ListNode node))
            {
                node.Value = value;
                MoveToHead(node);
            }
            else
            {
                if (_cache.Count >= _capacity)
                {
                    _cache.Remove(_tail.Prev.Key);
                    RemoveNode(_tail.Prev);
                }

                node = new ListNode(key, value);
                _cache.Add(key, node);
                AddNode(node);
            }
        }

        private void AddNode(ListNode node)
        {
            node.Prev = _head;
            node.Next = _head.Next;
            _head.Next.Prev = node;
            _head.Next = node;
        }

        private void RemoveNode(ListNode node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        private void MoveToHead(ListNode node)
        {
            RemoveNode(node);
            AddNode(node);
        }
    }
}

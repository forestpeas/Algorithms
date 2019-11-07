using Algorithms.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 460. LFU Cache
     * 
     * Design and implement a data structure for Least Frequently Used (LFU) cache. It should support
     * the following operations: get and put.
     * 
     * get(key) - Get the value (will always be positive) of the key if the key exists in the cache,
     * otherwise return -1.
     * put(key, value) - Set or insert the value if the key is not already present. When the cache
     * reaches its capacity, it should invalidate the least frequently used item before inserting
     * a new item. For the purpose of this problem, when there is a tie (i.e., two or more keys that
     * have the same frequency), the least recently used key would be evicted.
     * 
     * Note that the number of times an item is used is the number of calls to the get and put functions
     * for that item since it was inserted. This number is set to zero when the item is removed.
     * 
     * Follow up:
     * Could you do both operations in O(1) time complexity?
     * 
     * Example:
     * 
     * LFUCache cache = new LFUCache(2); // 2 is capacity
     * 
     * cache.put(1, 1);
     * cache.put(2, 2);
     * cache.get(1);       // returns 1
     * cache.put(3, 3);    // evicts key 2
     * cache.get(2);       // returns -1 (not found)
     * cache.get(3);       // returns 3.
     * cache.put(4, 4);    // evicts key 1.
     * cache.get(1);       // returns -1 (not found)
     * cache.get(3);       // returns 3
     * cache.get(4);       // returns 4
     */
    public class LFUCache
    {
        // Similar to "146. LRU Cache". We can associate a count with every item. Each time when
        // an item is accessed, its count is incremented. We need to maintain the minimum count.
        // In order to get the least recently used item when there is a tie, we need to map each
        // count to a set of items, which is similar to "146. LRU Cache".
        private class Entry
        {
            public int Value { get; set; }
            public int Count { get; set; }
        }

        private readonly Dictionary<int, Entry> _cache = new Dictionary<int, Entry>(); // key -> (value,count)
        private readonly Dictionary<int, LinkedHashSet<int>> _countToKeys = new Dictionary<int, LinkedHashSet<int>>();
        private readonly int _capacity;
        private int _minCount = 1;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _countToKeys.Add(1, new LinkedHashSet<int>()); // Avoid NPE when "Put".
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var entry)) return -1;
            _countToKeys[entry.Count].Remove(key);
            if (entry.Count == _minCount && _countToKeys[entry.Count].Count == 0)
            {
                _minCount++; // "_minCount++" always exists because every time "count" is only increased by 1.
            }

            entry.Count++;
            if (!_countToKeys.ContainsKey(entry.Count)) _countToKeys[entry.Count] = new LinkedHashSet<int>();
            _countToKeys[entry.Count].Add(key);
            return entry.Value;
        }

        public void Put(int key, int value)
        {
            if (_capacity <= 0) return; // There are test cases like this...
            if (_cache.ContainsKey(key))
            {
                _cache[key].Value = value;
                Get(key);
                return;
            }

            if (_cache.Count >= _capacity)
            {
                int evictKey = _countToKeys[_minCount].First();
                _countToKeys[_minCount].Remove(evictKey);
                _cache.Remove(evictKey);
            }

            _cache.Add(key, new Entry() { Value = value, Count = 1 });
            _countToKeys[1].Add(key);
            _minCount = 1;
        }
    }
}

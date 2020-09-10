using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 432. All O`one Data Structure
     * 
     * Implement a data structure supporting the following operations:
     * 
     * Inc(Key) - Inserts a new key with value 1. Or increments an existing key by 1. Key is guaranteed to be a non-empty string.
     * Dec(Key) - If Key's value is 1, remove it from the data structure. Otherwise decrements an existing key by 1. If the key
     * does not exist, this function does nothing. Key is guaranteed to be a non-empty string.
     * GetMaxKey() - Returns one of the keys with maximal value. If no element exists, return an empty string "".
     * GetMinKey() - Returns one of the keys with minimal value. If no element exists, return an empty string "".
     * 
     * Challenge: Perform all these in O(1) time complexity.
     */
    public class AllOne
    {
        private readonly Dictionary<string, LinkedListNode<Bucket>> _keyToBucket = new Dictionary<string, LinkedListNode<Bucket>>();
        private readonly LinkedList<Bucket> _buckets = new LinkedList<Bucket>();

        private class Bucket
        {
            public int num;
            public HashSet<string> keys;
            public Bucket(int num, HashSet<string> keys)
            {
                this.num = num;
                this.keys = keys;
            }
        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            // "bucket 0" is a dummy to simplify code.
            if (!_keyToBucket.ContainsKey(key))
            {
                var head = _buckets.AddFirst(new Bucket(0, new HashSet<string>() { key }));
                _keyToBucket.Add(key, head);
            }

            var old = _keyToBucket[key];
            var next = old.Next;
            if (next == null || next.Value.num > old.Value.num + 1)
            {
                next = _buckets.AddAfter(old, new Bucket(old.Value.num + 1, new HashSet<string>()));
            }
            next.Value.keys.Add(key);
            _keyToBucket[key] = next;

            old.Value.keys.Remove(key);
            if (old.Value.keys.Count == 0)
            {
                _buckets.Remove(old);
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!_keyToBucket.ContainsKey(key)) return;

            var old = _keyToBucket[key];
            var prev = old.Previous;
            if (old.Value.num == 1)
            {
                _keyToBucket.Remove(key);
            }
            else
            {
                if (prev == null || prev.Value.num < old.Value.num - 1)
                {
                    prev = _buckets.AddBefore(old, new Bucket(old.Value.num - 1, new HashSet<string>()));
                }
                prev.Value.keys.Add(key);
                _keyToBucket[key] = prev;
            }

            old.Value.keys.Remove(key);
            if (old.Value.keys.Count == 0)
            {
                _buckets.Remove(old);
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey() => _buckets.Last?.Value.keys.First() ?? "";

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey() => _buckets.First?.Value.keys.First() ?? "";
    }

    public class AllOne2
    {
        private readonly Dictionary<string, int> _keyToNum = new Dictionary<string, int>();
        private readonly List<HashSet<string>> _numToKeys = new List<HashSet<string>>() { new HashSet<string>() }; // buckets of keys
        private int _max = 0;
        private int _min = 0;

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if (_keyToNum.TryGetValue(key, out int num))
            {
                _keyToNum[key] = num + 1;
                _numToKeys[num].Remove(key);
                AddKeyToBucket(num + 1, key);
                if (num == _max) _max++;
                if (num == _min && _numToKeys[num].Count == 0) _min++;
            }
            else
            {
                _keyToNum.Add(key, 1);
                AddKeyToBucket(1, key);
                if (_max == 0) _max = 1;
                _min = 1;
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (_keyToNum.TryGetValue(key, out int num))
            {
                _keyToNum[key] = num - 1;
                if (num == 1) _keyToNum.Remove(key);
                _numToKeys[num].Remove(key);
                if (num != 1) _numToKeys[num - 1].Add(key);
                if (num == _max && _numToKeys[num].Count == 0) _max--;
                if (num == _min) _min--;
            }
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            return _max == 0 ? "" : _numToKeys[_max].First();
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            if (_min == 0)
            {
                for (int i = 1; i <= _max; i++)
                {
                    if (_numToKeys[i].Count != 0)
                    {
                        _min = i;
                        break;
                    }
                }
            }

            return _min == 0 ? "" : _numToKeys[_min].First();
        }

        private void AddKeyToBucket(int num, string key)
        {
            if (num == _numToKeys.Count)
            {
                _numToKeys.Add(new HashSet<string>() { key });
            }
            else
            {
                _numToKeys[num].Add(key);
            }
        }
    }
}

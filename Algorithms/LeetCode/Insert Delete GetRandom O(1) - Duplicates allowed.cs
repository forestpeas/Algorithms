using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 381. Insert Delete GetRandom O(1) - Duplicates allowed
     * 
     * Design a data structure that supports all following operations in average O(1) time.
     * Note: Duplicate elements are allowed.
     * 
     * insert(val): Inserts an item val to the collection.
     * remove(val): Removes an item val from the collection if present.
     * 
     * getRandom: Returns a random element from current collection of elements. The probability of each element being
     * returned is linearly related to the number of same value the collection contains.
     * 
     * Example:
     * 
     * // Init an empty collection.
     * RandomizedCollection collection = new RandomizedCollection();
     * 
     * // Inserts 1 to the collection. Returns true as the collection did not contain 1.
     * collection.insert(1);
     * 
     * // Inserts another 1 to the collection. Returns false as the collection contained 1. Collection now contains [1,1].
     * collection.insert(1);
     * 
     * // Inserts 2 to the collection, returns true. Collection now contains [1,1,2].
     * collection.insert(2);
     * 
     * // getRandom should return 1 with the probability 2/3, and returns 2 with the probability 1/3.
     * collection.getRandom();
     * 
     * // Removes 1 from the collection, returns true. Collection now contains [1,2].
     * collection.remove(1);
     * 
     * // getRandom should return 1 and 2 both equally likely.
     * collection.getRandom();
     */
    public class RandomizedCollection
    {
        // Similar to "380. Insert Delete GetRandom O(1)". Although there can be duplicate values, indexes are always unique.
        // So the value-to-index mapping becomes value-to-indexes mapping. A value can map to multiple indexes.
        private readonly Random _random = new Random();
        private readonly List<int> _indexToValue = new List<int>();
        private readonly Dictionary<int, HashSet<int>> _valueToIndexes = new Dictionary<int, HashSet<int>>();

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (!_valueToIndexes.TryGetValue(val, out var indexes))
            {
                indexes = new HashSet<int>();
                _valueToIndexes.Add(val, indexes);
            }
            indexes.Add(_indexToValue.Count);
            _indexToValue.Add(val);
            return indexes.Count == 1;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!_valueToIndexes.TryGetValue(val, out var indexes)) return false;
            int maxIndex = _indexToValue.Count - 1;
            int maxIndexValue = _indexToValue[maxIndex];
            int index = indexes.First();
            indexes.Remove(index);
            _valueToIndexes[maxIndexValue].Add(index);
            _valueToIndexes[maxIndexValue].Remove(maxIndex);
            if (indexes.Count == 0) _valueToIndexes.Remove(val);
            _indexToValue[index] = maxIndexValue;
            _indexToValue.RemoveAt(maxIndex);
            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            return _indexToValue[_random.Next(0, _indexToValue.Count)];
        }
    }
}

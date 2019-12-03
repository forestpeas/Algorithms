using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class TreeSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly SortedSet<T> _set = new SortedSet<T>();

        public bool Ceiling(T item, out T ret)
        {
            T max = _set.Max;
            ret = default;
            if (item.CompareTo(max) > 0) return false;
            ret = _set.GetViewBetween(item, max).Min;
            if (ret.CompareTo(item) >= 0 && _set.Contains(ret)) return true;
            return false;
        }

        public bool Add(T item)
        {
            return _set.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }
    }
}

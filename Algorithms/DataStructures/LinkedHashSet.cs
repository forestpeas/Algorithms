using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class LinkedHashSet<T> : IEnumerable<T>
    {
        private readonly IDictionary<T, LinkedListNode<T>> _dict = new Dictionary<T, LinkedListNode<T>>();
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public bool Add(T item)
        {
            if (_dict.ContainsKey(item))
            {
                return false;
            }
            LinkedListNode<T> node = _list.AddLast(item);
            _dict[item] = node;
            return true;
        }

        public bool Remove(T item)
        {
            if (!_dict.TryGetValue(item, out LinkedListNode<T> node))
            {
                return false;
            }
            _dict.Remove(item);
            _list.Remove(node);
            return true;
        }

        public int Count => _dict.Count;

        public bool Contains(T item)
        {
            return _dict.ContainsKey(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}

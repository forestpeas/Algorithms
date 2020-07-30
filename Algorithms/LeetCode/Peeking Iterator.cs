using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 284. Peeking Iterator
     * 
     * Given an Iterator class interface with methods: next() and hasNext(), design and implement a PeekingIterator
     * that support the peek() operation -- it essentially peek() at the element that will be returned by the next
     * call to next().
     * 
     * Example:
     * 
     * Assume that the iterator is initialized to the beginning of the list: [1,2,3].
     * 
     * Call next() gets you 1, the first element in the list.
     * Now you call peek() and it returns 2, the next element. Calling next() after that still return 2. 
     * You call next() the final time and it returns 3, the last element. 
     * Calling hasNext() after that should return false.
     * 
     * Follow up: How would you extend your design to be generic and work with all types, not just integer?
     */
    public class PeekingIterator
    {
        private readonly IEnumerator<int> _iterator;
        private int _top;
        private bool _hasNext;
        private bool _peekHasNext = true;

        // iterators refers to the first element of the array.
        public PeekingIterator(IEnumerator<int> iterator)
        {
            // "iterator" was called MoveNext() outside this constructor.
            _iterator = iterator;
            _top = _iterator.Current;
            _hasNext = iterator.MoveNext();
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int Peek()
        {
            return _top;
        }

        // Returns the next element in the iteration and advances the iterator.
        public int Next()
        {
            if (!_hasNext)
            {
                _peekHasNext = false;
                return _top;
            }
            int ret = _top;
            _top = _iterator.Current;
            _hasNext = _iterator.MoveNext();
            return ret;
        }

        // Returns false if the iterator is refering to the end of the array of true otherwise.
        public bool HasNext()
        {
            return _peekHasNext;
        }
    }
}

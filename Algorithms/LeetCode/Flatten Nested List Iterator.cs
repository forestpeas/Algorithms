using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 341. Flatten Nested List Iterator
     * 
     * Given a nested list of integers, implement an iterator to flatten it.
     * Each element is either an integer, or a list -- whose elements may also be integers or other lists.
     * 
     * Example 1:
     * 
     * Input: [[1,1],2,[1,1]]
     * Output: [1,1,2,1,1]
     * Explanation: By calling next repeatedly until hasNext returns false, 
     *              the order of elements returned by next should be: [1,1,2,1,1].
     * 
     * Example 2:
     * 
     * Input: [1,[4,[6]]]
     * Output: [1,4,6]
     * Explanation: By calling next repeatedly until hasNext returns false, 
     *              the order of elements returned by next should be: [1,4,6].
     */
    public class NestedIterator
    {
        private readonly Stack<IList<NestedInteger>> _stack = new Stack<IList<NestedInteger>>();
        private readonly Stack<int> _stackIdx = new Stack<int>();
        private int _i = 0; // index pointing to the next element

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            // When we push a list to _stack, we also save the current index to _stackIdx so that
            // when the list is popped, we can pop from _stackIdx to get the next index.
            _stack.Push(nestedList);
            _stackIdx.Push(-1); // nestedList has no "father".
        }

        public bool HasNext()
        {
            while (true)
            {
                if (_stack.Count == 0) return false;
                if (_i < _stack.Peek().Count) break;
                _stack.Pop();
                _i = _stackIdx.Pop();
            }
            while (!_stack.Peek()[_i].IsInteger()) // _i is now guaranteed to be valid.
            {
                if (_stack.Peek()[_i].GetList().Count == 0)
                {
                    _i++;
                    return HasNext();
                }
                _stack.Push(_stack.Peek()[_i].GetList());
                _stackIdx.Push(_i + 1); // Next correct index when we come back.
                _i = 0;
            }
            return true;
        }

        public int Next()
        {
            if (!HasNext()) throw new InvalidOperationException();
            return _stack.Peek()[_i++].GetInteger();
        }
    }

    public interface NestedInteger
    {
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

}

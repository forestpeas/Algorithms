using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1381. Design a Stack With Increment Operation
     * 
     * Design a stack which supports the following operations.
     * 
     * Implement the CustomStack class:
     * 
     * CustomStack(int maxSize) Initializes the object with maxSize which is the maximum number of
     * elements in the stack or do nothing if the stack reached the maxSize.
     * void push(int x) Adds x to the top of the stack if the stack hasn't reached the maxSize.
     * int pop() Pops and returns the top of stack or -1 if the stack is empty.
     * void inc(int k, int val) Increments the bottom k elements of the stack by val. If there are
     * less than k elements in the stack, just increment all the elements in the stack.
     * 
     * Example 1:
     * 
     * Input
     * ["CustomStack","push","push","pop","push","push","push","increment","increment","pop","pop",
     * "pop","pop"]
     * [[3],[1],[2],[],[2],[3],[4],[5,100],[2,100],[],[],[],[]]
     * Output
     * [null,null,null,2,null,null,null,null,null,103,202,201,-1]
     * Explanation
     * CustomStack customStack = new CustomStack(3); // Stack is Empty []
     * customStack.push(1);                          // stack becomes [1]
     * customStack.push(2);                          // stack becomes [1, 2]
     * customStack.pop();                            // return 2 --> Return top of the stack 2, stack becomes [1]
     * customStack.push(2);                          // stack becomes [1, 2]
     * customStack.push(3);                          // stack becomes [1, 2, 3]
     * customStack.push(4);                          // stack still [1, 2, 3], Don't add another elements as size is 4
     * customStack.increment(5, 100);                // stack becomes [101, 102, 103]
     * customStack.increment(2, 100);                // stack becomes [201, 202, 103]
     * customStack.pop();                            // return 103 --> Return top of the stack 103, stack becomes [201, 202]
     * customStack.pop();                            // return 202 --> Return top of the stack 102, stack becomes [201]
     * customStack.pop();                            // return 201 --> Return top of the stack 101, stack becomes []
     * customStack.pop();                            // return -1 --> Stack is empty return -1.
     */
    public class Design_a_Stack_With_Increment_Operation
    {
        // O(1) per push, pop and increment. Inspired by https://leetcode.com/problems/design-a-stack-with-increment-operation/discuss/539716/JavaC%2B%2BPython-Lazy-increment-O(1)
        // _inc[i] means "stack[0...i]" should be incremented by _inc[i].
        // We only make sure that _inc[stack_top] is accurate (stack_top points to the top of the stack),
        // by updating _inc each time an element is popped.
        public class CustomStack
        {
            private readonly int _maxSize;
            private readonly int[] _inc;
            private readonly Stack<int> _stack;

            public CustomStack(int maxSize)
            {
                _maxSize = maxSize;
                _inc = new int[maxSize];
                _stack = new Stack<int>();
            }

            public void Push(int x)
            {
                if (_stack.Count < _maxSize) _stack.Push(x);
            }

            public int Pop()
            {
                int i = _stack.Count - 1;
                if (i < 0) return -1;
                if (i > 0) _inc[i - 1] += _inc[i];
                int res = _stack.Pop() + _inc[i];
                _inc[i] = 0; // In case new elements are pushed later.
                return res;
            }

            public void Increment(int k, int val)
            {
                int i = Math.Min(k, _stack.Count) - 1;
                if (i >= 0) _inc[i] += val;
            }
        }

        // O(1) per push and pop and O(k) per increment.
        public class CustomStack2
        {
            private readonly int[] _stack;
            private int _ptr = -1;

            public CustomStack2(int maxSize)
            {
                _stack = new int[maxSize];
            }

            public void Push(int x)
            {
                if (_ptr == _stack.Length - 1) return;
                _ptr++;
                _stack[_ptr] = x;
            }

            public int Pop()
            {
                if (_ptr == -1) return -1;
                int ret = _stack[_ptr];
                _stack[_ptr] = 0;
                _ptr--;
                return ret;
            }

            public void Increment(int k, int val)
            {
                k = Math.Min(k, _stack.Length);
                for (int i = 0; i < k; i++)
                {
                    _stack[i] += val;
                }
            }
        }
    }
}

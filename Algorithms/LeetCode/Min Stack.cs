using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 155. Min Stack
     * 
     * Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
     * 
     * push(x) -- Push element x onto stack.
     * pop() -- Removes the element on top of the stack.
     * top() -- Get the top element.
     * getMin() -- Retrieve the minimum element in the stack.
     * 
     * Example:
     * 
     * MinStack minStack = new MinStack();
     * minStack.push(-2);
     * minStack.push(0);
     * minStack.push(-3);
     * minStack.getMin();   --> Returns -3.
     * minStack.pop();
     * minStack.top();      --> Returns 0.
     * minStack.getMin();   --> Returns -2.
     */
    public class MinStack
    {
        // Whenever push, push onto both stacks, but only push the current minimum element onto _mins.
        // Whenever pop, pop from both stacks.
        private readonly Stack<int> _data = new Stack<int>();
        private readonly Stack<int> _mins = new Stack<int>();

        public void Push(int x)
        {
            _data.Push(x);
            if (_mins.TryPeek(out int min))
            {
                _mins.Push(x > min ? min : x);
            }
            else
            {
                _mins.Push(x);
            }
        }

        public void Pop()
        {
            _mins.Pop();
            _data.Pop();
        }

        public int Top()
        {
            return _data.Peek();
        }

        public int GetMin()
        {
            return _mins.Peek();
        }
    }
}

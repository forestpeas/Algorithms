using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 232. Implement Queue using Stacks
     * 
     * Implement the following operations of a queue using stacks.
     * 
     *     push(x) -- Push element x to the back of queue.
     *     pop() -- Removes the element from in front of queue.
     *     peek() -- Get the front element.
     *     empty() -- Return whether the queue is empty.
     * 
     * Example:
     * 
     * MyQueue queue = new MyQueue();
     * 
     * queue.push(1);
     * queue.push(2);  
     * queue.peek();  // returns 1
     * queue.pop();   // returns 1
     * queue.empty(); // returns false
     * 
     * Notes:
     *     You must use only standard operations of a stack -- which means only push to top,
     *     peek/pop from top, size, and is empty operations are valid.
     *     Depending on your language, stack may not be supported natively. You may simulate
     *     a stack by using a list or deque (double-ended queue), as long as you use only
     *     standard operations of a stack.
     *     You may assume that all operations are valid (for example, no pop or peek operations
     *     will be called on an empty queue).
     */
    public class MyQueue
    {
        // _stack2 is responsible for the correct order of pop and peek operations.
        // When _stack2 is empty, simply take all elements from stack1.
        private readonly Stack<int> _stack1 = new Stack<int>();
        private readonly Stack<int> _stack2 = new Stack<int>();

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            _stack1.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            LoadFromStack1();
            return _stack2.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            LoadFromStack1();
            return _stack2.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return _stack1.Count == 0 && _stack2.Count == 0;
        }

        private void LoadFromStack1()
        {
            if (_stack2.Count == 0)
            {
                while (_stack1.Count != 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
        }
    }
}

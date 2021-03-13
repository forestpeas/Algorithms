namespace Algorithms.LeetCode
{
    /* 641. Design Circular Deque
     * 
     * Design your implementation of the circular double-ended queue (deque).
     * 
     * Your implementation should support following operations:
     * 
     *     MyCircularDeque(k): Constructor, set the size of the deque to be k.
     *     insertFront(): Adds an item at the front of Deque. Return true if the operation is successful.
     *     insertLast(): Adds an item at the rear of Deque. Return true if the operation is successful.
     *     deleteFront(): Deletes an item from the front of Deque. Return true if the operation is successful.
     *     deleteLast(): Deletes an item from the rear of Deque. Return true if the operation is successful.
     *     getFront(): Gets the front item from the Deque. If the deque is empty, return -1.
     *     getRear(): Gets the last item from Deque. If the deque is empty, return -1.
     *     isEmpty(): Checks whether Deque is empty or not. 
     *     isFull(): Checks whether Deque is full or not. 
     * 
     * Example:
     * 
     * MyCircularDeque circularDeque = new MycircularDeque(3); // set the size to be 3
     * circularDeque.insertLast(1);			// return true
     * circularDeque.insertLast(2);			// return true
     * circularDeque.insertFront(3);			// return true
     * circularDeque.insertFront(4);			// return false, the queue is full
     * circularDeque.getRear();  			// return 2
     * circularDeque.isFull();				// return true
     * circularDeque.deleteLast();			// return true
     * circularDeque.insertFront(4);			// return true
     * circularDeque.getFront();			// return 4
     */
    public class Design_Circular_Deque
    {
        // similar to "622. Design Circular Queue"
        public class MyCircularDeque
        {
            private readonly int[] _queue;
            private int _head = 0;
            private int _tail = 0;
            private int _count = 0;

            public MyCircularDeque(int k)
            {
                _queue = new int[k];
            }

            public bool InsertFront(int value)
            {
                if (IsFull()) return false;
                if (_count != 0) _head = (_head - 1 + _queue.Length) % _queue.Length;
                _queue[_head] = value;
                _count++;
                return true;
            }

            public bool InsertLast(int value)
            {
                if (IsFull()) return false;
                if (_count != 0) _tail = (_tail + 1) % _queue.Length;
                _queue[_tail] = value;
                _count++;
                return true;
            }

            public bool DeleteFront()
            {
                if (IsEmpty()) return false;
                if (_count != 1) _head = (_head + 1) % _queue.Length;
                _count--;
                return true;
            }

            public bool DeleteLast()
            {
                if (IsEmpty()) return false;
                if (_count != 1) _tail = (_tail - 1 + _queue.Length) % _queue.Length;
                _count--;
                return true;
            }

            public int GetFront()
            {
                if (IsEmpty()) return -1;
                return _queue[_head];
            }

            public int GetRear()
            {
                if (IsEmpty()) return -1;
                return _queue[_tail];
            }

            public bool IsEmpty()
            {
                return _count == 0;
            }

            public bool IsFull()
            {
                return _count == _queue.Length;
            }
        }
    }
}

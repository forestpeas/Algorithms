using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 295. Find Median from Data Stream
     * 
     * Median is the middle value in an ordered integer list. If the size of the list is even,
     * there is no middle value. So the median is the mean of the two middle value.
     * 
     * For example,
     * [2,3,4], the median is 3
     * 
     * [2,3], the median is (2 + 3) / 2 = 2.5
     * 
     * Design a data structure that supports the following two operations:
     * 
     * void addNum(int num) - Add a integer number from the data stream to the data structure.
     * double findMedian() - Return the median of all elements so far.
     * 
     * Example:
     * 
     * addNum(1)
     * addNum(2)
     * findMedian() -> 1.5
     * addNum(3) 
     * findMedian() -> 2
     *  
     * Follow up:
     * 
     * If all integer numbers from the stream are between 0 and 100, how would you optimize it?
     * If 99% of all integer numbers from the stream are between 0 and 100, how would you optimize it?
     */
    public class MedianFinder
    {
        // Follow ups:
        // 1. Count the frequency of each numbers using an array of size 100.
        // 2. When 0 <= num <= 100, same as follow up 1.
        //    When num < 0 or num > 100, use two sorted arrays, or use two priority queues same as below.

        // _small is a max priority queue and _large is a min priority queue.
        private readonly PriorityQueue<int> _small = new PriorityQueue<int>();
        private readonly PriorityQueue<int> _large = new PriorityQueue<int>(Comparer<int>.Create((x, y) => y - x));

        public void AddNum(int num)
        {
            // _small contains the smaller half numbers, _large contains the larger half numbers.
            // At any time, either _small.Count = _large.Count, or _small.Count - 1 = _large.Count
            _small.Add(num);
            _large.Add(_small.DeleteTop());
            if (_small.Count < _large.Count)
            {
                _small.Add(_large.DeleteTop());
            }
        }

        public double FindMedian()
        {
            if (_small.Count == _large.Count) return (_small.PeekTop() + _large.PeekTop()) / 2.0;
            return _small.PeekTop();
        }
    }
}

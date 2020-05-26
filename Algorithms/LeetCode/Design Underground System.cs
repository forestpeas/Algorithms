using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1396. Design Underground System
     * 
     * Implement the class UndergroundSystem that supports three methods:
     * 
     * 1. checkIn(int id, string stationName, int t)
     * 
     * A customer with id card equal to id, gets in the station stationName at time t.
     * A customer can only be checked into one place at a time.
     * 2. checkOut(int id, string stationName, int t)
     * 
     * A customer with id card equal to id, gets out from the station stationName at time t.
     * 3. getAverageTime(string startStation, string endStation) 
     * 
     * Returns the average time to travel between the startStation and the endStation.
     * The average time is computed from all the previous traveling from startStation to endStation that happened directly.
     * Call to getAverageTime is always valid.
     * You can assume all calls to checkIn and checkOut methods are consistent. That is, if a customer gets in at time t1 at
     * some station, then it gets out at time t2 with t2 > t1. All events happen in chronological order.
     * 
     * https://leetcode.com/problems/design-underground-system/
     */
    public class UndergroundSystem
    {
        private readonly Dictionary<int, Tuple<string, int>> _customers = new Dictionary<int, Tuple<string, int>>();
        private readonly Dictionary<string, Tuple<int, int>> _travelTimes = new Dictionary<string, Tuple<int, int>>();

        public void CheckIn(int id, string stationName, int t)
        {
            _customers.Add(id, new Tuple<string, int>(stationName, t));
        }

        public void CheckOut(int id, string stationName, int t)
        {
            var item = _customers[id];
            _customers.Remove(id);
            string key = item.Item1 + "_" + stationName;
            int time = t - item.Item2;
            if (!_travelTimes.ContainsKey(key))
            {
                _travelTimes.Add(key, new Tuple<int, int>(time, 1));
            }
            else
            {
                int sum = _travelTimes[key].Item1 + time;
                int count = _travelTimes[key].Item2 + 1;
                _travelTimes[key] = new Tuple<int, int>(sum, count);
            }
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            var item = _travelTimes[startStation + "_" + endStation];
            return (double)item.Item1 / item.Item2;
        }
    }
}

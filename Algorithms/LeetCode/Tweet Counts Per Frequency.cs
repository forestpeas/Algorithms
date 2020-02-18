using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1348. Tweet Counts Per Frequency
     * 
     * https://leetcode.com/problems/tweet-counts-per-frequency/
     */
    public class TweetCounts
    {
        private readonly Dictionary<string, List<int>> _tweets = new Dictionary<string, List<int>>();

        public void RecordTweet(string tweetName, int time)
        {
            if (!_tweets.TryGetValue(tweetName, out var times))
            {
                times = new List<int>();
                _tweets.Add(tweetName, times);
            }

            times.Add(time);
        }

        public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
        {
            int delta = freq == "minute" ? 60 : freq == "hour" ? 3600 : 3600 * 24;
            var result = new List<int>();
            for (int i = 0; ; i++)
            {
                result.Add(0);
                int end = Math.Min(startTime + delta * (i + 1), endTime + 1);
                if (end == endTime + 1) break;
            }

            int offset = startTime / delta;
            foreach (int time in _tweets[tweetName])
            {
                // for example, freq = 6, start = 4
                // intervals:  [0, 6), [6, 12), [12, 18),...
                // intervals': [4,10), [10,16), [16, 22),...
                // "time" belongs to the i-th interval.
                // The i-th interval corresponds to the i-th interval'.
                // If "time" < the start of the i-th interval', then
                // "time" belongs to the (i-1)th interval'.
                int i = time / delta - offset;
                int start = startTime + delta * i;
                if (time < start) i--;
                if (i < result.Count && time >= startTime && time < endTime + 1)
                {
                    result[i]++;
                }
            }

            return result;
        }
    }
}

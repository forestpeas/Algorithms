using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1311. Get Watched Videos by Your Friends
     * 
     * https://leetcode.com/problems/get-watched-videos-by-your-friends/
     */
    public class Get_Watched_Videos_by_Your_Friends
    {
        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            var targetFriends = new HashSet<int>(); // friends of the target level
            bool[] visited = new bool[friends.Length];
            visited[id] = true;
            var queue = new Queue<int>();
            queue.Enqueue(id);
            int k = 0;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                while (size-- > 0)
                {
                    int i = queue.Dequeue();
                    foreach (int f in friends[i])
                    {
                        if (visited[f]) continue;
                        visited[f] = true;
                        queue.Enqueue(f);
                    }
                }

                if (++k == level)
                {
                    foreach (int i in queue) targetFriends.Add(i);
                    break;
                }
            }

            var counts = new Dictionary<string, int>();
            foreach (int i in targetFriends)
            {
                foreach (string v in watchedVideos[i])
                {
                    counts[v] = counts.GetValueOrDefault(v) + 1;
                }
            }

            return counts.OrderBy(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => kv.Key).ToArray();
        }
    }
}

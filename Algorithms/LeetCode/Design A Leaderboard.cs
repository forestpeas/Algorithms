using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1244. Design A Leaderboard
     * 
     * Design a Leaderboard class, which has 3 functions:
     * 
     * addScore(playerId, score): Update the leaderboard by adding score to the given player's score.
     * If there is no player with such id in the leaderboard, add him to the leaderboard with the given score.
     * top(K): Return the score sum of the top K players.
     * reset(playerId): Reset the score of the player with the given id to 0. It is guaranteed that the player
     * was added to the leaderboard before calling this function.
     * 
     * Initially, the leaderboard is empty.
     * 
     * Example 1:
     * 
     * Input: 
     * ["Leaderboard","addScore","addScore","addScore","addScore","addScore","top","reset","reset","addScore","top"]
     * [[],[1,73],[2,56],[3,39],[4,51],[5,4],[1],[1],[2],[2,51],[3]]
     * Output: 
     * [null,null,null,null,null,null,73,null,null,null,141]
     * 
     * Explanation: 
     * Leaderboard leaderboard = new Leaderboard ();
     * leaderboard.addScore(1,73);   // leaderboard = [[1,73]];
     * leaderboard.addScore(2,56);   // leaderboard = [[1,73],[2,56]];
     * leaderboard.addScore(3,39);   // leaderboard = [[1,73],[2,56],[3,39]];
     * leaderboard.addScore(4,51);   // leaderboard = [[1,73],[2,56],[3,39],[4,51]];
     * leaderboard.addScore(5,4);    // leaderboard = [[1,73],[2,56],[3,39],[4,51],[5,4]];
     * leaderboard.top(1);           // returns 73;
     * leaderboard.reset(1);         // leaderboard = [[2,56],[3,39],[4,51],[5,4]];
     * leaderboard.reset(2);         // leaderboard = [[3,39],[4,51],[5,4]];
     * leaderboard.addScore(2,51);   // leaderboard = [[2,51],[3,39],[4,51],[5,4]];
     * leaderboard.top(3);           // returns 141 = 51 + 51 + 39;
     *  
     * Constraints:
     * 
     * 1 <= playerId, K <= 10000
     * It's guaranteed that K is less than or equal to the current number of players.
     * 1 <= score <= 100
     * There will be at most 1000 function calls.
     */
    public class Design_A_Leaderboard
    {
        public class Leaderboard
        {
            private readonly SortedDictionary<int, int> _scoreCount =
                new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x))); // score -> count
            private readonly Dictionary<int, int> _idToScore = new Dictionary<int, int>(); // playerId -> score

            public void AddScore(int playerId, int score)
            {
                if (_idToScore.TryGetValue(playerId, out int oldScore))
                {
                    score += oldScore;
                    if (--_scoreCount[oldScore] == 0) _scoreCount.Remove(oldScore);
                }
                _idToScore[playerId] = score;
                _scoreCount[score] = _scoreCount.GetValueOrDefault(score) + 1;
            }

            public int Top(int K)
            {
                int result = 0;
                foreach (var item in _scoreCount)
                {
                    int score = item.Key;
                    int count = item.Value;
                    if (count < K)
                    {
                        result += score * count;
                        K -= count;
                    }
                    else
                    {
                        result += score * K;
                        break;
                    }
                }

                return result;
            }

            public void Reset(int playerId)
            {
                int score = _idToScore[playerId];
                _idToScore.Remove(playerId);
                if (--_scoreCount[score] == 0) _scoreCount.Remove(score);
            }
        }
    }
}

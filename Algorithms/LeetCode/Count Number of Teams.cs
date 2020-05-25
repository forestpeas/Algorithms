namespace Algorithms.LeetCode
{
    /* 1395. Count Number of Teams
     * 
     * There are n soldiers standing in a line. Each soldier is assigned a unique rating value.
     * 
     * You have to form a team of 3 soldiers amongst them under the following rules:
     * 
     * Choose 3 soldiers with index (i, j, k) with rating (rating[i], rating[j], rating[k]).
     * A team is valid if:  (rating[i] < rating[j] < rating[k]) or (rating[i] > rating[j] > rating[k]) where (0 <= i < j < k < n).
     * Return the number of teams you can form given the conditions. (soldiers can be part of multiple teams).
     * 
     * Example 1:
     * 
     * Input: rating = [2,5,3,4,1]
     * Output: 3
     * Explanation: We can form three teams given the conditions. (2,3,4), (5,4,1), (5,3,1).
     * 
     * Example 2:
     * 
     * Input: rating = [2,1,3]
     * Output: 0
     * Explanation: We can't form any team given the conditions.
     * 
     * Example 3:
     * 
     * Input: rating = [1,2,3,4]
     * Output: 4
     */
    public class Count_Number_of_Teams
    {
        public int NumTeams(int[] rating)
        {
            int n = rating.Length, res = 0;
            // dp_smaller[i] is the number of numbers smaller than rating[i] on the right of i.
            // dp_larger[i] is the number of numbers larger than rating[i] on the right of i.
            int[] dp_smaller = new int[rating.Length];
            int[] dp_larger = new int[rating.Length];
            dp_smaller[n - 1] = dp_larger[n - 1] = 0;
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (rating[j] < rating[i])
                    {
                        dp_smaller[i]++;
                        res += dp_smaller[j];
                    }
                    else if (rating[j] > rating[i])
                    {
                        dp_larger[i]++;
                        res += dp_larger[j];
                    }
                }
            }

            return res;
        }
    }
}

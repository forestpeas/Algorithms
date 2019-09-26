**1\. Two Sum**: Find two numbers in a given array that add up to a target.

Use a hash table to store complement of each number.

**2\. Add Two Numbers**: The two numbers are represented as linked lists.

Simple math problem.

**3\. Longest Substring Without Repeating Characters**

Maintain a sliding window that contains only unique characters.

**10\. Regular Expression Matching**: `'.'` matches any single character, `'*'` Matches zero or more of the preceding element.

DP: A `'*'`either matches empty or "swallows" one more character.

**43\. Multiply Strings**: Multiply two numbers represented as strings.

![43](D:\GitHub\CSharp\Algorithms\Algorithms\LeetCode\Notes\pics\43.png)

**44\. Wildcard Matching**: `'?'` matches any single character, `'*'` Matches any sequence of characters.

DP: A `'*'`either matches empty or "swallows" one more character.
Backtracking + Greedy: Every time we go into a dead end, we come back to the last `'*'` to make it "swallow" one more character.

**128\. Longest Consecutive Sequence**: Find the length of the longest consecutive elements sequence of an array of integers.

Use a hash set to count from the start of a sequence. A bit tricky.

**139\. Word Break**: Determine if a given string can be segmented into several words in a given dictionary.

Brute-force search with memoization, can also be thought as DP.

**140\. Word Break II**: Return all possible segmented results from "139. Word Break".

Same as "139. Word Break".

**148\. Sort List**: Sort a linked list in O(n log n) time using constant space complexity.

Merge sort.

**198\. House Robber**: Find the maximum sum of non-adjacent numbers in a given array.

DP: Either rob or not rob at i: `dp(i) = max(dp(i - 1), nums[i] + dp(i - 2))`

**213\. House Robber II**: Same as "198. House Robber", except that the first and last number cannot be chosen both.

Maximum of two sub-problems of "198. House Robber".

**239\. Sliding Window Maximum**: Find the max number in a sliding window of an array.

Use a deque to maintain the possible candidates.
















**1\. Two Sum**: Find two numbers in a given array that add up to a target.

Use a hash table to store complement of each number.

**2\. Add Two Numbers**: The two numbers are represented as linked lists.

Simple math problem.

**3\. Longest Substring Without Repeating Characters**

Maintain a sliding window that contains only unique characters.

**10\. Regular Expression Matching**: `'.'` matches any single character, `'*'` Matches zero or more of the preceding element.

DP: A `'*'`either matches empty or "swallows" one more character.

**33\. Search in Rotated Sorted Array**

Step 1\. Find the "rotated point" - the index of the smallest value in the array.

Step 2\. Binary search with the appropriate offset.

**34\. Find First and Last Position of Element in Sorted Array**

Binary search with special handling when `nums[mid] == target`.

**35\. Search Insert Position**

Binary search.

**43\. Multiply Strings**: Multiply two numbers represented as strings.

![43](D:\GitHub\CSharp\Algorithms\Algorithms\LeetCode\Notes\pics\43.png)

**44\. Wildcard Matching**: `'?'` matches any single character, `'*'` Matches any sequence of characters.

DP: A `'*'`either matches empty or "swallows" one more character.
Backtracking + Greedy: Every time we go into a dead end, we come back to the last `'*'` to make it "swallow" one more character.

**81\. Search in Rotated Sorted Array II**: A follow up to "33\. Search in Rotated Sorted Array", where the array may contain duplicates.

First, eliminate duplicates from the beginning. The rest is the same as "33\. Search in Rotated Sorted Array".

**128\. Longest Consecutive Sequence**: Find the length of the longest consecutive elements sequence of an array of integers.

Use a hash set to count from the start of a sequence. A bit tricky.

**139\. Word Break**: Determine if a given string can be segmented into several words in a given dictionary.

Brute-force search with memoization, can also be thought as DP.

**140\. Word Break II**: Return all possible segmented results from "139. Word Break".

Same as "139. Word Break".

**148\. Sort List**: Sort a linked list in O(n log n) time using constant space complexity.

Merge sort.

**153\. Find Minimum in Rotated Sorted Array**

Same as the first step of "33. Search in Rotated Sorted Array".

**154\. Find Minimum in Rotated Sorted Array II**

Same as the first step of "81. Search in Rotated Sorted Array II".

**164\. Maximum Gap**: Given an unsorted array, find the maximum difference between the successive elements in its **sorted form**. Assume all elements in the array are non-negative integers. Try to solve it in linear time/space.

Radix Sort(LSD String Sort) or Bucket Sort(somehow ensures that the two elements that forms the  maximum gap are in different buckets).

**165\. Compare Version Numbers**

Split the version number by dot.

**167\. Two Sum II - Input array is sorted**: Find two numbers in a given sorted array that add up to a target.

In each iteration, binary search in [lo + 1, hi], then narrow down the range of [lo, hi].

**187\. Repeated DNA Sequences**: Find all the 10-letter-long substrings that occur more than once.

Find all possible sequences and use a hash table to store the seen sequences.

**198\. House Robber**: Find the maximum sum of non-adjacent numbers in a given array.

DP: Either rob or not rob at i: `dp(i) = max(dp(i - 1), nums[i] + dp(i - 2))`

**199\. Binary Tree Right Side View**: Return the "right outline" of a binary tree.

DFS or BFS, only add current node to result under certain circumstances:

DFS: When the current depth is deeper than the maximum depth.

BFS: When the current node is the last node of the current level.

**201\. Bitwise AND of Numbers Range**

After observing, we can find a pattern that makes the problem equal to finding the longest common prefix of two numbers' binary representations.

**209\. Minimum Size Subarray Sum**: Find the minimal length of a contiguous subarray that satisfies a requirement.

Typical sliding window problem.

**211\. Add and Search Word - Data structure design**

Trie.

**213\. House Robber II**: Same as "198. House Robber", except that the first and last number cannot be chosen both.

Maximum of two sub-problems of "198. House Robber".

**217\. Contains Duplicate**: Find if a given array contains any duplicates.

Hash set.

**219\. Contains Duplicate II**: Given `nums` and `k`, find `i` and `j` such that `nums[i] = nums[j]` and `j - i >= k`.

Hash table.

**220\. Contains Duplicate III**: Given `nums` and `k` and `t`, find `i` and `j` such that `nums[j]- nums[i] >= t` and `j - i >= k`.

Sorted set(or ordered map, or balanced binary search tree).

**221\. Maximal Square**: Given a 2-D matrix filled with only 0 and 1, find the largest square containing only 1.

DP. `dp(i,j)` represents the side length of the maximum square whose **bottom right corner** is the cell with index `(i,j)` in the original matrix: 

`dp(i, j) = min(dp(i − 1, j - 1), dp(i, j − 1), dp(i, j − 1)) + 1.`

**222\. Count Complete Tree Nodes**: Given a complete binary tree, count the number of nodes.

Recursively check whether the heights of left subtree and right subtree are equal.

**229\. Majority Element II**: Find all elements in an array that appear more than `array.Length / 3` times.

A mathematical extension of the Boyer-Moore Voting Algorithm of "169. Majority Element".

**239\. Sliding Window Maximum**: Find the max number in a sliding window of an array.

Use a deque to maintain the possible candidates.

**263\. Ugly Number**: Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. Check whether a given number is an ugly number.

Math: Divide the given number by 2, 3, 5 until it becomes 1.

**264\. Ugly Number II**: Find the n-th ugly number.

The next ugly number is the minimum of a certain previous ugly number multiplied by 2 or 3 or 5.

**300\. Longest Increasing Subsequence**

Patience sorting, O(NlogN).

DP, O(N^2): `dp[i]` with the restriction of `nums[i]` being the tail of the longest increasing subsequence.

**313\. Super Ugly Number**: Find the nth super ugly number. Super ugly numbers are positive numbers whose all prime factors are in the given prime list.

A generalization of "Problem 264. Ugly Number II", same idea.

**315\. Count of Smaller Numbers After Self**: Given an integer array `nums`, return an array `counts` where `counts[i]` is the number of smaller elements to the right of `nums[i]`.

Mergesort. Similar to "493\. Reverse Pairs".

**378\. Kth Smallest Element in a Sorted Matrix**: Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Starting from `matrix[0][0]`, add `matrix[i + 1][j]` and `matrix[i][j + 1]` to a min priority queue because they are candidates for the next smallest element.

**402\. Remove K Digits**: Remove k digits from a given number so that the new number is the smallest possible.

We can find a pattern: from the most significant digit to the least significant digit, whenever we meet a digit that is less than the the previous digit, we should discard the previous digit.

**454\. 4Sum II**: Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that `A[i] + B[j] + C[k] + D[l]` is zero.

Store the sum of every combination of (A[i] + B[j]) in a hash table, then check every combination of (C[i] +D[j]).

**493\. Reverse Pairs**: Given an array `nums`, find how many pair(i, j) there are such that `i < j` and `nums[i] > 2*nums[j]`.

Mergesort.








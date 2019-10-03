**1\. Two Sum**: Find two numbers in a given array that add up to a target.

Use a hash table to store complement of each number.

**2\. Add Two Numbers**: The two numbers are represented as linked lists.

Simple math problem.

**3\. Longest Substring Without Repeating Characters**

Maintain a sliding window that contains only unique characters.

**10\. Regular Expression Matching**: `'.'` matches any single character, `'*'` Matches zero or more of the preceding element.

DP: A `'*'`either matches empty or "swallows" one more character.

**26. Remove Duplicates from Sorted Array**

Fast-slow pointers.

**31\. Next Permutation**: Return the lexicographically next greater permutation of the given numbers.

Write down the permutations of [1,2,3,4], then observe and find the pattern:

1. Find the first ascending pair `nums[i]` and `nums[i+1]` from right to left.
2. Find the next larger element to `nums[i]`.
3. Starting from the end, find the next larger element to `nums[i]` and swap with `nums[i]`.
4. Reverse from `nums[i + 1]` to the end.

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

**45\. Jump Game II**: Given an array of integers, `nums[i]` is the maximum jump length at `i`. Return the minimum number of jumps from start to end.

Greedy, also implicit BFS. The first level only contains `nums[0]`. For each element `nums[i]` in the current level, add `nums[i + nums[i]]` to the next level.

**46\. Permutations**: Given a collection of distinct integers, return all possible permutations.

Backtracking. Each time we choose an unchosen number. When all numbers have been chosen, backtrack to the last step and choose the next number.

**47\. Permutations II**: Given a collection of numbers that might contain duplicates, return all possible unique permutations.

The only difference with "46\. Permutations" is that we should skip the duplicates.

**48\. Rotate Image**: Rotate an *n* x *n* matrix by 90 degrees (clockwise).

Array manipulation. "circle" by "circle" from the outermost "circle".

**49\. Group Anagrams**

Hash table. Somehow guarantee that anagrams of the same group result in the same key.

**50. Pow(x, n)**

Math.

**51. N-Queens**

Backtracking and DFS. Just try every possible result.

**53\. Maximum Subarray**: Given an integer array, find the contiguous subarray which has the largest sum.

DP. Let `dp(i)` be the result when the right boundary of the subarray is fixed at index i.

**54. Spiral Matrix**: Given a matrix, return all elements of the matrix in spiral order.

Array manipulation. Similar to "problem 48 Rotate Image".

**55\. Jump Game**: Given an array of integers, `nums[i]` is the maximum jump length at `i`. Starting from the start, determine if you can reach the end.

Greedy. For each element `nums[i]`, the farthest position it can reach is `i + nums[i]`.

**56\. Merge Intervals**

First, sort the Intervals by their left boundaries. Then, use the fast-slow-runners technique to merge the "fast interval" with the "slow interval"(In place).

**57\. Insert Interval**: Given a set of *non-overlapping* intervals, insert a new interval into the intervals (merge if necessary).

Just do what the description asked.

**59. Spiral Matrix II**: Given a positive integer *n*, generate a square matrix filled with elements from 1 to *n*^2 in spiral order.

Similar to "54. Spiral Matrix".

**60\. Permutation Sequence**: Given n and k, the set [1,2,3,...,n] contains a total of n! unique permutations. Return the k-th permutation sequence.

Write down the permutations when n = 4. Observe that there is a pattern for us to determine each digit from MSD to LSD.

**61\. Rotate List**

Count length first or use slow-fast pointers.

**62\. Unique Paths**: Starting from the top-left, how many possible unique paths are there to reach the bottom-right?

DP. `dp[i,j] = dp[i-1,j] + dp[i,j-1]`

**63\. Unique Paths II**: Unique paths with obstacles.

DP. Same as "62\. Unique Paths", except that when `obstacleGrid[i][j] == 1`, `dp[i,j] = 0`.

**64. Minimum Path Sum**: Given a matrix, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

DP. `dp[i,j] = min(dp[i-1,j], dp[i,j-1]) + grid[i][j]`

**69. Sqrt(x)**

Binary search in `[1, Sqrt(int.MaxValue) + 1]`.

**70. Climbing Stairs**: Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top that requires *n* steps?

DP. `dp[i] = dp[i-1] + dp[i-2]`

**71. Simplify Path**: Given an absolute path for a file (Unix-style), simplify it.

The "enter a subdirectory" and "back to parent directory" operations can be represented by a stack.

**72. Edit Distance**: Given two words *word1* and *word2*, find the minimum number of operations required to convert *word1* to *word2*.

DP.  `dp[i,j]` is the answer to `word1[0...i - 1]` and `word2[0...j - 1]`. `dp[i, j]` is the minimum of these three cases:

* Delete a character: `dp[i - 1, j] + 1`
* Insert a character: `dp[i, j - 1] + 1`
* Replace a character: `dp[i - 1, j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1)`

**73. Set Matrix Zeroes**: Given a *m* x *n* matrix, if an element is 0, set its entire row and column to 0. Do it in-place with constant space.

If `matrix[i][j] == 0`, set `matrix[0][j]` and `matrix[i][0]` to zero as a mark to indicate that "row i" and "column j" should be zero. Be careful that `matrix[0][0]` is shared by "row 0" and "column 0".

**74. Search a 2D Matrix**: Integers in each row are sorted from left to right. The first integer of each row is greater than the last integer of the previous row.

Map the matrix to a one-dimensional sorted array and do binary search.

**75. Sort Colors**: Sort an array containing only 0, 1, 2 with a one-pass algorithm using only constant space.

The idea is that we throw "0"s to the start and throw "2"s to the end. When "0" is met, we swap it with the leftmost "1".

**76. Minimum Window Substring**: Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Sliding window. The trick is we can count characters. For a certain character, if it appears in T, increment its count, if it appears in S, decrement its count.

**77. Combinations**: Given two integers *n* and *k*, return all possible combinations of *k* numbers out of 1 ... *n*.

Backtracking.  Write down an example, and keep every row and every column in ascending order and you will find the pattern.

**78. Subsets**: Given a set of distinct integers, return all possible subsets (the power set).

Iterative approach: For each number, add it to each subset in the last step.

Bit manipulation: To get a subset, for each number we choose whether to put it in the subset. Let 1 represent being chosen, and 0 represent not being chosen, we can use an integer to represent a subset.

**79. Word Search**: Given a 2D board and a word, find if the word exists in the grid.

Backtracking.

**81\. Search in Rotated Sorted Array II**: A follow up to "33\. Search in Rotated Sorted Array", where the array may contain duplicates.

First, eliminate duplicates from the beginning. The rest is the same as "33\. Search in Rotated Sorted Array".

**83\. Remove Duplicates from Sorted List**

Fast-slow pointers, similar to "26. Remove Duplicates from Sorted Array".

**84. Largest Rectangle in Histogram**

Use a stack to store ascending heights.

**85. Maximal Rectangle**: Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

Transform the matrix into many sub-problems of "Problem 84. Largest Rectangle in Histogram".

**86. Partition List**: Given a linked list and a value *x*, partition it such that all nodes less than *x* come before nodes greater than or equal to *x*.

Use two pointers to construct the left and right linked lists, and merge them in the end.

**87. Scramble String**: Given two strings *s1* and *s2* of the same length, determine if *s2* is a *scrambled string* of *s1*.

Recursion(divide and conquer). Split s1 and s2 in two by the same length, check if the left parts are equal or contain exactly the same characters, and the right parts too.

**88. Merge Sorted Array**: Given two sorted integer arrays `nums1` and `nums2`, merge `nums2` into `nums1` as one sorted array.

Starting from the end, use the two-pointers technique.

**89. Gray Code**

Find the pattern of how to get `GrayCode(n)` from `GrayCode(n-1)`.

**90. Subsets II**: Given a collection of integers that might contain duplicates, return all possible subsets (the power set).

Similar to the Iterative approach of "78. Subsets", we should sort the `nums` first to avoid duplicate subsets.

**91. Decode Ways**: Given a non-empty string containing only digits, determine the total number of ways to decode it. 'A' maps to 1, 'B' maps to 2,...

The idea is similar to "Problem 70. Climbing Stairs". Let `dp[i]` be the result of `s[0,i]`, `dp[i]` can be derived from `dp[i-1]` and `dp[i-2]`.

**92. Reverse Linked List II**: Reverse a linked list from position *m* to *n*. Do it in one-pass.

Linked list manipulation.

**93. Restore IP Addresses**: Given a string containing only digits, restore it by returning all possible valid IP address combinations.

The idea is similar to "Problem 91. Decode Ways". Let `dp[i]` be the result of `s[0,i]`, `dp[i]` can be derived from `dp[i-1]` and `dp[i-2]` and `dp[i-3]`.

**95. Unique Binary Search Trees II**: Given an integer `n`, generate all structurally unique BST's (binary search trees) that store values 1 ... `n`.

Catalan number problem. For each `i` in `n`, let `i` be the root.
Its left node should be all possible results of  generating trees from `[0, i - 1]`.
Its right node should be all possible results of generating trees from `[i + 1, n]`.

**96. Unique Binary Search Trees**: Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?

Basically the idea is the same as "Problem 95. Unique Binary Search Trees II".

**97. Interleaving String**: Given `s1`, `s2`, `s3`, find whether `s3` is formed by the interleaving of `s1` and `s2`.

DP. Let `dp[i,j]` be whether `s1[0...i-1]` and `s2[0...j-1]` can form the interleaving string of `s3[0...i+j-1]`.

**98. Validate Binary Search Tree**

The inorder traversal of a BST is in ascending order.

**99. Recover Binary Search Tree**: Two elements of a binary search tree (BST) are swapped by mistake. Recover the tree without changing its structure.

The problem can be simplified to "Find two swapped number in a sorted array".

**100. Same Tree**: Given two binary trees, write a function to check if they are the same or not.

Recursion.

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

**226\. Invert Binary Tree**

DFS or BFS, swap the left and right child of every node.

**229\. Majority Element II**: Find all elements in an array that appear more than `array.Length / 3` times.

A mathematical extension of the Boyer-Moore Voting Algorithm of "169. Majority Element".

**239\. Sliding Window Maximum**: Find the max number in a sliding window of an array.

Use a deque to maintain the possible candidates.

**241\. Different Ways to Add Parentheses**: Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators using parentheses.

Recursion(divide and conquer).

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

**326\. Power of Three**: Given an integer, determine if it is a power of three.

Math: A number is a power of three if and only if it is divisible by 3^19 (3^20 > `int.MaxValue`).

**378\. Kth Smallest Element in a Sorted Matrix**: Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Starting from `matrix[0][0]`, add `matrix[i + 1][j]` and `matrix[i][j + 1]` to a min priority queue because they are candidates for the next smallest element.

**402\. Remove K Digits**: Remove k digits from a given number so that the new number is the smallest possible.

We can find a pattern: from the most significant digit to the least significant digit, whenever we meet a digit that is less than the the previous digit, we should discard the previous digit.

**454\. 4Sum II**: Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that `A[i] + B[j] + C[k] + D[l]` is zero.

Store the sum of every combination of (A[i] + B[j]) in a hash table, then check every combination of (C[i] +D[j]).

**493\. Reverse Pairs**: Given an array `nums`, find how many pair(i, j) there are such that `i < j` and `nums[i] > 2*nums[j]`.

Mergesort.








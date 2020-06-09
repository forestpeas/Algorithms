[TOC]

# Hash Table

**1\. Two Sum**: Find two numbers in a given array that add up to a target.

Use a hash table to store complement of each number.

**30. Substring with Concatenation of All Words**: Example: s = "barfoothefoobarman", words = ["foo","bar"],  Output: [0,9]. Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.

Hash table. Because words may contain duplicates, use a dictionary to count every word. The rest is brute-force.

**36. Valid Sudoku**: Determine if a 9x9 Sudoku board is valid.

Brute-force solution using hash sets.

**37. Sudoku Solver**: Write a program to solve a Sudoku puzzle by filling the empty cells.

Backtracking brute-force solution.

**49\. Group Anagrams**

Hash table. Somehow guarantee that anagrams of the same group result in the same key.

**146. LRU Cache**: Design and implement a data structure for Least Recently Used (LRU) cache.

Use `LinkedHashMap` in Java. Or we can maintain a list. Every time an element is accessed, put it to the head of the list. When the cache reaches its capacity, delete the element from the tail of the list. And in order to support the key value mapping, we associate every node with its corresponding key and value, using a hash table.

**460. LFU Cache**: when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.

Similar to "146. LRU Cache". We can associate a count with every item. Each time when an item is accessed, its count is incremented. We need to maintain the minimum count. In order to get the least recently used item when there is a tie, we need to map each count to a set of items, which is similar to "146. LRU Cache".

**187\. Repeated DNA Sequences**: Find all the 10-letter-long substrings that occur more than once.

Find all possible sequences and use a hash table to store the seen sequences.

**202. Happy Number**

Use a hash table to store the seen numbers.

**219\. Contains Duplicate II**: Given `nums` and `k`, find `i` and `j` such that `nums[i] = nums[j]` and `j - i >= k`.

Hash table. Map value to index.

**220\. Contains Duplicate III**: Given `nums` and `k` and `t`, find `i` and `j` such that `nums[j]- nums[i] >= t` and `j - i >= k`.

Sorted set(or ordered map, or balanced binary search tree).

**205. Isomorphic Strings**

Similar problem: **290. Word Pattern**

**217\. Contains Duplicate**: Find if a given array contains any duplicates.

**242. Valid Anagram**: Given two strings `s` and `t` , write a function to determine if `t` is an anagram of `s`.

Use a hash table to count characters. We can allocate a single hash table and let characters from `s` increment the count while characters from `t` decrement the count. If `t` is an anagram of `s`, all counts should be 0.

**347. Top K Frequent Elements**: Given a non-empty array of integers, return the `k` most frequent elements. Your algorithm's time complexity must be better than O(n log n), where n is the array's size.

Buckets! `buckets`'s index is frequency, e.g. `buckets[3]` contains the numbers that appear 3 times.

**349. Intersection of Two Arrays**: Given two arrays, write a function to compute their intersection.

Hash set.

**350. Intersection of Two Arrays II**: Each element in the result should appear as many times as it shows in both arrays. For example,  nums1 = [1,2,2,1], nums2 = [2,2], Output: [2,2].

Use a hash map to count frequency.

**380. Insert Delete GetRandom O(1)**:Design a data structure representing a set that supports `getRandom()` that returns a random element from the set.

Store value-to-index mapping and index-to-value mapping. When removing, we can "fill up the empty position" with the **last** element.

**381. Insert Delete GetRandom O(1) - Duplicates allowed**

Similar to "380. Insert Delete GetRandom O(1)". Although there can be duplicate values, indexes are always unique. So the value-to-index mapping becomes value-to-indexes mapping. A value can map to multiple indexes, which can be held in a `HashSet`.

**392. Is Subsequence**: Given a string `s` and a string `t`, check if `s` is subsequence of `t`.

Follow up: If `t` is fixed, we can pre-process `t` to character-to-indexes mappings.

**454. 4Sum II**: Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that `A[i] + B[j] + C[k] + D[l]` is zero.

Store the sum of every combination of (A[i] + B[j]) in a hash table, then check every combination of (C[i] +D[j]).

**560. Subarray Sum Equals K**: Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

Store the frequencies of "prefix sums" in a hash map. For each sum, check whether (sum - k) exists in the map.

**1189. Maximum Number of Balloons**: Count frequencies of characters.

**1224. Maximum Equal Frequency**: Use 2 maps to store the frequencies of each number, and the "frequencies of frequencies".

**1282. Group the People Given the Group Size They Belong To**

**1396. Design Underground System**: Use a map to store the total travel time and the number of travelers that traveled through this route (route is the key). 

# Stack

**20. Valid Parentheses**: Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

Stack.

**32. Longest Valid Parentheses**

Approach 1: Stack.
Approach 2:  From left to right, count the number of ')' and '(', only when the number of '(' is greater than ')'. When they are equal, update the final result. Repeat the similar process from right to left.

**42. Trapping Rain Water**: Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

Approach 1: Use a stack to track those heights that may be "useful" in the future (that is, we cannot draw any conclusion of trapping water yet).
Approach 2: A very smart one using two pointers. Let `left` start from the start and `right` start from the end. For example, when `height[left] < height[right]` and there is height `maxLeft` which is higher than `height[left]` on the left of `height[left]`, we can draw the conclusion that `maxLeft - height[left]` of water can be trapped, because `height[right]` is always able to hold these water, no matter what values the un-visited heights are.

**71. Simplify Path**: Given an absolute path for a file (Unix-style), simplify it.

The "enter a subdirectory" and "back to parent directory" operations can be represented by a stack.

**84. Largest Rectangle in Histogram**

Use a stack to store ascending heights.

**85. Maximal Rectangle**: Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

Transform the matrix into many sub-problems of "Problem 84. Largest Rectangle in Histogram".

**150. Evaluate Reverse Polish Notation**

Stack.

**155. Min Stack**: Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Use another stack to store the minimum elements.

Similar Problem: **1381. Design a Stack With Increment Operation**: Increment operation increments the bottom `k` elements of the stack by `val`.

`_inc[i]` means "stack[0...i]" should be incremented by `_inc[i]`. We only make sure that `_inc[stack_top]` is accurate by updating `_inc` each time an element is popped.

**225. Implement Stack using Queues**

When pushing, put other elements after the new element.

**232. Implement Queue using Stacks**

Use two stacks.

**341. Flatten Nested List Iterator**: Given a nested list of integers, implement an iterator to flatten it.

Stack.

**394. Decode String**: Examples: s = "3[a]2[bc]", return "aaabcbc". s = "3[a2[c]]", return "accaccacc".

Stack.

**946. Validate Stack Sequences**: Given two sequences `pushed` and `popped` **with distinct values**, return `true` if and only if this could have been the result of a sequence of push and pop operations on an initially empty stack.

Use a stack to simulate the push and pop operations from `pushed` and `popped`. If we can pop, we should do it prior to push because values are distinct and a push will make the previous top value impossible to be popped again.

**1047. Remove All Adjacent Duplicates In String**: Example: "abbaca" => "ca"

Stack.

**1209. Remove All Adjacent Duplicates in String II**: Similar to **1047. Remove All Adjacent Duplicates In String**, except that we are given a `k` and we can only remove `k` adjacent duplicate characters.

Similar to **1047. Remove All Adjacent Duplicates In String**, the item held in the stack is `{char, count}`.

# Two Pointers

**11. Container With Most Water**

"low-high" pointers. Each time we move the shorter line inwards, looking for a probably longer line instead.

**167\. Two Sum II - Input array is sorted**: Find two numbers in a given sorted array that add up to a target.

High-low pointers, similar to "11. Container With Most Water".

**15. 3Sum**: Find all unique triplets in the array which gives the sum of zero.

Sort `nums` first and use the "low-high" pointers technique.
Similar problems: 
**16. 3Sum Closest**
**18. 4Sum**

**21. Merge Two Sorted Lists**

Merge Sort.
Extension: **23. Merge k Sorted Lists**
Priority queue or divide and conquer (merge the first and second list, the 3rd and 4th list...).

**26. Remove Duplicates from Sorted Array**

Fast-slow pointers.
Similar problems:
**80. Remove Duplicates from Sorted Array II**
**82. Remove Duplicates from Sorted List II**
**83. Remove Duplicates from Sorted List**

**27. Remove Element**: Given an array nums and a value val, remove all instances of that value in-place and return the new length.

Fast-slow pointers. Or "high-low" pointers (if the order of elements does not matter).

**88. Merge Sorted Array**: Given two sorted integer arrays `nums1` and `nums2`, merge `nums2` into `nums1` as one sorted array.

Starting from the end, use the two-pointers technique.

**283. Move Zeroes**: Given an array `nums`, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Fast-slow pointers. Move all the non-zero numbers to the beginning, then fill the end with 0.

**905. Sort Array By Parity**: Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.

"High-low" pointers. Elements before `i` is even, elements after `j` is odd.

# Sliding Window

**3\. Longest Substring Without Repeating Characters**

Save each unique character's latest position in a hash table, and maintain a sliding window that contains only unique characters.

**76. Minimum Window Substring**: Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

The trick is that we can count characters. For a certain character, if it appears in T, increment its count, if it appears in S, decrement its count.

**209\. Minimum Size Subarray Sum**: Find the minimal length of a contiguous subarray that satisfies a requirement.

Typical sliding window problem.

**395. Longest Substring with At Least K Repeating Characters**: Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Count the number of unique characters and the number of characters that appears no less than k times in the sliding window.

**413. Arithmetic Slices**

Essentially the problem asks us to find the number of all possible subarrays that are arithmetic progressions and contain at least 3 elements.

**424. Longest Repeating Character Replacement**:  Given a string `s` that consists of only uppercase English letters, you can perform at most `k` operations on that string.  In one operation, you can choose any character of the string and change it to any other uppercase English character.  Find the length of the longest sub-string containing all repeating letters you can get after performing the above operations.

Sliding window. Maintain a sliding window such that the character that appears the maximum number of times in it is greater than its length minus k.

**438. Find All Anagrams in a String**: Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

Sliding window. Count the number of each character in p.

**992. Subarrays with K Different Integers**:  Given an array `A` of positive integers, call a (contiguous, not necessarily distinct) subarray of `A` *good* if the number of different integers in that subarray is exactly `K`.  Return the number of good subarrays of `A`. 

The right bound of the sliding window is always the current number, but the left bound can "slide" within a range `[l1,l2]`, we need to know the value of  `l2 - l1`.
Similar problems:
**1248. Count Number of Nice Subarrays**: Given an array of integers nums and an integer k. A subarray is called nice if there are k odd numbers on it.
**1358. Number of Substrings Containing All Three Characters**: Given a string `s` consisting only of characters a, b and c. Return the number of substrings containing at least one occurrence of all these characters a, b and c.

**1208. Get Equal Substrings Within Budget**: Find the max length of a sub-array such that the sum of its elements is no greater than `maxCost`.

The sliding window never needs to shrink.

**1234. Replace the Substring for Balanced String**:  You are given a string containing only 4 kinds of characters 'Q', 'W', 'E' and 'R'. A string is said to be balanced if each of its characters appears n/4 times where n is the length of the string. Return the minimum length of the substring that can be replaced with any other string of the same length to make the original string s balanced.

Count the number of characters that appear more than n/4 times, and maintain certain amounts of these characters in the sliding window.

# Binary Search

**4. Median of Two Sorted Arrays**: Find the median of the two sorted arrays.

Find a "split line" that splits `nums1` and `nums2` such that all the numbers on the left are less than those on the right.

**29. Divide Two Integers**: Given two integers `dividend` and `divisor`, divide two integers without using multiplication, division and mod operator.

Check whether `divisor` * 2, `divisor` * 4, `divisor` * 8, ... (shift operations) are greater than `dividend`. Do the same to the remainder.

**33\. Search in Rotated Sorted Array**

Step 1\. Use Binary search to find the "rotated point" - the index of the smallest value in the array.
Step 2\. Binary search with the appropriate offset.
Similar problem: **153\. Find Minimum in Rotated Sorted Array**: Same as the first step.

**81\. Search in Rotated Sorted Array II**: A follow up to "33\. Search in Rotated Sorted Array", where the array may contain duplicates.

First, eliminate duplicates from the beginning. The rest is the same as **33. Search in Rotated Sorted Array**.
Similar problem: **154\. Find Minimum in Rotated Sorted Array II**: Same as the first step.

**34\. Find First and Last Position of Element in Sorted Array**

2 binary searches with special handling when `nums[mid] == target`.

**35\. Search Insert Position**

Binary search.

**69. Sqrt(x)**

Binary search in `[1, Sqrt(int.MaxValue)]`.
Similar problem: **367. Valid Perfect Square**

**74. Search a 2D Matrix**: Integers in each row are sorted from left to right. The first integer of each row is greater than the last integer of the previous row.

Map the matrix to a one-dimensional sorted array and do binary search.

**240. Search a 2D Matrix II**: Write an efficient algorithm that searches for a value in an m x n matrix. Integers in each row are sorted in ascending from left to right. Integers in each column are sorted in ascending from top to bottom.

Search from the bottom-left point, rule out one row or one column each time (Not binary search, but relating to **74. Search a 2D Matrix**).

**162. Find Peak Element**: A peak element is an element that is greater than its neighbors. Given an input array nums, where nums[i] ≠ nums[i+1], find a peak element and return its index.

Binary search. Gradually narrow down the range according to `mid`'s "derivative", "hi" and "lo" will eventually converge to a peak element.

**875. Koko Eating Bananas**

When k (the speed) increases, h (time spent) decreases, and vice versa.

**1287. Element Appearing More Than 25% In Sorted Array**: Given an integer array **sorted** in non-decreasing order, there is exactly one integer in the array that occurs more than 25% of the time.

Binary search the "upper bound" and "lower bound" of "critical points": `arr[n*25%]`, `arr[n*50%]`, `arr[n*75%]`.

**1283. Find the Smallest Divisor Given a Threshold**
**1292. Maximum Side Length of a Square with Sum Less than or Equal to Threshold**: Also needs to calculate "prefix sums".
**1300. Sum of Mutated Array Closest to Target**

# Divide and Conquer

**87. Scramble String**: Given two strings *s1* and *s2* of the same length, determine if *s2* is a *scrambled string* of *s1*.

Recursion (divide and conquer). Split s1 and s2 in two by the same length, check if the left parts are equal or contain exactly the same characters, and the right parts too.

**148\. Sort List**: Sort a linked list in O(n log n) time using constant space complexity.

Merge sort.

**241\. Different Ways to Add Parentheses**: Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators using parentheses.

Recursion(divide and conquer).

**493\. Reverse Pairs**: Given an array `nums`, find how many pair(i, j) there are such that `i < j` and `nums[i] > 2*nums[j]`.

Merge sort.

**315\. Count of Smaller Numbers After Self**: Given an integer array `nums`, return an array `counts` where `counts[i]` is the number of smaller elements to the right of `nums[i]`.

Merge sort. Similar to "493\. Reverse Pairs".

**1274. Number of Ships in a Rectangle**

**1382. Balance a Binary Search Tree**: Given a binary search tree, return a balanced binary search tree with the same node values.

Convert the BST to an ascending array first and then construct the balanced tree recursively.

# Backtracking and/or DFS (Recursion)

**39. Combination Sum**: Given a set of candidate numbers (`candidates`) (without duplicates) and a target number (`target`), find all unique combinations in `candidates` where the candidate numbers sums to `target`. The same repeated number may be chosen from `candidates` unlimited number of times.

Backtracking. Sort the array, and choose small numbers first.
Similar problems: 
**40. Combination Sum II**: Each number in `candidates` may only be used **once** in the combination.
**216. Combination Sum III**: Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

**46\. Permutations**: Given a collection of distinct integers, return all possible permutations.

Each time we choose an unchosen number. When all numbers have been chosen, backtrack to the last step and choose the next number.

**47\. Permutations II**: Given a collection of numbers that might contain duplicates, return all possible unique permutations.

The only difference with "46\. Permutations" is that we should skip the duplicates.

**77. Combinations**: Given two integers *n* and *k*, return all possible combinations of *k* numbers out of 1 ... *n*.

Backtracking.  Write down an example, and keep every row and every column in ascending order and you will find the pattern.
Similar problems: **1286. Iterator for Combination**.

**78. Subsets**: Given a set of distinct integers, return all possible subsets (the power set).

Iterative approach: For each number, add it to each subset in the last step.

Bit manipulation: To get a subset, for each number we choose whether to put it in the subset. Let 1 represent being chosen, and 0 represent not being chosen, we can use an integer to represent a subset.

**90. Subsets II**: Given a collection of integers that might contain duplicates, return all possible subsets (the power set).

Similar to the Iterative approach of "78. Subsets", we should sort the `nums` first to avoid duplicate subsets.

**51. N-Queens**

Backtracking and DFS. Just try every possible result.

**131. Palindrome Partitioning**: Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

Recursion  with memoization. Check every possible partitioning.

**139\. Word Break**: Determine if a given string can be segmented into several words in a given dictionary.

Brute-force search with memoization, can be transformed to bottom up  DP solution.
Similar problems:
**140\. Word Break II**: Return all possible segmented results from "139. Word Break".

**279. Perfect Squares**: Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

Recursion + Memoization. Choose larger square numbers prior to smaller ones.

**301. Remove Invalid Parentheses**: Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

To check whether a string is valid, count the number of left and right parentheses from left to right and from right to left, or use a stack. Backtrack to find all possible results. The tricky part is how to avoid duplicates.
Similar problem: **1249. Minimum Remove to Make Valid Parentheses**

**397. Integer Replacement**: Given a positive integer n and you can do operations as follow: If n is even, replace n with n/2. If n is odd, you can replace n with either n + 1 or n - 1. What is the minimum number of replacements needed for n to become 1?

Recursion+Memoization+Greedy.

**403. Frog Jump**: Given an array of positions, each time we can jump k - 1, k, or k + 1, here k is the last jump.  Determine whether we can reach the end.

Recursion + Memoization.

**1125. Smallest Sufficient Team**

An NP Complete problem: https://en.wikipedia.org/wiki/Set_cover_problem. Every skill can be represented as an integer. Every skill combination can also be represented as an integer. Then brute-force: For each person, we combine this person with all the skill combinations we already had and see if the new combination covers more skills or if it needs less people.

**1255. Maximum Score Words Formed by Letters**: Given a list of words, list of  single letters (might be repeating) and score of every character. Return the maximum score of any valid set of words formed by using the given letters.

Try all possible sets of words. For each word[i], we can pick this word or not.

**1306. Jump Game III**: Check if you can reach to any index with value 0.

BFS or DFS.

**1320. Minimum Distance to Type a Word Using Two Fingers**

0 - 25 represents A - Z respectively. 26 represents the initial state. Each time we have two choices, either use the left or right finger to type the letter. Top-down recursion or bottom-up DP.

# Dynamic Programming

## String or Array

Consider a part of the array such as `arr[0~i]` or `arr[i~j]`

**5. Longest Palindromic Substring**

Let `dp[i,j]` be whether `s[i]`~`s[j]` is a palindrome. 
`dp[i,j] = (s[i] == s[j]) && (dp[i + 1, j - 1])`
Similar problem: **647. Palindromic Substrings**

**132. Palindrome Partitioning II**: Given a string s, partition s such that every substring of the partition is a palindrome. Return the minimum cuts needed for a palindrome partitioning of s.

Similar to the DP solution of "Problem 5. Longest Palindromic Substring". Let `isPalindrome[j, i]` be whether s[j...i] is a palindrome, and `cut[i]` be the minimum cuts for `s[0...i]`.

**516. Longest Palindromic Subsequence**:  Given a string s, find the longest palindromic subsequence's length in s. 

Similar to the DP solution of "5. Longest Palindromic Substring".
Similar questions: **1312. Minimum Insertion Steps to Make a String Palindrome**

**10\. Regular Expression Matching**: `'.'` matches any single character, `'*'` Matches zero or more of the preceding element.

Let `dp[i,j]` be whether `s[0~i]` matches `p[0~j]`. Note that a `'*'`either matches empty or "swallows" one more character.

**44\. Wildcard Matching**: `'?'` matches any single character, `'*'` Matches any sequence of characters.

Similar to **10\. Regular Expression Matching**. A `'*'`either matches empty or "swallows" one more character.
Backtracking + Greedy: Every time we go into a dead end, we come back to the last `'*'` to make it "swallow" one more character.

**72. Edit Distance**: Given two words *word1* and *word2*, find the minimum number of operations required to convert *word1* to *word2*.

DP.  `dp[i,j]` is the answer to `word1[0...i - 1]` and `word2[0...j - 1]`. `dp[i, j]` is the minimum of these three cases:

* Delete a character: `dp[i - 1, j] + 1`
* Insert a character: `dp[i, j - 1] + 1`
* Replace a character: `dp[i - 1, j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1)`

**97. Interleaving String**: Given `s1`, `s2`, `s3`, find whether `s3` is formed by the interleaving of `s1` and `s2`.

DP. Let `dp[i,j]` be whether `s1[0...i-1]` and `s2[0...j-1]` can form the interleaving string of `s3[0...i+j-1]`.

**115. Distinct Subsequences**: For example, Input: S = "rabbbit", T = "rabbit". **rabb**b**it**, **ra**b**bbit**, **rab**b**bit**.

DP. Let `dp[i,j]` be the answer of `T[0...i]` and `S[0...j]`.

**1246. Palindrome Removal**: Given an integer array `arr`, in one move you can select a palindromic subarray and remove that subarray from the given array. Return the minimum number of moves needed to remove all numbers from the array.

Let `dp[j, i]` be the answer to arr[j...i] and consider all possible cases. Time complexity is O(n^3).

**1278. Palindrome Partitioning III**: Divide `s` into `k` non-empty disjoint substrings such that each substring is palindrome. Return the minimal number of characters that you need to change to divide the string.

`dp[m,i]` is the answer of `s[0...i]` when `k = m`.  For each substring, check all possibilities of dividing.

**1289. Minimum Falling Path Sum II**: Given a square grid of integers arr, a falling path with non-zero shifts is a choice of exactly one element from each row of arr, such that no two elements chosen in adjacent rows are in the same column. Return the minimum sum of a falling path with non-zero shifts.

DP. `dp[j]` is the minimum sum of a falling path with `arr[i][j]` being the chosen element from row `i`.

**1301. Number of Paths with Max Score**

`maxSums[i,j]` is the maximum score so far, `pathNums[i,j]` is the number of paths with the maximum score.

**1395. Count Number of Teams**

`dp_smaller[i]` is the number of numbers smaller than `rating[i]` on the right of `i`.
`dp_larger[i]` is the number of numbers larger than `rating[i]` on the right of `i`.

## Combination and Permutation

**17. Letter Combinations of a Phone Number**

For each digit, add each of its mapping to all the current combinations (cartesian product).

**70. Climbing Stairs**: Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top that requires *n* steps?

DP. `dp[i] = dp[i-1] + dp[i-2]`

**91. Decode Ways**: Given a non-empty string containing only digits, determine the total number of ways to decode it. 'A' maps to 1, 'B' maps to 2,...

The idea is similar to "Problem 70. Climbing Stairs". Let `dp[i]` be the result of `s[0,i]`, `dp[i]` can be derived from `dp[i-1]` and `dp[i-2]`.

**93. Restore IP Addresses**: Given a string containing only digits, restore it by returning all possible valid IP address combinations.

The idea is similar to "Problem 91. Decode Ways". Let `dp[i]` be the result of `s[0,i]`, `dp[i]` can be derived from `dp[i-1]` and `dp[i-2]` and `dp[i-3]`.

**118. Pascal's Triangle**: Given a non-negative integer `numRows`, generate the first `numRows` rows of Pascal's triangle.

DP. Generate every row from its previous row.

**119. Pascal's Triangle II**: Return the kth index row of the Pascal's triangle. Could you optimize your algorithm to use only O(k) extra space?

We can only allocate a single array of length k and reuse it, for example, when k = 5:
[0,0,0,0,1]
[0,0,0,1,1]
[0,0,1,2,1]
[0,1,3,3,1]
[1,4,6,4,1]

**1220. Count Vowels Permutation**

`dp[i]['a']` means the number of possible strings of length `i` that ends with an `'a'`.

**1223. Dice Roll Simulation**: Exclude the ineligible cases.

**1259. Handshakes That Don't Cross**

DP. `dp[n] = dp[0] * dp[n-2] + dp[2] * dp[n-4] + dp[4] * dp[n-6] + ... + dp[n-2] * dp[0]`

**1269. Number of Ways to Stay in the Same Place After Some Steps**: You have a pointer at index 0 in an array of size arrLen. At each step, you can move 1 position to the left, 1 position to the right in the array or stay in the same place. Given two integers `steps` and `arrLen`, return the number of ways such that your pointer still at index 0 after exactly `steps` steps.

DP. `dp[i,j]` is the number of ways to reach `arr[j]` after i steps.

**1359. Count All Valid Pickup and Delivery Options**: Given `n` pair of `(P,D)`, `Pn` must be on the left of `Dn`. Count all valid possible sequences. Example: n = 2, answer is 6. `(P1,P2,D1,D2), (P1,P2,D2,D1), (P1,D1,P2,D2), (P2,P1,D1,D2), (P2,P1,D2,D1) and (P2,D2,P1,D1)`

`F(n) = F(n-1)*(2n-1)*n`. Insert the new pair into gaps in the sequence.

## Paths or regions in a 2-D array

**62\. Unique Paths**: Starting from the top-left, how many possible unique paths are there to reach the bottom-right?

`dp[i,j] = dp[i-1,j] + dp[i,j-1]`

**63\. Unique Paths II**: Unique paths with obstacles.

DP. Same as "62\. Unique Paths", except that when `obstacleGrid[i][j] == 1`, `dp[i,j] = 0`.

**174. Dungeon Game**

Similar to "62. Unique Paths" (`dp[i,j] = F(dp[i-1,j], dp[i,j-1])`) but requires a very smart thinking to start from bottom-right (`dp[i,j] = F(dp[i+1,j], dp[i,j+1])`).

**64. Minimum Path Sum**: Given a matrix, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

DP. `dp[i,j] = min(dp[i-1,j], dp[i,j-1]) + grid[i][j]`

**221\. Maximal Square**: Given a 2-D matrix filled with only 0 and 1, find the largest square containing only 1.

DP. `dp(i,j)` represents the side length of the maximum square whose **bottom right corner** is the cell with index `(i,j)` in the original matrix: 

`dp(i, j) = min(dp(i − 1, j - 1), dp(i, j − 1), dp(i, j − 1)) + 1.`
Similar problem: **1277. Count Square Submatrices with All Ones**: Given a m * n matrix of ones and zeros, return how many square submatrices have all ones.

## Techniques

Restrict `dp[i]` being the answer that ends with something.
For each `i`, we can decide whether or not do something.

**53\. Maximum Subarray**: Given an integer array, find the contiguous subarray which has the largest sum.

Let `dp[i]` be the result when the right boundary of the subarray is fixed at index i, So `dp[i] = max(nums[i], nums[i]+dp[i-1]`.

**152. Maximum Product Subarray**: Given an integer array `nums`, find the contiguous subarray within an array (containing at least one number) which has the largest product.

DP. Similar to "Problem 53. Maximum Subarray". `dp[i]` contains the max product and min product of a subarray whose right boundary is fixed at index i.

**120. Triangle**: Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.

From the first row to the last row, or from the last row to the first row. `dp[i]` is the minimum sum of a path that ends with `triangle[row][i]`.

**122. Best Time to Buy and Sell Stock II**: Find the maximum profit. You may complete as many transactions as  you like.

There is a accumulative approach that accumulates each difference of an ascending pair to get the final result.

**123. Best Time to Buy and Sell Stock III**: Find the maximum profit. You may complete at most two transactions.

For each day, consider how we can get the following values?

1. The max profit so far of buying and selling only once.
2. The lowest buy price of the second buy, by spending the profit from our first trade.
3. The max profit so far of buying and selling twice.

**188. Best Time to Buy and Sell Stock IV**: Say you have an array for which the i-th element is the price of a given stock on day i. Design an algorithm to find the maximum profit. You may complete at most k transactions.

Generalization of **123. Best Time to Buy and Sell Stock III**.`dp[i, j]` = the maximum profit from at most `i` transactions using `prices[0..j]`. Either do nothing(not buy) or sell on day j (so we need to know which day we bought last time such that we can gain the maximum profit) .
`dp[i, j] = max(dp[i, j - 1], prices[j] + max(-prices[t] + dp[i - 1, t - 1])), 0 <= t < j`

**309. Best Time to Buy and Sell Stock with Cooldown**: Cooldown 1 day.

DP. Let `buy[i]` be the max profit that ends with buying on a day from range [0...i]. Let `sell[i]` means the max profit that ends with selling on a day from range [0...i].

**198\. House Robber**: Find the maximum sum of non-adjacent numbers in a given array.

Either rob or not rob at i: `dp(i) = max(dp(i - 1), nums[i] + dp(i - 2))`

**213\. House Robber II**: Same as "198. House Robber", except that the first and last number cannot be chosen both.

Maximum of two sub-problems of "198. House Robber".

**337. House Robber III**

DFS a tree. The idea is similar to DP. If we rob at `root`, we can't rob `root.left` and `root.right`.

**312. Burst Balloons**: Given `n` balloons, indexed from `0` to `n-1`. Each balloon is painted with a number on it represented by array `nums`. You are asked to burst all the balloons. If the you burst balloon `i` you will get `nums[left] * nums[i] * nums[right]` coins. Here `left` and `right` are adjacent indices of `i`. After the burst, the `left` and `right` then becomes adjacent. Find the maximum coins you can collect by bursting the balloons wisely.

DP. `dp[l, r]` is the answer of bursting all the balloons in (l, r). If the balloon at index i is the **last** balloon to burst(l < i < r), we get `nums[l] * nums[i] * nums[r]` coins.

`dp(l, r) = max(nums[l] * nums[i] * nums[r] + dp[l, i] + dp[i, r]), l < i < r`

**322. Coin Change**: You are given coins of different denominations and a total amount of money *amount*. Write a function to compute the fewest number of coins that you need to make up that amount.

DP. `dp(S)` is the problem answer to an amount of S. 

`dp(S) = min(dp(S - coins[i]) + 1, 0 <= i < coins.Length, S - coins[i] >= 0`

**368. Largest Divisible Subset**: Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj) of elements in this subset satisfies: Si % Sj = 0 or Sj % Si = 0.

Sort the array first and find the pattern.

**416. Partition Equal Subset Sum**: Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

The problem is equal to finding if there is a subset such that the sum of elements in it is "sum of array" / 2. Then we can use DP to solve it. Let `dp[i, j]` be whether there can be a sum `j` from a certain subset in `nums[0...i]`. For each `nums[i]`, we check whether we need to include it to achieve `j`. Somewhat like the knapsack problem.
`dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i]]`

**518. Coin Change 2**: You are given coins of different denominations and a total amount of money. Write a function to compute the number of combinations that make up that amount. You may assume that you have infinite number of each kind of coin.

DP. `dp[i, j]` means how many combinations there are, where amount = j and we can only use coins[0...i]. For each `coins[i]`, we have two choices: 1\. Not using `coins[i]`, we have `dp[i - 1, j]` combinations. 2. Use one `coins[i]` first, we have `dp[i, j - coins[i]]` combinations. These two events do not overlap with each other, so we can just add them, and all possibilities are included in these two events. Can be compared with "416. Partition Equal Subset Sum" because they can all be categorized to the Knapsack problem.
`dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i]]`

**377. Combination Sum IV**: Permutation version of "518. Coin Change 2".

Recursion with memoization is more intuitive. DP: Similar to the recursive solution and "518. Coin Change 2". let `dp[j]` be the answer when target sum is j, calculate `dp[1], dp[2], dp[3],...`, in each iteration we check all the numbers in `nums`.

**494. Target Sum**

DP. Similar to "416. Partition Equal Subset Sum". `dp[i, j]` means the ways to achieve a sum`j` using only `nums[0...i]`. 
`dp[i, j] = dp[i - 1, j - nums[i]] + dp[i - 1, j + nums[i]]`

**887. Super Egg Drop**

DP. Given k eggs and m moves, `dp[m,k]` is the maximum floor that we can know with certainty what F (the "critical" floor) is.

**1218. Longest Arithmetic Subsequence of Given Difference**: Given an integer array `arr` and an integer `difference`, return the length of the longest subsequence in `arr` which is an arithmetic sequence such that the difference between adjacent elements in the subsequence equals `difference`.

For each `num` in `arr`, `map[num]` is the length of the longest subsequence that ends with `num`.

**1235. Maximum Profit in Job Scheduling**

1\. Sort by `startTime`.
2\. `dp[i]` is the max profit starting from jobs[i] to the end.
3\. From right to left, binary search `job[i].endTime` in the sorted `startTime` array in order to find the first non-overlapping `job[j]` with `job[i]`.

**1262. Greatest Sum Divisible by Three**:  Given an array `nums` of integers, we need to find the maximum possible sum of elements of the array such that it is divisible by three. 

DP. `dp[i]` is the maximum possible sum so far such that `dp[i] % 3 == i`.

**1388. Pizza With 3n Slices**: Given an integer array with size 3N, select N integers with maximum sum and any selected integers are not next to each other in the array (the first and last element is also considered next to each other).

Knapsack problem, also similar to "213. House Robber II".
`dp[i,j] = max(dp[i-1, j], slices[i] + dp[i-2, j-1])`

## Catalan Number

**22. Generate Parentheses**: Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

The problem is equal to this problem: If 1...n is the sequence of push operations on an initially empty stack. How many different sequences of pop operations are there?  A push is a "(", and a pop is a ")". The root node in BST is the counterpart of the **last** element that popped out of the stack.

**95. Unique Binary Search Trees II**: Given an integer `n`, generate all structurally unique BST's (binary search trees) that store values 1 ... `n`.

For each `i` in `n`, let `i` be the root.
Its left node should be all possible results of  generating trees from `[0, i - 1]`.
Its right node should be all possible results of generating trees from `[i + 1, n]`.
Similar problem: **96. Unique Binary Search Trees**: Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?

**894. All Possible Full Binary Trees**:  A full binary tree is a binary tree where each node has exactly 0 or 2 children. Return a list of all possible full binary trees with N nodes.

Catalan number problem. For each node in the non-leaf nodes, let node be the root.

## Minimax

**877. Stone Game**

Approach 1: DP or DFS with memoization. Try all possible cases.
Approach 2: Alex (who gets to choose first) always wins.

# Greedy

**45\. Jump Game II**: Given an array of integers, `nums[i]` is the maximum jump length at `i`. Return the minimum number of jumps from start to end.

Greedy, also implicit BFS. The first level only contains `nums[0]`. For each element `nums[i]` in the current level, add `nums[i + nums[i]]` to the next level.
The following problems are equivalent or can be converted to this problem:
**1024. Video Stitching**
**1326. Minimum Number of Taps to Open to Water a Garden**

**55\. Jump Game**: Given an array of integers, `nums[i]` is the maximum jump length at `i`. Starting from the start, determine if you can reach the end.

Greedy. For each element `nums[i]`, the farthest position it can reach is `i + nums[i]`.

**1247. Minimum Swaps to Make Strings Equal**

Try to pair ("xx", "yy") as much as possible, because it only needs 1 swap.

**1253. Reconstruct a 2-Row Binary Matrix**

Always add "1" to the row with more "available seats", because if later the `colsums` are 0 or 2, upper and lower row will be increasing at equal speed.

**1368. Minimum Cost to Make at Least One Valid Path in a Grid**

Always choose the neighbor with 0 cost first. Another approach: represent the grid as a directed weighted graph and use Dijkstra's algorithm.

**1402. Reducing Dishes**: Given an int array `nums` where the numbers can be negative, find the largest `a1*1 + a2*2 + a3*3 + ... + an*n`, where `a1...an` can be chosen freely from `nums`.

Sort first. `a1*2 + a2*3 + a3*4 = a1*1 + a2*2 + a3*3 + (a1+a2+a3)`

**1405. Longest Happy String**: Given `a`, `b`, `c`, find the longest string `s` such that `s`  contains at most `a` occurrences of the letter 'a', at most `b` occurrences of the letter 'b' and at most `c` occurrences of the letter 'c', and does not have any of the strings 'aaa', 'bbb' or 'ccc'.

Find the maximum number, then we need to "fill the slots" with the other two minor number of letters.
Easier version: **984. String Without AAA or BBB**

# Tree

Traversal: 
DFS or stack:
**94. Binary Tree Inorder Traversal**
**144. Binary Tree Preorder Traversal**
**145. Binary Tree Postorder Traversal**
BFS:
**102. Binary Tree Level Order Traversal**
**107. Binary Tree Level Order Traversal II**

Others:

**98. Validate Binary Search Tree**

The inorder traversal of a BST is in ascending order.
Similar problems:
**173. Binary Search Tree Iterator**
**230. Kth Smallest Element in a BST**

**99. Recover Binary Search Tree**: Two elements of a binary search tree (BST) are swapped by mistake. Recover the tree without changing its structure.

The problem can be simplified to "Find two swapped number in a sorted array".

**100. Same Tree**: Given two binary trees, write a function to check if they are the same or not.

DFS.

**101. Symmetric Tree**: Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

DFS is simple. BFS: Enqueue the left and right children twice in a specific order: left,right,right,left. In this way, if the tree is symmetric, two consecutive nodes in the queue are equal.

**104. Maximum Depth of Binary Tree**

DFS or BFS.

**105. Construct Binary Tree from Preorder and Inorder Traversal**

The first element in preorder must be the root. Find this root in inorder and cut inorder by this root.

**106. Construct Binary Tree from Inorder and Postorder Traversal**

The last element in postorder must be the root. Find this root in inorder and cut inorder by this root.

**108. Convert Sorted Array to Binary Search Tree**: Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

DFS. Let the element in the middle be the root, so that the left and right parts are same in height.

**109. Convert Sorted List to Binary Search Tree**: Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

There is a very subtle solution. Basically it's very similar to "Problem 108. Convert Sorted Array to Binary Search Tree". We only have to make sure that when we are processing on the recursive stack, we can visit each node in the linked list sequentially to construct the tree.

**110. Balanced Binary Tree**: Given a binary tree, determine if it is height-balanced.

DFS. Check the height of every subtree.

**111. Minimum Depth of Binary Tree**: Given a binary tree, find its minimum depth.

DFS or BFS.

**112. Path Sum**: Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

DFS. Similar to "Problem 111. Minimum Depth of Binary Tree".

**113. Path Sum II**:  Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

DFS and backtracking.

**437. Path Sum III**: You are given a binary tree in which each node contains an integer value. Find the number of paths that sum to a given value. The path does not need to start or end at the root or a leaf, but it must go downwards.

Save the "prefix sum" of the path from root to each node.

**114. Flatten Binary Tree to Linked List**: Given a binary tree, flatten it to a linked list in-place.

DFS.

**116. Populating Next Right Pointers in Each Node**:  You are given a perfect binary tree where all leaves are on the same level.

For each node, for example, root, set `next` like this:
![43](.\pics\116.jpg)

**117. Populating Next Right Pointers in Each Node II**: You are given a binary tree.

Level by level (row by row). Each level can be generated based on its previous level. Use a dummy head to save the first node of each level.

**124. Binary Tree Maximum Path Sum**: Given a non-empty binary tree, find the maximum path sum.

For each node, recursively calculate the maximum path sum of paths that must **end or start** with this node.

**127. Word Ladder**: Given two words (*beginWord* and *endWord*), and a dictionary's word list, find the length of shortest transformation sequence from *beginWord* to *endWord*, such that: 1\. Only one letter can be changed at a time. 2\. Each transformed word must exist in the word list. Note that *beginWord* is *not* a transformed word. Example: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]. one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog".

Think of *beginWord* as the root of a tree, and all the words that differ only one letter from it are its children nodes. The problem is like BFS of a tree.

**129. Sum Root to Leaf Numbers**: Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number. Find the total sum of all root-to-leaf numbers.

DFS.

**199\. Binary Tree Right Side View**: Return the "right outline" of a binary tree.

DFS or BFS, only add current node to result under certain circumstances:
DFS: When the current depth is deeper than the maximum depth.
BFS: When the current node is the last node of the current level.

**222\. Count Complete Tree Nodes**: Given a complete binary tree, count the number of nodes.

Binary search, or recursively get the height of the tree and the height of left and right subtrees.

**226\. Invert Binary Tree**

DFS or BFS, swap the left and right child of every node.

**235. Lowest Common Ancestor of a Binary Search Tree**: Given two tree nodes `p` and `q` from a BST, find their lowest common ancestor.

Starting from root, let `p` and `q` compare with each node to decide which branch they should take next. When they are about to separate, they are at their lowest common ancestor.

**236. Lowest Common Ancestor of a Binary Tree**: Given two tree nodes `p` and `q` from a binary tree, find their lowest common ancestor.

Depth first search the tree, If we find `p` or `q`, just stop going deeper and return the current node. Compare the nodes returned from left and right subtrees.
Similar problem: **1257. Smallest Common Region**: Find the Lowest Common Ancestor of a Tree.

**257. Binary Tree Paths**: DFS

**297. Serialize and Deserialize Binary Tree**

Use preorder traversal so that when deserializing, we can "new" the root first. Use a special character such as '#' to mark `null` nodes.

**331. Verify Preorder Serialization of a Binary Tree**

Approach 1: Similar to the deserialization part of "297. Serialize and Deserialize Binary Tree".
Approach 2: Count outdegrees and indegrees.

**404. Sum of Left Leaves**

DFS.

**429. N-ary Tree Level Order Traversal**

BFS.

**543. Diameter of Binary Tree**: Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the **longest** path between any two nodes in a tree. This path may or may not pass through the root.

DFS the tree and check every node's left subtree's depth + its right subtree's depth.

**572. Subtree of Another Tree**: Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s.

Simple recursive solution based on "Problem 100. Same Tree".

**617. Merge Two Binary Trees**

DFS.

**655. Print Binary Tree**

BFS. Be careful of corner cases such as an odd number being divided by 2.

**1261. Find Elements in a Contaminated Binary Tree**

Recursion.

**1273. Delete Tree Nodes**: Given a tree, Remove every subtree whose sum of values of nodes is zero. After doing so, return the number of nodes remaining in the tree.

From leaves to the root, check each subtree's sum.

**1302. Deepest Leaves Sum**: Given a binary tree, return the sum of values of its deepest leaves.

DFS or BFS.

**1315. Sum of Nodes with Even-Valued Grandparent**

DFS.

**1325. Delete Leaves With a Given Value**

DFS.

**1361. Validate Binary Tree Nodes**: You have `n` binary tree nodes numbered from `0` to `n - 1` where node `i` has two children `leftChild[i]` and `rightChild[i]`, return `true` if and only if **all** the given nodes form **exactly one** valid binary tree.

Find root and DFS. Be aware of all invalid cases.

**1367. Linked List in Binary Tree**: Given a linked list and a binary tree, return whether the binary tree "contains" the linked list.

Brute-force DFS.

**1372. Longest ZigZag Path in a Binary Tree**

DFS. Maintain a variable for direction (left or right) and the maximum zigzag length.

**1373. Maximum Sum BST in Binary Tree**

Dfs and return a tuple of `(bool isBST, int min, int max, int sum)` for each tree node.

**1376. Time Needed to Inform All Employees**

DFS. Note that the actions of subordinates can be performed simultaneously. So the total time of a node should be the maximum time spent by one of its child node.

**1377. Frog Position After T Seconds**

Each node corresponds to a time and possibility: DFS(node, time, possibility).

**1379. Find a Corresponding Node of a Binary Tree in a Clone of That Tree**

Dfs both the original tree and the cloned tree simultaneously.

# Graph

**79. Word Search**: Given a 2D board and a word, find if the word exists in the grid.

DFS + Backtracking. Search all possible paths (brute-force).
Similar questions: **1219. Path with Maximum Gold**

**212. Word Search II**: Given a 2D board and a list of words from the dictionary, find all words in the board.

First we build a trie from the given words. Then everything goes the same as "79. Word Search", except that we can stop going deeper if the current path does not match any word's prefix.

**130. Surrounded Regions**: Given a 2D board containing 'X' and 'O' (the letter O), flip all 'O's into 'X's in all regions of 'O's surrounded by 'X'. Surrounded regions shouldn’t be on the border.

BFS starting from borders. Mark the 'O's with a marker such as '#'.

**417. Pacific Atlantic Water Flow**

Similar to "130. Surrounded Regions". We need to search from borders, and we need to "go against the current" (逆流而上).

**200. Number of Islands**: Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.

BFS. Mark the visited grids using another "marker character". Similar to "Problem 130. Surrounded Regions".
Similar problem: **1254. Number of Closed Islands**: DFS.

**133. Clone Graph**: Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph. Each node in the graph contains a val (int) and a list (List[Node]) of its neighbors.

BFS. Use a dictionary to map old node to new node.

**207. Course Schedule**

This problem is equivalent to finding if a cycle exists in a directed graph.

**210. Course Schedule II**

Topological Sort.

**310. Minimum Height Trees**:  For an undirected graph with tree characteristics, we can choose any node as the root. The result graph is then a rooted tree. Among all possible rooted trees, those with minimum height are called minimum height trees (MHTs). Given such a graph, write a function to find all the MHTs and return a list of their root labels. 

A minimum height tree's root must be the longest path's middle node. BFS: In every round, we remove the leaves (vertices with only 1 neighbor), until there are only 1 or 2 vertices. DFS: Start at any node A and traverse the tree to find the furthest node from it, let's call it B. Having found the furthest node B, traverse the tree from B to find the furthest node from it, let's call it C. The distance between B and C is the tree diameter.
Similar problem: **1245. Tree Diameter: Given an undirected tree, return its diameter: the number of edges in a longest path in that tree.**

**329. Longest Increasing Path in a Matrix**: Given an integer matrix, find the length of the longest increasing path.

Approach 1: DFS from each element, optimized with memoization.
Approach 2: Treat the matrix as a directed graph, with edges pointing from smaller value to larger value. Use BFS topological sort based on in-degree counting. Count the number of levels.

**332. Reconstruct Itinerary**

Eulerian path. Choose a path (edge) and delete this path so that we won't go through the same path again. We can use a priority queue to hold the neighbors of each vertex. DFS until we meet a dead end and the path must be the "last part" of the final result.

**399. Evaluate Division**

Find a path between two nodes in a graph.

**547. Friend Circles**

Find connected components in a undirected graph.

**909. Snakes and Ladders**

BFS.

**994. Rotting Oranges**

BFS.

**1210. Minimum Moves to Reach Target with Rotations**

BFS. Search state is the snake's position.

**1202. Smallest String With Swaps**: You can swap the characters at any pair of indices in the given pairs any number of times. Return the lexicographically smallest string that s can be changed to after using the swaps.

Think of it as a graph problem. A pair is an edge, a character is a vertex. In each connected component, we can freely rearrange the nodes in this component. So we need to find all connected components and sort each component independently.

**1263. Minimum Moves to Move a Box to Their Target Location**

BFS. Represent the search state as `(player_row, player_col, box_row, box_col)`, and maintain the minimum number of pushes needed so far to reach every seen state.
Similar problems: **1293. Shortest Path in a Grid with Obstacles Elimination**: Represent the search state as `(i, j, k)`, where `k` is the number of opportunities left that we can remove obstacles.

**1284. Minimum Number of Flips to Convert Binary Matrix to Zero Matrix**

Brute-force BFS. Reverse the process, start from a zero matrix.

**1319. Number of Operations to Make Network Connected**

Union-find or DFS. Find redundant cables(edges) in connected components.

# Math

Make use of `x % 10` and `x / 10` to get each digit (in decimal).

## Find the Pattern

**31\. Next Permutation**: Return the lexicographically next greater permutation of the given numbers.

Write down the permutations of [1,2,3,4], then observe and find the pattern:
1. Find the first ascending pair `nums[i]` and `nums[i+1]` from right to left.
2. Find the next larger element to `nums[i]`.
3. Starting from the end, find the next larger element to `nums[i]` and swap with `nums[i]`.
4. Reverse from `nums[i + 1]` to the end.

**43\. Multiply Strings**: Multiply two numbers represented as strings.

![](.\pics\43.png)

**60\. Permutation Sequence**: Given n and k, the set [1,2,3,...,n] contains a total of n! unique permutations. Return the k-th permutation sequence.

Write down the permutations when n = 4. Observe that there is a pattern for us to determine each digit from MSD to LSD.

**89. Gray Code**

Find the pattern of how to get `GrayCode(n)` from `GrayCode(n-1)`.
Similar problem: **1238. Circular Permutation in Binary Representation**

**233. Number of Digit One**: Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.

Consider how many 1's there are in each position (one's position, then ten's position, then hundred's position).

**258. Add Digits**

 [Digit root](https://en.wikipedia.org/wiki/Digital_root#Congruence_formula). The function is periodic.

**386. Lexicographical Numbers**: Given an integer n, return 1 - n in lexicographical order.

Write down an example and observe its pattern.

**390. Elimination Game**: There is a list of sorted integers from 1 to n. Starting from left to right, remove the first number and every other number afterward until you reach the end of the list. Then from right to left. Return the last number that remains.

The sequence of every step is a  arithmetic progression, so it can be represented by its first number and difference.

**396. Rotate Function**

Math. Try to get F(n) from F(n - 1).

**400. Nth Digit**: Find the n-th digit of the infinite integer sequence 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...

Find the corresponding number.

**402\. Remove K Digits**: Remove k digits from a given number so that the new number is the smallest possible.

We can find a pattern: from the most significant digit to the least significant digit, whenever we meet a digit that is less than the the previous digit, we should discard the previous digit. So we can use a stack to hold the eligible digits.

**670. Maximum Swap**: Given a non-negative integer, you could swap two digits at most once to get the maximum valued number. Return the maximum valued number you could get.

From right to left, save the maximum digit and a smaller digit in the left of it.

**1291. Sequential Digits**: Example: low = 1000, high = 13000 => [1234,2345,3456,4567,5678,6789,12345]

Just find all the valid numbers in the given range. Consider the possible number of digits allowed.

**1354. Construct Target Array With Multiple Sums**: Example:
Input: target = [9,3,5]
Output: true
Explanation: Start with [1, 1, 1] 
[1, 1, 1], sum = 3 choose index 1 and replace its value with the sum of the array.
[1, 3, 1], sum = 5 choose index 2 and replace its value with the sum of the array.
[1, 3, 5], sum = 9 choose index 0 and replace its value with the sum of the array.
[9, 3, 5], we have reached the target given.

If we reverse the process, then every step is determined: find the current maximum number and the number of its previous step should be (`currMax` - "sum of all other numbers"). Be careful of overflow and corner cases, and we should use mod instead of minus to handle cases like [1,1000000000].

**1363. Largest Multiple of Three**: Our goal is to maximize the number of digits, so we can choose all digits and then try to remove one or two digits.

## Others

**2\. Add Two Numbers**: The two numbers are represented as linked lists.

**7. Reverse Integer**: Given a 32-bit signed integer, reverse digits of an integer.

**9. Palindrome Number**: Determine whether an integer is a palindrome.

Reverse the right half of the number using solution of "7. Reverse Integer". Check whether left and right halves are equal.

**50. Pow(x, n)**

Consider all possible cases.

**149. Max Points on a Line**: Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.

Math. A slope and a point determines a line. Given a point `points[i]`, compute the slope of a line containing `points[i]` and another point `point[j]`. Points with the same slope are on the same line. So time complexity is O(N^2).
Similar problem: **1232. Check If It Is a Straight Line**

**166. Fraction to Recurring Decimal**: Given two integers representing the numerator and denominator of a fraction, return the fraction in string format. If the fractional part is repeating, enclose the repeating part in parentheses. Example: Input: numerator = 2, denominator = 3, Output: "0.(6)"

Math. Just like doing division in elementary school.

**168. Excel Sheet Column Title**

Convert from base-10 to base-26.

**171. Excel Sheet Column Number**

Convert a number from base-26 to base-10 and vice versa (168. Excel Sheet Column Title). Notice that in each iteration, we need to add or minus 1 to the number because there is no letter corresponding to 0.

**172. Factorial Trailing Zeroes**: Given an integer n, return the number of trailing zeroes in n!.

Every pair of 2 and 5 results in a trailing zero. 2 is much more than 5, so the problem becomes how many 5 are there?

**204. Count Primes**: Count the number of prime numbers less than a non-negative number, n.

Sieve of Eratosthenes. For each `i`in [2, n), `i×1`, `i×2`, `i×3`,... should all be marked as non-prime numbers.
![](.\pics\204.gif)

**223. Rectangle Area**

Check every  possible case.
Similar problem: **1401. Circle and Rectangle Overlapping**: Given a circle and a rectangle, return True if the circle and rectangle are overlapped otherwise return False.
Find the closest point to the center of the circle within the border of the rectangle, then check whether its distance to the center is less than `r`.

**224. Basic Calculator**: The expression string may contain open ( and closing parentheses ), the plus `+` or minus sign `-`, non-negative integers.

Use a stack to store the current expression value and its corresponding sign.

**227. Basic Calculator II**: The expression string contains only non-negative integers, `+`,`-`, `*`, `/` operators.

When we meet a `*` or `/`, subtract the last value from the result because it was incorrectly added.

**326\. Power of Three**: Given an integer, determine if it is a power of three.

Math: A number is a power of three if and only if it is divisible by 3^19 (3^20 > `int.MaxValue`).
Similar problems:
**231. Power of Two**: Another approach is bit manipulation: Power of 2 only have one '1' bit in their binary representation.
**342. Power of Four**: Another approach is bit manipulation: Power of 4 only have one '1' bit in their binary representation and are in the odd positions.

**263\. Ugly Number**: Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. Check whether a given number is an ugly number.

Math: Divide the given number by 2, 3, 5 until it becomes 1.

**264\. Ugly Number II**: Find the n-th ugly number.

The next ugly number is the minimum of a certain previous ugly number multiplied by 2 or 3 or 5. We should maintains 3 pointers `p2`, `p3` and `p5`.

**313\. Super Ugly Number**: Find the nth super ugly number. Super ugly numbers are positive numbers whose all prime factors are in the given prime list.

A generalization of "Problem 264. Ugly Number II", same idea, using priority queue.

**343. Integer Break**:  Given a positive integer *n*, break it into the sum of at least two positive integers and maximize the product of those integers. Return the maximum product you can get. 

DP or Math. If an optimal product contains a factor f >= 4, then you can replace it with factors 2 and f-2 without losing optimality, as `2*(f-2) = 2f-4 >= f`. So you never need a factor greater than or equal to 4, meaning you only need factors 1, 2 and 3 (and 1 is of course wasteful and you'd only use it for n=2 and n=3, where it's needed). 3 * 3 is simply better than 2 * 2 * 2, so you'd never use 2 more than twice. For example: 6 = 2 + 2 + 2 = 3 + 3. But 2 * 2 * 2 < 3 * 3.

**1362. Closest Divisors**: Search the factor from square root to 1.
**1390. Four Divisors**: Search the factor from 1 to square root (Sqrt is an expensive operation, so we can do ` i * i <= num` instead).

## Brainteaser

**365. Water and Jug Problem**
**1227. Airplane Seat Assignment Probability**: Pure probability problem.
**1250. Check If It Is a Good Array**: Bézout's identity: If gcd(a,b)=d, then there exist integers x and y such that ax+by=d.

# String or Array

## Techniques

**41. First Missing Positive**: Given an unsorted integer array, find the smallest missing positive integer.

Put every number in its proper position, that is, put `i` in `nums[i - 1]`.

**448. Find All Numbers Disappeared in an Array**: Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array). Find all the elements of [1, n] inclusive that do not appear in this array.

Put `num[i]` in `nums[num[i] - 1]`. Similar to "41. First Missing Positive".

**128\. Longest Consecutive Sequence**: Find the length of the longest consecutive elements sequence of an array of integers.

Use a hash set to count from the start of a sequence.
Similar questions: **1296. Divide Array in Sets of K Consecutive Numbers**

**303. Range Sum Query - Immutable**:  Given an integer array *nums*, find the sum of the elements between indices *i* and *j* (*i* ≤ *j*), inclusive. 

"Prefix sum".
Similar questions: **1310. XOR Queries of a Subarray**

**304. Range Sum Query 2D - Immutable**

Sum(ABCD)=Sum(OD)−Sum(OB)−Sum(OC)+Sum(OA), O is at matrix[0,0].
Similar questions: **1314. Matrix Block Sum**

**307. Range Sum Query - Mutable**

Segment Tree.

**1031. Maximum Sum of Two Non-Overlapping Subarrays**:  Given an array `A` of non-negative integers, return the maximum sum of elements in two non-overlapping (contiguous) subarrays, which have lengths `L` and `M`. 

Traverse `A`, for each i, maintain the maximum "array L" before i, and add it with "array M" starting from i, then we get a potential answer.

**151. Reverse Words in a String**: Given an input string, reverse the string word by word.

1\. Reverse the whole string. 2\. Reverse each word.

**189. Rotate Array**: Given an array, rotate the array to the right by k steps, where k is non-negative.

Approach 1: Similar to the solution of "151. Reverse Words in a String". Reverse the whole "string" and then reverse each "word" (as for this problem, there are 2 words: left and right parts).

Approach 2:
For example: [1,2,3,4,5,6], k=2
Rotated:         [5,6,1,2,3,4]
![](.\pics\189.png)

**169. Majority Element**: Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊n/2⌋ times.

Boyer-Moore Voting Algorithm. For each element, vote for the same element.

**229\. Majority Element II**: Find all elements in an array that appear more than `array.Length / 3` times.

A mathematical extension of the Boyer-Moore Voting Algorithm of "169. Majority Element".

**384. Shuffle an Array**

Fisher-Yates algorithm. Randomly choose a number from [i, length) and put it at the front of the array as the chosen numbers.

**73. Set Matrix Zeroes**: Given a *m* x *n* matrix, if an element is 0, set its entire row and column to 0. Do it in-place with constant space.

If `matrix[i][j] == 0`, set `matrix[0][j]` and `matrix[i][0]` to zero as a mark to indicate that "row i" and "column j" should be zero. Be careful that `matrix[0][0]` is shared by "row 0" and "column 0".

**376. Wiggle Subsequence**:  Given an array `nums`, return the length of the longest subsequence that is a wiggle sequence. 

Count the number of peaks and valleys.

**75. Sort Colors**: Sort an array containing only 0, 1, 2 with a one-pass algorithm using only constant space.

The idea is that we throw "0"s to the start and throw "2"s to the end. When "0" is met, we swap it with the leftmost "1".

**134. Gas Station**: The problem is equivalent to: Find a position in a given array such that the accumulative sum in the clockwise direction is always non-negative.

If the accumulative sum becomes negative, we reset it to 0. If it becomes non-negative, we record the current index.

**135. Candy**: There are N children standing in a line. Each child is assigned a rating value. You are giving candies to these children subjected to the following requirements: 1\. Each child must have at least one candy. 2\. Children with a higher rating get more candies than their neighbors. What is the minimum candies you must give?

1\. From left to right, make sure each element is bigger than its previous element.
2\. From right tot left, make sure each element is bigger than its next element.

**214. Shortest Palindrome**:  Given a string `s`, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation. 

Find the longest palindrome starting from the beginning. For each substring, check whether it's a  palindrome.

**336. Palindrome Pairs**:  Given a list of unique words, find all pairs of distinct indices `(i, j)` in the given list, so that the concatenation of the two words, i.e. `words[i] + words[j]` is a palindrome.

Basically the same as "214. Shortest Palindrome". Use a hash table to store and retrieve all the unique words.

**238. Product of Array Except Self**: Given an array `nums` of n integers where n > 1,  return an array `output` such that `output[i]` is equal to the product of all the elements of `nums` except `nums[i]`. Could you solve it with constant space complexity?

From left to right and right to left, calculate each num[i]'s "prefix product".

**268. Missing Number**: Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

Calculate sum=0+1+2+3+...+n, and the sum of the array, then return their difference.

**274. H-Index**: Given an integer array `nums`, find a `nums[i]` such that `nums[0..i - 1] <= h` and `nums[i..n] >= h`, where h is the number of `nums[i..n]`, which is n - i.  If there are several possible  results, find the leftmost one.

"Counting sort", or sort the input array first.

**275. H-Index II**: Same as 274. H-Index, except that `nums` is sorted in ascending order.

Binary search. Compare each `nums[i]` with `n - i`.

**306. Additive Number**: "112358" => 1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8; "199100199" => 1 + 99 = 100, 99 + 100 = 199

Just try all possibilities for the first two numbers and check whether the rest fits.  Because if we try other possibilities for the other numbers, we will break the rule. The only numbers that we can change without breaking the rule are the first two. Use `BigInteger` to handle overflow for very large input integers.

**334. Increasing Triplet Subsequence**: Find if there exists *i, j, k* such that *arr[i]* < *arr[j]* < *arr[k]* given 0 ≤ *i* < *j* < *k* ≤ *n*-1.

Scan the array and update candidates for *arr[i]*, *arr[j]* and *arr[k]*.

**363. Max Sum of Rectangle No Larger Than K**

1\. Let an array of sums represent the sum of subarrays of rows, so the question is simplified to 1-dimension.
2\. Use the "prefix sum" technique. For each current sum so far, find a previous sum that satisfies the requirement. We can use a `TreeSet`.

**406. Queue Reconstruction by Height**

First consider the tallest man, then the second tallest man...

**409. Longest Palindrome**: Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

Find the letters that appear an odd number of times.
Similar problem: **1400. Construct K Palindrome Strings**

**419. Battleships in a Board**

Check each 'X' grid's left and top grid.

**581. Shortest Unsorted Continuous Subarray**

Let [l, r] represent the expected shortest subarray so far. Traverse the array and expand [l, r] if necessary.

**621. Task Scheduler**: Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle. However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle. You need to return the least number of intervals the CPU will take to finish all the given tasks.
Example: Input: tasks = ["A","A","A","B","B","B"], n = 2. Output: 8
Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.

The idea is that we can get the task that appears the maximum number of times and consider how to schedule them. For example, there are 3 'A's and n = 2: A -> idle -> idle -> A -> idle -> idle -> A
We also need to take care of some special cases.

**739. Daily Temperatures**

Somehow avoid unnecessary compares.

**1252. Cells with Odd Values in a Matrix**

The state of each row and column can be represented by a single variable, so we only need `bool[] rows = new bool[n]` and `bool[] columns = new bool[m]`.
Similar problem: **1380. Lucky Numbers in a Matrix**: Save the minimum value of each row and maximum value of each column.

**1267. Count Servers that Communicate**

Mark each server to corresponding row and column. Similar to "1252. Cells with Odd Values in a Matrix".

**1260. Shift 2D Grid**

"189. Rotate Array" with virtual index.

**1371. Find the Longest Substring Containing Vowels in Even Counts**: Given the string `s`, return the size of the longest  substring containing each vowel an even number of times. That is, 'a',  'e', 'i', 'o', and 'u' must appear an even number of times.

For each substring s[0..i], we need to save its state: (number of 'a', number of 'e', number of 'i', number of 'o', number of 'u'). For each state, find the leftmost substring with the same state, because "odd - odd = even, even - even = even, odd - even = odd".

**1375. Bulb Switcher III**: At moment *k* (for *k* from `0` to `n - 1`), we turn on the `light[k]` bulb. A bulb change color to blue only if it is on and all the previous bulbs (to the left) are turned on too. Return the number of moments in which all turned on bulbs are blue.

`rightMostOn` is the number of the rightmost light that is on. All turned on bulbs are blue if and only if the total number of lights that is on so far equals `rightMostOn`.

## Sort first

**56\. Merge Intervals**

First, sort the Intervals by their left boundaries. Then, use the fast-slow-runners technique to merge the "fast interval" with the "slow interval"(In place).
Similar problems: 
**1288. Remove Covered Intervals**: sort first.

**354. Russian Doll Envelopes**:  You have a number of envelopes with widths and heights given as a pair of integers `(w, h)`. One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.   What is the maximum number of envelopes can you Russian doll? (put one inside other) 

Sort by width, then find the longest increasing subsequence (Problem 300) of height.

**1233. Remove Sub-Folders from the Filesystem**: Sort first.

**1268. Search Suggestions System**: Sort and binary search. Alternative approach: Trie.

**1288. Remove Covered Intervals**
**1403. Minimum Subsequence in Non-Increasing Order**

## Others

**6. ZigZag Conversion**: Convert "PAYPALISHIRING" to: 
P    A    H   N
A P L S  I  I G
Y     I     R

It's like periodic functions in mathematics.
Similar problem: **1324. Print Words Vertically**

**14. Longest Common Prefix**

Compare characters of the same index from each string.

**28. Implement strStr()**

Classic brute-force solution.

**48\. Rotate Image**: Rotate an *n* x *n* matrix by 90 degrees (clockwise).

Array manipulation. "circle" by "circle" from the outermost "circle".
Similar problems:
**54. Spiral Matrix**: Given a matrix, return all elements of the matrix in spiral order.
**59. Spiral Matrix II**: Given a positive integer *n*, generate a square matrix filled with elements from 1 to *n*^2 in spiral order.

**57\. Insert Interval**: Given a set of *non-overlapping* intervals, insert a new interval into the intervals (merge if necessary).

Just do what the description asked.

**165\. Compare Version Numbers**

Split the version number by dot.

**575. Distribute Candies**: Distribute the given candies equally in number to brother and sister.

Find the nature of the problem and we can get the answer: `Math.Min(candies.Length / 2, new HashSet<int>(candies).Count)`

**1392. Longest Happy Prefix**: A string is called a happy prefix if is a non-empty prefix which is also a suffix (excluding itself). Given a string `s`. Return the longest happy prefix of `s`.

KMP or rolling hash.

**228. Summary Ranges**: String and math.
**289. Game of Life**: Mark visited cell as other numbers in order to do it in place.
**1217. Play with Chips**: Everything is 0 or 1.
**1221. Split a String in Balanced Strings**: Count 'L' and 'R'.
**1222. Queens That Can Attack the King**: Check 8 directions around the king.
**1272. Remove Interval**: Draw diagrams and consider all possible cases.
**1386. Cinema Seat Allocation**: Just check all possible cases.
**1391. Check if There is a Valid Path in a Grid**: Just go down the one direction path.

## Math

**8. String to Integer (atoi)**
**12. Integer to Roman**
**13. Roman to Integer**
**405. Convert a Number to Hexadecimal**
**65. Valid Number**: Validate if a given string can be interpreted as a decimal number.
**66. Plus One**: `[1,2,3]` to `[1,2,4]`
**67. Add Binary**: Given two binary strings, return their sum (also a binary string).

# Linked List

Consider corner cases. Sometimes a dummy header can avoid extra code for checking corner cases. Maintain a fast and a slow pointer that have the same or different speeds.

**19. Remove Nth Node From End of List**

Fast-slow pointers.

**61\. Rotate List**

Count length first or use slow-fast pointers.

**141. Linked List Cycle**: Given a linked list, determine if it has a cycle in it.

Fast-slow pointers. Each time we let the fast-runner take 2 steps and the slow-runner take 1 step. The fast-runner will always catch up with the slow-runner if there is a cycle.

**142. Linked List Cycle II**

The first step is the same as "Problem 141. Linked List Cycle". After that, the distance `slow` moved is exactly the circumference of the cycle(or a multiple of it). So let a pointer `p `start from head and wait until `p` and `slow` meets.

**287. Find the Duplicate Number**: Given an array `nums` containing n + 1 integers where each integer is between 1 and n (inclusive). Assume that there is only one duplicate number, find the duplicate one.

Think of the value of each element as a pointer(index) to another element, and the problem becomes equivalent to "Problem 142 . Linked List Cycle II": Given a linked list, return the node where the cycle begins.

**160. Intersection of Two Linked Lists**

The key is that, for example, when the pointer of A reaches the end, then redirect it to the head of B, until "pA" meets "pB".

**203. Remove Linked List Elements**:  Remove all elements from a linked list of integers that have value val.

We need these variables: `dummyHead`, `prev`, `curr`.

**206. Reverse Linked List**: Reverse a singly linked list.

We need these variables: `prev`, `curr`.

**24. Swap Nodes in Pairs**: Given a linked list, swap every two adjacent nodes and return its head.

**25. Reverse Nodes in k-Group**: Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

An extension of "24. Swap Nodes in Pairs". We need more pointers to save the critical nodes.

**86. Partition List**: Given a linked list and a value *x*, partition it such that all nodes less than *x* come before nodes greater than or equal to *x*.

Use two pointers to construct the left and right linked lists, and merge them in the end.

**92. Reverse Linked List II**: Reverse a linked list from position *m* to *n*. Do it in one-pass.

Linked list manipulation.

**138. Copy List with Random Pointer**

Save the mapping of old node to new node like this:
A      B    C
↓ ↗ ↓ ↗ ↓
A'     B'   C'
Then use this mapping to set "random" of the new nodes.

**143. Reorder List**: Given a singly linked list L: L0→L1→…→Ln-1→Ln, reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

1\. Find the middle node (fast-slow pointers). 2\. Reverse the right half. 3\. Let "left" move towards tail and "right" move towards head.

**234. Palindrome Linked List**: Given a singly linked list, determine if it is a palindrome.

1\. Find the middle node. 2\. Reverse the right half. 3\. Compare the left and right halves.

**328. Odd Even Linked List**:  Given a singly linked list, group all odd nodes together followed by the even nodes. 

Construct the "odd list" and "even list" and then merge them.

**430. Flatten a Multilevel Doubly Linked List**

Recursion.

# Bit Manipulation

**136. Single Number**: Given a non-empty array of integers, every element appears twice except for one. Find that single one.

XOR all the numbers, two same numbers will cancel out.
Same problem: **389. Find the Difference**

**137. Single Number II**:  Given a non-empty array of integers, every element appears three times except for one, which appears exactly once. Find that single one.

Design a truth table, then guess the bitwise operations from it.

**260. Single Number III**: Given an array of numbers, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements `a` and `b` that appear only once.

Tricky solution: If we can divide the numbers into two groups and make sure  `a` and `b` are in different groups, we can get the answer using the XOR technique. We can group the numbers from one digit of `a^b`.

**190. Reverse Bits**: Reverse bits of a given 32 bits unsigned integer.

Bit manipulation. Reverse the left and right 16 bits,  Let us denote it as (16,16), then reverse (8,8) and (8,8), then reverse (4,4), (4,4),(4,4),(4,4), and reverse (2,2),(2,2),(2,2),(2,2),(2,2),(2,2),(2,2),(2,2), and...

**191. Number of 1 Bits**:  Write a function that takes an unsigned integer and return the number of '1' bits it has.

A trick: n &(n - 1) is equal to changing the rightmost 1 in n to 0.

**201\. Bitwise AND of Numbers Range**

After observing, we can find a pattern that makes the problem equal to finding the longest common prefix of two numbers' binary representations.

**318. Maximum Product of Word Lengths**:  Given a string array `words`, find the maximum value of `length(word[i]) * length(word[j])` where the two words do not share common letters. You may assume that each word will contain only lower case letters. If no such two words exist, return 0. 

Every word can be represented as a integer, with every letter corresponding to a bit.
Similar problem: **1239. Maximum Length of a Concatenated String with Unique Characters**

**371. Sum of Two Integers**: Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

Bit manipulation. Simulate addition with XOR, save the carry digits using bitwise AND.

**421. Maximum XOR of Two Numbers in an Array**

First we check whether the MSB can be 1, then the second MSB...Each time we only consider a prefix of the numbers.

**1310. XOR Queries of a Subarray**

Similar to prefix sums.

**1318. Minimum Flips to Make a OR b Equal to c**

For every bit, consider all cases.

**1404. Number of Steps to Reduce a Number in Binary Representation to One**

 Division by two is the same as removing the rightmost 0.

# Sort

**164\. Maximum Gap**: Given an unsorted array, find the maximum difference between the successive elements in its **sorted form**. Assume all elements in the array are non-negative integers. Try to solve it in linear time/space.

Radix Sort(LSD String Sort) or Bucket Sort(somehow ensures that the two elements that forms the  maximum gap are in different buckets).

**179. Largest Number**: Given a list of non negative integers, arrange them such that they form the largest number.

Consider how to achieve this: 9 is "bigger" than 34, 3 is "bigger" than 30...
A simple way is to convert the number to string then compare their string concatenations.

**215. Kth Largest Element in an Array**

Quick select. Repeat the partition(same as the partition in quick sort) until the number of elements in the left part equals k.

**324. Wiggle Sort II**: Given an unsorted array `nums`, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....

Divide `nums` into smaller and larger halves using quick select from "215. Kth Largest Element in an Array". Place the smaller numbers in the positions with even index, and the larger numbers in the position with odd index. Deal with special cases such as nums = [4,5,5,5, 5,6,6,6] (After FindKthLargest), "5" is the median in this example, we should move all the "5" in the even-indexed numbers to the beginning, an all the "5" in the odd-indexed numbers to the end, so that the "5"s won't be next to each other.

**300\. Longest Increasing Subsequence**

Patience sorting, O(NlogN). Think of the nums as cards. We need to group the cards into piles. For each of the cards  from left to right, place the card onto the leftmost pile whose top card has a value higher than (or equal to, for example:[2,5,5]) the current card's value, if there is no such pile, form a new pile on the right. The number of piles is the length of longest increasing subsequence.

DP, O(N^2): `dp[i]` with the restriction of `nums[i]` being the tail of the longest increasing subsequence.

**1200. Minimum Absolute Difference**: The minimum absolute difference must be a difference between two consecutive elements in the sorted array.

**1366. Rank Teams by Votes**

Sort by position then by votes.

# Priority Queue

**218. The Skyline Problem**: Output the skyline formed by the buildings given.

Use a priority queue to maintain the highest building so far.

**295. Find Median from Data Stream**

Use a max priority queue to store the smaller half, and a min priority queue to store the larger half.

**378\. Kth Smallest Element in a Sorted Matrix**: Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Starting from `matrix[0][0]`, add `matrix[i + 1][j]` and `matrix[i][j + 1]` to a min priority queue because they are candidates for the next smallest element.

**373. Find K Pairs with Smallest Sums**: You are given two integer arrays `nums1` and `nums2` sorted in ascending order and an integer k. Define a pair (u,v) which consists of one element from the first array and one element from the second array. Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.

Essentially the same as "378. Kth Smallest Element in a Sorted Matrix".

**1383. Maximum Performance of a Team**: Given two arrays: `speed` and `efficiency`, where `speed[i]` and `efficiency[i]` represent the speed and efficiency for the i-th engineer respectively. Return the maximum *performance* of a team composed of at most `k` engineers. The *performance* of a team is the sum of their engineers' speeds multiplied by the minimum efficiency among their engineers. 

For each efficiency `e`, if `e` is the minimum efficiency in the result, then the corresponding maximum sum of speeds should be the sum of the `k`(or less than `k`) highest speeds among the engineers with efficiencies equal or greater than `e`. So we can sort the engineers by their efficiencies in decreasing order, and use a priority queue to keep track of the `k` highest speeds.

# Trie

**208. Implement Trie (Prefix Tree)**

**211\. Add and Search Word - Data structure design**: `Search(word)` can search a literal word or a regular expression string containing only letters a-z or `'.'`. A `'.'` means it can represent any one letter.

# Deque

**239\. Sliding Window Maximum**: Find the max number in a sliding window of an array.

Use a deque to maintain the possible candidates.

# TreeSet or TreeMap

**729. My Calendar I**
**1244. Design A Leaderboard**: Use a sorted map: score -> count; and a hash map: playerId -> score
**1\. Two Sum**: Find two numbers in a given array that add up to a target.

Use a hash table to store complement of each number.

**2\. Add Two Numbers**: The two numbers are represented as linked lists.

Simple math problem.

**3\. Longest Substring Without Repeating Characters**

Maintain a sliding window that contains only unique characters.

**4. Median of Two Sorted Arrays**: Find the median of the two sorted arrays.

Find a "split line" that splits `nums1` and `nums2` such that all the numbers on the left are less than those on the right.

**5. Longest Palindromic Substring**

DP. let `dp[i,j]` be whether `s[i]`~`s[j]` is a palindrome. 

`dp[i,j] = (s[i] == s[j]) && (dp[i + 1, j - 1])`

**6. ZigZag Conversion**: The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
P    A    H   N
A P L S  I  I G
Y     I     R
And then read line by line: "PAHNAPLSIIGYIR". Write the code that will take a string and make this conversion given a number of rows.

It's like periodic function in mathematics.

**7. Reverse Integer**: Given a 32-bit signed integer, reverse digits of an integer.

Math. Make use of `x % 10` and `x / 10` to get each digit.

**9. Palindrome Number**: Determine whether an integer is a palindrome.

Reverse the right half of the number using solution of "7. Reverse Integer". Check whether left and right halves are equal.

**10\. Regular Expression Matching**: `'.'` matches any single character, `'*'` Matches zero or more of the preceding element.

DP: A `'*'`either matches empty or "swallows" one more character.

**11. Container With Most Water**

"low-high" pointers. Each time we move the shorter line inwards, looking for a probably longer line instead.

**14. Longest Common Prefix**

Compare characters of the same index from each string.

**15. 3Sum**: Find all unique triplets in the array which gives the sum of zero.

Sort `nums` first and use the "low-high" pointers technique.

**17. Letter Combinations of a Phone Number**

For each digit, add each of its mapping to all the current combinations.

**18. 4Sum**

Extension of "15. 3Sum". Solution is the same.

**19. Remove Nth Node From End of List**

Two pointers.

**20. Valid Parentheses**: Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

Stack.

**21. Merge Two Sorted Lists**

Two pointers.

**22. Generate Parentheses**: Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Catalan number problem. The problem is equal to "Problem 95. Unique Binary Search Trees II" and this problem: If 1...n is the sequence of push operations on an initially empty stack. How many different sequences of pop operations are there?  A push is a "(", and a pop is a ")". The root node in BST is the counterpart of the **last** element that popped out of the stack.

**23. Merge k Sorted Lists**

Divide and conquer or min priority queue.

**24. Swap Nodes in Pairs**: Given a linked list, swap every two adjacent nodes and return its head.

Linked list manipulation.

**25. Reverse Nodes in k-Group**: Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

An extension of "24. Swap Nodes in Pairs". We need more pointers to save the critical nodes.

**26. Remove Duplicates from Sorted Array**

Fast-slow pointers.

**27. Remove Element**: Given an array nums and a value val, remove all instances of that value in-place and return the new length.

Fast-slow pointers. Or "high-low" pointers (if the order of elements does not matter).

**29. Divide Two Integers**: Given two integers `dividend` and `divisor`, divide two integers without using multiplication, division and mod operator.

Check whether `divisor` * 2, `divisor` * 4, `divisor` * 8, ... is greater than `dividend`. Do the same to the remainder.

**30. Substring with Concatenation of All Words**: Example: s = "barfoothefoobarman", words = ["foo","bar"],  Output: [0,9]. Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.

Hash table. Because words may contain duplicates, use a dictionary to count every word. The rest is brute-force.

**31\. Next Permutation**: Return the lexicographically next greater permutation of the given numbers.

Write down the permutations of [1,2,3,4], then observe and find the pattern:

1. Find the first ascending pair `nums[i]` and `nums[i+1]` from right to left.
2. Find the next larger element to `nums[i]`.
3. Starting from the end, find the next larger element to `nums[i]` and swap with `nums[i]`.
4. Reverse from `nums[i + 1]` to the end.

**32. Longest Valid Parentheses**

A very smart solution: From left to right, count the number of ')' and '(', only when the number of '(' is greater than ')'. When they are equal, update the final result. Repeat the similar process from right to left.

**33\. Search in Rotated Sorted Array**

Step 1\. Find the "rotated point" - the index of the smallest value in the array.

Step 2\. Binary search with the appropriate offset.

**34\. Find First and Last Position of Element in Sorted Array**

Binary search with special handling when `nums[mid] == target`.

**35\. Search Insert Position**

Binary search.

**36. Valid Sudoku**: Determine if a 9x9 Sudoku board is valid.

Brute-force solution using hash sets.

**37. Sudoku Solver**: Write a program to solve a Sudoku puzzle by filling the empty cells.

Backtracking brute-force solution.

**39. Combination Sum**: Given a set of candidate numbers (`candidates`) (without duplicates) and a target number (`target`), find all unique combinations in `candidates` where the candidate numbers sums to `target`. The same repeated number may be chosen from `candidates` unlimited number of times.

Backtracking. Sort the array, and choose small numbers first.

**41. First Missing Positive**: Given an unsorted integer array, find the smallest missing positive integer.

A little tricky. Put every number in its proper position, that is, put `i` in `nums[i - 1]`.

**42. Trapping Rain Water**: Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

Approach 1: Use a stack to track those heights that may be "useful" in the future (that is, we cannot draw any conclusion of trapping water yet).
Approach 2: A very smart one using two pointers. Let `left` start from the start and `right` start from the end. For example, when `height[left] < height[right]` and there is height `maxLeft` which is higher than `height[left]` on the left of `height[left]`, we can draw the conclusion that `maxLeft - height[left]` of water can be trapped, because `height[right]` is always able to hold these water, no matter what values the un-visited heights are.

**43\. Multiply Strings**: Multiply two numbers represented as strings.

![](D:\GitHub\CSharp\Algorithms\Algorithms\LeetCode\Notes\pics\43.png)

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

Backtracking (DFS).

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

**101. Symmetric Tree**: Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

Recursion (DFS) is simple. Iterative solution (BFS): Enqueue the left and right children twice in a specific order: left,right,right,left. In this way, if the tree is symmetric, two consecutive nodes in the queue are equal.

**104. Maximum Depth of Binary Tree**

DFS or BFS.

**105. Construct Binary Tree from Preorder and Inorder Traversal**

The first element in preorder must be the root. Find this root in inorder and cut inorder by this root.

**106. Construct Binary Tree from Inorder and Postorder Traversal**

The last element in postorder must be the root. Find this root in inorder and cut inorder by this root.

**108. Convert Sorted Array to Binary Search Tree**: Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

Let the element in the middle be the root, so that the left and right parts are same in height.

**109. Convert Sorted List to Binary Search Tree**: Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

There is a very subtle solution. Basically it's very similar to "Problem 108. Convert Sorted Array to Binary Search Tree". We only have to make sure that when we are processing on the recursive stack, we can visit each node in the linked list sequentially to construct the tree.

**110. Balanced Binary Tree**: Given a binary tree, determine if it is height-balanced.

Recursion. Check the height of every subtree.

**111. Minimum Depth of Binary Tree**: Given a binary tree, find its minimum depth.

DFS or BFS.

**112. Path Sum**: Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

DFS. Similar to "Problem 111. Minimum Depth of Binary Tree".

**113. Path Sum II**:  Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

DFS and backtracking.

**114. Flatten Binary Tree to Linked List**: Given a binary tree, flatten it to a linked list in-place.

Recursion.

**115. Distinct Subsequences**: For example, Input: S = "rabbbit", T = "rabbit". **rabb**b**it**, **ra**b**bbit**, **rab**b**bit**.

DP. Let `dp[i,j]` be the answer of T[0...i] and S[0...j].

**116. Populating Next Right Pointers in Each Node**:  You are given a perfect binary tree where all leaves are on the same level.

For each node, for example, root, set `next` like this:
![43](D:\GitHub\CSharp\Algorithms\Algorithms\LeetCode\Notes\pics\116.jpg)

**117. Populating Next Right Pointers in Each Node II**: You are given a binary tree.

Level by level (row by row). Each level can be generated based on its previous level. Use a dummy head to save the first node of each level.

**118. Pascal's Triangle**: Given a non-negative integer `numRows`, generate the first `numRows` rows of Pascal's triangle.

DP. Generate every row from its previous row.

**119. Pascal's Triangle II**: Return the kth index row of the Pascal's triangle. Could you optimize your algorithm to use only O(k) extra space?

We can only allocate a single array of length k and reuse it, for example, when k = 5:
[0,0,0,0,1]
[0,0,0,1,1]
[0,0,1,2,1]
[0,1,3,3,1]
[1,4,6,4,1]

**120. Triangle**: Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.

DP.

**122. Best Time to Buy and Sell Stock II**: Find the maximum profit. You may complete as many transactions as  you like.

There is a accumulative approach that accumulates each difference of an ascending pair to get the final result.

**123. Best Time to Buy and Sell Stock III**: Find the maximum profit. You may complete at most two transactions.

For each day, consider how we can get the following values?

1. The max profit so far of buying and selling only once.
2. The lowest buy price of the second buy, by spending the profit from our first trade.
3. The max profit so far of buying and selling twice.

**124. Binary Tree Maximum Path Sum**: Given a non-empty binary tree, find the maximum path sum.

For each node, recursively calculate the maximum path sum of paths that must **end or start** with this node.

**127. Word Ladder**: Given two words (*beginWord* and *endWord*), and a dictionary's word list, find the length of shortest transformation sequence from *beginWord* to *endWord*, such that: 1\. Only one letter can be changed at a time. 2\. Each transformed word must exist in the word list. Note that *beginWord* is *not* a transformed word. Example: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]. one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog".

Think of *beginWord* as the root of a tree, and all the words that differ only one letter from it are its children nodes. The problem is like BFS of a tree.

**128\. Longest Consecutive Sequence**: Find the length of the longest consecutive elements sequence of an array of integers.

Use a hash set to count from the start of a sequence. A bit tricky.

**129. Sum Root to Leaf Numbers**: Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number. Find the total sum of all root-to-leaf numbers.

DFS.

**130. Surrounded Regions**: Given a 2D board containing 'X' and 'O' (the letter O), flip all 'O's into 'X's in all regions of 'O's surrounded by 'X'. Surrounded regions shouldn’t be on the border.

BFS starting from borders. Mark the 'O's with a marker such as '#'.

**131. Palindrome Partitioning**: Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

Recursion  with memoization. Check every possible partitioning.

**132. Palindrome Partitioning II**: Given a string s, partition s such that every substring of the partition is a palindrome. Return the minimum cuts needed for a palindrome partitioning of s.

DP. Similar to the DP solution of "Problem 5. Longest Palindromic Substring". Let `isPalindrome[j, i]` be whether s[j...i] is a palindrome, and `cut[i]` be the minimum cuts for s[0...i].

**133. Clone Graph**: Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph. Each node in the graph contains a val (int) and a list (List[Node]) of its neighbors.

BFS. Use a dictionary to map old node to new node.

**134. Gas Station**: The problem is equivalent to: Find a position in a given array such that the accumulative sum in the clockwise direction is always non-negative.

If the accumulative sum becomes negative, we reset it to 0. If it becomes non-negative, we record the current index.

**135. Candy**: There are N children standing in a line. Each child is assigned a rating value. You are giving candies to these children subjected to the following requirements: 1\. Each child must have at least one candy. 2\. Children with a higher rating get more candies than their neighbors. What is the minimum candies you must give?

1\. From left to right, make sure each element is bigger than its previous element.
2\. From right tot left, make sure each element is bigger than its next element.

**136. Single Number**: Given a non-empty array of integers, every element appears twice except for one. Find that single one.

XOR all the numbers, two same numbers will cancel out.

**137. Single Number II**:  Given a non-empty array of integers, every element appears three times except for one, which appears exactly once. Find that single one.

Design a truth table, then guess the bitwise operations from it.

**138. Copy List with Random Pointer**

Save the mapping of old node to new node like this:
A      B    C
↓ ↗ ↓ ↗ ↓
A'     B'   C'
Then use this mapping to set "random" of the new nodes.

**139\. Word Break**: Determine if a given string can be segmented into several words in a given dictionary.

Brute-force search with memoization, can also be thought as DP.

**140\. Word Break II**: Return all possible segmented results from "139. Word Break".

Same as "139. Word Break".

**141. Linked List Cycle**: Given a linked list, determine if it has a cycle in it.

Fast-slow pointers. Each time we let the fast-runner take 2 steps and the slow-runner take 1 step. The fast-runner will always catch up with the slow-runner if there is a cycle.

**142. Linked List Cycle II**

The first step is the same as "Problem 141. Linked List Cycle". After that, the distance `slow` moved is exactly the circumference of the cycle(or a multiple of it). So let a pointer `p `start from head and wait until `p` and `slow` meets.

**143. Reorder List**: Given a singly linked list L: L0→L1→…→Ln-1→Ln, reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

1\. Find the middle node. 2\. Reverse the right half. 3\. Let "left" move towards tail and "right" move towards head.

**146. LRU Cache**: Design and implement a data structure for Least Recently Used (LRU) cache.

We can maintain a list. Every time an element is accessed, put it to the head of the list. When the cache reaches its capacity, delete the element from the tail of the list. And in order to support the key value mapping, we associate every node with its corresponding key and value, using a hash table.

**148\. Sort List**: Sort a linked list in O(n log n) time using constant space complexity.

Merge sort.

**149. Max Points on a Line**: Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.

Math. A slope and a point determines a line. Given a point `points[i]`, compute the slope of a line containing `points[i]` and another point `point[j]`. Points with the same slope are on the same line.

**150. Evaluate Reverse Polish Notation**

Stack.

**151. Reverse Words in a String**: Given an input string, reverse the string word by word.

1\. Reverse the whole string. 2\. Reverse each word.

**152. Maximum Product Subarray**: Given an integer array `nums`, find the contiguous subarray within an array (containing at least one number) which has the largest product.

DP. Similar to "Problem 53. Maximum Subarray". `dp(i)` contains the max product and min product of a subarray whose right boundary is fixed at index i.

**153\. Find Minimum in Rotated Sorted Array**

Same as the first step of "33. Search in Rotated Sorted Array".

**154\. Find Minimum in Rotated Sorted Array II**

Same as the first step of "81. Search in Rotated Sorted Array II".

**155. Min Stack**: Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Use another stack to store the minimum elements.

**160. Intersection of Two Linked Lists**

The key is that, for example, when the pointer of A reaches the end, then redirect it to the head of B, until "pA" meets "pB".

**164\. Maximum Gap**: Given an unsorted array, find the maximum difference between the successive elements in its **sorted form**. Assume all elements in the array are non-negative integers. Try to solve it in linear time/space.

Radix Sort(LSD String Sort) or Bucket Sort(somehow ensures that the two elements that forms the  maximum gap are in different buckets).

**165\. Compare Version Numbers**

Split the version number by dot.

**166. Fraction to Recurring Decimal**: Given two integers representing the numerator and denominator of a fraction, return the fraction in string format. If the fractional part is repeating, enclose the repeating part in parentheses. Example: Input: numerator = 2, denominator = 3, Output: "0.(6)"

Math. Just like doing division in elementary school.

**167\. Two Sum II - Input array is sorted**: Find two numbers in a given sorted array that add up to a target.

High-low pointers, similar to "11. Container With Most Water".

**169. Majority Element**: Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊n/2⌋ times.

Boyer-Moore Voting Algorithm. For each element, vote for the same element.

**171. Excel Sheet Column Number**

Convert a number from base-26 to base-10.

**172. Factorial Trailing Zeroes**: Given an integer n, return the number of trailing zeroes in n!.

Every pair of 2 and 5 results in a trailing zero. 2 is much more than 5, so the problem becomes how many 5 are there?

**179. Largest Number**: Given a list of non negative integers, arrange them such that they form the largest number.

Consider how to achieve this: 9 is "bigger" than 34, 3 is "bigger" than 30...

A simple way is to convert the number to string then compare their string concatenations.

**187\. Repeated DNA Sequences**: Find all the 10-letter-long substrings that occur more than once.

Find all possible sequences and use a hash table to store the seen sequences.

**188. Best Time to Buy and Sell Stock IV**: Say you have an array for which the i-th element is the price of a given stock on day i. Design an algorithm to find the maximum profit. You may complete at most k transactions.

DP. `dp[i, j]` = the maximum profit from at most `i` transactions using `prices[0..j]`. Either do nothing(not buy) or sell on day j (so we need to know which day we bought last time such that we can gain the maximum profit) .
`dp[i, j] = max(dp[i, j - 1], prices[j] + max(-prices[t] + dp[i - 1, t - 1])), 0 <= t < j`

**189. Rotate Array**: Given an array, rotate the array to the right by k steps, where k is non-negative.

Approach 1: Similar to the solution of "151. Reverse Words in a String". Reverse the whole "string" and then reverse each "word" (as for this problem, there are 2 words).

Approach 2:
For example: [1,2,3,4,5,6], k=2
Rotated:         [5,6,1,2,3,4]
![](D:\GitHub\CSharp\Algorithms\Algorithms\LeetCode\Notes\pics\189.png)

**190. Reverse Bits**: Reverse bits of a given 32 bits unsigned integer.

Bit manipulation. Reverse the left and right 16 bits,  Let us denote it as (16,16), then reverse (8,8) and (8,8), then reverse (4,4), (4,4),(4,4),(4,4), and reverse (2,2),(2,2),(2,2),(2,2),(2,2),(2,2),(2,2),(2,2), and...

**191. Number of 1 Bits**:  Write a function that takes an unsigned integer and return the number of '1' bits it has.

A trick: n &(n - 1) is equal to changing the rightmost 1 in n to 0.

**198\. House Robber**: Find the maximum sum of non-adjacent numbers in a given array.

DP: Either rob or not rob at i: `dp(i) = max(dp(i - 1), nums[i] + dp(i - 2))`

**199\. Binary Tree Right Side View**: Return the "right outline" of a binary tree.

DFS or BFS, only add current node to result under certain circumstances:

DFS: When the current depth is deeper than the maximum depth.

BFS: When the current node is the last node of the current level.

**200. Number of Islands**: Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.

BFS. Mark the visited grids using another "marker character". Similar to "Problem 130. Surrounded Regions".

**201\. Bitwise AND of Numbers Range**

After observing, we can find a pattern that makes the problem equal to finding the longest common prefix of two numbers' binary representations.

**203. Remove Linked List Elements**:  Remove all elements from a linked list of integers that have value val.

We need these variables: `dummyHead`, `prev`, `curr`.

**204. Count Primes**: Count the number of prime numbers less than a non-negative number, n.

Sieve of Eratosthenes. For each `i`in [2, n), `i×1`, `i×2`, `i×3`,... should all be marked as non-prime numbers.
![](D:\GitHub\CSharp\Algorithms\Algorithms\LeetCode\Notes\pics\204.gif)

**206. Reverse Linked List**: Reverse a singly linked list.

We need these variables: `prev`, `curr`.

**209\. Minimum Size Subarray Sum**: Find the minimal length of a contiguous subarray that satisfies a requirement.

Typical sliding window problem.

**211\. Add and Search Word - Data structure design**: `Search(word)` can search a literal word or a regular expression string containing only letters a-z or `'.'`. A `'.'` means it can represent any one letter.

Trie.

**212. Word Search II**: Given a 2D board and a list of words from the dictionary, find all words in the board.

First we build a trie from the given words. Then everything goes the same as "79. Word Search", except that we can stop going deeper if the current path does not match any word's prefix.

**213\. House Robber II**: Same as "198. House Robber", except that the first and last number cannot be chosen both.

Maximum of two sub-problems of "198. House Robber".

**215. Kth Largest Element in an Array**

Quick select. Repeat the partition(same as the partition in quick sort) until the number of elements in the left part equals k.

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

**224. Basic Calculator**: The expression string may contain open ( and closing parentheses ), the plus `+` or minus sign `-`, non-negative integers.

Use a stack to store the current expression value and its corresponding sign.

**225. Implement Stack using Queues**

When pushing, put other elements after the new element.

**227. Basic Calculator II**: The expression string contains only non-negative integers, `+`,`-`, `*`, `/` operators.

When we meet a `*` or `/`, subtract the last value from the result because it was incorrectly added.

**229\. Majority Element II**: Find all elements in an array that appear more than `array.Length / 3` times.

A mathematical extension of the Boyer-Moore Voting Algorithm of "169. Majority Element".

**230. Kth Smallest Element in a BST**

The inorder traversal of a BST is an increasing array.

**232. Implement Queue using Stacks**

Use two stacks.

**233. Number of Digit One**: Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.

Consider how many 1's there are in each position (one's position, then ten's position, then hundred's position).

**234. Palindrome Linked List**: Given a singly linked list, determine if it is a palindrome.

1\. Find the middle node. 2\. Reverse the right half. 3\. Compare the left and right halves.

**235. Lowest Common Ancestor of a Binary Search Tree**: Given two tree nodes `p` and `q` from a BST, find their lowest common ancestor.

Starting from root, let `p` and `q` compare with each node to decide which branch they should take next. When they are about to separate, they are at their lowest common ancestor.

**236. Lowest Common Ancestor of a Binary Tree**: Given two tree nodes `p` and `q` from a binary tree, find their lowest common ancestor.

Depth first search the tree, If we find `p` or `q`, just stop going deeper and return the current node. Compare the nodes returned from left and right subtrees.

**238. Product of Array Except Self**: Given an array `nums` of n integers where n > 1,  return an array `output` such that `output[i]` is equal to the product of all the elements of `nums` except `nums[i]`. Could you solve it with constant space complexity?

From left to right and right to left, calculate each num[i]'s "prefix sum".

**239\. Sliding Window Maximum**: Find the max number in a sliding window of an array.

Use a deque to maintain the possible candidates.

**240. Search a 2D Matrix II**: Write an efficient algorithm that searches for a value in an m x n matrix. Integers in each row are sorted in ascending from left to right. Integers in each column are sorted in ascending from top to bottom.

Search from the bottom-left point, rule out one row or one column each time.

**241\. Different Ways to Add Parentheses**: Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators using parentheses.

Recursion(divide and conquer).

**242. Valid Anagram**: Given two strings `s` and `t` , write a function to determine if `t` is an anagram of `s`.

Use a hash table to count characters. We can allocate a single hash table and let characters from `s` increment the count while characters from `t` decrement the count. If `t` is an anagram of `s`, all counts should be 0.

**260. Single Number III**: Given an array of numbers, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements `a` and `b` that appear only once.

Tricky solution: If we can divide the numbers into two groups and make sure  `a` and `b` are in different groups, we can get the answer using the XOR technique. We can group the numbers from a "1" digit of `a^b`.

**263\. Ugly Number**: Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. Check whether a given number is an ugly number.

Math: Divide the given number by 2, 3, 5 until it becomes 1.

**264\. Ugly Number II**: Find the n-th ugly number.

The next ugly number is the minimum of a certain previous ugly number multiplied by 2 or 3 or 5.

**268. Missing Number**: Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

Calculate sum=0+1+2+3+...+n, and the sum of the array, then return their difference.

**279. Perfect Squares**: Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

Recursion + Memoization. Choose larger square numbers prior to smaller ones.

**283. Move Zeroes**: Given an array `nums`, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Fast-slow pointers. Move all the non-zero numbers to the beginning, then fill the end with 0.

**287. Find the Duplicate Number**: Given an array `nums` containing n + 1 integers where each integer is between 1 and n (inclusive). Assume that there is only one duplicate number, find the duplicate one.

Think of the value of each element as a pointer(index) to another element, and the problem becomes equivalent to "Problem 142 . Linked List Cycle II": Given a linked list, return the node where the cycle begins.

**295. Find Median from Data Stream**

Use a max priority queue to store the smaller half, and a min priority queue to store the larger half.

**297. Serialize and Deserialize Binary Tree**

Use preorder traversal so that when deserializing, we can "new" the root first. Use a special character such as '#' to mark `null` nodes.

**300\. Longest Increasing Subsequence**

Patience sorting, O(NlogN).

DP, O(N^2): `dp[i]` with the restriction of `nums[i]` being the tail of the longest increasing subsequence.

**301. Remove Invalid Parentheses**: Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

Recursion. Find every possible substring and check whether it's a valid string. If we have found a valid substring, no need to further split it and go deeper.

**309. Best Time to Buy and Sell Stock with Cooldown**: Cooldown 1 day.

DP. Let `buy[i]` be the max profit that ends with buying on a day from range [0-i]. Let `sell[i]` means the max profit that ends with selling on a day from range [0-i].

**312. Burst Balloons**: Given `n` balloons, indexed from `0` to `n-1`. Each balloon is painted with a number on it represented by array `nums`. You are asked to burst all the balloons. If the you burst balloon `i` you will get `nums[left] * nums[i] * nums[right]` coins. Here `left` and `right` are adjacent indices of `i`. After the burst, the `left` and `right` then becomes adjacent. Find the maximum coins you can collect by bursting the balloons wisely.

DP. `dp[l, r]` is the answer of bursting all the balloons in (l, r). If the balloon at index i is the **last** balloon to burst(l < i < r), we get `nums[l] * nums[i] * nums[r]` coins.

`dp(i, j) = max(nums[l] * nums[i] * nums[r] + dp[l, i] + dp[i, r]), l < i < r`

**313\. Super Ugly Number**: Find the nth super ugly number. Super ugly numbers are positive numbers whose all prime factors are in the given prime list.

A generalization of "Problem 264. Ugly Number II", same idea.

**315\. Count of Smaller Numbers After Self**: Given an integer array `nums`, return an array `counts` where `counts[i]` is the number of smaller elements to the right of `nums[i]`.

Mergesort. Similar to "493\. Reverse Pairs".

**322. Coin Change**: You are given coins of different denominations and a total amount of money *amount*. Write a function to compute the fewest number of coins that you need to make up that amount.

DP. `dp(S)` is the problem answer to an amount of S. 

`dp(S) = min(dp(S - coins[i]) + 1, 0 <= i < coins.Length, S - coins[i] >= 0`

**324. Wiggle Sort II**: Given an unsorted array `nums`, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....

Divide `nums` into smaller and larger halves using quick select from "215. Kth Largest Element in an Array". Place the smaller numbers in the positions with even index, and the larger numbers in the position with odd index. Deal with special cases such as nums = [4,5,5,5, 5,6,6,6] (After FindKthLargest), "5" is the median in this example, we should move all the "5" in the even-indexed numbers to the beginning, an all the "5" in the odd-indexed numbers to the end, so that the "5"s won't be next to each other.

**326\. Power of Three**: Given an integer, determine if it is a power of three.

Math: A number is a power of three if and only if it is divisible by 3^19 (3^20 > `int.MaxValue`).

**329. Longest Increasing Path in a Matrix**: Given an integer matrix, find the length of the longest increasing path.

Approach 1: DFS from each element, optimized with memoization.
Approach 2: Treat the matrix as a directed graph, with edges pointing from smaller value to larger value. Use BFS topological sort based on in-degree counting. Count the number of levels.

**334. Increasing Triplet Subsequence**: Find if there exists *i, j, k* such that *arr[i]* < *arr[j]* < *arr[k]* given 0 ≤ *i* < *j* < *k* ≤ *n*-1.

Scan the array and update candidates for *arr[i]*, *arr[j]* and *arr[k]*.

**341. Flatten Nested List Iterator**: Given a nested list of integers, implement an iterator to flatten it.

Stack.

**347. Top K Frequent Elements**: Given a non-empty array of integers, return the `k` most frequent elements. Your algorithm's time complexity must be better than O(n log n), where n is the array's size.

Buckets! `buckets`'s index is frequency, e.g. `buckets[3]` contains the numbers that appear 3 times.

**349. Intersection of Two Arrays**: Given two arrays, write a function to compute their intersection.

Hash set.

**350. Intersection of Two Arrays II**: Each element in the result should appear as many times as it shows in both arrays. For example,  nums1 = [1,2,2,1], nums2 = [2,2], Output: [2,2].

Use a hash map to count frequency.

**371. Sum of Two Integers**: Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

Bit manipulation. Simulate addition with XOR, save the carry digits using bitwise AND.

**378\. Kth Smallest Element in a Sorted Matrix**: Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Starting from `matrix[0][0]`, add `matrix[i + 1][j]` and `matrix[i][j + 1]` to a min priority queue because they are candidates for the next smallest element.

**380. Insert Delete GetRandom O(1)**:Design a data structure representing a set that supports `getRandom()` that returns a random element from the set.

Store value-to-index mapping and index-to-value mapping. When removing, we can "fill up the empty position" with the **last** element.

**384. Shuffle an Array**

Fisher-Yates algorithm. Randomly choose a number from [i, length) and put it at the front of the array as the chosen numbers.

**395. Longest Substring with At Least K Repeating Characters**: Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Sliding window.  Count the number of unique characters and the number of characters that appears no less than k times in the sliding window.

**402\. Remove K Digits**: Remove k digits from a given number so that the new number is the smallest possible.

We can find a pattern: from the most significant digit to the least significant digit, whenever we meet a digit that is less than the the previous digit, we should discard the previous digit.

**454\. 4Sum II**: Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that `A[i] + B[j] + C[k] + D[l]` is zero.

Store the sum of every combination of (A[i] + B[j]) in a hash table, then check every combination of (C[i] +D[j]).

**493\. Reverse Pairs**: Given an array `nums`, find how many pair(i, j) there are such that `i < j` and `nums[i] > 2*nums[j]`.

Mergesort.

**572. Subtree of Another Tree**: Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s.

Simple recursive solution based on "Problem 100. Same Tree".

**621. Task Scheduler**: Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle. However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle. You need to return the least number of intervals the CPU will take to finish all the given tasks.
Example: Input: tasks = ["A","A","A","B","B","B"], n = 2. Output: 8
Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.

The idea is that we can get the task that appears the maximum number of times and consider how to schedule them. For example, there are 3 'A's and n = 2: A -> idle -> idle -> A -> idle -> idle -> A
We also need to take care of some special cases.

**894. All Possible Full Binary Trees**:  A full binary tree is a binary tree where each node has exactly 0 or 2 children. Return a list of all possible full binary trees with N nodes.

Catalan number problem. For each node in the non-leaf nodes, let node be the root.

**905. Sort Array By Parity**: Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.

"High-low" pointers.

**946. Validate Stack Sequences**: Given two sequences `pushed` and `popped` **with distinct values**, return `true` if and only if this could have been the result of a sequence of push and pop operations on an initially empty stack.

Use a stack to simulate the push and pop operations from `pushed` and `popped`. If we can pop, we should do it prior to push because values are distinct and a push will make the previous top value impossible to be popped again.


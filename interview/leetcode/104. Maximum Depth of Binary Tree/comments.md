# 104. Maximum Depth of Binary Tree - Technical Guide

## Problem Statement
Given the root of a binary tree, return its **maximum depth**.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

## Examples
```plaintext
Input: root = [3,9,20,null,null,15,7]
Output: 3

Input: root = [1,null,2]
Output: 2
```

## Constraints
- The number of nodes in the tree is in the range [0, 10^4].
- -100 <= Node.val <= 100

## Approach
This problem is most naturally solved using **Depth First Search (DFS)**. For each node, we compute the depth of its left and right subtrees and take the maximum.

## Python Code (Recursive DFS)
```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def maxDepth(self, root: TreeNode) -> int:
        if not root:
            return 0
        
        left_depth = self.maxDepth(root.left)
        right_depth = self.maxDepth(root.right)

        return max(left_depth, right_depth) + 1
```

## Time and Space Complexity
- **Time Complexity:** O(n), where n is the number of nodes in the tree
- **Space Complexity:** O(h), where h is the height of the tree (recursive call stack)

## Follow-Up
You can also implement the solution iteratively using BFS (level-order traversal).

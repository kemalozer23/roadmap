# 102. Binary Tree Level Order Traversal - Technical Guide

## Problem Statement
Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

## Examples
```plaintext
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]

Input: root = [1]
Output: [[1]]

Input: root = []
Output: []
```

## Constraints
- The number of nodes in the tree is in the range [0, 2000].
- -1000 <= Node.val <= 1000

## Intuition
We are asked for a "level order" traversal, which naturally points to **Breadth-First Search (BFS)**. In BFS, we explore nodes level by level from top to bottom.

## Approach
- Use a queue to facilitate BFS.
- Start by adding the root node to the queue.
- While the queue is not empty:
  - Initialize an empty list for the current level.
  - Process all nodes currently in the queue (this ensures nodes are grouped by levels).
  - For each node:
    - Add its value to the current level list.
    - If it has a left child, add it to the queue.
    - If it has a right child, add it to the queue.
  - After processing the level, add the level list to the final result.

## Python Code
```python
from collections import deque

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def levelOrder(root):
    if not root:
        return []

    result = []
    queue = deque([root])

    while queue:
        level = []
        for _ in range(len(queue)):
            node = queue.popleft()
            level.append(node.val)
            if node.left:
                queue.append(node.left)
            if node.right:
                queue.append(node.right)
        result.append(level)

    return result
```

## Time and Space Complexity
- **Time Complexity:** O(n), where n is the number of nodes in the tree.
- **Space Complexity:** O(n), for storing the queue and the result list.

---

This approach cleanly separates each level and naturally builds the required output using BFS.


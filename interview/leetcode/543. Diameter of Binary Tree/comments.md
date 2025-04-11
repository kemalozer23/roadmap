# 543. Diameter of Binary Tree - Technical Guide

## Problem Statement
Given the root of a binary tree, return the **length of the diameter** of the tree.

The diameter is the length of the **longest path between any two nodes** in the tree. This path may or may not pass through the root.

- The length of a path is the **number of edges** between the nodes.

## Examples
```plaintext
Input: root = [1,2,3,4,5]
Output: 3
Explanation: The longest path is [4,2,1,3] or [5,2,1,3]

Input: root = [1,2]
Output: 1
```

## Constraints
- The number of nodes in the tree is in the range [1, 10^4].
- -100 <= Node.val <= 100

## DSA Concepts Involved
- Tree Traversal
- Depth-First Search (DFS)
- Recursion

## Intuition
For each node, the longest path that **passes through** that node is:
```
left_depth + right_depth
```
We use DFS to calculate the depth of left and right subtrees and update the diameter at each node.

## Python Code (Without Using Libraries)
```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def diameterOfBinaryTree(root):
    max_diameter = [0]

    def dfs(node):
        if not node:
            return 0

        left = dfs(node.left)
        right = dfs(node.right)

        # update the max diameter if needed
        max_diameter[0] = max(max_diameter[0], left + right)

        return 1 + max(left, right)

    dfs(root)
    return max_diameter[0]
```

## Time and Space Complexity
- **Time Complexity:** O(n) — We visit each node once
- **Space Complexity:** O(h) — Call stack of DFS (h is height of tree)

## Follow-Up
- Try solving iteratively using stack-based traversal (less elegant)
- Visualize diameter path using an auxiliary list if needed
# Balanced Binary Tree - Technical Interview Guide

## Problem Statement
Given a binary tree, determine if it is height-balanced.
A binary tree is balanced if:
- The left and right subtrees of every node differ in height by no more than 1.

### Examples
```plaintext
Input: root = [3,9,20,null,null,15,7]
Output: true

Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

Input: root = []
Output: true
```

## Problem Topology
### Category:
- Binary Tree
- DFS / Recursion

### Constraints:
- 0 <= number of nodes <= 5000
- -10^4 <= Node.val <= 10^4

### Concept Tested:
- Depth-First Search (DFS)
- Recursion
- Post-order traversal

## Solution Approach

### 1. Recursive Post-order DFS
We calculate the height of left and right subtree for each node, and check if the difference is more than 1. If yes, the tree is not balanced.

```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def isBalanced(root):
    def dfs(node):
        if not node:
            return 0

        left = dfs(node.left)
        if left == -1:
            return -1

        right = dfs(node.right)
        if right == -1:
            return -1

        if abs(left - right) > 1:
            return -1

        return max(left, right) + 1

    return dfs(root) != -1
```

**Time Complexity:** O(n) - each node is visited once.
**Space Complexity:** O(h) - recursion stack, where h is the height of the tree.

## Edge Cases to Consider
- An empty tree is considered balanced.
- A tree with a single node is balanced.
- Trees that are skewed to one side are not balanced.

## Data Structure & Concept Notes
### What is a Balanced Binary Tree?
A tree where the height of the two subtrees of every node never differs by more than one.

### DFS and Post-order Traversal
Post-order means we first visit the left subtree, then right subtree, and finally the current node — ideal for calculating properties like height.

## Hints for Interview
1. **Recursive Base Case:** Always return height and check condition at the same time.
2. **Early Exit:** Use -1 to signal unbalanced subtree to avoid unnecessary traversal.
3. **Don’t Recalculate:** Avoid computing subtree height multiple times to keep complexity O(n).

This is a classic recursive DFS problem that tests understanding of tree depth and efficient traversal.
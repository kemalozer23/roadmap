# Lowest Common Ancestor of a Binary Search Tree (BST)

## Problem Statement
Given a Binary Search Tree (BST), find the **Lowest Common Ancestor (LCA)** of two given nodes `p` and `q`. The LCA is defined as the lowest node in the BST that has both `p` and `q` as descendants (a node can be a descendant of itself).

## Example
```plaintext
Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
Output: 6

Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
Output: 2

Input: root = [2,1], p = 2, q = 1
Output: 2
```

## Problem Topology
### Category:
- Binary Tree
- BST
- Recursion

### Type of DSA Concept Tested:
- Binary Tree Traversal
- BST properties

## Constraints
- The number of nodes is in the range [2, 10^5]
- Node values are unique.
- p != q, and both p and q exist in the tree.

## Solution Approach
### 1. BST Property Based Recursive Search
In a BST, the left subtree contains smaller values and the right subtree contains greater values.
- If both `p` and `q` are smaller than current node → LCA lies in the left subtree.
- If both are larger → LCA lies in the right subtree.
- If `p <= node <= q` or `q <= node <= p` → current node is LCA.

```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def lowestCommonAncestor(root, p, q):
    if root is None:
        return None

    # If both nodes are smaller, go left
    if p.val < root.val and q.val < root.val:
        return lowestCommonAncestor(root.left, p, q)

    # If both nodes are greater, go right
    elif p.val > root.val and q.val > root.val:
        return lowestCommonAncestor(root.right, p, q)

    # If p and q are on different sides, current node is the LCA
    else:
        return root
```

**Time Complexity:** O(h), where `h` is the height of the tree. In the worst case (skewed tree), h = n.
**Space Complexity:** O(h) due to recursive call stack.

### 2. Iterative Version
```python
def lowestCommonAncestor(root, p, q):
    while root:
        if p.val < root.val and q.val < root.val:
            root = root.left
        elif p.val > root.val and q.val > root.val:
            root = root.right
        else:
            return root
    return None
```

**Time Complexity:** O(h)
**Space Complexity:** O(1)

## Data Structure & Concept Notes
### Binary Search Tree (BST)
- For every node, left child < node < right child.
- This property allows efficient searching and comparisons.

### Lowest Common Ancestor (LCA)
- The deepest node which is ancestor of both given nodes.
- In a BST, LCA logic is simplified using its ordering property.

## Tips for Interviews
- Always clarify whether it’s a BST or general binary tree (solution differs).
- Consider iterative vs recursive approaches.
- Be clear about base cases and comparison logic.
- Think in terms of value comparison, not pointer comparison.

This problem is a classic application of BST traversal logic and is frequently asked to test understanding of tree structures and recursion.
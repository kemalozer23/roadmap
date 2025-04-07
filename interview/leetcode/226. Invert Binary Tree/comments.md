# Invert Binary Tree - Technical Interview Guide

## Problem Statement
Given the root of a binary tree, invert the tree, and return its root.

### Examples
```plaintext
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Input: root = [2,1,3]
Output: [2,3,1]

Input: root = []
Output: []
```

## Problem Topology
### Category:
- Binary Tree
- Tree Traversal

### Constraints:
- The number of nodes in the tree is in the range [0, 100]
- `-100 <= Node.val <= 100`

### Type of DSA Concept Tested:
- **Recursion**
- **Tree Traversal (Preorder / Postorder)**
- **Binary Tree Manipulation**

## Solution Approaches
### 1. Recursive Approach (Most Common)
**Approach:**
- Traverse the tree in a depth-first manner.
- Swap the left and right children of every node.
- Recursively call the function on the left and right subtrees.

**Time Complexity:** O(n) — Visit every node once.
**Space Complexity:** O(h) — Due to recursion stack (h = height of tree).

### 2. Iterative Approach (Using Queue)
**Approach:**
- Use a queue for level-order traversal (BFS).
- For each node, swap its children and enqueue them.

**Time Complexity:** O(n)
**Space Complexity:** O(n) — Due to queue usage in the worst case.

## Code Implementations (Python)
### Recursive Approach
```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def invertTree(self, root: TreeNode) -> TreeNode:
        if root is None:
            return None

        root.left, root.right = self.invertTree(root.right), self.invertTree(root.left)
        return root
```

### Iterative Approach (Using BFS)
```python
from collections import deque

class Solution:
    def invertTree(self, root: TreeNode) -> TreeNode:
        if not root:
            return None

        queue = deque([root])
        while queue:
            current = queue.popleft()
            current.left, current.right = current.right, current.left

            if current.left:
                queue.append(current.left)
            if current.right:
                queue.append(current.right)

        return root
```

## Data Structure & Concept Notes
### What is a Binary Tree?
A tree data structure where each node has at most two children referred to as the left child and the right child.

### What is Recursion in Trees?
A natural way to traverse trees where the function calls itself on the left and right subtrees.

## Hints for a Technical Interview
1. **Recognize the Recursive Nature**: Many tree problems can be solved with recursive calls.
2. **Ask for Input Representation**: Clarify if you're working with arrays, node references, etc.
3. **Draw the Tree**: Helps visualize the swaps.
4. **Know When to Use Iterative vs Recursive**: Depth-first (recursion) vs breadth-first (queue).
5. **Discuss Time and Space Trade-offs**: Especially if tree is skewed (linked-list-like).

## Follow-Up Questions
- Can you invert the tree in-place?
- How would the recursion behave on a skewed tree?
- Can you extend this to n-ary trees?

This question is very popular and frequently asked at companies like Google, Facebook, and Microsoft. It's a great test of recursion fundamentals and binary tree traversal understanding.

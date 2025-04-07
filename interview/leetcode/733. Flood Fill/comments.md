# Flood Fill - Technical Interview Guide

## Problem Statement
You are given an image as an m x n grid of integers where `image[i][j]` represents the pixel value. 
Perform a flood fill starting from position `(sr, sc)` and change the color of all connected pixels (up, down, left, right) that have the same color as the starting pixel to the new given color.

### Examples
```plaintext
Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
Output: [[2,2,2],[2,2,0],[2,0,1]]

Input: image = [[0,0,0],[0,0,0]], sr = 0, sc = 0, color = 0
Output: [[0,0,0],[0,0,0]]
```

## Problem Topology
### Category:
- Matrix
- DFS / BFS
- Recursion

### Constraints:
- 1 <= m, n <= 50
- 0 <= image[i][j], color < 2^16
- 0 <= sr < m
- 0 <= sc < n

### Type of DSA Concept Tested:
- Depth-First Search (DFS)
- Breadth-First Search (BFS)
- Recursion and Base Conditions

## Solution Approaches

### 1. Depth-First Search (Recursive, No Libraries)
```python
def floodFill(image, sr, sc, color):
    original_color = image[sr][sc]
    if original_color == color:
        return image

    def dfs(r, c):
        if (r < 0 or r >= len(image) or 
            c < 0 or c >= len(image[0]) or 
            image[r][c] != original_color):
            return

        image[r][c] = color
        dfs(r+1, c)
        dfs(r-1, c)
        dfs(r, c+1)
        dfs(r, c-1)

    dfs(sr, sc)
    return image
```
**Time Complexity:** O(m * n) — in the worst case, we may visit every cell.  
**Space Complexity:** O(m * n) — due to recursion stack.

### 2. Breadth-First Search (Queue-based, No Libraries)
```python
def floodFill(image, sr, sc, color):
    original_color = image[sr][sc]
    if original_color == color:
        return image

    q = [(sr, sc)]
    while q:
        r, c = q.pop(0)
        if (0 <= r < len(image) and 0 <= c < len(image[0]) 
            and image[r][c] == original_color):
            image[r][c] = color
            q.append((r+1, c))
            q.append((r-1, c))
            q.append((r, c+1))
            q.append((r, c-1))

    return image
```
**Time Complexity:** O(m * n)  
**Space Complexity:** O(m * n)

## Edge Cases to Consider
- The starting pixel already has the target color → No operation needed.
- Image of size 1x1.
- Multiple isolated regions with the same color.

## Data Structure & Concept Notes
### What is DFS?
A depth-first traversal explores as far as possible along one branch before backtracking. It can be implemented via recursion or a stack.

### What is BFS?
A breadth-first traversal explores neighbors level by level. Implemented using a queue.

### Flood Fill Concept
A fundamental operation in graphics (like the bucket tool in MS Paint). It replaces all connected pixels of a certain color with another.

## Hints for a Technical Interview
1. **Base Case Matters**: Always check if the current pixel is within bounds and has the original color.
2. **Early Return**: Handle the case where original and target colors are the same to avoid infinite loops.
3. **Recursion Depth**: Be mindful of Python’s recursion depth if using DFS on large grids.
4. **Traversal Order**: It doesn’t matter here, but consistent logic is important for debugging.

This problem is frequently asked to test graph traversal concepts in a grid structure. It's a good stepping stone before tackling more complex grid DFS/BFS problems like island counting or maze solving.

# 542. 01 Matrix - Technical Guide

## Problem Statement
Given an m x n binary matrix `mat`, return a matrix where each cell contains the distance to the nearest 0.

The distance between two adjacent cells is 1.

---

## Examples
```plaintext
Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
Output: [[0,0,0],[0,1,0],[0,0,0]]

Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
Output: [[0,0,0],[0,1,0],[1,2,1]]
```

---

## Constraints
- m == mat.length
- n == mat[i].length
- 1 <= m, n <= 10^4
- 1 <= m * n <= 10^4
- mat[i][j] is either 0 or 1
- There is at least one 0 in mat

---

## Intuition
We need to compute the distance from each cell with value 1 to its nearest 0. A brute-force method from each 1 to all 0s is too slow. Instead, we use **multi-source BFS**, starting from all 0s and expanding to reach 1s.

---

## Approach: Multi-Source BFS
1. Create a queue and enqueue all 0s.
2. Set distances of 0s to 0 and all other cells to infinity or -1.
3. Perform BFS:
   - For each position in the queue, check its neighbors.
   - If the neighbor hasn’t been visited (distance is -1), set its distance to current + 1 and enqueue it.

---

## Python Code (No library usage except built-ins)
```python
from collections import deque

def updateMatrix(mat):
    rows, cols = len(mat), len(mat[0])
    dist = [[-1 for _ in range(cols)] for _ in range(rows)]
    queue = deque()

    # Step 1: Initialize the queue with all 0s
    for r in range(rows):
        for c in range(cols):
            if mat[r][c] == 0:
                dist[r][c] = 0
                queue.append((r, c))

    directions = [(0, 1), (1, 0), (-1, 0), (0, -1)]

    # Step 2: BFS
    while queue:
        r, c = queue.popleft()
        for dr, dc in directions:
            nr, nc = r + dr, c + dc
            if 0 <= nr < rows and 0 <= nc < cols and dist[nr][nc] == -1:
                dist[nr][nc] = dist[r][c] + 1
                queue.append((nr, nc))

    return dist
```

---

## Time and Space Complexity
- **Time Complexity:** O(m * n), each cell is visited once.
- **Space Complexity:** O(m * n), for the result matrix and queue.

---

## Follow-Up
- Can you solve it in-place with minimal extra memory?
- Consider optimizing for sparse matrices.
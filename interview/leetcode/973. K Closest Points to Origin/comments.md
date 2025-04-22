# 973. K Closest Points to Origin - Technical Guide

## Problem Statement
Given an array of points where `points[i] = [xi, yi]` represents a point on the X-Y plane and an integer `k`, return the `k` closest points to the origin `(0, 0)`.

The distance between two points is the **Euclidean distance**:

\[ \sqrt{(x_1-0)^2 + (y_1-0)^2} = \sqrt{x_1^2 + y_1^2} \]

You may return the answer in **any order**.

---

## Examples

### Example 1
```plaintext
Input: points = [[1,3],[-2,2]], k = 1
Output: [[-2,2]]
Explanation:
- (1,3) -> sqrt(1+9) = sqrt(10)
- (-2,2) -> sqrt(4+4) = sqrt(8)
Since sqrt(8) < sqrt(10), (-2,2) is closer.
```

### Example 2
```plaintext
Input: points = [[3,3],[5,-1],[-2,4]], k = 2
Output: [[3,3],[-2,4]]
Explanation:
Both [[-2,4],[3,3]] are valid outputs.
```

---

## Constraints
- 1 <= k <= points.length <= 10^4
- -10^4 <= xi, yi <= 10^4

---

## Intuition
Rather than computing the actual distance (which involves a square root), we can just compare the **squared distances** since \( \sqrt{a} < \sqrt{b} \) if and only if \( a < b \).

We want the k points with the smallest distances.

Two common approaches:
- Sort all points based on distance and pick the first `k`.
- Use a max-heap of size `k` to maintain the closest points.

---

## Approach 1: Sorting

### Python Code
```python
def kClosest(points, k):
    points.sort(key=lambda p: p[0]**2 + p[1]**2)
    return points[:k]
```

### Complexity
- **Time Complexity:** O(n log n) due to sorting.
- **Space Complexity:** O(1) (ignoring the output).

---

## Approach 2: Max Heap (Efficient when k << n)

### Python Code
```python
import heapq

def kClosest(points, k):
    max_heap = []
    
    for (x, y) in points:
        dist = -(x*x + y*y)  # Negate to simulate max heap
        heapq.heappush(max_heap, (dist, x, y))
        if len(max_heap) > k:
            heapq.heappop(max_heap)
    
    return [[x, y] for (_, x, y) in max_heap]
```

### Complexity
- **Time Complexity:** O(n log k)
- **Space Complexity:** O(k)

---

## Conclusion
- If `k` is close to `n`, sorting is simpler and efficient.
- If `k` is much smaller than `n`, using a max-heap gives better performance.
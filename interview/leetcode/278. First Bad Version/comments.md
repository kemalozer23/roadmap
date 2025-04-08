# 278. First Bad Version - Technical Guide

## Problem Statement
You are a product manager leading a team developing a product. Unfortunately, the latest version fails the quality check. All versions after a bad version are also bad.

You are given an API `bool isBadVersion(version)` which returns whether the version is bad. Your task is to find the first bad version with the minimum number of API calls.

## Examples
```plaintext
Input: n = 5, bad = 4
Output: 4
Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.

Input: n = 1, bad = 1
Output: 1
```

## Constraints
- 1 <= bad <= n <= 2^31 - 1

## Type of DSA Concept Tested
- Binary Search
- Search Space Reduction

## Solution Approach
Use **binary search** to minimize the number of calls to `isBadVersion()`.

### Python Code
```python
# The isBadVersion API is already defined for you.
# def isBadVersion(version: int) -> bool:

def firstBadVersion(n):
    left, right = 1, n
    while left < right:
        mid = left + (right - left) // 2
        if isBadVersion(mid):
            right = mid  # look on the left half
        else:
            left = mid + 1  # look on the right half
    return left
```

### Time & Space Complexity
- **Time Complexity:** O(log n)
- **Space Complexity:** O(1)

## Edge Cases
- If the first version is bad → should return 1
- If the last version is the only bad one → still binary search correctly

## Interview Tips
- Talk through binary search logic step-by-step.
- Emphasize minimizing API calls by reducing search space efficiently.
- Avoid overflow: use `mid = left + (right - left) // 2` instead of `(left + right) // 2`

---
Let me know if you want a visual explanation or code in another language like Java or C++.

# 70. Climbing Stairs - Technical Guide

## Problem Statement
You are climbing a staircase. It takes `n` steps to reach the top.
Each time you can either climb **1 step** or **2 steps**.
Determine how many distinct ways you can climb to the top.

## Examples
```plaintext
Input: n = 2
Output: 2
Explanation:
1. 1 step + 1 step
2. 2 steps

Input: n = 3
Output: 3
Explanation:
1. 1 + 1 + 1
2. 1 + 2
3. 2 + 1
```

## Constraints
- 1 <= n <= 45

## DSA Concepts Involved
- Dynamic Programming
- Fibonacci Sequence

## Intuition
At each step, you can arrive from either:
- `n-1` step (taking 1 step), or
- `n-2` step (taking 2 steps).

So, the recurrence becomes:
```
ways(n) = ways(n-1) + ways(n-2)
```
This is the Fibonacci sequence.

## Python Code (Without Using Libraries)
```python
def climbStairs(n: int) -> int:
    if n == 1:
        return 1
    if n == 2:
        return 2

    first = 1
    second = 2
    for i in range(3, n + 1):
        current = first + second
        first = second
        second = current
    return second
```

## Time and Space Complexity
- **Time Complexity:** O(n)
- **Space Complexity:** O(1) (only constant space is used for variables `first`, `second`, and `current`)

## Follow-Up
You could also solve it recursively with memoization or using dynamic programming arrays, but this space-optimized approach is most efficient for the given constraints.

### Recursive with Memoization
```python
def climbStairs(n: int, memo=None) -> int:
    if memo is None:
        memo = {}
    if n in memo:
        return memo[n]
    if n == 1:
        return 1
    if n == 2:
        return 2

    memo[n] = climbStairs(n - 1, memo) + climbStairs(n - 2, memo)
    return memo[n]
```

### Dynamic Programming with Array
```python
def climbStairs(n: int) -> int:
    if n == 1:
        return 1
    dp = [0] * (n + 1)
    dp[1] = 1
    dp[2] = 2

    for i in range(3, n + 1):
        dp[i] = dp[i - 1] + dp[i - 2]

    return dp[n]
```

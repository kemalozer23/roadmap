# 67. Add Binary - Technical Guide

## Problem Statement
Given two binary strings `a` and `b`, return their sum as a binary string.

## Examples
```plaintext
Input: a = "11", b = "1"
Output: "100"

Input: a = "1010", b = "1011"
Output: "10101"
```

## Constraints
- 1 <= a.length, b.length <= 10^4
- `a` and `b` consist only of '0' or '1' characters.
- Each string does not contain leading zeros except for the zero itself.

## DSA Concepts Involved
- String manipulation
- Binary arithmetic
- Two-pointer technique

## Intuition
Start from the end of both strings and add digit-by-digit (similar to how you'd do column addition by hand), keeping track of a carry.

## Python Code (Without Using Libraries)
```python
def addBinary(a: str, b: str) -> str:
    i = len(a) - 1
    j = len(b) - 1
    carry = 0
    result = []

    while i >= 0 or j >= 0 or carry:
        total = carry
        if i >= 0:
            total += int(a[i])
            i -= 1
        if j >= 0:
            total += int(b[j])
            j -= 1

        result.append(str(total % 2))
        carry = total // 2

    return ''.join(reversed(result))
```

## Time and Space Complexity
- **Time Complexity:** O(max(len(a), len(b)))
- **Space Complexity:** O(max(len(a), len(b))) to store the result list

## Follow-Up
- Can be implemented in-place for reduced space usage.
- Similar logic can be extended to other base arithmetic operations.
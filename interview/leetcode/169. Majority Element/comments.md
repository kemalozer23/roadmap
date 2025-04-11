# 169. Majority Element - Technical Guide

## Problem Statement
Given an array `nums` of size `n`, return the majority element. The majority element is the element that appears **more than** `n / 2` times.
You may assume that the majority element **always exists** in the array.

## Examples
```plaintext
Input: nums = [3,2,3]
Output: 3

Input: nums = [2,2,1,1,1,2,2]
Output: 2
```

## Constraints
- `n == nums.length`
- `1 <= n <= 5 * 10^4`
- `-10^9 <= nums[i] <= 10^9`

## DSA Concepts Involved
- Hash Maps (for naive solution)
- Boyer-Moore Voting Algorithm (for optimal solution)

---

## Optimal Solution (Boyer-Moore Voting Algorithm)
### Intuition
Since we are guaranteed that a majority element exists, we can use a counter approach:
- If the count is 0, we take the current element as the candidate.
- If the current element is the candidate, we increment the count.
- Otherwise, we decrement the count.

This works in **O(n)** time and **O(1)** space.

## Python Code (No Libraries)
```python
def majorityElement(nums):
    count = 0
    candidate = None

    for num in nums:
        if count == 0:
            candidate = num
        if num == candidate:
            count += 1
        else:
            count -= 1

    return candidate
```

## Time and Space Complexity
- **Time Complexity:** O(n)
- **Space Complexity:** O(1)

## Follow-Up
The Boyer-Moore Voting Algorithm is a clever and efficient solution. If the assumption of guaranteed majority is not given, you'd need a second pass to confirm the result by counting occurrences of the candidate.

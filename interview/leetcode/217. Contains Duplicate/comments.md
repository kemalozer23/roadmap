# 217. Contains Duplicate - Technical Guide

## Problem Statement
Given an integer array `nums`, return `true` if any value appears **at least twice** in the array, and return `false` if every element is **distinct**.

## Examples
```plaintext
Input: nums = [1,2,3,1]
Output: true
Explanation: The element 1 occurs at the indices 0 and 3.

Input: nums = [1,2,3,4]
Output: false
Explanation: All elements are distinct.

Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true
```

## Constraints
- 1 <= nums.length <= 10^5
- -10^9 <= nums[i] <= 10^9

## Intuition
We need to determine whether any number appears more than once in the array. A brute-force approach using nested loops would be inefficient for large arrays. Instead, we can use a data structure that allows constant-time lookup to track previously seen elements.

## Approach (Without Libraries)
Use a set-like behavior with a dictionary to store seen elements.

## Python Code (No library usage)
```python
def containsDuplicate(nums):
    seen = {}  # acts like a set
    for num in nums:
        if num in seen:
            return True
        seen[num] = True
    return False
```

## Time and Space Complexity
- **Time Complexity:** O(n), where n is the length of the input array.
- **Space Complexity:** O(n), for storing seen elements.

## Follow-Up
- If you can sort the array first (modifying the array is allowed), then check adjacent elements: this can reduce space complexity to O(1) but increases time to O(n log n).

```python
# Optional Follow-Up Approach (modifies the input)
def containsDuplicateSorted(nums):
    nums.sort()
    for i in range(1, len(nums)):
        if nums[i] == nums[i - 1]:
            return True
    return False
```
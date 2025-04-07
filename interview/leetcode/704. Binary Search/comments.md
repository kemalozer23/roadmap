# Binary Search - Technical Interview Guide

## Problem Statement
Given a sorted array `nums` and an integer `target`, return the index of the target if found. Otherwise, return -1.

### Examples
```plaintext
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4

Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
```

## Problem Topology
### Category:
- Searching

### Constraints:
- `1 <= nums.length <= 10^4`
- `-10^4 < nums[i], target < 10^4`
- All the integers in `nums` are unique
- `nums` is sorted in ascending order

### Type of DSA Concept Tested:
- **Binary Search**
- **Algorithm Efficiency (Logarithmic Time)**

## Solution Approach: Binary Search (Iterative)

**Approach:**
- Set two pointers: `left = 0`, `right = len(nums) - 1`
- While `left <= right`, compute `mid = (left + right) // 2`
- If `nums[mid] == target`, return `mid`
- If `nums[mid] < target`, search in the right half (`left = mid + 1`)
- If `nums[mid] > target`, search in the left half (`right = mid - 1`)
- If not found, return -1

**Time Complexity:** O(log n)
**Space Complexity:** O(1)

```python
def binary_search(nums, target):
    left, right = 0, len(nums) - 1

    while left <= right:
        mid = (left + right) // 2

        if nums[mid] == target:
            return mid
        elif nums[mid] < target:
            left = mid + 1
        else:
            right = mid - 1

    return -1
```

## Edge Cases to Consider
- Empty list → return -1
- Single-element list → check if it matches target
- Target less than all elements or greater than all elements

## Data Structure & Concept Notes

### What is Binary Search?
Binary Search is a divide-and-conquer algorithm that repeatedly divides the sorted input array into two halves and checks where the target could exist. It reduces the time complexity to O(log n) compared to linear search (O(n)).

### Requirements for Binary Search:
- The array must be sorted

## Hints for a Technical Interview
1. **Mention Logarithmic Complexity:** Point out how binary search scales efficiently.
2. **Edge Conditions:** Make sure to handle empty arrays and off-by-one errors in the loop.
3. **Avoid Overflow:** In some languages, `mid = left + (right - left) // 2` is safer.
4. **Ask Clarifying Questions:** Is the input always sorted? What if duplicates are allowed?

This is a classic interview problem frequently asked to test understanding of algorithmic thinking and the binary search pattern.

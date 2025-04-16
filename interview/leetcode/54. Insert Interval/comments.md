# 57. Insert Interval - Technical Guide

## Problem Statement
You are given an array of non-overlapping intervals sorted by start time and a new interval. Insert the new interval and merge if necessary.

## Examples
```plaintext
Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
```

## Constraints
- 0 <= intervals.length <= 10^4
- intervals[i].length == 2
- 0 <= starti <= endi <= 10^5
- intervals is sorted by starti in ascending order
- newInterval.length == 2
- 0 <= start <= end <= 10^5

## Intuition
Since the input list is already sorted and non-overlapping, we can iterate through it and add intervals that come before the new interval, merge overlapping ones, and then add the rest.

## Approach
- Iterate through intervals
  - Add intervals that end before newInterval starts
  - Merge overlapping intervals with newInterval
  - Add intervals that start after newInterval ends

## Python Code (No Libraries)
```python
def insert(intervals, newInterval):
    merged = []
    i = 0
    n = len(intervals)

    # Add all intervals before newInterval
    while i < n and intervals[i][1] < newInterval[0]:
        merged.append(intervals[i])
        i += 1

    # Merge overlapping intervals
    while i < n and intervals[i][0] <= newInterval[1]:
        newInterval[0] = min(newInterval[0], intervals[i][0])
        newInterval[1] = max(newInterval[1], intervals[i][1])
        i += 1
    merged.append(newInterval)

    # Add remaining intervals
    while i < n:
        merged.append(intervals[i])
        i += 1

    return merged
```

## Time and Space Complexity
- **Time Complexity:** O(n) where n is the number of intervals
- **Space Complexity:** O(n) for the output list

## Follow-Up
- What if the input intervals are not sorted? You would need to sort them first.
- Can this be done in-place? Yes, but at the cost of code readability and complexity.
# 53. Maximum Subarray - Kadane's Algorithm Explained

## Problem Statement
Given an integer array `nums`, find the **subarray** with the largest sum, and return **its sum**.

## Examples
```plaintext
Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: The subarray [4,-1,2,1] has the largest sum 6.

Input: nums = [1]
Output: 1

Input: nums = [5,4,-1,7,8]
Output: 23
Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
```

## Constraints
- 1 <= nums.length <= 10^5
- -10^4 <= nums[i] <= 10^4

---

## Intuition
We want to find a **contiguous subarray** that produces the **maximum possible sum**. A brute-force approach would check all subarrays which leads to O(n^2) time — too slow.

Instead, we use **Kadane's Algorithm** which works in O(n) time by keeping track of the maximum sum **ending at each index**.

---

## Approach (Kadane's Algorithm, No Libraries)

```python
def maxSubArray(nums):
    max_sum = nums[0]
    current_sum = nums[0]

    for i in range(1, len(nums)):
        current_sum = max(nums[i], current_sum + nums[i])
        max_sum = max(max_sum, current_sum)

    return max_sum
```

### Step-by-Step Example:
- Start with `current_sum = nums[0]`, `max_sum = nums[0]`
- For each element in the array:
  - Either start a new subarray at the current index, or extend the existing subarray
  - Update `max_sum` if current subarray is better

---

## Time and Space Complexity
- **Time Complexity:** O(n)
- **Space Complexity:** O(1) (constant extra space)

---

## Follow-Up
- You can also modify this approach to **return the subarray itself** instead of just its sum if needed.

```python
def maxSubArrayWithSubarray(nums):
    max_sum = current_sum = nums[0]
    start = end = s = 0

    for i in range(1, len(nums)):
        if nums[i] > current_sum + nums[i]:
            current_sum = nums[i]
            s = i
        else:
            current_sum += nums[i]

        if current_sum > max_sum:
            max_sum = current_sum
            start = s
            end = i

    return max_sum, nums[start:end+1]
```

---

## Final Notes
- Kadane’s algorithm is efficient and widely used in interview questions.
- It handles negative numbers correctly and avoids extra space.
# 15. 3Sum - Technical Guide

## Problem Statement
Given an integer array `nums`, return all the triplets `[nums[i], nums[j], nums[k]]` such that:
- `i != j`, `i != k`, and `j != k`
- `nums[i] + nums[j] + nums[k] == 0`

**Note:** The solution set must not contain duplicate triplets.

## Examples
```plaintext
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation:
- nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0
- nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0
- nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0
- Distinct triplets: [-1,0,1] and [-1,-1,2]

Input: nums = [0,1,1]
Output: []
Explanation: No triplet sums to 0.

Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: Only one triplet sums to 0.
```

## Constraints
- 3 <= nums.length <= 3000
- -10^5 <= nums[i] <= 10^5

## Intuition
Finding three numbers that add up to zero efficiently requires reducing the complexity compared to brute force (O(n^3)). Sorting the array allows us to use the two-pointer technique to check pairs efficiently.

## Approach
- **Sort** the array.
- **Iterate** through the array with index `i`, and for each element:
  - Use a **two-pointer** approach (`left` and `right`) starting from `i+1` and the end of the array.
  - Calculate the **sum**:
    - If `sum == 0`, record the triplet and move both pointers while avoiding duplicates.
    - If `sum < 0`, increment `left`.
    - If `sum > 0`, decrement `right`.
- **Skip duplicates** to avoid repeated triplets.

## Python Code
```python
def threeSum(nums):
    nums.sort()
    result = []
    n = len(nums)

    for i in range(n):
        if i > 0 and nums[i] == nums[i-1]:
            continue  # Skip duplicate 'i'
        
        left, right = i + 1, n - 1
        while left < right:
            total = nums[i] + nums[left] + nums[right]

            if total == 0:
                result.append([nums[i], nums[left], nums[right]])
                left += 1
                right -= 1
                while left < right and nums[left] == nums[left-1]:
                    left += 1
                while left < right and nums[right] == nums[right+1]:
                    right -= 1
            elif total < 0:
                left += 1
            else:
                right -= 1

    return result
```

## Time and Space Complexity
- **Time Complexity:** O(n^2)
  - Sorting takes O(n log n)
  - Two pointers loop through the array in O(n^2) in total.
- **Space Complexity:** O(1) (excluding the space needed for the output list)

## Follow-Up
- Could be further optimized by stopping early if the current number is positive and no triplet will sum to 0.


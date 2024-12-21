# Best Time to Buy and Sell Stock: Hints and Approach

## Problem Type
This is a **single-pass** and **dynamic tracking** problem. The goal is to track the minimum price seen so far and calculate the potential profit for every price after that.

## Clarify in an Interview
1. **Confirm**:
   - Only one transaction (buy and sell) is allowed.
2. **Ask**:
   - Should the solution return `0` if no profit is possible?
3. **Discuss**:
   - Time complexity constraints—**O(n)** is optimal.

## High-level Approach
1. Traverse the array once while keeping track of:
   - The **minimum price** encountered so far.
   - The **maximum profit** achievable at each step by calculating `current_price - min_price`.

## Key Points to Articulate in an Interview

### Explain the Problem
- **Objective**: Maximize profit by finding the smallest price to buy and the largest price to sell after it.
- **Dynamic Tracking**: Maintain a dynamic minimum price as you traverse the array.

### Optimal Approach
- Instead of using **nested loops** to compare every pair of days (**O(n²)**), optimize to **O(n)** by:
  - Tracking the minimum price.
  - Calculating profits dynamically in a single pass.

### Edge Case Handling
- If the array is empty or all prices are non-increasing, the profit will remain **0** since no transactions are possible.

### Profit Calculation
- For each price:
  - Update the **minimum price** if the current price is lower.
  - Calculate the potential profit if the current price is sold after the minimum price and update the **maximum profit**.

## Tricks for Efficiency
1. **Single Pass**: Avoid multiple loops by maintaining the minimum price and profit in a single traversal.
2. **Avoid Extra Space**: Use variables (`minPrice` and `maxProfit`) instead of additional data structures, ensuring **O(1)** space complexity.

## Topology Insight
This is a **maximum subarray problem** in disguise, similar to **Kadane's Algorithm** for finding the maximum sum of a subarray.

### Variants
- Allowing multiple transactions (e.g., LeetCode Problem 122).
- Introducing transaction fees or cooldown periods.

## Optimal Solution Structure
The implementation efficiently tracks the minimum price and maximum profit in a single traversal of the array.
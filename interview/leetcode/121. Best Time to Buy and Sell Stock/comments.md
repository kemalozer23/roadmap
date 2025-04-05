# Best Time to Buy and Sell Stock - Technical Interview Guide

## Problem Statement
You are given an array `prices` where `prices[i]` is the price of a given stock on the `i`-th day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return `0`.

### Examples
```plaintext
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6 - 1 = 5.

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: No transaction is possible. Max profit = 0.
```

## Problem Topology
### Category:
- Arrays
- Greedy Algorithms
- Dynamic Programming (1D)

### Constraints:
- `1 <= prices.length <= 10^5`
- `0 <= prices[i] <= 10^4`

### Type of DSA Concept Tested:
- **Greedy Strategy**: Keep track of the minimum price so far and calculate max profit.
- **Array Traversal**: One-pass traversal to check and update conditions.
- **Dynamic Programming (Conceptual)**: Similar to tracking state over iterations, like max-so-far and min-so-far.

## Solution Approach
### 1. One-Pass Greedy Approach (Optimal)
**Approach:**
- Initialize `min_price` as infinity and `max_profit` as 0.
- Traverse the array:
  - If the current price is lower than `min_price`, update `min_price`.
  - Otherwise, calculate the profit `price - min_price` and update `max_profit` if it is greater than the current `max_profit`.

**Time Complexity:** O(n) — Traverse the array once.
**Space Complexity:** O(1) — Constant extra space.

## Code Implementation (Python)
```python
def maxProfit(prices):
    min_price = float('inf')
    max_profit = 0

    for price in prices:
        if price < min_price:
            min_price = price
        else:
            max_profit = max(max_profit, price - min_price)

    return max_profit
```

## Data Structure & Concept Notes
### What is a Greedy Algorithm?
A **greedy algorithm** builds up a solution piece by piece, always choosing the next piece that offers the most immediate benefit. In this case, it chooses the lowest price to buy and highest price after it to sell.

### What is Array Traversal?
**Array traversal** is the process of accessing each element of an array exactly once, which is what we do here to find the optimal buy and sell days.

## Hints for a Technical Interview
1. **Brute Force First**: Talk about comparing every pair (O(n^2)), then improve.
2. **Focus on the Buy Day**: Track the minimum so far — that is your best buy option.
3. **Greedy Pattern**: Always maximize profit as you iterate.
4. **Edge Cases**: Array with 1 element, decreasing array.
5. **Explain Time Complexity**: Why is O(n) optimal here?

## Follow-Up Questions
- What if you can buy and sell multiple times (multiple transactions)?
- What if there is a transaction fee on each trade?
- What if you must hold for at least `k` days before selling?

This is a foundational algorithm question that frequently appears in interviews at companies like Amazon, Microsoft, and Google. Mastery of this pattern helps in many greedy/optimization problems.

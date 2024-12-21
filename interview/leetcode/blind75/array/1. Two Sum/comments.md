# Two Sum Problem: Hints and Approach

## Problem Type
This is a classic **hashing problem**. The goal is to find pairs of numbers that add up to the target efficiently.

## Clarify in an Interview
1. **Constraints**:
   - Only one solution exists.
   - Indices of the same number can't be used twice.
2. **Ask**:
   - Is the input array sorted? (It's not here.)
   - Is it acceptable to return the indices in any order?

## High-level Approach
1. Use a hash map to store numbers and their indices as you iterate through the array.
2. For each number:
   - Calculate its complement (`target - current_number`).
   - Check if the complement exists in the hash map.
   - If it exists, return the indices of the current number and its complement.

## Key Points to Articulate in an Interview

### Naive Approach and Optimization
- **Naive Approach**: Use nested loops to check all pairs, resulting in **O(n²)** time complexity.
- **Optimization**: Use a hash map to store and look up complements efficiently, reducing complexity to **O(n)**.

### Explain the Hash Map
- **Purpose**: Store each number and its index while traversing the array.
- **Benefit**: When a number's complement is found in the map, the solution is identified immediately.

### Handle Edge Cases
- Small arrays or negative numbers can be handled by adhering to problem constraints (e.g., a valid solution always exists).

### Throw an Exception
- Although the problem guarantees one solution, adding an exception ensures safety for unexpected inputs.

## Tricks for Efficiency
1. **One-pass Solution**: Iterate through the array only once, achieving **O(n)** time complexity.
2. **Minimized Space**: The hash map stores each number only once, ensuring space efficiency.

## Topology Insight
This is a **pair-sum problem**, forming the basis for more complex challenges like:
- Finding triplets or subsets with specific properties.
- Variants:
  - Finding pairs in sorted arrays.
  - Problems requiring all pairs, not just one.

## Optimal Solution Structure
The implementation leverages the hash map approach, ensuring both time and space efficiency.

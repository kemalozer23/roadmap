# Product Except Self: Hints and Approach

## Problem Type
This is a **prefix and suffix product problem**. The goal is to calculate the product of all elements except the current one without using division.

## Clarify in an Interview
1. **Confirm**:
   - That the product of prefixes and suffixes fits within a 32-bit integer.
2. **Ask**:
   - If modifying the input array is allowed.

## High-level Approach
1. Use two passes through the array:
   - **First pass**: Compute the product of all elements to the left of each index.
   - **Second pass**: Compute the product of all elements to the right of each index and multiply it with the result from the first pass.

## Key Points to Articulate in an Interview

### Why Division is Avoided
- "Division can lead to precision issues or division by zero errors. This approach avoids such pitfalls by using prefix and suffix products."

### Space Complexity
- "We use the result array to store the output. The additional variable for tracking right products doesn’t grow with input size, so the extra space complexity is **O(1)**."

### Edge Cases
1. Single-element arrays:
   - "The problem guarantees **n ≥ 2**, so this case doesn't arise."
2. Arrays containing zeros:
   - "For indices with a zero, the output depends on whether it's the only zero in the array or not."

## Tricks for Efficiency
1. Reuse the result array to store both left and right products, minimizing space usage.
2. Initialize prefix/suffix products carefully to avoid boundary errors.

## Topology Insight
This is a **prefix-suffix product problem**, a common pattern in array manipulation.

### Variants
- Calculating the **sum** instead of the product.
- Extending to **2D arrays** for prefix-suffix calculations.

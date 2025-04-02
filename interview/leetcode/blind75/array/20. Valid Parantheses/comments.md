# Valid Parentheses - Technical Interview Guide

## Problem Statement
Given a string `s` containing just the characters `'('`, `')'`, `'{'`, `'}'`, `'['`, and `']'`, determine if the input string is valid.

A string is valid if:
- Open brackets must be closed by the same type of brackets.
- Open brackets must be closed in the correct order.
- Every closing bracket has a corresponding open bracket of the same type.

### Examples
```plaintext
Input: s = "()"
Output: true

Input: s = "()[]{}"
Output: true

Input: s = "(]"
Output: false

Input: s = "([])"
Output: true
```

## Problem Topology
### Category:
- Stack-based problem
- String processing

### Constraints:
- `1 <= s.length <= 10^4`
- `s` consists of parentheses only `'()[]{}'`

### Type of DSA Concept Tested:
- **Stack Data Structure**: Used to track open brackets and match them with closing brackets.
- **LIFO Principle (Last-In-First-Out)**: Ensures that the most recent opening bracket is matched with the corresponding closing bracket.
- **Hash Map (Optional Enhancement)**: Can be used for quick lookup of matching pairs.

## Solution Approaches
### 1. Stack-Based Solution (Optimal)
**Approach:**
1. Use a stack to keep track of opening brackets.
2. Iterate through the string:
   - If an opening bracket is encountered, push it onto the stack.
   - If a closing bracket is encountered, check if the stack is empty:
     - If empty, return `false` (no matching opening bracket).
     - Otherwise, pop from the stack and check if it matches the closing bracket.
3. After processing the entire string, the stack should be empty for a valid input.

**Time Complexity:** O(n) - We traverse the string once.
**Space Complexity:** O(n) - In the worst case, the stack holds all opening brackets.

### 2. Using a Hash Map + Stack (Optimized for Readability)
**Approach:**
- Store matching pairs in a dictionary: `{')': '(', '}': '{', ']': '['}`.
- Iterate through the string and use a stack as in Approach 1.

## Code Implementation (Python)
### Stack-Based Approach
```python
def isValid(s):
    stack = []
    mapping = {')': '(', '}': '{', ']': '['}
    
    for char in s:
        if char in mapping:
            top_element = stack.pop() if stack else '#'
            if mapping[char] != top_element:
                return False
        else:
            stack.append(char)
    
    return not stack
```

### Edge Cases to Consider
1. **Empty String** (`s = ""`): Should return `true` as it's trivially valid.
2. **Single Opening or Closing Bracket** (`s = "("` or `s = ")"`): Should return `false`.
3. **Mismatched Brackets** (`s = "(]"`): Should return `false`.
4. **Nested and Interleaved Brackets** (`s = "([])"` and `s = "([{}])"`): Should return `true`.
5. **Long Inputs** (`s` with 10^4 characters): The solution should run efficiently.

## Hints for a Technical Interview
1. **Ask Clarifying Questions**: Ensure you understand the constraints and expected behavior.
2. **Think of Edge Cases**: What happens with empty strings, odd-length inputs, or all closing brackets?
3. **Start with a Naïve Approach**: Discuss a brute-force solution (like checking all combinations) before optimizing.
4. **Mention Data Structures**: Highlight why a stack is the best fit for this problem.
5. **Analyze Time and Space Complexity**: Explain why O(n) time and O(n) space is optimal.
6. **Write Clean Code**: Use descriptive variable names and comments.

## Follow-Up Questions
- Can you solve this problem without using extra space (without a stack)?
- How would you modify the solution if brackets could be nested but of arbitrary types (e.g., `<`, `>`, `|`, etc.)?
- Can you optimize the space complexity?

This problem is commonly asked in technical interviews for companies like Amazon, Google, and Microsoft. Mastering it will help in solving similar problems involving stack-based parsing and validation.

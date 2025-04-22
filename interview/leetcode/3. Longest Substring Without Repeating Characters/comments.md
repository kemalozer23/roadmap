# 3. Longest Substring Without Repeating Characters - Technical Guide

## Problem Statement
Given a string `s`, find the **length** of the longest substring without repeating characters.

## Examples
```plaintext
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
(Note: "pwke" is a subsequence, not a substring.)
```

## Constraints
- 0 <= s.length <= 5 * 10^4
- `s` consists of English letters, digits, symbols, and spaces.

## Intuition
To find the longest substring without repeating characters, we can use the **sliding window** technique:
- Expand the window when the character is unique.
- Shrink the window from the left when a repeated character is encountered.

We use a set or dictionary to keep track of characters and their indices.

## Approach

### Sliding Window with HashSet
1. Initialize a set to store characters.
2. Use two pointers (`left` and `right`) to represent the window.
3. Expand the `right` pointer to add new characters.
4. If a character is repeated, remove characters from the `left` until it is unique.
5. Track the maximum window size.

### Python Code
```python
def lengthOfLongestSubstring(s):
    char_set = set()
    left = 0
    max_length = 0

    for right in range(len(s)):
        while s[right] in char_set:
            char_set.remove(s[left])
            left += 1
        char_set.add(s[right])
        max_length = max(max_length, right - left + 1)

    return max_length
```

### Alternative Approach: Dictionary for Faster Index Jumps
```python
def lengthOfLongestSubstring(s):
    char_index = {}
    max_length = 0
    left = 0

    for right in range(len(s)):
        if s[right] in char_index and char_index[s[right]] >= left:
            left = char_index[s[right]] + 1
        char_index[s[right]] = right
        max_length = max(max_length, right - left + 1)

    return max_length
```

## Time and Space Complexity
- **Time Complexity:** O(n), where n is the length of the string. Each character is visited at most twice.
- **Space Complexity:** O(min(n, m)), where m is the size of the character set (e.g., 128 for ASCII).

## Key Points
- Sliding window technique is perfect for problems dealing with contiguous sequences.
- Using a dictionary to store the latest index allows faster jumps, avoiding unnecessary steps.
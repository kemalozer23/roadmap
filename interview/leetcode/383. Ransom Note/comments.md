# 383. Ransom Note - Technical Guide

## Problem Statement
Given two strings `ransomNote` and `magazine`, return `true` if `ransomNote` can be constructed using the letters from `magazine`.
Each letter in `magazine` can only be used **once** in `ransomNote`.

## Examples
```plaintext
Input: ransomNote = "a", magazine = "b"
Output: false

Input: ransomNote = "aa", magazine = "ab"
Output: false

Input: ransomNote = "aa", magazine = "aab"
Output: true
```

## Constraints
- 1 <= ransomNote.length, magazine.length <= 10^5
- `ransomNote` and `magazine` consist of lowercase English letters

## Type of DSA Concept Tested
- Hashing
- Frequency Counting

## Solution Approach
Use a frequency counter (dictionary or array) to count the characters in `magazine`, and then check if each character in `ransomNote` exists in sufficient quantity.

### Python Code (Without Using Libraries)
```python
def canConstruct(ransomNote: str, magazine: str) -> bool:
    count = [0] * 26  # There are only 26 lowercase English letters

    for ch in magazine:
        count[ord(ch) - ord('a')] += 1

    for ch in ransomNote:
        count[ord(ch) - ord('a')] -= 1
        if count[ord(ch) - ord('a')] < 0:
            return False

    return True
```

### Time & Space Complexity
- **Time Complexity:** O(n + m) where n = len(ransomNote), m = len(magazine)
- **Space Complexity:** O(1) since the alphabet has only 26 lowercase characters

## Follow-Up
- Can you implement it in C or C++ with similar logic?
- How would you handle this if extended to all Unicode characters?

Let me know if you want a visual breakdown or other language implementations.

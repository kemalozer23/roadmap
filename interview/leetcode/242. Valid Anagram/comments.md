# Valid Anagram - Technical Interview Guide

## Problem Statement
Given two strings `s` and `t`, return `true` if `t` is an anagram of `s`, and `false` otherwise.

### Examples
```plaintext
Input: s = "anagram", t = "nagaram"
Output: true

Input: s = "rat", t = "car"
Output: false
```

## Problem Topology
### Category:
- String
- Hashing / Frequency Count

### Constraints:
- `1 <= s.length, t.length <= 5 * 10^4`
- `s` and `t` consist of lowercase English letters.

### Type of DSA Concept Tested:
- **Hash Map / Frequency Counter**
- **Sorting (as alternate approach)**
- **Character Count Matching**

## Solution Approaches

### 1. Hash Map / Frequency Count Approach (Optimal Without Libraries)
**Approach:**
- Use a dictionary to count the frequency of each character in `s`.
- Decrease the count for each character in `t`.
- If all counts become zero and no mismatches are found, return `True`.

**Time Complexity:** O(n) — one pass to count characters.
**Space Complexity:** O(1) — only 26 lowercase letters, so constant auxiliary space.

```python
def isAnagram(s: str, t: str) -> bool:
    if len(s) != len(t):
        return False

    count = {}

    for char in s:
        count[char] = count.get(char, 0) + 1

    for char in t:
        if char not in count:
            return False
        count[char] -= 1
        if count[char] < 0:
            return False

    return True
```

### 2. Sorting Approach
**Approach:**
- Sort both strings and compare.

**Time Complexity:** O(n log n)
**Space Complexity:** O(n) — due to sorted copies.

```python
def isAnagram(s: str, t: str) -> bool:
    return sorted(s) == sorted(t)
```

## Edge Cases to Consider
1. **Different Lengths**: `s = "a"`, `t = "aa"` → return false early.
2. **Empty Strings**: `s = ""`, `t = ""` → return true.
3. **Same Letters, Different Frequency**: `s = "aabb"`, `t = "ab"` → false.

## Data Structure & Concept Notes
### What is a Hash Map?
A data structure that maps keys to values with average O(1) time complexity for insertion and lookup. In this problem, we use it to count occurrences of each character.

### What is an Anagram?
A rearrangement of letters of one string to form another. Character counts must match exactly.

## Hints for a Technical Interview
1. **Think Frequency**: The definition of anagram revolves around identical character frequencies.
2. **Ask About Character Set**: Clarify if only lowercase English letters are allowed or if it includes Unicode.
3. **Mention Time Complexity**: Prefer the O(n) hash map solution for large inputs.
4. **Know Alternatives**: Sorting is also valid but less optimal.

## Follow-Up Question
**What if the inputs contain Unicode characters?**
- You can still use a dictionary to count characters.
- Remember that Unicode characters can vary in range and encoding, so handling them with custom frequency mapping is still feasible.

This problem is popular at interviews with companies like Facebook, Amazon, and Google. It’s simple yet effective at testing knowledge of hashing, sorting, and basic string manipulation.
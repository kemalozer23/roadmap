# 409. Longest Palindrome - Technical Guide

## Problem Statement
Given a string `s` which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.

Letters are case sensitive, so for example, "Aa" is not a palindrome.

---

## Examples
```plaintext
Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.

Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.
```

---

## Constraints
- 1 <= s.length <= 2000
- s consists of lowercase and/or uppercase English letters only.

---

## DSA Concepts Involved
- Hash Map / Frequency Counting
- Greedy Algorithm

---

## Intuition
To form a palindrome:
- We can pair characters (e.g., two 'a's, two 'b's, etc.).
- At most one character can appear in the middle (for odd-counted characters).

---

## Python Code (Without Using Libraries)
```python
def longestPalindrome(s: str) -> int:
    count = [0] * 128  # ASCII size
    for char in s:
        count[ord(char)] += 1

    length = 0
    odd_found = False
    for c in count:
        if c % 2 == 0:
            length += c
        else:
            length += c - 1
            odd_found = True

    return length + 1 if odd_found else length
```

---

## Time and Space Complexity
- **Time Complexity:** O(n), where n is the length of the string.
- **Space Complexity:** O(1), fixed-size array for ASCII characters.

---

## Follow-Up
- What if the input includes Unicode characters beyond ASCII?
- Consider edge cases where all characters are unique or all are the same.

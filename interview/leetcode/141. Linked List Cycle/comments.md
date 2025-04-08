# 141. Linked List Cycle - Technical Guide

## Problem Statement
Given the `head` of a linked list, determine if the linked list contains a cycle.

A cycle occurs if a node can be reached again by continuously following the `next` pointer. The position `pos` is the index where the tail connects, but it's only for visualization purposes and not part of the function signature.

### Examples
```plaintext
Input: head = [3,2,0,-4], pos = 1
Output: true

Input: head = [1,2], pos = 0
Output: true

Input: head = [1], pos = -1
Output: false
```

## Constraints
- Number of nodes in the list: [0, 10^4]
- Node values: [-10^5, 10^5]
- `pos` is -1 or a valid index in the list.

## Type of DSA Concept Tested
- Linked List Traversal
- Cycle Detection
- Floyd's Tortoise and Hare Algorithm

## Solution Approach

### Floyd's Cycle Detection Algorithm (Tortoise and Hare)
Use two pointers:
- **slow**: moves one step at a time
- **fast**: moves two steps at a time

If there's a cycle, `fast` will eventually meet `slow`. If not, `fast` will reach the end.

```python
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def hasCycle(head):
    slow = head
    fast = head

    while fast and fast.next:
        slow = slow.next
        fast = fast.next.next
        if slow == fast:
            return True

    return False
```

### Time & Space Complexity
- **Time Complexity:** O(n)
- **Space Complexity:** O(1) — constant memory used

## Follow-Up
Can you solve it using O(1) memory?
> ✅ Yes, Floyd's algorithm uses constant space.

## Edge Cases
- Empty list → return False
- One node pointing to itself → return True
- Linear list without cycle → return False
- Large cycle at the end → still returns True

## Interview Tips
- Mention using hash sets for cycle detection, but it takes O(n) space.
- Prefer Floyd’s algorithm for optimal memory usage.
- Carefully handle edge conditions like empty list and single node.

---
Let me know if you'd like the code in C#, Java, or C++ as well.
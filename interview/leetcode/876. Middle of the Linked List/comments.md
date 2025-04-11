# 876. Middle of the Linked List - Technical Guide

## Problem Statement
Given the head of a singly linked list, return the middle node of the linked list.

If there are two middle nodes, return the **second** middle node.

## Examples
```plaintext
Input: head = [1,2,3,4,5]
Output: [3,4,5]
Explanation: The middle node of the list is node 3.

Input: head = [1,2,3,4,5,6]
Output: [4,5,6]
Explanation: There are two middle nodes (3 and 4), return the second one.
```

## Constraints
- The number of nodes in the list is in the range [1, 100].
- 1 <= Node.val <= 100

## Intuition
Use two pointers:
- One moves one step at a time (slow)
- The other moves two steps at a time (fast)

When the fast pointer reaches the end, the slow pointer will be at the middle.

## Python Code (Without Using Libraries)
```python
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def middleNode(head):
    slow = head
    fast = head

    while fast and fast.next:
        slow = slow.next
        fast = fast.next.next

    return slow
```

## Time and Space Complexity
- **Time Complexity:** O(n), where n is the number of nodes in the list
- **Space Complexity:** O(1), no additional space used

## Follow-Up
- You can also solve this by counting the length of the list first, then iterating to the middle, but that uses two passes. The fast/slow pointer method is more optimal with only one pass.
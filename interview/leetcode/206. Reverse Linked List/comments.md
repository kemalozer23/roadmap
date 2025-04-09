# 206. Reverse Linked List - Technical Guide

## Problem Statement
Given the head of a singly linked list, reverse the list and return the reversed list.

## Examples
```plaintext
Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]

Input: head = [1,2]
Output: [2,1]

Input: head = []
Output: []
```

## Constraints
- The number of nodes in the list is in the range [0, 5000].
- -5000 <= Node.val <= 5000

## Follow Up
Can you implement both iterative and recursive solutions?

---

## Iterative Approach
```python
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def reverseList(head):
    prev = None
    current = head
    while current:
        next_node = current.next
        current.next = prev
        prev = current
        current = next_node
    return prev
```

## Recursive Approach
```python
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def reverseList(head):
    if not head or not head.next:
        return head
    reversed_head = reverseList(head.next)
    head.next.next = head
    head.next = None
    return reversed_head
```

## Time and Space Complexity
### Iterative
- **Time Complexity:** O(n)
- **Space Complexity:** O(1)

### Recursive
- **Time Complexity:** O(n)
- **Space Complexity:** O(n) due to the call stack
# Merge Two Sorted Lists - Technical Interview Guide

## Problem Statement
You are given the heads of two sorted linked lists `list1` and `list2`.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

### Examples
```plaintext
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]

Input: list1 = [], list2 = []
Output: []

Input: list1 = [], list2 = [0]
Output: [0]
```

## Problem Topology
### Category:
- Linked List
- Recursion / Iteration

### Constraints:
- The number of nodes in both lists is in the range [0, 50].
- -100 <= Node.val <= 100
- Both `list1` and `list2` are sorted in non-decreasing order.

### Type of DSA Concept Tested:
- **Linked List Traversal**: Requires the ability to navigate and manipulate pointers to nodes.
- **Recursion**: Useful for a clean, elegant solution.
- **Iteration**: Useful for an in-place and more space-efficient solution.

## Solution Approaches
### 1. Iterative Merge (Optimal for space efficiency)
**Approach:**
- Use a dummy node to build the merged list.
- Use a pointer `current` to keep track of the end of the merged list.
- Compare the current nodes of both lists, attach the smaller node to `current`, and advance the pointer in the corresponding list.
- After one list is exhausted, append the remainder of the other list.

**Time Complexity:** O(n + m) where n and m are the lengths of `list1` and `list2`
**Space Complexity:** O(1) (excluding the output list)

### 2. Recursive Merge (Concise)
**Approach:**
- Base cases: if either list is null, return the other.
- Compare the values of the heads of both lists.
- Recursively call the function to merge the remainder of the lists.

**Time Complexity:** O(n + m)
**Space Complexity:** O(n + m) due to recursion stack

## Code Implementation (Python)
### Iterative Approach
```python
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def mergeTwoLists(list1, list2):
    dummy = ListNode()
    current = dummy

    while list1 and list2:
        if list1.val < list2.val:
            current.next = list1
            list1 = list1.next
        else:
            current.next = list2
            list2 = list2.next
        current = current.next

    current.next = list1 or list2
    return dummy.next
```

### Recursive Approach
```python
def mergeTwoLists(list1, list2):
    if not list1:
        return list2
    if not list2:
        return list1

    if list1.val < list2.val:
        list1.next = mergeTwoLists(list1.next, list2)
        return list1
    else:
        list2.next = mergeTwoLists(list1, list2.next)
        return list2
```

## Data Structure Notes
### What is a Linked List?
A **linked list** is a linear data structure where each element (called a node) contains a value and a pointer to the next node. This allows for efficient insertions and deletions without reorganizing the entire data structure.

### What is Recursion?
**Recursion** is a method of solving a problem where the solution depends on solving smaller instances of the same problem. It is especially useful for problems that can be broken down into similar subproblems.

## Hints for a Technical Interview
1. **Clarify Input and Output**: Ask if you can modify the input lists or need to create a new one.
2. **Mention Time and Space Trade-offs**: Recursive vs Iterative.
3. **Edge Cases**: One or both lists are empty, all elements of one list are smaller than the other.
4. **Clean Code**: Use helper functions and keep pointer logic simple.
5. **Mention Dummy Node**: It simplifies pointer logic and avoids null checks on head.

## Follow-Up Questions
- Can you do the merge in-place without using extra nodes?
- How would you modify the solution for doubly linked lists?
- What changes if the input lists are not sorted?

This is a classic question that tests understanding of linked lists and recursion. It’s frequently asked in interviews for roles at companies like Amazon, Meta, and Apple.
# 232. Implement Queue using Stacks - Technical Guide

## Problem Statement
Implement a first-in-first-out (FIFO) queue using only two stacks. The queue should support the standard queue operations:
- `push(x)` — Push element `x` to the back of queue.
- `pop()` — Removes and returns the element from the front of queue.
- `peek()` — Returns the front element.
- `empty()` — Returns `true` if the queue is empty, `false` otherwise.

### Notes
- You must use only standard stack operations: `push`, `pop`, `peek`, `size`, and `isEmpty`.
- You can simulate a stack using a list or deque if native support is unavailable.

## Example
```plaintext
Input:
["MyQueue", "push", "push", "peek", "pop", "empty"]
[[], [1], [2], [], [], []]

Output:
[null, null, null, 1, 1, false]

Explanation:
MyQueue myQueue = new MyQueue();
myQueue.push(1);     // queue: [1]
myQueue.push(2);     // queue: [1, 2]
myQueue.peek();      // returns 1
myQueue.pop();       // returns 1, queue is [2]
myQueue.empty();     // returns false
```

## Constraints
- `1 <= x <= 9`
- At most 100 calls will be made to `push`, `pop`, `peek`, and `empty`.
- All calls to `pop` and `peek` are valid (queue is not empty).

## Solution Approach

### Using Two Stacks
- Use two stacks: `stack_in` for push operations, and `stack_out` for pop/peek operations.
- Push is always O(1).
- Pop and peek transfer elements from `stack_in` to `stack_out` only when `stack_out` is empty.

### Code
```python
class MyQueue:
    def __init__(self):
        self.stack_in = []
        self.stack_out = []

    def push(self, x):
        self.stack_in.append(x)

    def pop(self):
        self.peek()  # Ensure stack_out has the current front
        return self.stack_out.pop()

    def peek(self):
        if not self.stack_out:
            while self.stack_in:
                self.stack_out.append(self.stack_in.pop())
        return self.stack_out[-1]

    def empty(self):
        return not self.stack_in and not self.stack_out
```

### Time & Space Complexity
- **Time Complexity (Amortized):**
  - `push`: O(1)
  - `pop`: Amortized O(1)
  - `peek`: Amortized O(1)
  - `empty`: O(1)
- **Space Complexity:** O(n) — for storing all elements in stacks

## Follow-Up
> Can you implement the queue such that each operation is amortized O(1) time complexity?

✅ Yes! The transfer of elements from `stack_in` to `stack_out` happens only when `stack_out` is empty, making each element move at most once per operation cycle. Thus, O(1) amortized.

## Interview Tips
- Emphasize how two stacks simulate queue behavior.
- Show understanding of amortized analysis.
- Mention edge cases like popping/peeking from empty `stack_out`.

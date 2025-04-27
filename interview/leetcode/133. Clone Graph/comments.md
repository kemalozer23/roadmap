# 133. Clone Graph - Technical Guide

## Problem Statement
Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph.

Each node contains a value (`val`) and a list (`neighbors`) of its adjacent nodes.

```java
class Node {
    public int val;
    public List<Node> neighbors;
}
```

## Test Case Format
- Each node's value matches its index (1-indexed).
- The graph is represented by an adjacency list.
- The first node in the list corresponds to the node with `val = 1`.

## Examples

### Example 1
```plaintext
Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
Output: [[2,4],[1,3],[2,4],[1,3]]
Explanation:
- Node 1 -> Neighbors: 2, 4
- Node 2 -> Neighbors: 1, 3
- Node 3 -> Neighbors: 2, 4
- Node 4 -> Neighbors: 1, 3
```

### Example 2
```plaintext
Input: adjList = [[]]
Output: [[]]
Explanation:
- Only one node (val = 1) without neighbors.
```

### Example 3
```plaintext
Input: adjList = []
Output: []
Explanation:
- Empty graph.
```

## Constraints
- 0 <= number of nodes <= 100
- 1 <= Node.val <= 100
- Node values are unique.
- No repeated edges or self-loops.
- Graph is connected and can be traversed starting from the given node.

## Intuition
We need to create a **deep copy** of the graph:
- Clone each node exactly once.
- Preserve the neighbor relationships.

Since graphs can have cycles, we must avoid infinite loops by keeping track of already cloned nodes.

## Approach
- Use a **hashmap** to map original nodes to their cloned versions.
- Use **DFS** or **BFS** to traverse and clone the graph.

## Python Code (DFS Approach)
```python
class Node:
    def __init__(self, val=0, neighbors=None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []

def cloneGraph(node):
    if not node:
        return None

    old_to_new = {}

    def dfs(node):
        if node in old_to_new:
            return old_to_new[node]

        clone = Node(node.val)
        old_to_new[node] = clone

        for neighbor in node.neighbors:
            clone.neighbors.append(dfs(neighbor))

        return clone

    return dfs(node)
```

## Time and Space Complexity
- **Time Complexity:** O(N + E)
  - N = number of nodes
  - E = number of edges
- **Space Complexity:** O(N)
  - For recursion stack and hashmap.

## Alternative Approach (BFS)
- Initialize a queue.
- Clone the starting node.
- For each node, clone its neighbors if they aren't already cloned.

Would you like me to also add the BFS version? 🚀

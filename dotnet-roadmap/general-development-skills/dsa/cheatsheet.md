# Data Structures and Algorithms Cheat Sheet

## 1. Data Structures Overview

### Arrays
- **Description**: A collection of elements stored at contiguous memory locations.
- **Time Complexity**:
  - Access: `O(1)`
  - Search: `O(n)`
  - Insertion/Deletion (end): `O(1)`, (beginning/middle): `O(n)`

### Linked Lists
- **Description**: A sequence of nodes where each node contains data and a pointer/reference to the next node.
- **Types**: Singly Linked List, Doubly Linked List, Circular Linked List.
- **Time Complexity**:
  - Access: `O(n)`
  - Search: `O(n)`
  - Insertion/Deletion: `O(1)` at the beginning

### Stacks
- **Description**: A LIFO (Last-In-First-Out) structure.
- **Common Operations**:
  - `push()`: Add element to the top
  - `pop()`: Remove element from the top
  - `peek()`: View the top element
- **Use Cases**: Expression evaluation, Backtracking, Undo operations.

### Queues
- **Description**: A FIFO (First-In-First-Out) structure.
- **Types**: Simple Queue, Circular Queue, Priority Queue, Deque.
- **Use Cases**: Order processing, Scheduling, BFS in graph traversal.

### Trees
- **Description**: Hierarchical data structure with a root node and child nodes.
- **Types**: Binary Tree, Binary Search Tree (BST), AVL Tree, B-Tree, Heap.
- **Key Operations**:
  - Insertion, Deletion, Searching, Traversals (Inorder, Preorder, Postorder).

### Graphs
- **Description**: A collection of nodes (vertices) connected by edges.
- **Types**: Directed, Undirected, Weighted, Unweighted, Cyclic, Acyclic.
- **Key Algorithms**: DFS, BFS, Dijkstra’s Algorithm, Floyd-Warshall.

### Hash Tables
- **Description**: Data structure that stores key-value pairs and uses hash functions to index data.
- **Common Operations**: Insert, Delete, Search.
- **Use Cases**: Caching, Implementing dictionaries/maps.

---

## 2. Algorithm Complexity

### Big O Notation
- **O(1)**: Constant Time – No matter the input size, the operation takes a fixed amount of time.
- **O(log n)**: Logarithmic Time – Reduces the problem size each time (e.g., binary search).
- **O(n)**: Linear Time – Time grows proportionally with input size.
- **O(n log n)**: Log-Linear Time – Common for efficient sorting algorithms like merge sort.
- **O(n^2)**: Quadratic Time – Common in nested loops; inefficient for large inputs.

---

## 3. Searching Algorithms

### Linear Search
- **Description**: Sequentially checks each element.
- **Time Complexity**: `O(n)`

### Binary Search
- **Description**: Efficiently searches in a sorted array by dividing the search interval in half.
- **Time Complexity**: `O(log n)`

### Depth-First Search (DFS)
- **Description**: Explores as far as possible along each branch before backtracking.
- **Applications**: Pathfinding, Topological Sorting.

### Breadth-First Search (BFS)
- **Description**: Explores neighbors before moving to the next level.
- **Applications**: Shortest path in an unweighted graph.

---

## 4. Sorting Algorithms

### Bubble Sort
- **Description**: Repeatedly swaps adjacent elements if they’re in the wrong order.
- **Time Complexity**: `O(n^2)`

### Selection Sort
- **Description**: Finds the minimum element and places it at the beginning.
- **Time Complexity**: `O(n^2)`

### Insertion Sort
- **Description**: Builds the sorted array one item at a time.
- **Time Complexity**: `O(n^2)`

### Merge Sort
- **Description**: Divides the array, sorts each part, and then merges them.
- **Time Complexity**: `O(n log n)`

### Quick Sort
- **Description**: Divides the array around a pivot and recursively sorts sub-arrays.
- **Time Complexity**: Average `O(n log n)`, Worst `O(n^2)`

---

## 5. Key Algorithms

### Dijkstra’s Algorithm
- **Purpose**: Finds the shortest path in a weighted graph.
- **Complexity**: `O(V^2)` or `O(E log V)` with a priority queue.
- **Use Case**: Routing and GPS navigation.

### Dynamic Programming
- **Description**: Solves complex problems by breaking them down into overlapping subproblems.
- **Common Problems**: Fibonacci, Knapsack, Longest Common Subsequence.

### Greedy Algorithms
- **Description**: Builds up a solution piece by piece, choosing the most optimal piece each time.
- **Common Problems**: Prim’s MST, Kruskal’s MST, Huffman Coding.
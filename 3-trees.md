# Tree C# Tutorial

## Introduction

A **tree** is a hierarchical data structure made up of interconnected nodes. Trees are used to represent hierarchical relationships and are widely used in computer science for efficient data storage and manipulation.

Key Characteristics:
- **Root**: The topmost node in the tree.
- **Parent and Child Nodes**: Nodes with connections to or from other nodes.
- **Leaf Nodes**: Nodes with no children.
- **Subtree**: A subset of the tree formed by selecting a node and all its descendants.
- **Height**: The length of the longest path from the root to a leaf.

Applications:
- **File Systems**: Represent directories and files.
- **Search and Sorting**: Binary Search Trees (BSTs) allow for efficient lookup, insertion, and deletion.
- **AI and Decision Trees**: Used in decision-making and game logic.
- **Networking**: Tries are used for routing and prefix-based searching.

---

## Types of Trees

Binary Trees
A **binary tree** is a tree where each node has at most two children: a `left` child and a `right` child. Nodes in a binary tree form smaller subtrees.

Binary Search Trees (BST)
A **Binary Search Tree (BST)** is a binary tree where:
1. All values in the left subtree are less than the parent node.
2. All values in the right subtree are greater than the parent node.
3. Duplicate values can be placed in either subtree (implementation-specific).

This structure ensures efficient searching, insertion, and deletion by excluding half of the tree at each comparison, resulting in an average time complexity of `O(log n)` for balanced trees.

Balanced Binary Search Trees
A **Balanced Binary Search Tree (BST)** maintains a height difference of no more than 1 between any two subtrees. This ensures logarithmic performance for most operations. Algorithms like **AVL Trees** and **Red-Black Trees** maintain balance by rebalancing nodes after insertion or deletion.

---

## BST Operations

Inserting into a BST
Inserting a value into a BST is a recursive process:
1. **Base Case**: If the current node is `null`, the value is inserted here.
2. **Recursive Case**: Compare the value with the current node:
   - If smaller, recurse into the left subtree.
   - If larger, recurse into the right subtree.

Traversing a BST
Traversal is the process of visiting all nodes in a tree:
- **In-order Traversal**: Left subtree → Root → Right subtree (yields sorted order in BSTs).
- **Pre-order Traversal**: Root → Left subtree → Right subtree (used for tree serialization).
- **Post-order Traversal**: Left subtree → Right subtree → Root (used for deleting nodes).

Performance Comparison

| **Operation**    | **Description**                                | **Average Case** | **Worst Case (Unbalanced)** |
|-------------------|------------------------------------------------|------------------|-----------------------------|
| **Insert(value)** | Add a value to the tree.                       | O(log n)         | O(n)                       |
| **Remove(value)** | Remove a value from the tree.                  | O(log n)         | O(n)                       |
| **Contains(value)** | Check if a value exists in the tree.         | O(log n)         | O(n)                       |
| **Traverse (In-order)** | Visit all nodes in sorted order.        | O(n)             | O(n)                       |
| **Height(node)**  | Find the height of a subtree or the tree.      | O(n)             | O(n)                       |

---

## Example: Insert into a BST

Code Example:
```csharp
public class BinarySearchTree {
    private Node? _root;

    // Insert a value into the BST
    public void Insert(int value) {
        if (_root == null) {
            _root = new Node(value);
        } else {
            _root.Insert(value);
        }
    }

    private class Node {
        public int Data;
        public Node? Left, Right;

        public Node(int data) {
            Data = data;
            Left = Right = null;
        }

        public void Insert(int value) {
            if (value < Data) {
                if (Left == null) {
                    Left = new Node(value);
                } else {
                    Left.Insert(value);
                }
            } else {
                if (Right == null) {
                    Right = new Node(value);
                } else {
                    Right.Insert(value);
                }
            }
        }
    }
}

```
Explanation: BinarySearchTree Insert Method

The `BinarySearchTree.Insert` method starts at the root and recursively calls `Node.Insert`.

How It Works:
1. **Determine Placement**:
   - The method checks if the value should go in the left or right subtree based on its comparison with the current node's value.
2. **Recursive Call**:
   - The function recursively calls itself until an empty spot is found.
3. **Insert the Value**:
   - Once the correct position is located, the value is inserted.

---

### Example: Traversing a BST (In-Order)

Code Example:
```csharp
public class BinarySearchTree {
    private Node? _root;

    public IEnumerable<int> TraverseInOrder() {
        var values = new List<int>();
        Traverse(_root, values);
        return values;
    }

    private void Traverse(Node? node, List<int> values) {
        if (node != null) {
            Traverse(node.Left, values);
            values.Add(node.Data);
            Traverse(node.Right, values);
        }
    }

    private class Node {
        public int Data;
        public Node? Left, Right;

        public Node(int data) {
            Data = data;
            Left = Right = null;
        }
    }
}
```

Explanation

TraverseInOrder Method
The **TraverseInOrder** method:
1. Calls a private recursive helper method, **Traverse**.
2. Visits the left subtree first, then the node, and finally the right subtree.
3. Collects values in sorted order, which is particularly useful for Binary Search Trees.

---

## Balanced BSTs and AVL Trees

Why Balance Matters
A **balanced BST** ensures optimal performance of `O(log n)` by minimizing the height difference between the left and right subtrees. This balance is crucial for maintaining efficient operations such as search, insertion, and deletion.

AVL Tree Balancing
An **AVL Tree** maintains balance after every insertion or deletion:
1. **Check for Unbalance**: After an operation, the height difference of subtrees is checked.
2. **Perform Rotations**: If the height difference exceeds `1`, rotations are used to restore balance.
   - **Rotations**: Rearrange nodes to reduce the height and ensure the tree remains balanced.

---

Example of Rebalancing
**Initial State**: Insert nodes in ascending order (e.g., `1, 2, 3, 4, 5`). This creates an unbalanced tree resembling a linked list.

**Rebalance**: Perform rotations to restructure the tree into a balanced state, improving search and insertion performance.

---

## Problem: Implement a Phone Directory with a BST

Requirements
1. **Insert Contacts**: Add contacts (`name` and `phone number`) into the BST.
2. **Search for a Contact**: Locate a contact by its name.
3. **Display All Contacts**: Use in-order traversal to show all contacts in alphabetical order.


```csharp
using System;
using System.Collections.Generic;

public class PhoneDirectory {
    private ContactNode? _root;

    public void AddContact(string name, string phone) {
        if (_root == null) {
            _root = new ContactNode(name, phone);
        } else {
            _root.Insert(name, phone);
        }
    }

    public string? SearchContact(string name) {
        var node = _root?.Search(name);
        return node?.Phone;
    }

    public void DisplayContacts() {
        foreach (var contact in TraverseInOrder()) {
            Console.WriteLine($"{contact.Name}: {contact.Phone}");
        }
    }

    private IEnumerable<ContactNode> TraverseInOrder() {
        var nodes = new List<ContactNode>();
        _root?.Traverse(nodes);
        return nodes;
    }

    private class ContactNode {
        public string Name;
        public string Phone;
        public ContactNode? Left, Right;

        public ContactNode(string name, string phone) {
            Name = name;
            Phone = phone;
        }

        public void Insert(string name, string phone) {
            if (string.Compare(name, Name, StringComparison.Ordinal) < 0) {
                if (Left == null) Left = new ContactNode(name, phone);
                else Left.Insert(name, phone);
            } else {
                if (Right == null) Right = new ContactNode(name, phone);
                else Right.Insert(name, phone);
            }
        }

        public ContactNode? Search(string name) {
            if (name == Name) return this;
            if (string.Compare(name, Name, StringComparison.Ordinal) < 0) return Left?.Search(name);
            return Right?.Search(name);
        }

        public void Traverse(List<ContactNode> nodes) {
            Left?.Traverse(nodes);
            nodes.Add(this);
            Right?.Traverse(nodes);
        }
    }
}
```

Explanation of Code

This code implements a **Phone Directory** using a **Binary Search Tree (BST)**.

- **AddContact**: Adds a contact (`name` and `phone`) in alphabetical order.
- **SearchContact**: Searches for a contact by name and returns the phone number or `null`.
- **DisplayContacts**: Traverses the tree in sorted order (in-order traversal) and prints all contacts.
- **ContactNode Class**: Represents each node with a `name`, `phone`, and pointers to `Left` and `Right` child nodes.
  - **Insert**: Recursively adds a contact to the correct position.
  - **Search**: Recursively finds a contact by name.
  - **Traverse**: Collects nodes in sorted order for display.

| **Term**            | **Definition**                                                         |
|----------------------|------------------------------------------------------------------------|
| **AVL Tree**         | A self-balancing binary search tree that maintains height differences ≤ 1. |
| **Balanced BST**     | A BST where height differences between subtrees are minimized.         |
| **Binary Search Tree** | A tree where left children are smaller, and right children are greater. |
| **Leaf**             | A node with no children.                                              |
| **Root**             | The topmost node in the tree.                                         |
| **Subtree**          | A smaller tree starting at any node.                                  |



### Problem to Solve: Movie Rental Management with a Binary Search Tree

A movie rental system uses a **Binary Search Tree (BST)** to manage a collection of movies. Each movie is represented as a node in the tree, with its title as the key. Your tasks:

1. **Add a Movie**: Insert a movie into the collection, keeping the tree organized alphabetically by title.
2. **Search for a Movie**: Search for a movie by title and return its details (e.g., title, genre, and year).
3. **Display All Movies**: Perform an in-order traversal to list all movies in alphabetical order.

**Consider Edge Cases**:
- What happens when the tree is empty, and you try to search for a movie?
- How does the system handle duplicate titles when inserting?
- What happens if you search for a movie that does not exist in the tree?

Below is an example interaction:

Welcome to the Movie Rental System! Enter a command (add, search, display, quit):

> add Titanic Drama 1997 Movie "Titanic" added to the collection.

Enter a command (add, search, display, quit):

> add Avatar SciFi 2009 Movie "Avatar" added to the collection.

Enter a command (add, search, display, quit):

> add Inception Thriller 2010 Movie "Inception" added to the collection.

Enter a command (search, add, display, quit):

> search Titanic Details of the movie: Title: Titanic Genre: Drama Year: 1997

Enter a command (search, add, display, quit):

> display Movies in alphabetical order: Avatar (SciFi, 2009) Inception (Thriller, 2010) Titanic (Drama, 1997)

Enter a command (search, add, display, quit):

> quit Goodbye!
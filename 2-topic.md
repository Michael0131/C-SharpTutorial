
A linked list is a linear data structure where elements, known as nodes, are linked using pointers. Each node typically contains:

- Data: The value stored in the node.
- Pointer(s): A reference to the next node (and the previous node in doubly-linked lists).

Unlike dynamic arrays, which store data in contiguous memory locations, linked lists store data in random memory locations. Each node contains a pointer that connects it to the next node, ensuring the sequence of elements.

### Types of Linked Lists

- Singly Linked List: Each node points to the next node.
- Doubly Linked List: Each node has pointers to both the next and previous nodes.
- Circular Linked List: The last node points back to the first node, creating a loop.

### Why Use Linked Lists?
- Dynamic size: No need for memory reallocation or resizing as in arrays.
- Efficient insertions and deletions: Particularly at the beginning or end (O(1) at head or tail).
- Memory management: Linked lists dynamically allocate memory, reducing waste.

### Linked List Structure
- Head: Points to the first node in the list. Access to the head is O(1).
- Tail: Points to the last node in the list (in doubly-linked lists). Access to the tail is O(1).
- Node: Contains the data and pointers.

| **Operation**      | **Dynamic Array** | **Linked List** |
|---------------------|-------------------|-----------------|
| **Insert Front**    | O(n)             | O(1)           |
| **Insert Middle**   | O(n)             | O(n)           |
| **Insert End**      | O(1)             | O(1)           |
| **Remove Front**    | O(n)             | O(1)           |
| **Remove Middle**   | O(n)             | O(n)           |
| **Remove End**      | O(1)             | O(1)           |
| **Access by Index** | O(1)             | O(n)           |

Dynamic arrays excel at indexed access (O(1)), while linked lists excel at frequent insertions and deletions.

### Code Example: Singly Linked List
Here is a basic implementation of a singly linked list:

```csharp
using System;

class Node {
    public int Data; // The value stored in the node
    public Node Next; // Pointer to the next node

    public Node(int data) {
        Data = data;
        Next = null; // Initialize the next pointer to null
    }
}

class LinkedList {
    private Node head; // Reference to the head of the list

    // Inserts a new node at the beginning of the list
    public void InsertAtHead(int data) {
        Node newNode = new Node(data) { Next = head }; // New node points to current head
        head = newNode; // Update head to the new node
    }

    // Inserts a new node at the end of the list
    public void InsertAtTail(int data) {
        Node newNode = new Node(data);
        if (head == null) {
            head = newNode; // If the list is empty, set the head
            return;
        }
        Node current = head;
        while (current.Next != null) {
            current = current.Next; // Traverse to the last node
        }
        current.Next = newNode; // Add new node at the end
    }

    // Traverses the list and prints all node values
    public void Traverse() {
        Node current = head;
        while (current != null) {
            Console.Write($"{current.Data} -> "); // Print each node's data
            current = current.Next; // Move to the next node
        }
        Console.WriteLine("null"); // Indicate the end of the list
    }
}

class Program {
    static void Main() {
        LinkedList list = new LinkedList();

        list.InsertAtHead(10);
        list.InsertAtHead(20);
        list.Traverse(); // Output: 20 -> 10 -> null

        list.InsertAtTail(30);
        list.InsertAtTail(40);
        list.Traverse(); // Output: 20 -> 10 -> 30 -> 40 -> null
    }
}
```

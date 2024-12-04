# Stack C# Tutorial

## Introduction

A `stack` is a fundamental linear data structure that operates on the principle of `Last In`, `First Out (LIFO)`. This means that the `last` element `added` 
to the stack is the `first` one to be `removed`. Think of a stack as a collection where items are added and removed only from the top, much like a stack of 
plates in a kitchen. When a new plate is added, it goes on top of the stack, and when a plate is needed, it is taken from the top first.

Stacks are widely used in programming because of their `simplicity` and `efficiency`. They excel in scenarios where data needs to be processed in reverse 
order of its addition or when the most recent data is the most important to handle first. Their `push`, `pop`, and `peek` operations are performed in constant 
time, making them a go-to choice for `algorithms` and systems that require fast data management.

The `Push(value)` operation adds an element to the top of the stack. For instance, calling `myStack.Push(value)` places value onto the stack, and it operates in `constant time` O(1).
The `Pop()` operation removes and returns the top element from the stack, adhering to the `Last In`, `First Out (LIFO)` principle. For example, `var value = myStack.Pop()` retrieves 
and removes the most recent item, also in `constant time` O(1). To determine the size of the stack, the `Size()` operation can be used by checking `myStack.Count`, which returns the 
number of elements in the stack with a time complexity of O(1). Finally, the `Empty()` operation checks whether the stack is empty by evaluating `myStack.Count == 0`, which returns 
`true` if there are no elements and operates in `constant time` O(1). These operations ensure that stacks are efficient and straightforward to use for a variety of tasks.



## But why use stacks??

A stack provides efficient methods to add and remove elements:

- Adding `(push)` or removing `(pop)` an element from the stack takes `O(1)` time.
- Stacks are simple to implement and help solve problems that involve `backtracking` or `temporary storage`.

## Examples of real stack use

- Undo functionality in text editors.
- Navigating backward in browser history.
- Evaluating mathematical expressions.

Stacks are a fundamental data structure in C#. They are used whenever you need to manage data in a `Last In`, `First Out (LIFO)` order. 
The `Push` operation is used to add an item to the top of the stack, the `Pop` operation removes the top item, and the `Peek` operation allows 
you to view the top item without removing it. Stacks are ideal for scenarios like `backtracking` (e.g., navigating browser history), 
managing function calls (e.g., call stacks), or evaluating expressions. Selecting stacks in these situations helps simplify your code and 
ensures operations are efficient and intuitive.

## Analogy

Think of a stack as a stack of plates in a cafeteria. The last plate placed on the top is the first one you pick up when you need a plate.


| **Operation** | **Description**                     | **Efficiency** |
|---------------|-------------------------------------|----------------|
| **Push**      | Adds an item to the top of the stack. | O(1)           |
| **Pop**       | Removes the top item from the stack. | O(1)           |
| **Peek**      | Views the top item without removing it. | O(1)           |

## Code Example

In this example, we'll create a stack, add elements to it using Push, view the top element with Peek, and remove elements using Pop.

```csharp
using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Stack<int> stack = new Stack<int>();

        // Push elements onto the stack
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Peek at the top element
        Console.WriteLine($"Top element: {stack.Peek()}"); // Output: 30

        // Pop elements off the stack
        Console.WriteLine($"Popped: {stack.Pop()}"); // Output: 30
        Console.WriteLine($"Popped: {stack.Pop()}"); // Output: 20
    }
}
```

- Push adds elements to the top of the stack in order (10 → 20 → 30).
- Peek allows us to view the top element (30) without removing it.
- Pop removes the top element in reverse order (30 → 20).

## Efficiency

The primary advantage of stacks is their `constant-time` performance for `Push`, `Pop`, and `Peek` operations. 
This makes them ideal for scenarios where quick access to the most recently added data is needed.

## Example Problem: Check Balanced Parentheses
Problem Statement:
Write a program to check if an input string containing parentheses ((), {}, []) is balanced. For instance:

- Balanced: ({[()]})
- Unbalanced: ({[()]}]

***Notice the unbalanced does not have the same outside parentheses***

Explanation:
We'll use a stack to solve this problem:

Traverse each character in the string.
Push opening brackets ((, {, [) onto the stack.
For closing brackets (), }, ]), check if the top of the stack matches the corresponding opening bracket.
If the stack is empty after processing all characters, the string is balanced.

```csharp
using System;
using System.Collections.Generic;

class Program {
    static bool IsBalanced(string expression) {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in expression) {
            if ("({[".Contains(ch)) {
                stack.Push(ch);
            } else if (")}]".Contains(ch)) {
                if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), ch)) {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    static bool IsMatchingPair(char open, char close) {
        return (open == '(' && close == ')') || 
               (open == '{' && close == '}') || 
               (open == '[' && close == ']');
    }

    static void Main() {
        Console.WriteLine(IsBalanced("({[()]})")); // Output: True
        Console.WriteLine(IsBalanced("({[()]}]")); // Output: False
    }
}
```
- This program uses a stack to keep track of opening brackets.
- It ensures that every closing bracket has a matching opening bracket in the correct order.


## Problem to Solve: Browser History Management
Concept and Purpose:
A browser history system uses a stack to manage visited pages, leveraging its Last In, `First Out (LIFO)` behavior. 
When a user visits a new page, the current page is pushed onto the stack. Pressing "back" removes `(pops)` the most recent page from the stack, 
revealing the previous page. Using a stack ensures `efficient` page management with constant `time complexity` (O(1)) for these operations.

This program will simulate a browser history system, allowing users to:

- Visit new pages by adding them to the stack.
- Go back to the previous page by removing the most recently visited page.
- View the current page without removing it.

What You’ll Learn:

- How to implement a stack-based solution for browser history.
- The practical use of stack operations: Push, Pop, and Peek.
- How to handle user input to interact with a stack.

The following shows how the program might behave during execution:

```
Welcome to the Browser History Manager!
Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> google.com
Visited: google.com

Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> stackoverflow.com
Visited: stackoverflow.com

Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> github.com
Visited: github.com

Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> current
Current page: github.com

Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> back
Going back to: stackoverflow.com

Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> current
Current page: stackoverflow.com

Enter a new page (or type "back" to go back, "current" to see current page, or "quit" to exit):
> quit
Goodbye!
```

You can check your code with the solution here: [Solution](./stack-problem-solution)


#### Citations

GeeksforGeeks
- Title: Basic Operations in Stack Data Structure
- Link: https://www.geeksforgeeks.org/basic-operations-in-stack-data-structure-with-implementations/
- Description: An article featuring diagrams illustrating stack operations like push, pop, and peek.

Programiz
- Title: Stack Data Structure and Implementation
- Link: https://www.programiz.com/dsa/stack
- Description: A comprehensive explanation of stack operations with visuals demonstrating their functionality.

Freepik
- Title: Stack Operations Vectors
- Link: https://www.freepik.com/vectors/stack-operations
- Description: A collection of vector illustrations for stack operations, free to use with attribution.


Pixabay
- Title: Free Stack Illustrations
- Link: https://pixabay.com/illustrations/search/stack/
- Description: A variety of stack-related illustrations, all free for personal and commercial use under the Pixabay license.
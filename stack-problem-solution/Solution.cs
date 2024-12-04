using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Stack<string> history = new Stack<string>();
        string command = "";

        Console.WriteLine("Welcome to the Browser History Manager!");
        while (command != "quit") {
            Console.WriteLine("Enter a new page (or type \"back\" to go back, \"current\" to see current page, or \"quit\" to exit):");
            command = Console.ReadLine();

            if (command == "back") {
                if (history.Count > 0) {
                    Console.WriteLine($"Going back to: {history.Pop()}");
                } else {
                    Console.WriteLine("No pages in history.");
                }
            } else if (command == "current") {
                if (history.Count > 0) {
                    Console.WriteLine($"Current page: {history.Peek()}");
                } else {
                    Console.WriteLine("No pages in history.");
                }
            } else if (command != "quit") {
                history.Push(command);
                Console.WriteLine($"Visited: {command}");
            }
        }
        Console.WriteLine("Goodbye!");
    }
}

using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Stack<string> history = new Stack<string>();
        string command = "";

        Console.WriteLine("Welcome to the Browser History Manager!");
        while (command != "3") { // Quit is now represented by 3
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Enter a new page");
            Console.WriteLine("2: Go back");
            Console.WriteLine("3: Quit");
            Console.WriteLine("4: See current page");

            command = Console.ReadLine();

            if (command == "1") { // Add a new page
                Console.Write("Enter the page URL: ");
                string page = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(page)) {
                    history.Push(page);
                    Console.WriteLine($"Visited: {page}");
                } else {
                    Console.WriteLine("Invalid page. Please try again.");
                }
            } else if (command == "2") { // Go back
                if (history.Count > 0) {
                    Console.WriteLine($"Going back to: {history.Pop()}");
                } else {
                    Console.WriteLine("No pages in history.");
                }
            } else if (command == "4") { // See current page
                if (history.Count > 0) {
                    Console.WriteLine($"Current page: {history.Peek()}");
                } else {
                    Console.WriteLine("No pages in history.");
                }
            } else if (command != "3") { // Invalid command
                Console.WriteLine("Invalid option. Please choose a valid number.");
            }
        }
        Console.WriteLine("Goodbye!");
    }
}
qu
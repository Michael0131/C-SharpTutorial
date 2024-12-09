using System;

class Node {
    public string Data; // Song name
    public Node Next;   // Pointer to the next node

    public Node(string data) {
        Data = data;
        Next = null; // Initialize the next pointer to null
    }
}

class Playlist {
    private Node head; // Reference to the head of the playlist

    // Adds a song to the beginning of the playlist
    public void AddToHead(string song) {
        Node newNode = new Node(song) { Next = head };
        head = newNode;
        Console.WriteLine($"{song} added to the beginning of the playlist.");
    }

    // Adds a song to the end of the playlist
    public void AddToTail(string song) {
        Node newNode = new Node(song);
        if (head == null) {
            head = newNode; // If the playlist is empty, set the head
        } else {
            Node current = head;
            while (current.Next != null) {
                current = current.Next; // Traverse to the last node
            }
            current.Next = newNode; // Add new node at the end
        }
        Console.WriteLine($"{song} added to the end of the playlist.");
    }

    // Removes the first song from the playlist
    public void RemoveHead() {
        if (head == null) {
            Console.WriteLine("Playlist is empty! Nothing to remove.");
            return;
        }
        Console.WriteLine($"Removed {head.Data} from the beginning of the playlist.");
        head = head.Next; // Update head to the next node
    }

    // Removes the last song from the playlist
    public void RemoveTail() {
        if (head == null) {
            Console.WriteLine("Playlist is empty! Nothing to remove.");
            return;
        }
        if (head.Next == null) { // If only one song exists
            Console.WriteLine($"Removed {head.Data} from the playlist.");
            head = null; // Set head to null, making the playlist empty
            return;
        }
        Node current = head;
        while (current.Next.Next != null) {
            current = current.Next; // Traverse to the second-to-last node
        }
        Console.WriteLine($"Removed {current.Next.Data} from the playlist.");
        current.Next = null; // Remove the last node
    }

    // Displays the current playlist
    public void Display() {
        if (head == null) {
            Console.WriteLine("Playlist is empty.");
            return;
        }
        Console.Write("Current playlist: ");
        Node current = head;
        while (current != null) {
            Console.Write($"{current.Data} -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

class Program {
    static void Main() {
        Playlist playlist = new Playlist();

        Console.WriteLine("Welcome to the Playlist Manager!");
        while (true) {
            Console.Write("Enter a command (add_head, add_tail, remove_head, remove_tail, display, quit): ");
            string[] input = Console.ReadLine().Split(' ', 2); // Split command and optional song name
            string command = input[0];
            string song = input.Length > 1 ? input[1] : null;

            switch (command) {
                case "add_head":
                    if (song != null) playlist.AddToHead(song);
                    else Console.WriteLine("Please specify a song name.");
                    break;
                case "add_tail":
                    if (song != null) playlist.AddToTail(song);
                    else Console.WriteLine("Please specify a song name.");
                    break;
                case "remove_head":
                    playlist.RemoveHead();
                    break;
                case "remove_tail":
                    playlist.RemoveTail();
                    break;
                case "display":
                    playlist.Display();
                    break;
                case "quit":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        }
    }
}

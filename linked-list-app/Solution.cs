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
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Add a song to the beginning");
            Console.WriteLine("2: Add a song to the end");
            Console.WriteLine("3: Remove the first song");
            Console.WriteLine("4: Remove the last song");
            Console.WriteLine("5: Display the playlist");
            Console.WriteLine("6: Quit");

            string command = Console.ReadLine();
            switch (command) {
                case "1":
                    Console.Write("Enter the song name: ");
                    string songHead = Console.ReadLine();
                    playlist.AddToHead(songHead);
                    break;
                case "2":
                    Console.Write("Enter the song name: ");
                    string songTail = Console.ReadLine();
                    playlist.AddToTail(songTail);
                    break;
                case "3":
                    playlist.RemoveHead();
                    break;
                case "4":
                    playlist.RemoveTail();
                    break;
                case "5":
                    playlist.Display();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid number.");
                    break;
            }
        }
    }
}

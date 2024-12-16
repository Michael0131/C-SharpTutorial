using System;
using System.Collections.Generic;

public class MovieRentalSystem {
    private MovieNode? _root;

    // Adds a movie to the BST
    public void AddMovie(string title, string genre, int year) {
        if (_root == null) {
            _root = new MovieNode(title, genre, year);
        } else {
            _root.Insert(title, genre, year);
        }
        Console.WriteLine($"Movie \"{title}\" added to the collection.");
    }

    // Searches for a movie by title
    public void SearchMovie(string title) {
        var movie = _root?.Search(title);
        if (movie == null) {
            Console.WriteLine($"Movie \"{title}\" not found.");
        } else {
            Console.WriteLine($"Details of the movie:\nTitle: {movie.Title}\nGenre: {movie.Genre}\nYear: {movie.Year}");
        }
    }

    // Displays all movies in alphabetical order
    public void DisplayMovies() {
        if (_root == null) {
            Console.WriteLine("No movies in the collection.");
            return;
        }

        Console.WriteLine("Movies in alphabetical order:");
        foreach (var movie in TraverseInOrder()) {
            Console.WriteLine($"{movie.Title} ({movie.Genre}, {movie.Year})");
        }
    }

    // In-order traversal to get all movies in sorted order
    private IEnumerable<MovieNode> TraverseInOrder() {
        var movies = new List<MovieNode>();
        _root?.Traverse(movies);
        return movies;
    }

    // MovieNode class represents each node in the BST
    private class MovieNode {
        public string Title;
        public string Genre;
        public int Year;
        public MovieNode? Left, Right;

        public MovieNode(string title, string genre, int year) {
            Title = title;
            Genre = genre;
            Year = year;
            Left = Right = null;
        }

        // Insert a new movie into the BST
        public void Insert(string title, string genre, int year) {
            if (string.Compare(title, Title, StringComparison.OrdinalIgnoreCase) < 0) {
                if (Left == null) {
                    Left = new MovieNode(title, genre, year);
                } else {
                    Left.Insert(title, genre, year);
                }
            } else if (string.Compare(title, Title, StringComparison.OrdinalIgnoreCase) > 0) {
                if (Right == null) {
                    Right = new MovieNode(title, genre, year);
                } else {
                    Right.Insert(title, genre, year);
                }
            } else {
                Console.WriteLine($"Movie \"{title}\" already exists in the collection.");
            }
        }

        // Search for a movie by title
        public MovieNode? Search(string title) {
            if (title.Equals(Title, StringComparison.OrdinalIgnoreCase)) {
                return this;
            }

            if (string.Compare(title, Title, StringComparison.OrdinalIgnoreCase) < 0) {
                return Left?.Search(title);
            } else {
                return Right?.Search(title);
            }
        }

        // Traverse the BST in in-order
        public void Traverse(List<MovieNode> movies) {
            Left?.Traverse(movies);
            movies.Add(this);
            Right?.Traverse(movies);
        }
    }

    // Main method to test the Movie Rental System
    public static void Main() {
        var movieSystem = new MovieRentalSystem();

        Console.WriteLine("Welcome to the Movie Rental System!");
        string command;
        do {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Add a movie");
            Console.WriteLine("2: Search for a movie");
            Console.WriteLine("3: Display all movies");
            Console.WriteLine("4: Quit");

            command = Console.ReadLine();

            switch (command) {
                case "1": // Add a movie
                    Console.Write("Enter the movie title: ");
                    string title = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter the movie genre: ");
                    string genre = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter the release year: ");
                    int year = int.TryParse(Console.ReadLine(), out var parsedYear) ? parsedYear : 0;

                    if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(genre) && year > 0) {
                        movieSystem.AddMovie(title, genre, year);
                    } else {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                    break;

                case "2": // Search for a movie
                    Console.Write("Enter the movie title to search: ");
                    string searchTitle = Console.ReadLine() ?? string.Empty;
                    movieSystem.SearchMovie(searchTitle);
                    break;

                case "3": // Display all movies
                    movieSystem.DisplayMovies();
                    break;

                case "4": // Quit
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid number.");
                    break;
            }
        } while (command != "4");
    }
}

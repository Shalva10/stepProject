using BookOop.Books;
using BookOop.Services;
using System.Text.Json;

BooksService library = new BooksService();

var folder = "C:\\Users\\short\\OneDrive\\Documents\\BookOop";
var file = "BookOop.json";
var path = Path.Combine(folder, file);

if (!Directory.Exists(folder))
{
    Directory.CreateDirectory(folder);
}

if (!File.Exists(path))
{
    File.Create(path).Close();
}

File.WriteAllText(path, "[]");

library.AddBook(new Books { Id = 1, Title = "The Raven", Author = "Hidetaka Miyazaki", Genre = "Action", Year = 2023 });
library.AddBook(new Books { Id = 2, Title = "Don Quixote", Author = "Miguel de Cervantes", Genre = "Psychological Fiction", Year = 1605 });
library.AddBook(new Books { Id = 3, Title = "The Lion, the Witch and the Wardrobe", Genre = "Fantasy", Author = "C.S. Lewis", Year = 2005 });
library.AddBook(new Books { Id = 4, Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Philosophy", Year = 2016 });
library.AddBook(new Books { Id = 5, Title = "One Piece", Author = "Eichiro Oda", Genre = "Adventure, Action", Year = 1998 });
library.AddBook(new Books { Id = 6, Title = "The Hobbit", Author = "John Ronald Reuel Tolkien", Genre = "Action", Year = 1998 });

bool running = true;

while (running)
{
    Console.WriteLine("Add a Book - 1");
    Console.WriteLine("Get All Books - 2");
    Console.WriteLine("Get a Book By Author - 3");
    Console.WriteLine("Remove a Book - 4");
    Console.WriteLine("Sort books by Author - 5");
    Console.WriteLine("Choose books by Genre - 6");
    Console.WriteLine("Remove All Books - 7");
    Console.WriteLine("Exit - 0");

    var userInput = Console.ReadLine();

    List<Books> allBooks = library.GetAllBooks();
    var lastBook = allBooks.LastOrDefault();

    switch (userInput)
    {
        case "1":
            Console.WriteLine("Enter Book Author");
            var author = Console.ReadLine();
            Console.WriteLine("Enter Book Title");
            var title = Console.ReadLine();
            Console.WriteLine("Enter Book Year");
            var year = Convert.ToInt32(Console.ReadLine());

            int id = 0;

            if (lastBook != null) 
            {
                id = lastBook.Id + 1;
            }


            if (author != null && title != null)
            {
                var newBook = new Books { Id = id, Author = author, Title = title, Year = year };
                library.AddBook(newBook);
                Console.WriteLine("Book Added successfully");
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
                }

                var wholeLibrary1 = library.GetAllBooks();
                var serialized1 = JsonSerializer.Serialize(wholeLibrary1, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, serialized1);
            }
            else
            {
                Console.WriteLine("Author and Title cannot be null");
            }

            break;

        case "2":
            foreach (var book in allBooks)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
            }
            var wholeLibrary = library.GetAllBooks();

            var serialized = JsonSerializer.Serialize(wholeLibrary, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, serialized);
            break;

        case "3":
            Console.WriteLine("Enter the Book's Author");
            var bookAuthor = Console.ReadLine();

            if (bookAuthor != null)
            {
                library.GetBookByAuthor(bookAuthor);
            }

            var wholeLibrary3 = library.GetAllBooks();
            var serialized3 = JsonSerializer.Serialize(wholeLibrary3, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, serialized3);
            break;

        case "4":
            Console.WriteLine("Enter the ID of the book you want to delete");
            var bookId = Convert.ToInt32(Console.ReadLine());
            library.RemoveBookById(bookId);

            var wholeLibrary4 = library.GetAllBooks();
            var serialized4 = JsonSerializer.Serialize(wholeLibrary4, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, serialized4);
            break;

        case "5":
            var sortedBooks = library.GetAllBooks().OrderBy(b => b.Author).ToList();
            Console.WriteLine("Books sorted by author:");
            foreach (var b in sortedBooks)
            {
                Console.WriteLine($"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}, Year: {b.Year}");
            }

            var serialized5 = JsonSerializer.Serialize(sortedBooks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, serialized5);
            Console.WriteLine("The books were sorted by author name in alphabetical order and saved to JSON.\n");
            break;

        case "6":
            Console.WriteLine("Enter genre name to filter (e.g., Fantasy, Action, Adventure, Philosophy, Psychological Fiction):");
            string genreInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(genreInput))
            {
                string genreToMatch = genreInput.Trim().ToLower();

                var booksByGenre = new List<Books>();

                foreach (var book in allBooks)
                {
                    if (book.Genre != null)
                    {
                        string genreStr = book.Genre;
                        int start = 0;

                        for (int i = 0; i <= genreStr.Length; i++)
                        {
                            if (i == genreStr.Length || genreStr[i] == ',')
                            {
                                string part = genreStr.Substring(start, i - start).Trim().ToLower();

                                if (part == genreToMatch)
                                {
                                    booksByGenre.Add(book);
                                    break;
                                }

                                start = i + 1;
                            }
                        }
                    }
                }

                if (booksByGenre.Count > 0)
                {
                    Console.WriteLine("Books in genre '" + genreInput + "':");
                    foreach (var book in booksByGenre)
                    {
                        Console.WriteLine("ID: " + book.Id + ", Title: " + book.Title + ", Author: " + book.Author + ", Genre: " + book.Genre + ", Year: " + book.Year);
                    }

                    var serializedBooks = JsonSerializer.Serialize(booksByGenre, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(path, serializedBooks);
                    Console.WriteLine("Filtered books saved to JSON.");
                }
                else
                {
                    Console.WriteLine("No books found in genre '" + genreInput + "'.");
                }
            }
            else
            {
                Console.WriteLine("Invalid genre input.");
            }
            break;


        case "7":
            Console.WriteLine("are you sure you want to remove all books, y/n");
            string userAnswer = Console.ReadLine();

            if (userAnswer.ToLower() == "y")
            {
                library.RemoveAllBooks();
            }
            else if (userAnswer.ToLower() == "n")
            {
                Console.WriteLine("Alright!!!!!!!!");
            }
            else
            {
                Console.WriteLine("shen xar cudi biwi ^-^ ");
            }

            var wholeLibrary7 = library.GetAllBooks();
            var serialized7 = JsonSerializer.Serialize(wholeLibrary7, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, serialized7);
            break;

        case "0":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Error try again");
            break;
    }
}

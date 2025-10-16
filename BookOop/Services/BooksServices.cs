using System;
using System.Collections.Generic;
using System.Linq;
using BookOop.Services;
using BookOop.Books;


namespace BookOop.Services
{
    internal class BooksService
    {
        private List<Books.Books> _list;

        public BooksService()
        {
            _list = new List<Books.Books>();
        }

        public void AddBook(Books.Books item)
        {
            _list.Add(item);
        }

        public void GetBookByAuthor(string author)
        {
            var books = _list
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (books.Any())
            {
                foreach (var b in books)
                {
                    Console.WriteLine($"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}, Year: {b.Year}");
                }
            }
            else
            {
                Console.WriteLine("No books found by that author.");
            }
        }

        public List<Books.Books> GetAllBooks()
        {
            return _list;
        }

        public void RemoveBookById(int id)
        {
            var book = _list.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                _list.Remove(book);
                Console.WriteLine($"Book '{book.Title}' removed successfully.");
                Console.WriteLine("Remaining books:");
                foreach (var b in _list)
                {
                    Console.WriteLine($"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}, Year: {b.Year}");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void SortBooksByAuthor()
        {
            var sorted = _list.OrderBy(b => b.Author).ToList();

            Console.WriteLine("Books sorted by author:");
            foreach (var b in sorted)
            {
                Console.WriteLine($"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}, Year: {b.Year}");
            }
        }

        public void RemoveAllBooks()
        {
            _list.Clear();
            Console.WriteLine("All books have been removed.");
        }
    }
}

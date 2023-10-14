using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }

    public class BookLibrary
    {
        private Dictionary<string, Book> _bookDictionary = new Dictionary<string, Book>();

        public void AddBook(string isbn, string title, string author)
        { // Add new book to Dictionary
            Console.WriteLine("-----------------------------------");

            if (_bookDictionary.ContainsKey(isbn))
            {
                Console.WriteLine("Book dictionary already contains key: " + isbn);
                return;
            }

            Book book = new Book(title, author);
            _bookDictionary.Add(isbn, book);
            Console.WriteLine
            (
            "Book '"
            + book.Title
            + " by "
            + book.Author
            + "' added to the library"
            );
        }

        public void LendBook(string isbn)
        { // If book is lend, it is not available
            Console.WriteLine("-----------------------------------");

            if (!_bookDictionary.ContainsKey(isbn))
            {
                Console.WriteLine("Book dictionary does not contain key: " + isbn);
                return;
            }
            if (!_bookDictionary[isbn].IsAvailable)
            {
                Console.WriteLine("Book with ISBN " + isbn + " is not available");
                return;
            }

            _bookDictionary[isbn].IsAvailable = false;
            Console.WriteLine("Book '" + _bookDictionary[isbn].Title + "' is now lent");
        }

        public void ReturnBook(string isbn)
        { // If book is returned, then it is available again
            Console.WriteLine("-----------------------------------");

            if (!_bookDictionary.ContainsKey(isbn))
            {
                Console.WriteLine("Book dictionary does not contain key: " + isbn);
                return;
            }

            if (_bookDictionary[isbn].IsAvailable)
            {
                Console.WriteLine("Book with ISBN : " + isbn + " , Title : '" + _bookDictionary[isbn].Title + "' is already available in the library");
                return;
            }

            _bookDictionary[isbn].IsAvailable = true;
            Console.WriteLine("Book " + _bookDictionary[isbn].Title + " has been returned and is now available");

        }

        public void ListBooks()
        { // Use foreach to display all book ISBM, title, author and avialablity
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("Library Catalog:");

            foreach (KeyValuePair<string, Book> kvp in _bookDictionary)
            {
                Console.WriteLine
                (
                "ISBN: "
                + kvp.Key
                + ", Title: "
                + kvp.Value.Title
                + ", Author: "
                + kvp.Value.Author
                + ", Available: "
                + kvp.Value.IsAvailable
                );
            }
            Console.WriteLine("-----------------------------------");

        }


        public class Program
        {
            public static void Main(string[] args)
            {
                BookLibrary library = new BookLibrary();

                library.AddBook("001", "The Great Gatsby", "F. Scott Fitzgerald");
                library.AddBook("002", "To Kill a Mockingbird", "Harper Lee");
                library.AddBook("003", "1984", "George Orwell");

                library.LendBook("001");
                library.LendBook("003");

                library.ReturnBook("002");

                library.ListBooks();
            }
        }

    }
}


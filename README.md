# Library Management System

This repository contains a solution to a set of three exercises related to object-oriented design and programming for a library management system. The exercises are aimed at designing classes, creating text parsers, organizing data in collections, and establishing test cases.

## Exercise 1.1

In this exercise, we are tasked with designing a set of types that represent items that can be borrowed at a library. These items include books, CDs, DVDs, and Blu-ray discs, some of which can be downloaded as e-books, audio, or video files. Here, we will focus on designing the class diagram for these various kinds of items.

### Class Diagram

![Class Diagram](https://github.com/pmsanz/3shape/blob/main/ConsoleApp1/Images/Diagram.jpg)

### Explanation

- `LibraryItem` is the base class representing common properties of all library items, such as title and ISBN.
- `Book` is a derived class from `LibraryItem`, containing additional properties like author and number of pages.
- `MediaItem` is a derived class from `LibraryItem` that represents items like CDs, DVDs, and Blu-ray discs. It includes properties for tracks, artists, and duration.

## Exercise 1.2

In this exercise, we are required to create methods to enter and search for books based on specific criteria.

### Method Signatures

```csharp
List<Book> ReadBooks(string input);
List<Book> FindBooks(string searchString);
```

### Explanation

- `ReadBooks` method parses the input text and creates a list of `Book` objects.
- `FindBooks` method searches for books based on the provided search string criteria, including wildcard searches and boolean operations.

## Exercise 1.3

In this exercise, we need to create an object model to represent a library's organization and implement functions for registering, inventory creation, and book location by ISBN.

### Object Model
```csharp
using LibraryProjectChallenge.Models;
using LibraryProjectChallenge.Models.Repository;
using LibraryProjectChallenge.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProjectChallenge
{
    public class BookManager
    {
        private IRoomRepository roomRepository;
        private IBookshelfRepository bookshelfRepository;
        private IBookRepository bookRepository;
        public List<Book> Books { get; private set; }

        public BookManager(string input)
        {
            Books = ReadBooks(input);
        }

        public BookManager(List<Room> db)
        {
            this.roomRepository = new RoomRepository(db);
            this.bookshelfRepository = new BookshelfRepository(db);
            this.bookRepository = new BookRepository(db);
        }

        public static List<Book> ReadBooks(string input)
        {
            // Implementation as provided in the code
        }

        public List<Book> FindBooks(string searchString)
        {
            // Implementation as provided in the code
        }

        public static List<string> SanitizeQuery(string searchString)
        {
            // Implementation as provided in the code
        }

        public static bool MatchBook(Book book, string searchTerm)
        {
            // Implementation as provided in the code
        }

        // BookService
        public Book? FindBookByISBNOrDefault(string isbn) => bookRepository.GetBookByISBNOrDefault(isbn);
        public Bookshelf? GetBookshelfOrDefault(int roomNumber, int rowNumber, int shelfNumber) => bookshelfRepository.GetBookshelfOrDefault(roomNumber, rowNumber, shelfNumber);
        public Room? GetRoomOrDefault(int roomNumber) => roomRepository.GetRoomByNumberOrDefault(roomNumber);
        public void AddBook(Book book) => bookRepository.AddBook(book);
    }
}
```
- The code provided in class BookManager handles the object model for managing books, rooms, bookshelves, and related operations.

### Test Data

- Sample test data is provided to populate the library's organizational units and books.

### Test Cases

- A set of test cases is included to verify the functionality of the solution against the test data.

## Conclusion

This repository provides a comprehensive solution to the given exercises, focusing on object-oriented design principles, data organization, and test cases. Please refer to individual exercise folders for detailed implementation and code. Have fun exploring the solution!

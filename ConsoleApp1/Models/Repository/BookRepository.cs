using LibraryProjectChallenge.Models.Repository.Interfaces;

namespace LibraryProjectChallenge.Models.Repository
{
    internal class BookRepository : FakeDBContext, IBookRepository
    {
        public BookRepository(List<Room> db) : base(db)
        {
        }

        public void AddBook(Book book)
        {
            if (book.ShelfNumber == 0)
                throw new ArgumentException("ShelfNumber cannot be zero.");

            List<Book> books = new List<Book>();
            foreach (var room in DB)
                foreach (var row in room.Rows)
                    foreach (var shelf in row.Shelves)
                        if (shelf.ShelfNumber == book.ShelfNumber)
                            shelf.Books.Add(book);
        }
        public Book? GetBookByISBNOrDefault(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                throw new ArgumentException("ISBN cannot be null or empty.");

            foreach (var room in DB)
                foreach (var row in room.Rows)
                    foreach (var shelf in row.Shelves)
                        foreach (var book in shelf.Books)
                            if (book.ISBN == isbn)
                                return book;
            return null;
        }


    }
}

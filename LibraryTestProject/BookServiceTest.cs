using LibraryProjectChallenge;
using LibraryProjectChallenge.Models;

namespace LibraryTestProject
{
    public class BookServiceTest
    {
        protected List<Room> FakeDB { get; private set; }
        public BookServiceTest()
        {
            // Create mock data for rooms, rows, bookshelves, and books
            List<Room> rooms = new List<Room>();

            for (int roomNumber = 1; roomNumber <= 5; roomNumber++)
            {
                Room room = new Room
                {
                    RoomNumber = roomNumber,
                    Rows = new List<Row>()
                };

                for (int rowNumber = 1; rowNumber <= 4; rowNumber++)
                {
                    Row row = new Row
                    {
                        RowId = rowNumber,
                        RoomId = roomNumber,
                        RowNumber = rowNumber,
                        Shelves = new List<Bookshelf>()
                    };

                    for (int shelfNumber = 1; shelfNumber <= 5; shelfNumber++)
                    {
                        Bookshelf shelf = new Bookshelf
                        {
                            RowId = rowNumber,
                            ShelfNumber = shelfNumber,
                            Books = new List<Book>()
                        };

                        for (int bookNumber = 1; bookNumber <= 10; bookNumber++)
                        {
                            List<string> authors = new List<string> { "Author1", "Author2" };
                            Book book = new Book(authors, $"ISBN-{roomNumber}-{rowNumber}-{shelfNumber}-{bookNumber}", $"Book {bookNumber}", "Publisher", 200, 2020);
                            shelf.Books.Add(book);
                        }

                        row.Shelves.Add(shelf);
                    }

                    room.Rows.Add(row);
                }

                rooms.Add(room);
            }

            FakeDB = rooms;
        }
        [Fact]
        public void GetRoomOrDefault_ShouldExists_True()
        {
            int roomNumber = 2;
            BookManager manager = new BookManager(FakeDB);

            var room = manager.GetRoomOrDefault(roomNumber);

            Assert.True(room != null);
            Assert.True(room.RoomNumber == roomNumber);
        }

        [Fact]
        public void FindBookByISBNOrDefault_ShouldExists_True()
        {
            string isbn = "ISBN-3-1-3-10";
            BookManager manager = new BookManager(FakeDB);

            var book = manager.FindBookByISBNOrDefault(isbn);

            Assert.True(book != null);
            Assert.True(book.ISBN == isbn);
        }

        [Fact]
        public void GetBookshelfOrDefault_ShouldExists_True()
        {
            int roomNumber = 2;
            int rowNumber = 1;
            int shelfNumber = 2;

            BookManager manager = new BookManager(FakeDB);

            var shelf = manager.GetBookshelfOrDefault(roomNumber, rowNumber, shelfNumber);

            Assert.True(shelf != null);
            Assert.True(shelf.ShelfNumber == shelfNumber);
        }

        [Fact]
        public void AddBook_ShouldExists_True()
        {
            //get shelf where to add new book
            int roomNumber = 2;
            int rowNumber = 1;
            int shelfNumber = 2;
            int initialBookCount = 10;

            BookManager manager = new BookManager(FakeDB);
            var shelf = manager.GetBookshelfOrDefault(roomNumber, rowNumber, shelfNumber);

            Assert.True(shelf != null);
            Assert.True(shelf.ShelfNumber == shelfNumber);
            Assert.True(shelf.Books.Count == initialBookCount);

            //create new book
            List<string> authors = new List<string> { "Brian Jensen" };
            string title = "My awesome title";
            string publisher = "Gyldendal";
            int published = 2001;
            int pages = 253;
            string isbn = "999-999-999-999";

            Book newBook = new Book(authors, isbn: isbn, title, publisher, pages, published);
            newBook.SetShelf(shelf.ShelfNumber);

            //add new book
            manager.AddBook(newBook);

            //check shelf data
            shelf = manager.GetBookshelfOrDefault(roomNumber, rowNumber, shelfNumber);
            Assert.True(shelf != null);
            Assert.True(shelf.ShelfNumber == shelfNumber);
            Assert.True(shelf.Books.Count == initialBookCount + 1);

            //check book data
            var book = manager.FindBookByISBNOrDefault(isbn);
            Assert.True(book != null);
            Assert.True(book.ISBN == isbn);
        }
    }
}

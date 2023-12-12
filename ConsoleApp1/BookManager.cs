using LibraryProjectChallenge.Models;
using LibraryProjectChallenge.Models.Repository;
using LibraryProjectChallenge.Models.Repository.Interfaces;

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
            List<Book> books = new List<Book>();
            string[] bookData = input.Split(new string[] { "Book:" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string bookInfo in bookData)
            {
                string[] lines = bookInfo.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries);
                List<string> authors = new List<string>();
                string title = null;
                string publisher = null;
                int published = 0;
                int pages = 0;

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length != 2)
                    {
                        continue;
                    }

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "Author":
                            authors.Add(value);
                            break;
                        case "Title":
                            title = value;
                            break;
                        case "Publisher":
                            publisher = value;
                            break;
                        case "Published":
                            if (int.TryParse(value, out int publishedYear))
                            {
                                published = publishedYear;
                            }
                            break;
                        case "NumberOfPages":
                            if (int.TryParse(value, out int pageCount))
                            {
                                pages = pageCount;
                            }
                            break;
                    }
                }

                if (authors.Count != 0 && title != null && publisher != null && published > 0 && pages > 0)
                {
                    books.Add(new Book(authors, Guid.NewGuid().ToString(), title, publisher, pages, published));
                }
            }

            return books;
        }
        public List<Book> FindBooks(string searchString)
        {
            List<Book> finalResults = new List<Book>();
            List<string> searchTerms = SanitizeQuery(searchString);
            List<List<Book>> searchResults = new List<List<Book>>();

            foreach (string term in searchTerms)
            {
                List<Book> termResults = new List<Book>();
                string searchTermNormalized = term.Trim().ToLower();

                foreach (Book book in Books)
                {
                    if (MatchBook(book, searchTermNormalized))
                    {
                        termResults.Add(book);
                    }
                }
                searchResults.Add(termResults);
            }

            finalResults = searchResults.Aggregate((intermediateResults, termResults) => intermediateResults.Intersect(termResults).ToList());

            return finalResults;
        }
        public static List<string> SanitizeQuery(string searchString)
        {
            List<string> sanitizedList = new List<string>();
            bool hasLiteral = searchString.Contains(@"\&");

            if (hasLiteral)
            {
                int j = 0;
                for (int i = 0; i < searchString.Length; i++)
                {
                    if (i > 0 && searchString[j] != '\\' && searchString[i] == '&')
                    {
                        sanitizedList.Add(searchString.Substring(0, i));
                        searchString = searchString.Remove(0, i + 1);
                        i = 0;
                        j = 0;
                    }
                    j = i > 0 ? i : 0;
                }
                if (searchString.Length > 0)
                    sanitizedList.Add(searchString);
            }
            else
            {
                sanitizedList = searchString.Split('&').ToList();
            }
            for (int i = 0; i < sanitizedList.Count; i++)
            {
                string query = sanitizedList[i];
                query = query.Replace(@"\&", "&");
                query = query.Trim().Remove(0, 1);
                query = query.Remove(query.Length - 1, 1);
                sanitizedList[i] = query;
            }

            return sanitizedList;

        }
        public static bool MatchBook(Book book, string searchTerm)
        {
            return book.Title.ToLower().Contains(searchTerm) ||
                   book.Authors.Any(author => author.ToLower().Contains(searchTerm)) ||
                   book.Publisher.ToLower().Contains(searchTerm) ||
                   book.Published.ToString().Contains(searchTerm);
        }

        //BookService
        public Book? FindBookByISBNOrDefault(string isbn) => bookRepository.GetBookByISBNOrDefault(isbn);
        public Bookshelf? GetBookshelfOrDefault(int roomNumber, int rowNumber, int shelfNumber) => bookshelfRepository.GetBookshelfOrDefault(roomNumber, rowNumber, shelfNumber);
        public Room? GetRoomOrDefault(int roomNumber) => roomRepository.GetRoomByNumberOrDefault(roomNumber);
        public void AddBook(Book book) => bookRepository.AddBook(book);
    }
}

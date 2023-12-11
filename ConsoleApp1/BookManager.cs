namespace LibraryProjectChallenge
{
    public class BookManager
    {
        public List<Book> Books { get; private set; }
        public BookManager(string input)
        {
            Books = ReadBooks(input);
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

    }
}

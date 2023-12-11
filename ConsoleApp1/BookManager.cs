using System.Text.RegularExpressions;

namespace LibraryProjectChallenge
{
    public static class BookManager
    {
        public static List<Book> ReadBooks(string input)
        {
            List<Book> books = new List<Book>();

            // Define a regular expression pattern to match book sections
            string pattern = @"Book:(.*?)\n\n";
            var matches = Regex.Matches(input, pattern, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                string bookInfo = match.Groups[1].Value;
                Book book = ParseBook(bookInfo);
                books.Add(book);
            }

            return books;
        }

        private static Book ParseBook(string bookInfo)
        {
            string[] lines = bookInfo.Split('\n').Select(line => line.Trim()).ToArray();
            string author = "";
            string title = "";
            string publisher = "";
            int pages = 0;
            int published = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length != 2) continue;

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                switch (key)
                {
                    case "Author":
                        author = value;
                        break;
                    case "Title":
                        title = value;
                        break;
                    case "Publisher":
                        publisher = value;
                        break;
                    case "NumberOfPages":
                        if (int.TryParse(value, out int parsedPages))
                        {
                            pages = parsedPages;
                        }
                        break;
                    case "Published":
                        if (int.TryParse(value, out int parsedPublished))
                        {
                            published = parsedPublished;
                        }
                        break;
                }
            }

            return new Book(Guid.NewGuid().ToString(), title, author, publisher, pages, published);

        }
    }
}

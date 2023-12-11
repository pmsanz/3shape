namespace LibraryProjectChallenge
{
    public class Book : LibraryItem
    {
        public List<string> Author { get; set; }
        public string Publisher { get; private set; }
        public int Published { get; private set; }
        public int Pages { get; private set; }
        //Consider to create a class with a DTO instead a constructor with too many arguments.
        public Book(string isbn, string title, string author, string publisher, int pages, int published) : base(isbn, title)
        {
            Author = new List<string> { author };
            Pages = pages;
            Published = published;
            Publisher = publisher;
        }

        public void AddAuthor(string author)
        {
            Author.Add(author);
        }
        public override void DownloadFile()
        {
            Console.WriteLine("Downloading e-book file...");
        }
    }
}

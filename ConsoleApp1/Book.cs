namespace LibraryProjectChallenge
{
    public class Book : LibraryItem
    {
        public List<string> Authors { get; set; }
        public string Publisher { get; private set; }
        public int Published { get; private set; }
        public int Pages { get; private set; }
        //Consider to create a class with a DTO instead a constructor with too many arguments.
        public Book(string isbn, string title, string author, string publisher, int pages, int published) : base(isbn, title)
        {
            Authors = new List<string> { author };
            Pages = pages;
            Published = published;
            Publisher = publisher;
        }

        public void AddAuthor(string author)
        {
            Authors.Add(author);
        }
        public override void DownloadFile()
        {
            Console.WriteLine("Downloading e-book file...");
        }
    }
}

namespace LibraryProjectChallenge
{
    public class Book : LibraryItem
    {
        public string Author { get; private set; }
        public int Pages { get; private set; }

        public Book(string isbn, string title, string author, int pages) : base(isbn, title)
        {
            Author = author;
            Pages = pages;
        }

        public override void DownloadFile()
        {
            Console.WriteLine("Downloading e-book file...");
        }
    }
}

namespace LibraryProjectChallenge.Models
{
    public class Book : LibraryItem
    {
        public List<string> Authors { get; set; }
        public string Publisher { get; private set; }
        public int Published { get; private set; }
        public int Pages { get; private set; }
        public int ShelfNumber { get; private set; }
        //Consider to create a class with a DTO instead a constructor with too many arguments.
        public Book(List<string> authors, string isbn, string title, string publisher, int pages, int published) : base(isbn, title)
        {
            Authors = authors;
            Pages = pages;
            Published = published;
            Publisher = publisher;

        }

        public void AddAuthor(string author)
        {
            Authors.Add(author);
        }

        public void SetShelf(int shelfNumber)
        {
            ShelfNumber = shelfNumber;
        }
        public override void DownloadFile()
        {
            Console.WriteLine("Downloading e-book file...");
        }
    }
}

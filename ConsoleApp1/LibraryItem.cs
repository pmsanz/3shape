namespace LibraryProjectChallenge
{
    public abstract class LibraryItem
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }

        public LibraryItem(string isbn, string title)
        {
            ISBN = isbn;
            Title = title;
        }
        public abstract void DownloadFile();
    }
}

namespace LibraryProjectChallenge
{
    public class ElectronicItem : LibraryItem
    {
        public ElectronicItem(string isbn, string title) : base(isbn, title)
        {
        }

        public override void DownloadFile()
        {
            Console.WriteLine("Downloading electronic item file...");
        }
    }
}

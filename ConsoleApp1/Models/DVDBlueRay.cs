namespace LibraryProjectChallenge.Models
{
    public class DVDBlueRay : Media
    {
        public DVDBlueRay(string isbn, string title) : base(isbn, title)
        {
        }

        public override void DownloadFile()
        {
            Console.WriteLine("Downloading DVD/Blu-ray video files...");
        }
    }
}

namespace LibraryProjectChallenge.Models
{
    public class CD : Media
    {
        public CD(string isbn, string title) : base(isbn, title)
        {
        }

        public override void DownloadFile()
        {
            Console.WriteLine("Downloading CD audio files...");
        }
    }
}

namespace LibraryProjectChallenge.Models
{
    public class Track
    {
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
    }

    public abstract class Media : LibraryItem
    {
        public List<Track> Tracks { get; protected set; }
        public Media(string isbn, string title) : base(isbn, title)
        {
            Tracks = new List<Track>();
        }
    }

}

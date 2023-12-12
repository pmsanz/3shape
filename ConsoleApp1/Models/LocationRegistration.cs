namespace LibraryProjectChallenge.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public List<Row> Rows { get; set; }
    }

    public class Row
    {
        public int RowId { get; set; }
        public int RoomId { get; set; }
        public int RowNumber { get; set; }
        public List<Bookshelf> Shelves { get; set; }
    }

    public class Bookshelf
    {
        public int RowId { get; set; }
        public int ShelfNumber { get; set; }
        public List<Book> Books { get; set; }
    }
}

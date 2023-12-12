using LibraryProjectChallenge.Models.Repository.Interfaces;

namespace LibraryProjectChallenge.Models.Repository
{
    internal class BookshelfRepository : FakeDBContext, IBookshelfRepository
    {
        public BookshelfRepository(List<Room> db) : base(db)
        {
        }

        public Bookshelf? GetBookshelfOrDefault(int roomNumber, int rowNumber, int shelfNumber)
        {
            var room = DB.First(x => x.RoomNumber == roomNumber);
            return room.Rows.First(x => x.RowNumber == rowNumber).Shelves.FirstOrDefault(x => x.ShelfNumber == shelfNumber);
        }
    }
}

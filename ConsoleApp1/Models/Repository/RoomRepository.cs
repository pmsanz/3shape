using LibraryProjectChallenge.Models.Repository.Interfaces;

namespace LibraryProjectChallenge.Models.Repository
{
    internal class RoomRepository : FakeDBContext, IRoomRepository
    {
        public RoomRepository(List<Room> db) : base(db)
        {
        }

        public Room? GetRoomByNumberOrDefault(int roomNumber)
        {
            return DB.FirstOrDefault(x => x.RoomNumber == roomNumber);
        }
    }
}

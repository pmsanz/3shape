namespace LibraryProjectChallenge.Models.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Room? GetRoomByNumberOrDefault(int roomNumber);
    }
}

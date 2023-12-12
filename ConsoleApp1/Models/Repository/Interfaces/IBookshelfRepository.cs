namespace LibraryProjectChallenge.Models.Repository.Interfaces
{
    public interface IBookshelfRepository
    {
        Bookshelf? GetBookshelfOrDefault(int roomNumber, int rowNumber, int shelfNumber);
    }
}

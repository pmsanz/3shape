namespace LibraryProjectChallenge.Models.Repository.Interfaces
{
    internal interface IRowRepository
    {
        Row GetRowByNumber(int roomNumber);
    }
}

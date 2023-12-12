namespace LibraryProjectChallenge.Models.Repository.Interfaces
{
    public interface IBookRepository
    {
        Book? GetBookByISBNOrDefault(string isbn);
        void AddBook(Book book);
    }
}

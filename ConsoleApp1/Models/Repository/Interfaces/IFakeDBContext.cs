namespace LibraryProjectChallenge.Models.Repository.Interfaces
{
    public class FakeDBContext
    {
        protected List<Room> DB;

        public FakeDBContext(List<Room> db)
        {
            DB = db;
        }
    }
}

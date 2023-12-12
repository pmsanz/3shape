using LibraryProjectChallenge;
using LibraryProjectChallenge.Models;

namespace LibraryTestProject
{

    public static class Utils
    {

        public static string GetFilePath(string fileName)
        {

            string resourcePath = @"Resources\\";
            var currentDirectory = Directory.GetCurrentDirectory();
            resourcePath = Path.Combine(currentDirectory, resourcePath);
            string fullPath = Path.Combine(resourcePath, fileName);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException();
            }
            return fullPath;

        }

    }

    public class BookManagerTest
    {
        [Fact]
        public void ReadBooks_ReadFromTxtFile_True()
        {
            string fileName = "NewBooks.txt";
            string fullFilePath = Utils.GetFilePath(fileName);
            string input = File.ReadAllText(fullFilePath);

            List<Book> result = BookManager.ReadBooks(input);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            Assert.Equal("Texts from Denmark", result[0].Title);
            Assert.Equal("Brian Jensen", result[0].Authors[0]);
            Assert.Equal("Gyldendal", result[0].Publisher);
            Assert.Equal(2001, result[0].Published);
            Assert.Equal(253, result[0].Pages);

            Assert.Equal("Stories from abroad", result[1].Title);
            Assert.Contains("Peter Jensen", result[1].Authors[0]);
            Assert.Contains("Hans Andersen", result[1].Authors[1]);
            Assert.Equal("Borgen", result[1].Publisher);
            Assert.Equal(2012, result[1].Published);
            Assert.Equal(156, result[1].Pages);
        }

        [Fact]
        public void FindBooks_ShouldReturnMatchingBooks_Equal6()
        {
            string fileName = "FindBooksFile.txt";
            string fullFilePath = Utils.GetFilePath(fileName);
            string input = File.ReadAllText(fullFilePath);

            BookManager BookManagerInstance = new BookManager(input);

            string searchString = @"*20* & *The*";
            List<Book> result = BookManagerInstance.FindBooks(searchString);

            Assert.NotNull(result);
            Assert.Equal(6, result.Count);
        }

        [Fact]
        public void FindBooks_ShouldReturnMatchingBooks_Equal1()
        {
            string fileName = "FindBooksFile.txt";
            string fullFilePath = Utils.GetFilePath(fileName);
            string input = File.ReadAllText(fullFilePath);

            BookManager BookManagerInstance = new BookManager(input);

            string searchString = @"*Lisa Anderson \& Peter Jhon*";
            List<Book> result = BookManagerInstance.FindBooks(searchString);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void FindBooks_ShouldReturnMatchingBooks_Empty()
        {
            string fileName = "FindBooksFile.txt";
            string fullFilePath = Utils.GetFilePath(fileName);
            string input = File.ReadAllText(fullFilePath);

            BookManager BookManagerInstance = new BookManager(input);

            string searchString = @"*@*";
            List<Book> result = BookManagerInstance.FindBooks(searchString);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void SanitizeQuery_ShouldReturnTwoQueries_Equal3()
        {

            string searchString = @"*20* & *charles\&peter* & *george*";
            List<string> result = BookManager.SanitizeQuery(searchString);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

            Assert.Equal("20", result[0]);
            Assert.Contains(@"charles&peter", result[1]);
            Assert.Contains("george", result[2]);

        }

        [Fact]
        public void SanitizeQuery_ShouldReturnThreeQueries_Equal3()
        {

            string searchString = @"*20* & *charles* & *george*";
            List<string> result = BookManager.SanitizeQuery(searchString);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

            Assert.Equal("20", result[0]);
            Assert.Contains("charles", result[1]);
            Assert.Contains("george", result[2]);

        }

    }
}
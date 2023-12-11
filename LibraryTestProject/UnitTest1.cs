using LibraryProjectChallenge;

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

    public class UnitTest1
    {
        [Fact]
        public void ReadBooks_readFromFile_True()
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
    }
}
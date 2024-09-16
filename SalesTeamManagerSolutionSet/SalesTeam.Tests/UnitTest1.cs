using SalesTeam.DataAccess.Csv;

namespace SalesTeam.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var csvReader = new CsvReader();
            var path = @".\SalesRecords.csv";
            // Act
            var records = csvReader.ReadCsvFromFile(path);
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }
    }
}

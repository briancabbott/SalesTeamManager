
using SalesTeam.DataAccess.Csv;
using System.Collections.Generic;
using System.Formats.Asn1;

namespace SalesTeam.Tests
{
    [TestClass]
    public class CsvReaderTests
    {
        [TestMethod]
        public void ReadCsvFromFile_ValidFile_ReturnsRecords()
        {
            // Arrange
            var csvReader = new CsvReader();
            var path = @".\SalesRecords.csv";
            var expectedRecords = new List<string> { "Record1", "Record2", "Record3" }; // Adjust based on actual expected records

            // Act
            var records = csvReader.ReadCsvFromFile(path);

            // Assert
            CollectionAssert.AreEqual(expectedRecords, records);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadCsvFromFile_FileNotFound_ThrowsException()
        {
            // Arrange
            var csvReader = new CsvReader();
            var path = @".\NonExistentFile.csv";

            // Act
            csvReader.ReadCsvFromFile(path);

            // Assert is handled by ExpectedException
        }
    }
}

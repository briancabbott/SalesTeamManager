
using System.Text.Json;
using SalesTeam.Analytics;
using SalesTeam.Common;
using SalesTeam.DataAccess.Csv;

static string to_json(List<SalesRecord> records)
{
    JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        IncludeFields = true
    };
    var asJson = JsonSerializer.Serialize(records, options);
    return asJson ?? string.Empty;
}

var path = "SalesRecords.csv";
var csvReader = new CsvReader();
var records = csvReader.ReadCsvFromFile(path);

Console.WriteLine("Entering Main...");
// Console.WriteLine(to_json(records));

AnalyticalCalculator calculator = new(records);
Console.WriteLine($"Median Unit Cost: {calculator.CalculateMedianUnitCost()}");
Console.WriteLine($"Most Common Region: {calculator.CalculateMostCommonRegion()}");
var (firstOrderDate, lastOrderDate, daysBetween) = calculator.CalculateFirstAndLastOrderDate();
Console.WriteLine($"First Order Date: {firstOrderDate}");
Console.WriteLine($"Last Order Date: {lastOrderDate}");
Console.WriteLine($"Days Between: {daysBetween}");
Console.WriteLine($"Total Revenue: {calculator.CalculateTotalRevenue()}");
Console.WriteLine($"Total Profit: {calculator.CalculateTotalProfit()}");
Console.WriteLine($"Total Cost: {calculator.CalculateTotalCost()}");
Console.WriteLine("Exiting Main...");


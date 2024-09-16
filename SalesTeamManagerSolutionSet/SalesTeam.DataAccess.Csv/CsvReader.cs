
using SalesTeam.Common;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;


namespace SalesTeam.DataAccess.Csv
{
    public class CustomDateTimeConverter : DefaultTypeConverter
    {
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is DateTime date)
            {
                return date.ToString("MM/dd/yyyy");
            }
            var convertedString = base.ConvertToString(value, row, memberMapData);
            return convertedString;
        }

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var texts = text.Split("/");
            var newDate = "";

            for (int i = 0; i < texts.Length; i++)
            {
                if (i > 1)
                {
                    break;
                }
                var t = texts[i];
                if (t.Length == 1)
                {
                    t = "0" + t;
                }
                newDate += t + "/";
            }
            newDate += texts[2];
            try
            {
                var date = DateTime.ParseExact(newDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                return date;
            }
            catch (Exception ex)
            {
                if (DateTime.TryParseExact(newDate, "M/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
                {
                    return date;
                }
            }
            return DateTime.MinValue;
        }
    }

    public class CsvReader
    {
        public CsvReader()
        {
        }

        public List<SalesRecord> ReadCsvFromFile(string path)
        {
            using StreamReader reader = new(path);
            string text = reader.ReadToEnd();
            return ReadCsv(text);
        }
        public List<SalesRecord> ReadCsv(string content)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            using var reader = new StringReader(content);
            using var csv = new CsvHelper.CsvReader(reader, config);

            csv.Context.TypeConverterCache.AddConverter<DateTime>(new CustomDateTimeConverter());
            csv.Context.RegisterClassMap<SalesRecordMap>();

            var records = csv.GetRecords<SalesRecord>();
            var l = new List<SalesRecord>();
            foreach (var record in records)
            {
                l.Add(record);
            }
            return l;
        }

        public class SalesRecordMap : ClassMap<SalesRecord>
        {
            public SalesRecordMap()
            {
                Map(m => m.Region).Name("Region");
                Map(m => m.Country).Name("Country");
                Map(m => m.ItemType).Name("Item Type");
                Map(m => m.SalesChannel).Name("Sales Channel");
                Map(m => m.OrderPriority).Name("Order Priority");
                Map(m => m.OrderDate).Name("Order Date").TypeConverterOption.Format("MM/dd/yyyy");
                Map(m => m.OrderID).Name("Order ID");
                Map(m => m.ShipDate).Name("Ship Date").TypeConverterOption.Format("MM/dd/yyyy");
                Map(m => m.UnitsSold).Name("Units Sold");
                Map(m => m.UnitPrice).Name("Unit Price");
                Map(m => m.UnitCost).Name("Unit Cost");
                Map(m => m.TotalRevenue).Name("Total Revenue");
                Map(m => m.TotalCost).Name("Total Cost");
                Map(m => m.TotalProfit).Name("Total Profit");
            }
        }
    }
}

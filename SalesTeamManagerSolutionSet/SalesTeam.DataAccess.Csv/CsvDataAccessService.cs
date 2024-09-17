
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SalesTeam.Common;

namespace SalesTeam.DataAccess.Csv
{
    public class CsvDataAccessService : IDataAccessService
    {
        public CsvDataAccessService() { 
                
        }

        public void AddSalesRecord(SalesRecord record)
        {
            throw new NotImplementedException();
        }

        public void AddSalesRecords(List<SalesRecord> records)
        {
            throw new NotImplementedException();
        }

        public SalesRecord GetSalesRecord(int orderId)
        {
            return GetSalesRecords().FirstOrDefault(record => record.OrderID == orderId);
        }

        public List<SalesRecord> GetSalesRecords()
        {

            GeneralConfiguration config = GeneralConfiguration.Current();
            CsvReader reader = new CsvReader();
            return reader.ReadCsvFromFile(config.CsvFilePath);
        }

        public void ModifySalesRecord(int orderId, SalesRecord record)
        {
            throw new NotImplementedException();
        }

        public void RemoveSalesRecord(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
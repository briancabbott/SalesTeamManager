using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SalesTeam.Common;

namespace SalesTeam.DataAccess
{
    public interface IDataAccessService
    {
        void AddSalesRecord(SalesRecord record);
        void AddSalesRecords(List<SalesRecord> records);
        void ModifySalesRecord(int orderId, SalesRecord record);
        void RemoveSalesRecord(int orderId);
        SalesRecord GetSalesRecord(int orderId);
        List<SalesRecord> GetSalesRecords();
    }
}

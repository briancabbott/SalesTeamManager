
using System;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace SalesTeam.Common
{
    public class SalesRecord
    {
        public string Region { get; set; }
        public string Country { get; set; }
        public string ItemType { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderID { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal UnitPrice { get; set; }
        public  decimal  UnitCost { get; set; }
        public decimal   TotalRevenue { get; set; }
        public  decimal      TotalCost { get; set; }
        public decimal TotalProfit { get; set; }


        // ToString method
        override public string ToString()
        {
            // Json format
            var js = new JsonSerializerOptions();
            js.WriteIndented = true;
            js.IncludeFields = true;
            return JsonSerializer.Serialize(this, this.GetType(), js);


            //return $"{{Region: {Region}, Country: {Country}, ItemType: {ItemType}, SalesChannel: {SalesChannel}, OrderPriority: {OrderPriority}, OrderDate: {OrderDate}, OrderID: {OrderID}, ShipDate: {ShipDate}, UnitsSold: {UnitsSold}, UnitPrice: {UnitPrice}, UnitCost: {UnitCost}, TotalRevenue: {TotalRevenue}, TotalCost: {TotalCost}, TotalProfit: {TotalProfit} }}";
        }

    }
}
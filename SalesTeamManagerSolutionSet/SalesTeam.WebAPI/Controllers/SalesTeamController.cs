using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using SalesTeam.Analytics;
using SalesTeam.Common;
using SalesTeam.DataAccess;

namespace SalesTeam.WebAPI.Controllers
{
    public class SalesTeamController : GraphController {
        private readonly ILogger<SalesTeamController> _logger;
        private readonly IDataAccessService _dataAccessService;

        public SalesTeamController(ILogger<SalesTeamController> logger, IDataAccessService dataAccessService)
        {
            _logger = logger;
            _dataAccessService = dataAccessService;
        }

        [Mutation]
        public void AddSalesRecord(SalesRecord record)
        {
            _dataAccessService.AddSalesRecord(record);
        }

        [Mutation]
        public void AddSalesRecords(List<SalesRecord> records)
        {
            _dataAccessService.AddSalesRecords(records);
        }

        [Mutation]
        public void ModifySalesRecord(int orderId, SalesRecord record)
        {
            _dataAccessService.ModifySalesRecord(orderId, record);  
        }

        [Mutation]
        public void RemoveSalesRecord(int orderId)
        {
            _dataAccessService.RemoveSalesRecord(orderId);
        }

        [Query]
        public SalesRecord GetSalesRecord(int orderId)
        {
            return _dataAccessService.GetSalesRecord(orderId);
        }

        [Query]
        public List<SalesRecord> GetSalesRecords()
        {
            return _dataAccessService.GetSalesRecords();
        }

        // median Unit Cost
        [Query]
        public decimal CalculateMedianUnitCost()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateMedianUnitCost();
        }

        // most common Region
        [Query]
        public string CalculateMostCommonRegion()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateMostCommonRegion();
        }

        // first and last Order Date and the days between them
        [Query]
        public (DateTime, DateTime, int) CalculateFirstAndLastOrderDate()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateFirstAndLastOrderDate();
        }

        // total revenue
        [Query]
        public decimal CalculateTotalRevenue()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateTotalRevenue();
        }

        [Query]
        public decimal CalculateTotalProfit()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateTotalProfit();
        }

        [Query]
        public decimal CalculateTotalCost()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateTotalCost();
        }

        [Query]
        public decimal CalculateAverageProfit()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateAverageProfit();
        }

        [Query]
        public decimal CalculateAverageCost()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateAverageCost();

        }

        [Query]
        public decimal CalculateAverageRevenue()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateAverageRevenue();
        }

        [Query]
        public decimal CalculateAverageUnitCost()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateAverageUnitCost();
        }

        [Query]
        public decimal CalculateAverageUnitPrice()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateAverageUnitPrice();
        }

        [Query]
        public decimal CalculateAverageUnitsSold()
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateAverageUnitCost();
        }

        [Query]
        public decimal CalculateProfitForYear(int year)
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateProfitForYear(year);
        }

        // Calculate the total profit for a given quarter
        [Query]
        public decimal CalculateProfitForQuarter(int year, int quarter)
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateProfitForQuarter(year, quarter);
        }

        // Calculate the total profit for a given month
        [Query]
        public decimal CalculateProfitForMonth(int year, int month)
        {
            AnalyticalCalculator analyticalCalculator = new AnalyticalCalculator(_dataAccessService.GetSalesRecords());
            return analyticalCalculator.CalculateProfitForMonth(year, month);
        }
    }
}

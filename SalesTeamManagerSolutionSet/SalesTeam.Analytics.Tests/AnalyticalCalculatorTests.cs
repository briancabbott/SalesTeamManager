using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTeam.Analytics;
using System;
using System.Collections.Generic;

namespace SalesTeam.Tests
{
    [TestClass]
    public class SalesAnalyzerTests
    {

//        ReturnsExpectedResult
//NullData_ThrowsException
//            EmptyData_ReturnsZero
//            SingleSale_ReturnsSaleAmount




        [TestMethod]
        public void AnalyzeSalesData_ValidData_ReturnsExpectedResult()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnalyzeSalesData_NullData_ThrowsException()
        {
        }

        [TestMethod]
        public void AnalyzeSalesData_EmptyData_ReturnsZero()
        {
        }

        [TestMethod]
        public void AnalyzeSalesData_SingleSale_ReturnsSaleAmount()
        {
        }

        [TestMethod]
        public void AnalyzeSalesData_MixedData_ReturnsCorrectSum()
        {

        }









        //public decimal CalculateMedianUnitCost()
        //public string CalculateMostCommonRegion()
        //public (DateTime, DateTime, int) CalculateFirstAndLastOrderDate()
        //public decimal CalculateTotalRevenue()
        //public decimal CalculateTotalProfit()
        //public decimal CalculateTotalCost()
        //public decimal CalculateAverageProfit()
        //public decimal CalculateAverageCost()
        //public decimal CalculateAverageRevenue()
        //public decimal CalculateAverageUnitCost()
        //public decimal CalculateAverageUnitPrice()
        //public decimal CalculateAverageUnitsSold()
        //public decimal CalculateProfitForYear(int year)
        //public decimal CalculateProfitForQuarter(int year, int quarter)
        //public decimal CalculateProfitForMonth(int year, int month)
        
    }
}

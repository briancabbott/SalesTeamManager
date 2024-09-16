using SalesTeam.Common;

namespace SalesTeam.Analytics
{

    public class AnalyticalShaper
    {
        public List<SalesRecord> analysisTargetSet;

        public AnalyticalShaper(List<SalesRecord> _analysisTargetSet)
        {
            this.analysisTargetSet = _analysisTargetSet;
        }

        public List<SalesRecord> BaseShape()
        {
            return analysisTargetSet;
        }

        public List<SalesRecord> GetYearShape(int year)
        {
            return analysisTargetSet.Where(record => record.OrderDate.Year == year).ToList();
        }

        public List<SalesRecord> GetQuarterShape(int year, int quarter)
        {
            return this.analysisTargetSet.Where(record => record.OrderDate.Year == year && (record.OrderDate.Month - 1) / 3 == quarter - 1).ToList();
        }

        public List<SalesRecord> GetMonthShape(int year, int month)
        {
            return this.analysisTargetSet.Where(record => record.OrderDate.Year == year && record.OrderDate.Month == month).ToList();
        }
    }


    // * The median Unit Cost
    // * The most common Region
    // * The first and last Order Date and the days between them
    // * The total revenue

    public class OperationShapeAssoc<T, TT>
    {
        private Func<T> Operation;
        private Func<TT> Shape;
    }

    public class AnalyticalCalculator
    {
        private readonly List<SalesRecord> analysisTargetSet;
        private readonly List<OperationShapeAssoc<Func<object>, Func<object>>> dataQueryPipelineShapers;
        private readonly AnalyticalShaper shaper;

        public AnalyticalCalculator(List<SalesRecord> _analysisTargetSet)
        {
            this.analysisTargetSet = _analysisTargetSet;
            this.shaper = new AnalyticalShaper(_analysisTargetSet);
        }

        // median Unit Cost
        public decimal CalculateMedianUnitCost()
        {
            var sortedUnitCosts = this.shaper.BaseShape().Select(record => record.UnitCost).OrderBy(cost => cost).ToList();
            return sortedUnitCosts[sortedUnitCosts.Count / 2];
        }

        // most common Region
        public string CalculateMostCommonRegion()
        {
            return this.shaper.BaseShape().GroupBy(record => record.Region).OrderByDescending(group => group.Count()).First().Key;
        }

        // first and last Order Date and the days between them
        public (DateTime, DateTime, int) CalculateFirstAndLastOrderDate()
        {
            var sortedOrderDates = this.shaper.BaseShape().Select(record => record.OrderDate).OrderBy(date => date).ToList();
            return (sortedOrderDates.First(), sortedOrderDates.Last(), (int)(sortedOrderDates.Last() - sortedOrderDates.First()).TotalDays);
        }

        // total revenue
        public decimal CalculateTotalRevenue()
        {
            return this.shaper.BaseShape().Sum(record => record.TotalRevenue);
        }





        public decimal CalculateTotalProfit()
        {
            return this.shaper.BaseShape().Sum(record => record.TotalProfit);
        }

        public decimal CalculateTotalCost()
        {
            return this.shaper.BaseShape().Sum(record => record.TotalCost);
        }

        public decimal CalculateAverageProfit()
        {
            return this.shaper.BaseShape().Average(record => record.TotalProfit);
        }

        public decimal CalculateAverageCost()
        {
            return this.shaper.BaseShape().Average(record => record.TotalCost);
        }

        public decimal CalculateAverageRevenue()
        {
            return this.shaper.BaseShape().Average(record => record.TotalRevenue);
        }

        public decimal CalculateAverageUnitCost()
        {
            return this.shaper.BaseShape().Average(record => record.UnitCost);
        }

        public decimal CalculateAverageUnitPrice()
        {
            return this.shaper.BaseShape().Average(record => record.UnitPrice);
        }

        public decimal CalculateAverageUnitsSold()
        {
            return this.shaper.BaseShape().Average(record => record.UnitsSold);
        }

        public decimal CalculateProfitForYear(int year)
        {
            return this.shaper.GetYearShape(year).Where(record => record.OrderDate.Year == year).Sum(record => record.TotalProfit);
        }

        // Calculate the total profit for a given quarter
        public decimal CalculateProfitForQuarter(int year, int quarter)
        {
            return this.shaper.GetQuarterShape(year, quarter).Sum(record => record.TotalProfit);
        }

        // Calculate the total profit for a given month
        public decimal CalculateProfitForMonth(int year, int month)
        {
            return this.shaper.GetMonthShape(year, month).Sum(record => record.TotalProfit);
        }
    }
}

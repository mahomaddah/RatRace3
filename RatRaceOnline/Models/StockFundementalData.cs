namespace RatRace3.Models
{
    public class StockFundementalData
    {
        public string StockSymbol { get; set; }
        /// <summary>
        /// in Bilion USD
        /// </summary>
        public double TotalCash { get; set; }
        /// <summary>
        /// in Bilion USD
        /// </summary>
        public double TotalDebts { get; set; }
        /// <summary>
        /// in Bilion USD
        /// </summary>
        public double AnnualIncome { get; set; }
        /// <summary>
        ///     EPSpast5Y=0.4840, //48.40%
        /// </summary>
        public double EPSpast5Y { get; set; }
        /// <summary>
        ///     EPSthisYr= 1.2805,//128.05%
        /// </summary>
        public double EPSthisYr { get; set; }
        /// <summary>
        ///    EPSnext5Y=0.35,//+35%.. 
        /// </summary>
        public double EPSnext5Y { get; set; }
        /// <summary>
        /// //SustainableCompetitiveAdvantage 5 of 9 (Warentbuffet wide economic mote )
        /// </summary>
        public int SustainableCompetitiveAdvantage { get; set; }
        public double DCFvaluation { get; set; }
    }
}
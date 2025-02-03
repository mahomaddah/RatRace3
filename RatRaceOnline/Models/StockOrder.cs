namespace RatRace3.Models
{
    public class StockOrder
    {
        /// <summary>
        /// MSFT
        /// </summary>
        public string StockSymbol { get; set; }
        public double AmounthOfMoney { get; set; }
        /// <summary>
        /// 02.2025
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Requested, Filled, Faild...
        /// </summary>
        public string FillingStatus { get; set; }///
        public string Opration { get; set; }//BUY SELL
        public int ShareHolderID { get; set; }
    }

}
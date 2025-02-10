using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RatRace3.Models
{
    public class Company
    {
        /// <summary>
        /// // can be user as primery key ... Example: GOOGL is symbol of alphabet company .....
        /// </summary>
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value;
                ImagePath = symbol.ToLower() + ".png";
            }
        }
        private string symbol;

        // public string Symbol { get; set; }


        /// <summary>
        /// Symbol.Tolower+".png" Is Image path.. this is onley used for binding data and and Setting to symbol auto set this...
        /// </summary>
        public string ImagePath { get;private set; }

        /// <summary>
        /// StockPrice = 125.51, //PriceCanldes.last ..
        /// </summary>
        public double StockPrice { get; set; }

        /// <summary>
        /// StockLastCandlePrice =120.12,// USed for P&L...
        /// </summary>
        public double StockLastCandlePrice { get; set; }

        public string StockDetail { get; set; }
        public string StockExchange { get; set; }

        /// <summary>

        /// by defult is NASDAQ if not change ...
        /// </summary>

        //image paths are this.Symbol.ToLower()+".png"....

        public StockFundementalData StockFundementalData { get; set; }
        public List<PriceCandleModel> PriceCandles { get; set; }
        public List<StockOrder> StockOrders { get; set; }


        //  public AssetModel CompanyRelatedAsset { get; set; } 

        public Company()
        {
            StockExchange = "NASDAQ";
                
            StockFundementalData = new Models.StockFundementalData
            {
                StockSymbol = this.Symbol
                //,
                //TotalCash=380.23 ,//in Bilion USD
                //TotalDebts=254.16,
                //AnnualIncome=63.07,

                //EPSpast5Y=0.4840, //48.40%
                //EPSthisYr= 1.2805,//128.05%
                //EPSnext5Y=1.35,

                //SustainableCompetitiveAdvantage=5//5 of 9 

            };
            var random = new Random();

            PriceCandles = new List<PriceCandleModel>
            {
                //new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-14).ToString("MM-yyyy"), Value = 30 + random.Next(-50, 100) },
                //new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-13).ToString("MM-yyyy"), Value = 45 + random.Next(-50, 100) },
          
                //new PriceCandleModel { Date = DateTime.Now.Date.ToString("MM-yyyy"), Value = 188 + random.Next(-50, 100) }
            };

            StockOrders = new List<StockOrder>
            {
                //new StockOrder{ StockSymbol="MSFT" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                //new StockOrder{ StockSymbol="MSFT" , AmounthOfMoney = 103.56, Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Buy", ShareHolderID = 2 }

            };

        }
    }
}

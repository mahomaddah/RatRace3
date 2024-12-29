using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class Company
    {
        /// <summary>
        /// // can be user as primery key ... Example: GOOGL is symbol of alphabet company .....
        /// </summary>
        public string Symbol { get; set; } 
        public double StockPrice { get; set; }
        public string StockDetail { get; set; }
        public string StockExchange { get; internal set; }/// <summary>
        /// by defult is NASDAQ if not change ...
        /// </summary>

        //image paths are this.Symbol.ToLower()+".png"....

        public Company()
        {
            StockExchange = "NASDAQ";
        }
    }
}

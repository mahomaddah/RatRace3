using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class SunburstModel
    {
      

        public string RealStateName { get; set; }
     
   
        public double Rent { get; set; }
        public double LandBuyPrice { get; set; }
        public double MorgageValue { get; set; }

        //i'ts better to diversify Mathematiclly and not onley invest in 1 sector best is to invest in 
        public string Sector { get; set; } //Sector //1.Materials 2 Health Care 3 Information Technology 4. Real Estate 5 Communication Services 6 Utilities  7 Financials 7 Consumer Staples 8 Consumer Discretionary 9 Industrials 10  Energy 11
        //https://en.wikipedia.org/wiki/Global_Industry_Classification_Standard#
        //The Global Industry Classification Standard (GICS) 

        public string Luxury { get; set; }//level 0 is free services... level 1 2 3 level 1 is hight visitor but cheap products, levet 2 is medium visitor medium products, level 3 is Low visitors Expensive products...

        /// <summary>
        /// House Level (company level ) in monopoly every 3 land has the same color ()
        /// </summary>
        public short CompanyLevel { get; set; } //Level 0,1,2,3,4 and level 5 = Hotel in monopoly...
        public string LandType { get; set; }//land 1 Build 2 Store 3 Sell  // like in sim city Resistance , office , industury and Commirance ( having 4 of same will have a premiumt rate of 1.4 x rent for example becuse of comulative effect ) or having 1 of each type will give you 1.5x rent of commulative effect of having  bulding and storing and selling the product...
        //or 1 .mine  2.craft 3. sell...
        // 1.Marketing bonus ( how much pepole you can reach in this building) 2 of 5
        // 2.Engineering (how quality value you produce for you client ) 4 of 5
        // 3.Managment and pricing power ( how much more you can rase power and not losing any Client (if positive )((how competetive price you have ) negative means your compititors are better in quality to your price u still need to give some discount to reach the competetiveness...)
        /// <summary>
        /// there is 8 color in monopoly Owning 3 of same color give us chance to start upgrade the company from level 1 to 2 ... Limited. Anonim , Holding... ,IPO ..
        /// </summary>
        public string LandColor { get; set; } //can be same as sectors ....



        public SunburstModel()
        {
            CompanyLevel = 0;//by defult... //max = 5 means hotel...
        }


    }
}

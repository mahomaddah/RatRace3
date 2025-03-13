
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class AssetModel
    {


        /// <summary>
        /// Good For RD if + means growth - means Discount rate Automaticlly can grow every turn by void growth() method above...
        /// </summary>
      //  public double GrowthorDiscountRate { get; set; }
        public string AssetType { get; set; }
        public int AssetModelID { get; set; }
        /// <summary>
        /// PassiveIncome Will be Mounthly ...
        /// </summary>
        public double PassiveIncome { get; set; }  //in 8% annual will take 6.67 % / month if FD...
        public string AssetName { get; set; }
        public double AssetValue { get; set; }
        /// <summary>
        /// if the AssetType Is Stock , That stock's Company Model's Primery key which is SYMBOL of company ... 
        /// </summary>
        public string StockCompanySymbol { get; set; }

      /// <summary>
      /// Used for P&L EVEY TIME YOU Buy StockAverageCost will be averaged...
      /// </summary>
        public double StockAverageBuyCost { get; set; }
        public double StockQuantity { get; set; }

        public bool IsBankDeposit { get; set; }//false by defult...
        /// <summary>
        /// //false by defult...
        /// </summary>
        public bool IsRecursiveDepositRD { get; set; }
        /// <summary>
        /// AssetIncomeSourseRelatingGUID is the Passive income that asset crate on income list ... like bank deposit deposit and Mountlhy incomes...
        /// if (FD or RD,..)  ... Asset deleted income sourse should be also deleted.. 
        /// AssetIncomeSourseRelatingGUID = 0; // in case of passive asset that not gereate value by time like gold... 
        /// </summary>
        public string AssetIncomeSourseRelatingGUID { get; set; }

        /// <summary>
        /// //if i'ts a Fixed deposit at bank or RD or mutual fund or even SPX maybe ... (Note :i't ANNUAL ) ...
        /// </summary>
        public double IntrestRate { get; set; }//if i'ts a Fixed deposit at bank or RD or mutual fund or even SPX maybe ...

        /// <summary>
        /// for RD we have expancesObject which will be deleted after maturity and it value added to asset every month...
        /// </summary>
        public string AssetRelatedExpanceGUID { get; internal set; }
       /// <summary>
       /// Player.Month when purchesed the asset...
       /// </summary>
        public int AssetOwnedMonth { get; internal set; }

        public void GrowthBy(double GrouthOrDiscountRate)
        {
            this.AssetValue *=(1+GrouthOrDiscountRate);
        }
        public AssetModel()
        {
            IsBankDeposit = false;
            IsRecursiveDepositRD = false;
            AssetType = AssetTypes.Stock.ToString();
            AssetIncomeSourseRelatingGUID = "0"; // in case of passive asset that not gereate value by time like gold...
            IntrestRate = 1;//by defult.. CHange for RD and other automatic growthing values...
            AssetOwnedMonth = 0;
            StockAverageBuyCost = 0;
        }

       
    }

    public enum AssetTypes
    {
        FixedDeposit,
        RecursiveDeposit,
        Bond,
        Stock,
        RealEstate,
        MutualFund,
        Other
    }
}

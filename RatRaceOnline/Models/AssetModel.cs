
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class AssetModel
    {
        public Enum AssetType { get; set; }
        public int AssetModelID { get; set; }
        /// <summary>
        /// PassiveIncome Will be Mounthly ...
        /// </summary>
        public double PassiveIncome { get; set; }  //in 8% annual will take 6.67 % / month if FD...
        public string AssetName { get; set; }
        public double AssetValue { get; set; }
        /// <summary>
        /// //false by 
        public bool IsBankDeposit { get; set; }//false by defult...
        /// <summary>
        /// //false by defult...
        /// </summary>
        public bool IsRecursiveDepositRD { get; set; }

        /// <summary>
        /// //if i'ts a Fixed deposit at bank or RD or mutual fund or even SPX maybe ... (Note :i't ANNUAL ) ...
        /// </summary>
        public double IntrestRate { get; set; }//if i'ts a Fixed deposit at bank or RD or mutual fund or even SPX maybe ...

        public void GrowthBy(double GrouthOrDiscountRate)
        {
            this.AssetValue += GrouthOrDiscountRate;
        }
        public AssetModel()
        {
            IsBankDeposit = false;
            IsRecursiveDepositRD = false;
            AssetType = AssetTypes.Stock;
        }

       
    }
    public enum AssetTypes
    {
        FixedDeposit,
        RecursiveDeposit,
        Bond,
        Stock,
        RealEstate
    }
}

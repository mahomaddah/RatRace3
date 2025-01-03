
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class AssetModel
    {
        public int AssetModelID { get; set; }
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
        /// //if i'ts a Fixed deposit at bank or RD or mutual fund or even SPX maybe ...
        /// </summary>
        public double IntrestRate { get; set; }//if i'ts a Fixed deposit at bank or RD or mutual fund or even SPX maybe ...

        public AssetModel()
        {
            IsBankDeposit = false;
            IsRecursiveDepositRD = false;
        }


    }
}

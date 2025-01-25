using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RatRace3.Models
{
    public class PlayerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int PlayerModelID { get; set; }
        public double TotalExpences { get; set; }
      //  public double Balance { get; set; }

        private double balance;

        public double Balance
        {
            get { return balance; }
            set { balance = Math.Round(value,2);

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// NetTotalIncome = player Cashflow...
        /// </summary>
        public double NetTotalIncome { get; set; }

        public int MaximumMonth { get; set; }
        public int CurrentMonth { get; set; }

        public List<RealStateUnitModel> RealStateS { get; set; }

        public List<IncomeSourceModel> IncomeSources { get; set; }
        public List<ExpenseModel> Expenses { get; set; }
        public List<AssetModel>  Assets { get; set; }
        public List<LiabilityModel> Liabilities { get; set; }


        public PlayerModel()
        {
            Assets = new List<AssetModel> { };
            Liabilities = new List<LiabilityModel> { };
            IncomeSources = new List<IncomeSourceModel> { };
            Expenses = new List<ExpenseModel> { };
            RealStateS = new List<RealStateUnitModel> { };
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
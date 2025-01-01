namespace RatRace3.Models
{
    public class PlayerModel
    {
        public int PlayerModelID { get; set; }
        public double TotalExpences { get; set; }
        public double Balance { get; set; }
        public double Income { get; set; }

        public int MaximumMonth { get; set; }
        public int CurrentMonth { get; set; }

        public List<IncomeSourceModel> IncomeSources { get; set; }
        public List<ExpenseModel> Expenses { get; set; }
        public List<AssetModel>  Assets { get; set; }
        public List<LiabilityModel> Liabilities { get; set; }

        public PlayerModel()
        {
            Assets = new List<AssetModel> { };
            Liabilities = new List<LiabilityModel> { };
        }


    }
}
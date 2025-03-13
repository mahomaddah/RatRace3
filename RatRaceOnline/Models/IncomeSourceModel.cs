namespace RatRace3.Models
{
    public class IncomeSourceModel
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        /// <summary>
        /// AssetIncomeSourseRelatingGUID=0 if the IncomeSource's asset is intangble like Khowlage or salary...
        /// </summary>
        public string AssetIncomeSourseRelatingGUID { get; set; }

        public IncomeSourceModel()
        {
            AssetIncomeSourseRelatingGUID = "0";
        }

    }
}
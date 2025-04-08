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
        /// <summary>
        /// Usefull for Bond similir not every month paying income instruments like Tbond that pay every 6 month.
        /// </summary>
        public int MonthPeriodOfPayment { get; internal set; } = 1;

        public IncomeSourceModel()
        {
            AssetIncomeSourseRelatingGUID = "0";
        }

    }
}
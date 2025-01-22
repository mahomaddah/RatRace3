namespace RatRace3.Models
{
    public class IncomeSourceModel
    {
        public int IncomeSourceID { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        /// <summary>
        /// RelatedAssetID=0 if the IncomeSource's asset is intangble like Khowlage or salary...
        /// </summary>
        public int RelatedAssetID { get; set; }

        public IncomeSourceModel()
        {
            RelatedAssetID = 0;
        }

    }
}
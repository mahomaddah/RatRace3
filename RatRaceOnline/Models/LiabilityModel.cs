namespace RatRace3.Models
{
    public class LiabilityModel
    {
        public int LiabilityModelID { get; set; }
        public double Totalamount { get; set; }
        public double RemainingAmount { get; set; }
        public string LiabilityName { get; set; }
        public double EMI { get; set; }
        public int MounthRemaining { get; set; }
        public double IntrestRate { get; set; }

    }
}
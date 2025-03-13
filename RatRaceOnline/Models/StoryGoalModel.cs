namespace RatRace3.Models
{
    public class StoryGoalModel
    {
        public string Goal { get; internal set; }
        public double Target { get; internal set; }
        public double YouHave { get; internal set; }
    }

    public enum GameGoalTypes{
        Liabilities, //number
        Cashflow, //amount
        Balance,//amount
        Month,//number
        RealEstate//number
      
    }
}
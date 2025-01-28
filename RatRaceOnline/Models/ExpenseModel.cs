namespace RatRace3.Models
{
    public class ExpenseModel
    {
        public int ExpenseModelID { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public  double Quality { get; set; }
        /// <summary>
        /// for example Education debt's Liability has a Mountly Expance of Education Debt's EMI which will be added to expences ... So when we delete that Liability you need to delete also the Expance model of it ....
        /// </summary>
        public int RelatedLiabilityID { get; set; }

        //After MVP... i will add sectors... human biologic , socio and pschologic needs , and wants based things ...
        public string RDrelatedAssetGUID { get; set; }
        public bool IsRDassetsExpense { get; internal set; }
    }
}

//After MVP... i will add sectors... human biologic , socio and pschologic needs , and wants based things ...
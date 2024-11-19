namespace RatRace3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("MarketPage", typeof(MarketPage));

            InitializeComponent();
        }
    }
}

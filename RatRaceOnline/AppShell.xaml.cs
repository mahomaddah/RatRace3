using RatRace3.View;
namespace RatRace3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("MarketPage", typeof(MarketPage));
            Routing.RegisterRoute("StoryModeView", typeof(StoryModeView));
            Routing.RegisterRoute("StoryDetailView", typeof(StoryDetailView));
            Routing.RegisterRoute("GameView", typeof(GameView));
            Routing.RegisterRoute("NewsPaperView", typeof(NewsPaperView));

            InitializeComponent();
        }
    }
}

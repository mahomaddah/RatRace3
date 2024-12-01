
namespace RatRace3
{
    public partial class MainPage : ContentPage
    {
    
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MarketPageBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MarketPage");
        }

        private async void SinglePlayerBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("StoryModeView");
        }

        private void RealEconomyClicked(object sender, EventArgs e)
        {
            //print Wait for it ... :D 
    
        }
        private void MultiplayerClicked(object sender, EventArgs e)
        {

            //print Wait for it ...
        }
    }


}


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

        private async void RealEconomyClicked(object sender, EventArgs e)
        {
            //print Wait for it ... :D 
            await Shell.Current.DisplayAlert("Wait for it...", "Have Any Ideas to improve ? Have any personal Financial story to share ? We can create your level :D Please mail us: support@getValueHunter.com", "Set to clipboard!I can't memorize it!");
            await Clipboard.SetTextAsync("support@getValueHunter.com");

        }
        private async void MultiplayerClicked(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("Wait for it...", "Have Any Ideas to improve ? Have any personal Financial story to share ? We can create your level :D Please mail us: support@getValueHunter.com", "Set to clipboard!I can't memorize it!");
            await Clipboard.SetTextAsync("support@getValueHunter.com");
            
            //print Wait for it ...
        }
    }


}

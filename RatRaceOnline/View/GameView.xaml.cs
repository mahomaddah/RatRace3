namespace RatRace3.View;
using RatRace3.View;
using Syncfusion.Maui.Cards;

public partial class GameView : ContentPage
{
    public CardViewModel CardviewModel { get; set; }
    public GameView()
	{
		InitializeComponent();
        CardviewModel = new CardViewModel();
        BindingContext = CardviewModel;

        // Set default card index to open first 
        CardviewModel.VisibleIndex = 1;

        UpdateOrientation();

        // Event to detect orientation change
        DeviceDisplay.MainDisplayInfoChanged += (s, e) => UpdateOrientation();

        //binding VM to Listview ....
      //  LVcompaiesMarket.ItemsSource = CardviewModel.StockMarketCompanys;



    }
    private void UpdateOrientation()
    {
       
        // for fixin radial Menu button's ( flower bank button android rotation bug..)
        if (  (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
        {
            //change button point change the 0,0 to a real working tested button location ...
            radialMenu.Point = new Point(0,0);
        }
        else if ((DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait)
        {
            //return button point 83,125 which tested for a
            radialMenu.Point = new Point(83, 125);
        }

    }

    private async void cardNavBtn_Clicked(object sender, EventArgs e)
    {
		if(sender!=null)
		{ 
          CardviewModel.VisibleIndex = Convert.ToInt16(((Button)sender).CommandParameter);
        // BindingContext = CardviewModel;
        // await DisplayAlert("Alert", ((Button)sender).CommandParameter.ToString(), "OK");
        }
    }

    private async void GameProgressBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StoryDetailView");
    }

    private async void GameNextTurnBtn_Clicked(object sender, EventArgs e)
    {
        //  await DisplayAlert("Alert", ((Button)sender).CommandParameter.ToString(),);
        await Shell.Current.GoToAsync("NewsPaperView");
    }

    private async void CollectIncomeBTN_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Income...", "$1,200.00 Total Income Collected!","Amazing! $$$");
    }
}


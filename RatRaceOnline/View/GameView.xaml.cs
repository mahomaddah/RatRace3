namespace RatRace3.View;
using RatRace3.View;
using RatRace3.Models;
using RatRace3.ViewModel;
using Syncfusion.Maui.Rotator;

public partial class GameView : ContentPage
{
    public CardViewModel CardviewModel { get; set; }
    public RotatorViewModel IpoCompaniesVM { get; set; }
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
        //   LVcompaiesMarket.ItemsSource = CardviewModel.StockMarketCompanys;
        IpoCompaniesVM = new RotatorViewModel();

        CompanyInvestRoter.ItemsSource = IpoCompaniesVM.RotatorItems;


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
        //await Shell.Current.GoToAsync("NewsPaperView");
      //  PlayBackgroundMusic();
    }

    private async void CollectIncomeBTN_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Income...", "$1,200.00 Total Income Collected!","Amazing! $$$");
    }

    private async void CompanyInvestRoter_ItemTapped(object sender, EventArgs e)
    {
        SfRotator router = new SfRotator();
        router = (SfRotator)sender;

        SfRotatorItem selectedCompany = IpoCompaniesVM.RotatorItems[router.SelectedIndex];
        if(selectedCompany!= null)
        {
            var appShell = (AppShell)Shell.Current;
            appShell.CurrentCompany = new Company
            {
                Symbol = selectedCompany.Image,
                StockPrice = 10.12,
                StockDetail = selectedCompany.ItemText
            };

          //  await  DisplayAlert("Selected company's image, symbol and price ... Send them to Market page by Shell goToAsync parameter ... ",selectedCompany.Image,"OK");
        }
        await Shell.Current.GoToAsync("MarketPage");
    }
}


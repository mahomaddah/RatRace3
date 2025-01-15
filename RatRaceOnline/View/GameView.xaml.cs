namespace RatRace3.View;
using RatRace3.View;
using RatRace3.Models;
using RatRace3.ViewModel;
using Syncfusion.Maui.Rotator;
using System.Globalization;

public partial class GameView : ContentPage
{
    public GameViewModel GameViewModel { get; set; }
    public RotatorViewModel IpoCompaniesVM { get; set; }
    private void GameStarted(object sender, EventArgs e)
    {
        //GameViewModel = new GameViewModel();
        //BindingContext = GameViewModel;
        //IpoCompaniesVM = new RotatorViewModel();
        //ListViewIncomeSourses.ItemsSource = GameViewModel.Player.IncomeSources;
        //CompanyInvestRoter.ItemsSource = IpoCompaniesVM.RotatorItems;

    }

    public GameView()
	{
		InitializeComponent();
        GameViewModel = new GameViewModel();
      

        // Set default card index to open first 
        GameViewModel.VisibleIndex = 1;
        var appShell = (AppShell)Shell.Current;
        GameViewModel.LoadPlayerData(appShell.CurrentLevelModel.Players.First());

        // var playerModel = appShell.CurrentLevelModel.Players.First();
        BindingContext = GameViewModel;
      

        UpdateOrientation();

        // Event to detect orientation change
        DeviceDisplay.MainDisplayInfoChanged += (s, e) => UpdateOrientation();

        //binding VM to Listview ....
        //   LVcompaiesMarket.ItemsSource = GameViewModel.StockMarketCompanys;
        IpoCompaniesVM = new RotatorViewModel();

        CompanyInvestRoter.ItemsSource = IpoCompaniesVM.RotatorItems;


    }
    private void UpdateOrientation()
    {
       
        // for fixin radial Menu button's ( flower bank button android rotation bug..)
        if (  (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
        {
            //change button point change the 0,0 to a real working tested button location ...
            BankRadialMenu.Point = new Point(0,0);
        }
        else if ((DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait)
        {
            //return button point 83,125 which tested for a
            BankRadialMenu.Point = new Point(83, 125);
        }

    }

    private async void cardNavBtn_Clicked(object sender, EventArgs e)
    {
		if(sender!=null)
		{ 
          GameViewModel.VisibleIndex = Convert.ToInt16(((Button)sender).CommandParameter);
        }
    }

    private async void GameProgressBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StoryDetailView");
    }

    //private async void GameNextTurnBtn_Clicked(object sender, EventArgs e)
    //{
        
    //}

    //private async void CollectIncomeBTN_Clicked(object sender, EventArgs e)
    //{
    //  //  await DisplayAlert("TotalIncome...", "$1,200.00 Total TotalIncome Collected!","Amazing! $$$");
    //    //TODO: add player objects ... += 1200 to player.blance....
    //   // GameViewModel.CurrentBalance += 1200; // better to bind to viewmoddel ... 
    //   // CollectIncomeBtn.IsEnabled = false; // beter to bind to viewmodel

    //}

    private async void CompanyInvestRoter_ItemTapped(object sender, EventArgs e)
    {
        SfRotator router = new SfRotator();
        router = (SfRotator)sender;

        SfRotatorItem selectedCompany = IpoCompaniesVM.RotatorItems[router.SelectedIndex];
        if(selectedCompany!= null)
        {
            var appShell = (AppShell)Shell.Current;
            Company SelectedObject = appShell.IPOcompanies.First(x => selectedCompany.Image.Contains(x.Symbol));
            appShell.CurrentCompany = new Company
            {
                Symbol = SelectedObject.Symbol,
                StockPrice = SelectedObject.StockPrice,
                StockDetail = SelectedObject.StockDetail,
                StockExchange = SelectedObject.StockExchange
            };
        }
        await Shell.Current.GoToAsync("MarketPage");
    }

    private async void FixedDeposit_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {
        await DisplayAlert("Bank..", "Fixed deposit account addet to asset list!", "OK$$$");
        BankRadialMenu.IsOpen = false;
    }

    private async void BankAssetWithdrawal(object sender, Syncfusion.Maui.ListView.ItemDoubleTappedEventArgs e)
    {
       
        await DisplayAlert("Bank: "+ ((RatRace3.ViewModel.ListViewItemModel)e.DataItem).ItemText,"Bank Deposit Sucssesfully Withdrawed", "Good! Cash is King :D");
    }


}


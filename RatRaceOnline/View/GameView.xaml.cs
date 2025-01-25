namespace RatRace3.View;
using RatRace3.View;
using RatRace3.Models;
using RatRace3.ViewModel;
using Syncfusion.Maui.Rotator;
using System.Globalization;
using System.Net.NetworkInformation;
using Syncfusion.Maui.Popup;
using System.Linq;

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
        if (appShell.CurrentLevelModel.IsNewGameStarted)
        {
            //come for new game ... 
        }
        else
        {
            //come for Load last game
        }

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
        double IntrestRate = 0.041;//simdilik yuzde 4.1% olsun ilerie belki gazete deki TBon ile baglariz.....

        try {

            //    double deposit = Convert.ToDouble(GameViewModel.CurrentBankDepositAmount);
            bool isValid = double.TryParse(GameViewModel.CurrentBankDepositAmount,out double deposit);
        //await DisplayAlert("Bank..", "Fixed deposit account addet to asset list!", "OK$$$");
        if (isValid && deposit> 0.009 && GameViewModel.Player.Balance >= deposit)
        {
            GameViewModel.Player.Balance -= deposit;
            double passiveIncoemAmounth = Math.Round((deposit * IntrestRate / 12),2);
            var RelatedAssetID = Guid.NewGuid().ToString();
            var assetsPassiveIncome = new IncomeSourceModel { AssetIncomeSourseRelatingGUID = RelatedAssetID, Amount = passiveIncoemAmounth, Name = "FD $" + passiveIncoemAmounth + "@"+IntrestRate.ToString("p")+" Intrest |Passive Income" };
            GameViewModel.Player.Assets.Add(new AssetModel { AssetIncomeSourseRelatingGUID= RelatedAssetID, AssetName = "FD $" + deposit.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) +"@" + IntrestRate.ToString("p") + " Intrest |JPMorgen Bank" ,AssetValue = deposit,AssetType= AssetTypes
            .FixedDeposit.ToString() ,IntrestRate = 0.041, IsBankDeposit=true,IsRecursiveDepositRD = false ,PassiveIncome = passiveIncoemAmounth });
            GameViewModel.Player.IncomeSources.Add(assetsPassiveIncome);
            GameViewModel.LoadPlayerData(GameViewModel.Player);//fore updating bank listview and statments....
            BankRadialMenu.IsOpen = false;
            }
            else
            {
                await DisplayAlert("Bank:" , "Please Enter a Valid Amounth of fund", "Hony No$");
            }

        }
        catch
        {
            //await DisplayAlert("Bank:", "Issue With creating New Postion", "Ok");
        }
    }

    private async void BankAssetWithdrawal(object sender, Syncfusion.Maui.ListView.ItemDoubleTappedEventArgs e)
    {
        //BankAssetWithdrawal
        var SelectedBankAsset = GameViewModel.Player.Assets.Find(x => x.AssetName.Contains(((ListViewItemModel)e.DataItem).ItemText));
        if (SelectedBankAsset != null) {
            var assetRelatedIncomeSource = GameViewModel.Player.IncomeSources.Find(y => y.AssetIncomeSourseRelatingGUID.ToString() == SelectedBankAsset.AssetIncomeSourseRelatingGUID.ToString());
            if (assetRelatedIncomeSource != null) {

                GameViewModel.Player.Balance += SelectedBankAsset.AssetValue;//withdared..

                GameViewModel.Player.IncomeSources.Remove(assetRelatedIncomeSource);
                GameViewModel.Player.Assets.Remove(SelectedBankAsset);


                GameViewModel.LoadPlayerData(GameViewModel.Player);

            }
        }
    }

    private async void DebtDetailViewTapped(object sender, Syncfusion.Maui.ListView.ItemDoubleTappedEventArgs e)
    {
       // DebtPopup.BindingContext = new LiabilityModel { LiabilityName = "Student Loan", TotalAmount = 5000.00, MonthsRemaining = 24, InterestRate = 0.05, LiabilityModelID = 1 };
      
    //   await DisplayAlert("Debt: "+((RatRace3.ViewModel.ListViewItemModel)e.DataItem).ItemText,"Debt Details...", "Pay Debts");
   //      GameViewModel.DebtDetailViewTapped((RatRace3.ViewModel.ListViewItemModel)e.DataItem);
        //var appShell = (AppShell)Shell.Current;
        //var SelectedObject = appShell.CurrentLevelModel.Players.First();

        var liabilityModel = GameViewModel.Player.Liabilities.Find(x => x.LiabilityName.Contains(((ListViewItemModel)e.DataItem).ItemText));
        GameViewModel.SelectedLiability = liabilityModel;
        DebtPopup.Show();
    }

}


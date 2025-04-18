namespace RatRace3.View;
using RatRace3.View;
using RatRace3.Models;
using RatRace3.ViewModel;
using Syncfusion.Maui.Rotator;
using System.Globalization;
using System.Net.NetworkInformation;
using Syncfusion.Maui.Popup;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using RatRace3.DAL;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Syncfusion.Maui.Carousel;

public partial class GameView : ContentView
{
    public GameViewModel GameViewModel { get; set; }



    //
    //const bool isFirstTimeToGameViewCtor = true; // for  avoiding to load and override player while coming form Market or GameDetils similir Views in the same game 


    public GameView()
	{
        try
        {

            InitializeComponent();

        }
        catch (Exception ex)
        { Clipboard.SetTextAsync(ex.Message + " \n\n" + ex.StackTrace); }

        var appShell = (AppShell)Shell.Current;

          
        //Level Just Started... 
            if ( appShell.GameViewModel.Player==null)  //&& appShell.GameViewModel.Player.CurrentMonth==1) //sadece ilk aydaysa ve oyun yeni basladiysa ... contrat etsin view modeli Load yada Create new game yapsin deger turlu hic birsey yapmasin AppShell  Deki veriler kalsin cunku deger Panellerden gelmistir Market yada gamedetail gibi ...
            {
                //Loading old game or come for a clean new game ... so Set Player Object ...

                GameViewModel = new GameViewModel();

             

                appShell.GameViewModel = GameViewModel;

                //for creating a new game data every time GameViewLoad...


                var levelPlayer1 = appShell.CurrentLevelModel.Players.First();

                if (appShell.CurrentLevelModel.IsNewGameStarted)
                {
                    //NotLoad saved game New game 

                    appShell.getAnewGameData();//without this user can onley get new game 2 time and after 2. all restart games will be the same until he close and re open the game :D lol but with it bug has solved..
                    GameViewModel.LoadPlayerData(levelPlayer1);
                    
                }
                else
                {

                    //Load Saved game ... 
                    //Note: you can call auto-save function every turn on nextTurn()
                    var dal = new DataAccessService();
                    var savedPlayer = dal.LoadPlayerData(levelPlayer1.StoryLevelID, levelPlayer1.PlayerModelID);
                    var savedNews = dal.LoadNewsPapersData(levelPlayer1.StoryLevelID);
                    var savedCompanies = dal.LoadCompaniesData(levelPlayer1.StoryLevelID);

                    if (savedPlayer != null) levelPlayer1 = savedPlayer;
                    if (savedNews != null) appShell.CurrentNewsPaperViewModel = new NewsPaperViewModel { NewsPaperModels = savedNews, CurrentNewsPaperModel = savedNews.LastOrDefault() };
                    if (savedCompanies != null)
                    {
                        appShell.IPOcompanies = new ObservableCollection<Company>(savedCompanies);
                    }
                    //    appShell.CurrentLevelModel.Players[0] = savedPlayer;//if needed (search for appShell.CurrentLevelModel.Players.First() uses)
                    GameViewModel.LoadPlayerData(levelPlayer1);//secound // TODO : after MVP can refactor it with one if No IS game started and one LoadPlayerData()...
                   



                }

            }
            else
            {
                //Coming from the same game's market panel or story detail panels etc... So No Ovveride Player Object...
         

                //Short term solution for fixing Null Companies and null News bug for now ( latter will refactor ) ...

                //Load Saved game ... 
                //Note: you can call auto-save function every turn on nextTurn()
                var dal = new DataAccessService();
        
                var savedNews = dal.LoadNewsPapersData(appShell.GameViewModel.Player.StoryLevelID);
                var savedCompanies = dal.LoadCompaniesData(appShell.GameViewModel.Player.StoryLevelID);


                if (savedNews != null) appShell.CurrentNewsPaperViewModel = new NewsPaperViewModel { NewsPaperModels = savedNews, CurrentNewsPaperModel = savedNews.LastOrDefault() };
                if (savedCompanies != null)
                {
                    appShell.IPOcompanies = new ObservableCollection<Company>(savedCompanies);
                }
                //    appShell.CurrentLevelModel.Players[0] = savedPlayer;//if needed (search for appShell.CurrentLevelModel.Players.First() uses)
      //          GameViewModel.LoadPlayerData(levelPlayer1);//secound // TODO : after MVP can refactor it with one if No IS game started and one LoadPlayerData()...
                appShell.GameViewModel.LoadPlayerData(appShell.GameViewModel.Player);
                GameViewModel = appShell.GameViewModel;
            }




  

        //    appShell.IPOcompaniesSfCarouselViewModel = new IPOcompaniesSfCarouselViewModel { ImageCollection = appShell.IPOcompanies.ToList() };
        //FundementalDataRightStack.BindingContext = appShell.IPOcompaniesSfCarouselViewModel;
        //FundementalDataLeftStack.BindingContext = appShell.IPOcompaniesSfCarouselViewModel;
        //IPOcompaniesSfCarousel.BindingContext = appShell.IPOcompaniesSfCarouselViewModel;

            if (GameViewModel != null)
            {
                // Set default card index to open first     
                GameViewModel.VisibleIndex = 1;
                BindingContext = appShell.GameViewModel;
            }
            else
            {
                
                Debug.WriteLine("GameViewModel is NULL in GameView.xaml.cs");
            }


        //binding VM to Listview ....
        //   LVcompaiesMarket.ItemsSource = GameViewModel.StockMarketCompanys;
        //   if (GameViewModel.IpoCompaniesVM.RotatorItems != null && GameViewModel.IpoCompaniesVM.RotatorItems.Count > 0)
        // IPOcompaniesSfCarousel.ItemsSource = GameViewModel.IpoCompaniesVM.RotatorItems;... old codes... 



        #region codes for mobiles landscape mode: 

        //UpdateOrientation();

        //// Event to detect orientation change
        //DeviceDisplay.MainDisplayInfoChanged += (s, e) => UpdateOrientation();

        #endregion


    }
    //private void UpdateOrientation()
    //{

    //    // for fixin radial Menu button's ( flower bank button android rotation bug..)
    //    if (  (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
    //    {
    //        //change button point change the 0,0 to a real working tested button location ...
    //        BankRadialMenu.Point = new Point(0,0);
    //    }
    //    else if ((DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS) && DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait)
    //    {
    //        //return button point 83,125 which tested for a
    //        BankRadialMenu.Point = new Point(83, 125);
    //    }

    //}

    private async void cardNavBtn_Clicked(object sender, EventArgs e)
    {
		if(sender!=null && GameViewModel!=null)
		{ 
          GameViewModel.VisibleIndex = Convert.ToInt16(((Button)sender).CommandParameter);
        }
    }

    private async void GameProgressBtn_Clicked(object sender, EventArgs e)
    {
        // await Shell.Current.GoToAsync("StoryDetailView");
        //await Shell.Current.GoToAsync("/storydetailview");
        //  await Shell.Current.GoToAsync("..");
        var appShell = (AppShell)Shell.Current;
        ((MotherView)(appShell).CurrentPage).Show("storydetailview");
    }


    private async void CompanyInvestRoter_SelectedIndexChanged(object sender, Syncfusion.Maui.Core.Rotator.SelectedIndexChangedEventArgs e)
    {
        ////Change Fundemental data...
        //SfRotator router = new SfRotator();


      
           
      
        try
        {
            var appShell = (AppShell)Shell.Current;

            if (appShell.GameViewModel.VisibleIndex==3) 
            { 
            //await MainThread.InvokeOnMainThreadAsync(async () =>
            //{
           

            if (appShell.GameViewModel.IpoCompaniesVM.RotatorItems == null || appShell.GameViewModel.IpoCompaniesVM.RotatorItems.Count == 0 )
               {
                   return; // Bo� koleksiyon hatas�n� �nler
               }

               if (e.Rotator.SelectedIndex < 0 || e.Rotator.SelectedIndex >= appShell.GameViewModel.IpoCompaniesVM.RotatorItems.Count)
               {
                   return; // Hatal� index eri�imini �nler
               }

               if (e.Rotator.SelectedIndex == null || e.Rotator.SelectedIndex < 0) return;

            // var router = (SfRotator)sender;
            //SfRotator router = new SfRotator();
            //router = (SfRotator)sender;
        
           
            SfRotatorItem selectedCompany = appShell.GameViewModel.IpoCompaniesVM.RotatorItems.ElementAtOrDefault((int)e.Rotator.SelectedIndex);


            if (selectedCompany != null)
            {
                //        var appShell = (AppShell)Shell.Current;
                // Company SelectedObject = appShell.IPOcompanies.FirstOrDefault(x => selectedCompany.Image.ToLower().Contains(x.Symbol.ToLower()));
                Company SelectedObject = GameViewModel.IpoCompaniesVM.IPOcompanies.First(x => selectedCompany.ItemText.ToLower().Contains(x.Symbol.ToLower()));
                ////Bind Fundemental data.. in a better way ...
                ////BindingContext = SelectedObject.StockFundementalData;
                //FundementalDataLeftStack.BindingContext = SelectedObject;
                if (SelectedObject != null)
                {
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        FundementalDataTotalCashLB.Text = SelectedObject.StockFundementalData.TotalCash.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) + " B USD";
                        FundementalTotalDebts.Text = SelectedObject.StockFundementalData.TotalDebts.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) + " B USD";
                        CompetetiveAdvantageScoreLB.Text = SelectedObject.StockFundementalData.SustainableCompetitiveAdvantage.ToString();
                        EPSthisYrLB.Text = SelectedObject.StockFundementalData.EPSthisYr.ToString("P");
                        EPSpast5yrLB.Text = SelectedObject.StockFundementalData.EPSpast5Y.ToString("P");
                        EPSnext5yrLB.Text = SelectedObject.StockFundementalData.EPSnext5Y.ToString("P");
                        DCFvaluetionLB.Text = SelectedObject.StockFundementalData.DCFvaluation.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                        IncomeAnnualCompanyLB.Text = SelectedObject.StockFundementalData.AnnualIncome.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) + " B";
                        Task.Delay(100);
                    });
                }
            }

                //});
            }
        }
        catch (Exception exep) { await AppShell.Current.DisplayAlert(exep.Message,exep.StackTrace , "RotarIndex erorr catched.."); }

    
        //appShell.GameViewModel.Market.ChangeSelectedCompany((int)e.Index); //for auto updating the shit DataContext of Fundemental Data... Comment lined for now to fix the bug i't aslo changing Market CurrentCompany as well :D ... in fact i'ts not even changing fundemental data in here :D

        //  await Shell.Current.DisplayAlert("Fundemental data shoud be updated"+e.Index, "called : from GameView.xaml : CompanyInvestRoter_SelectedIndexChanged()", "OK");
    }

    private void CompanyLogo_Clicked(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        Company SelectedObject = null;

        if(IPOcompaniesSfCarousel.SelectedIndex>=0)
         SelectedObject = appShell.IPOcompanies.ElementAtOrDefault(IPOcompaniesSfCarousel.SelectedIndex);
        if (SelectedObject != null)
        {

            appShell.CurrentCompany = new Company
            {
                Symbol = SelectedObject.Symbol,
                StockPrice = SelectedObject.StockPrice,
                StockDetail = SelectedObject.StockDetail,
                StockExchange = SelectedObject.StockExchange,

            };

            appShell.GameViewModel.Market.SelectedCompany = SelectedObject;

        }

        ((MotherView)(appShell).CurrentPage).Show("marketpage");

    }
    private async void CompanyInvestRoter_ItemTapped(object sender, EventArgs e)
    {
        SfRotator router = new SfRotator();
        router = (SfRotator)sender;

        if (router.SelectedIndex < 0 || router.SelectedIndex >= GameViewModel.IpoCompaniesVM.RotatorItems.Count)
        {
            return; // Hatal� index eri�imini �nler
        }

        var appShell = (AppShell)Shell.Current;
         SfRotatorItem selectedCompany = appShell.GameViewModel.IpoCompaniesVM.RotatorItems.ElementAtOrDefault((int)router.SelectedIndex);
        if (selectedCompany != null)
        {
         
            //   Company SelectedObject = appShell.IPOcompanies.First(x => selectedCompany.Image.ToLower().Contains(x.Symbol.ToLower()));
            Company SelectedObject = GameViewModel.IpoCompaniesVM.IPOcompanies.First(x => selectedCompany.ItemText.ToLower().Contains(x.Symbol.ToLower()));
            if (SelectedObject != null)
            {

                appShell.CurrentCompany = new Company
                {
                    Symbol = SelectedObject.Symbol,
                    StockPrice = SelectedObject.StockPrice,
                    StockDetail = SelectedObject.StockDetail,
                    StockExchange = SelectedObject.StockExchange,

                };

                appShell.GameViewModel.Market.SelectedCompany = SelectedObject;

            }
        }
      //  await Shell.Current.GoToAsync("MarketPage");
        //await Shell.Current.GoToAsync("/marketpage");
       // await Shell.Current.GoToAsync("marketpage");
        ((MotherView)(appShell).CurrentPage).Show("marketpage");
    }

    double IntrestRate = 0.041;//simdilik yuzde 4.1% olsun ilerie belki gazete deki TBon ile baglariz.....

    private async void FixedDeposit_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {
    

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
                await AppShell.Current.DisplayAlert("Bank:" , "Please Enter a Valid Amounth of fund", "Hony No$");
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

                GameViewModel.Player.IncomeSources.Remove(assetRelatedIncomeSource);


            }
            var assetRelatedExpanceObjedRD = GameViewModel.Player.Expenses.Find(y => y.RDrelatedAssetGUID == SelectedBankAsset.AssetRelatedExpanceGUID);
            if(assetRelatedExpanceObjedRD != null)
            {
                GameViewModel.Player.Expenses.Remove(assetRelatedExpanceObjedRD);
            }

            GameViewModel.Player.Balance += SelectedBankAsset.AssetValue;//withdared..

            GameViewModel.Player.Assets.Remove(SelectedBankAsset);


            GameViewModel.LoadPlayerData(GameViewModel.Player); //updates ViewModel by Player View 

        }
    }

    private async void DebtDetailViewTapped(object sender, Syncfusion.Maui.ListView.ItemDoubleTappedEventArgs e)
    { 
        var liabilityModel = GameViewModel.Player.Liabilities.Find(x => x.LiabilityName.Contains(((ListViewItemModel)e.DataItem).ItemText));
        GameViewModel.SelectedLiability = liabilityModel;
        DebtPopup.Show();
    }

    private async void RecursiveDepositCreate_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {
        var USD = CultureInfo.CreateSpecificCulture("en-US");
        try
        {
            bool isValid = double.TryParse(GameViewModel.CurrentBankDepositAmount, out double deposit);

            if (isValid && deposit > 0.009 && GameViewModel.Player.NetTotalIncome >= deposit)
            {
               // GameViewModel.Player.Balance -= deposit;

                // Generate unique GUID to link RD asset, income, and expense
                var RDrelatedAssetGUID = Guid.NewGuid().ToString();

                // Calculate monthly passive income for the RD
               // double passiveIncomeAmount = Math.Round((deposit * IntrestRate / 12), 2);

                //// Create and add the Income Source for RD
                //var rdIncomeSource = new IncomeSourceModel
                //{
                //    AssetIncomeSourseRelatingGUID = RDrelatedAssetGUID,
                //    Amount = passiveIncomeAmount,
                //    Name = $"RD ${deposit.ToString("C2", USD)} @{IntrestRate.ToString("p")} Interest | Passive Income"
                //};

                // Create and add the Expense Model for monthly RD contribution
                var rdExpense = new ExpenseModel
                {
                    Amount = deposit,
                    RDrelatedAssetGUID = RDrelatedAssetGUID, //for RD
                    IsRDassetsExpense=true, //for RD
                    Name = $"RD Monthly Contribution"+ " Maturity:1-Year"
                };

               
                //test values first with  https://www.investor.gov/financial-tools-calculators/calculators/compound-interest-calculator....

                // Create and add the RD Asset
                GameViewModel.Player.Assets.Add(new AssetModel
                {
                    AssetRelatedExpanceGUID = RDrelatedAssetGUID,
                    AssetName = $"RD {deposit.ToString("C2", USD)} Monthly @{IntrestRate.ToString("p")} for 12 Months",
                    AssetValue = 0,
                    AssetType = AssetTypes.RecursiveDeposit.ToString(),
                    IntrestRate = IntrestRate,
                    IsBankDeposit = true,
                    IsRecursiveDepositRD = true,
                    PassiveIncome = 0,
                    AssetOwnedMonth = GameViewModel.Player.CurrentMonth,
                    
                });

                // Add to the player's income sources and expenses
                //GameViewModel.Player.IncomeSources.Add(rdIncomeSource);
                GameViewModel.Player.Expenses.Add(rdExpense);

                // Update the UI and close the radial menu
                GameViewModel.LoadPlayerData(GameViewModel.Player);
                BankRadialMenu.IsOpen = false;
            }
            else
            {
                await AppShell.Current.DisplayAlert("Bank Alert", $"Invalid amount entered! You currently have only {GameViewModel.Player.NetTotalIncome.ToString("C2", USD)} in free cash flow. Please enter a valid amount within your budget.or increase you FCF at first.", "Let's Try Again");
            }
        }
        catch
        {
            await AppShell.Current.DisplayAlert("Bank Alert", "An issue occurred while creating the new RD position. Please try again.", "OK");
        }
    }

    private void indexSPYpositionOrder_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {

    }

    private void TbondOrderBtn_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {

    }

    private void CoporateBondsOrderBtn_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {

    }

    private void LongTermBondsOrderBtn_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {

    }

    private void MutualFundBtn_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {

    }

    private async void AssetLV_ItemDoubleTapped(object sender, Syncfusion.Maui.ListView.ItemDoubleTappedEventArgs e)
    {
        try{
        var assetModel = GameViewModel.Player.Assets.Find(x => x.AssetName.Contains(((ListViewItemModel)e.DataItem).ItemText));

            if(assetModel != null)
            if(assetModel.IsBankDeposit || assetModel.AssetType.Contains(AssetTypes.FixedDeposit.ToString()))
            {
                GameViewModel.VisibleIndex = 2;//for bank....
            }
            else if(assetModel.AssetType == AssetTypes.Stock.ToString())
            {   //Can bring // AssetModel...
               // GameViewModel.VisibleIndex = 3;//for market....

               
                if (assetModel != null)
                {
                    var appShell = (AppShell)Shell.Current;
                    Company SelectedObject = appShell.IPOcompanies.First(x => assetModel.StockCompanySymbol.ToLower().Contains(x.Symbol.ToLower()));
                    appShell.CurrentCompany = SelectedObject;

                        appShell.GameViewModel.Market.CurrentCompanyAsset = assetModel;

                    appShell.GameViewModel.Market.SelectedCompany = (SelectedObject);
                        //this line make it break after clicking on back button becuse of parelel processing probebbly...

               //   await   Shell.Current.GoToAsync("MarketPage");
                       // await Shell.Current.GoToAsync("/marketpage");
                     
                        ((MotherView)appShell.CurrentPage).Show("marketpage");
                    }

              

            }
            else if (assetModel.AssetType == AssetTypes.RealEstate.ToString())
            {
                GameViewModel.VisibleIndex = 5;//for bank....
            }
        }
        catch { }
    }

    private void GetALoanOrder_ItemTapped(object sender, Syncfusion.Maui.RadialMenu.ItemTappedEventArgs e)
    {

    }

   
}


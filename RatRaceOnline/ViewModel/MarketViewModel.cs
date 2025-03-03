using RatRace3.Models;
using Syncfusion.Maui.Charts;
using Syncfusion.Maui.Gauges;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RatRace3.ViewModels
{
    public class MarketViewModel : INotifyPropertyChanged
    {

        //  public AssetModel CurrentAssetModel { get; set; }
        //  public Company CurrentCompany { get; set; }
        //  public List<object> ChartData { get; set; }

        public List<Brush> PaletteBrushes { get; private set; } = new List<Brush>
     {
                Color.FromArgb("#FF638A2D"),
                Color.FromArgb("#FFE3AAD6"),
                Color.FromArgb("#FFFF7D7D"),
                Color.FromArgb("#FF007C9C"),
                Color.FromArgb("#FF019FCC"),
                Color.FromArgb("#FF94652B"),
                Color.FromArgb("#FF89D9A8"),
                Color.FromArgb("#FF71CBB1"),
                Color.FromArgb("#FF4DB7BE"),
                Color.FromArgb("#FF4EB7BD")

     };


        private Company _selectedCompany;
        private ObservableCollection<PriceCandleModel> _chartData;
        public ObservableCollection<Company> IPOCompanies { get; set; }

        /// <summary>
        /// Setting to SelectedCompany will call LoadCompanyData() aswell to update Charts and etc..
        /// </summary>
        public Company SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                _selectedCompany = value;
                LoadCompanyData(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedCompanyFundamentals));
            }
        }
        private AssetModel currentCompanyAsset;

        public AssetModel CurrentCompanyAsset
        {
            get { return currentCompanyAsset; }
            set { currentCompanyAsset = value;
                OnPropertyChanged();
            }
        }


        public StockFundementalData SelectedCompanyFundamentals => SelectedCompany?.StockFundementalData;
        public ObservableCollection<PriceCandleModel> ChartData
        {
            get => _chartData;
            set
            {
                _chartData = value;
                OnPropertyChanged();
            }
        }

        private double totalPrice;
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value;
                OnPropertyChanged();

                //if quantity = 0 he want to buy 
                //else he want to buy or sell 
                //if balance is bigger taht total PaleVioletRed
                //else if smaller or equalt color Should be LimeGreen
                // 0 to 3 owns 10 money have 99 money dont have ... 
                try
                {
                            var appShell = (AppShell)Shell.Current;
                            var Player = appShell.GameViewModel.Player;

                    if (Player != null)
                        if (Player.Balance > TotalPrice)
                        {
                            //he want to selll or buy more 

                            //  Player.Balance> CurrentCompanyAsset.StockQuantity
                            TotalPriceColor = "LimeGreen";
                        }
                        else TotalPriceColor = "PaleVioletRed";
                     
                }
                catch {}
            }
        }
        private string totalPriceColor;
        public string TotalPriceColor
        {
            get { return totalPriceColor; }
            set { totalPriceColor = value;
                OnPropertyChanged();
            }
        }


        private double positionValue;
        public double PositionValue
        {
            get { return positionValue; }
            set { positionValue = value;
                OnPropertyChanged();
            }
        }

        private double selectedQuantity;
        public double SelectedQuantity
        {
            get { return selectedQuantity; }
            set {
                try 
                {
                    if(SelectedCompany!= null)
                    {
                        selectedQuantity = value;
                        TotalPrice = SelectedCompany.StockPrice * selectedQuantity;
                        OnPropertyChanged();
                    }
                    
                }
                catch(Exception ex){ Clipboard.SetTextAsync("Eror RatRace3: MarketViewModel.SelectedQuantity.Setter: \n"+ex.Message + " \n StackTrace: " + ex.StackTrace); }
            }
        }


        public ICommand BuyStockCommand { get; }
        public ICommand SellStockCommand { get; }

        public MarketViewModel()
        {
           
            var appShell = (AppShell)Shell.Current;
            if(appShell != null && IPOCompanies==null)
            {

                IPOCompanies = new ObservableCollection<Company>(appShell.IPOcompanies);
                //foreach (var company in appShell.IPOcompanies)
                //{
                //     IPOCompanies.Add(company);
                    
                //}
                SelectedCompany = IPOCompanies.FirstOrDefault();
            }

            if(ChartData == null)
            {
                ChartData = new ObservableCollection<PriceCandleModel>();

                BuyStockCommand = new Command(BuyStock);
                SellStockCommand = new Command(SellStock);
            }
 
        }

        /// <summary>
        /// Making it private to avoid calling it directlly Use SelectedCompany setter to avoid looping...
        /// </summary>
        /// <param name="company"></param>
        private async void LoadCompanyData(Company company)
        {
            double lastPrice = 0;

            if (company == null || ChartData == null) return;
            ChartData.Clear();
            foreach (var candle in company.PriceCandles)
            {
                ChartData.Add(new PriceCandleModel { Date = candle.Date, Value = candle.Value });
        
              
            }
            //update price
            company.StockPrice = company.PriceCandles.Last().Value;
            if(company.PriceCandles.Count>2)
            company.StockLastCandlePrice = company.PriceCandles[company.PriceCandles.Count - 2].Value;//test this code check and uncomment if needed... for P&L ... 








            var Player = ((AppShell)Shell.Current).GameViewModel.Player;

            var existingStock = Player.Assets.FirstOrDefault(a => a.StockCompanySymbol == SelectedCompany.Symbol);

            if (existingStock != null && existingStock.StockQuantity > 0)
            {
                //Update... 
                CurrentCompanyAsset = existingStock;
            }
            else
            {
                //Create... // for buying new ...
                CurrentCompanyAsset = new AssetModel { StockQuantity = 0, AssetType = AssetTypes.Stock.ToString(), StockCompanySymbol = company.Symbol, AssetName = company.Symbol };
            }


            CurrentCompanyAsset.AssetValue = CurrentCompanyAsset.StockQuantity * company.StockPrice; // for selling
            PositionValue = CurrentCompanyAsset.AssetValue;
            TotalPrice = PositionValue;//ready to sell if not 0 
            SelectedQuantity = CurrentCompanyAsset.StockQuantity;

            OnPropertyChanged(nameof(SelectedCompany));
            OnPropertyChanged(nameof(ChartData));
           
        }


        private async void BuyStock()
        {
            if (SelectedCompany == null) return;

            var appShell = (AppShell)Shell.Current;
            var Player = appShell.GameViewModel.Player;

            double purchaseAmount = Math.Round(SelectedCompany.StockPrice * SelectedQuantity, 2);

            // Step 1: Check if Player has enough balance to buy the stocks
            if (Player.Balance >= purchaseAmount && SelectedQuantity > 0)
            {
                Player.Balance -= purchaseAmount; // Deduct balance

                var existingStock = Player.Assets.FirstOrDefault(a => a.StockCompanySymbol == SelectedCompany.Symbol);

                if (existingStock != null)
                {
                    // Step 2: Update existing stock's quantity and average buy cost
                    double totalCostBefore = existingStock.StockAverageBuyCost * existingStock.StockQuantity;
                    double newTotalCost = totalCostBefore + purchaseAmount;

                    existingStock.StockQuantity += SelectedQuantity;
                    existingStock.StockAverageBuyCost = Math.Round(newTotalCost / existingStock.StockQuantity, 2);
                }
                else
                {
                    // Step 3: Create a new stock position
                    Player.Assets.Add(new AssetModel
                    {
                        StockCompanySymbol = SelectedCompany.Symbol,
                        AssetName = SelectedCompany.Symbol + " @ $" + SelectedCompany.StockPrice,
                        AssetType = AssetTypes.Stock.ToString(),
                        StockQuantity = SelectedQuantity,
                        StockAverageBuyCost = SelectedCompany.StockPrice,
                        AssetValue = purchaseAmount,
                        AssetOwnedMonth = Player.CurrentMonth,
                        IsBankDeposit = false ,
                        
                    });
                }

                updateAssetValue();

                // Step 4: Update UI and player data
                //      ContentPage_Loaded(this, new EventArgs());

                LoadCompanyData(SelectedCompany); //Seams like stupid and not needed or can call 1 or 2 sub opreations as ortak methods! latter Refactor :TODO...

                OnPropertyChanged(nameof(Player));
           //     OnPropertyChanged(nameof(Player.Balance));
                appShell.GameViewModel.LoadPlayerData(Player);

                await Shell.Current.GoToAsync("GameView");
            }
            else
            {
                await appShell.DisplayAlert("Stock Market",
                    "Insufficient balance! You need at least " + purchaseAmount.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) +
                    " to complete this purchase.", "Try Again");
            }

            //var appShell = (AppShell)Shell.Current;
            //var player = a((AppShell)Shell.Current).GameViewModel.Player;
            //double purchaseAmount = SelectedCompany.StockPrice;

            //if (player.Balance >= purchaseAmount)
            //{
            //    player.Balance -= purchaseAmount;
            //    var existingStock = player.Assets.FirstOrDefault(a => a.StockCompanySymbol == SelectedCompany.Symbol);

            //    if (existingStock != null)
            //    {
            //        existingStock.StockQuantity += 1;
            //        existingStock.StockAverageBuyCost = (existingStock.StockAverageBuyCost + SelectedCompany.StockPrice) / 2;
            //    }
            //    else
            //    {
            //        player.Assets.Add(new AssetModel
            //        {
            //            StockCompanySymbol = SelectedCompany.Symbol,
            //            AssetName = SelectedCompany.Symbol + " @ $" + SelectedCompany.StockPrice,
            //            AssetType = AssetTypes.Stock.ToString(),
            //            StockQuantity = 1,
            //            StockAverageBuyCost = SelectedCompany.StockPrice,
            //            AssetValue = purchaseAmount
            //        });
            //    }

            //    OnPropertyChanged(nameof(player.Balance));
            //    await Shell.Current.DisplayAlert("Stock Purchased", $"You bought every share of {SelectedCompany.Symbol} for {SelectedCompany.StockPrice:C2}", "OK");
            //}
            //else
            //{
            //    await Shell.Current.DisplayAlert("Insufficient Funds", "Not enough money to buy stock.", "OK");
            //}
        }

        private async void SellStock()
        {
            ////User SHould be ablae to sell their MSFT by Double clicking on asset this page should show up and msft postion should come here...
            ////ready to sell! bind gameViewModel and This Logics here also make sure double click on asset postion work well ... DONE
            ////aslo a tooltip like : stock market is currentlly at holyday i't will open after Level 1 was Complated and After Post Demo Update.....
            //  if (CurrentCompanyAsset == null) return;// Breaking code...

            if (SelectedCompany == null) return;

            var appShell = (AppShell)Shell.Current;
            var Player = ((AppShell)Shell.Current).GameViewModel.Player;
            if (SelectedQuantity <= CurrentCompanyAsset.StockQuantity && SelectedQuantity != 0)
            {
                //Sell amonth ...
                CurrentCompanyAsset.StockQuantity -= SelectedQuantity;

                ((AppShell)Shell.Current).GameViewModel.Player.Balance += Math.Round(SelectedCompany.StockPrice * SelectedQuantity, 2);

                if (CurrentCompanyAsset.StockQuantity == 0)
                    ((AppShell)Shell.Current).GameViewModel.Player.Assets.Remove(CurrentCompanyAsset);
            }
            else // Ya adam da Okadar yok ya elimdeki nekadar varsa onu sat kast etmistir...
            {
                if (CurrentCompanyAsset.StockQuantity > 0.009)
                {
                    //daha buyuktur ? 
                    bool result = await appShell.DisplayAlert("Stock Market", "The value you want to sell is higher than the total amount you hold! Did you mean to  sell all ?", "Yes, All In..", "No!!");
                    if (result)
                    {
                        //sell all...
                        Player.Balance += Math.Round(SelectedCompany.StockPrice * CurrentCompanyAsset.StockQuantity, 2);

                        ((AppShell)Shell.Current).GameViewModel.Player.Assets.Remove(CurrentCompanyAsset);


                    }
                }
                
            }
            updateAssetValue();



           // LoadCompanyData(SelectedCompany);    //Work like magic... for updating valuess..

            //Update GUI for this page and Statment page ... IF not work with functins than run above code...

            //if (CurrentCompanyAsset.AssetValue <= 0.009)
            //{
            //    //asset is now 0 quantity...    
            //    ((AppShell)Shell.Current).GameViewModel.Player.Assets.Remove(CurrentCompanyAsset);
            //}

            appShell.GameViewModel.LoadPlayerData(Player);

            await Shell.Current.GoToAsync("GameView");

            ////Orders System li yapmaliyiz Aslinda ileride Gercek economy gibi...


            //var appShell = (AppShell)Shell.Current;
            //var player =((AppShell)Shell.Current).GameViewModel.Player;
            //var existingStock = player.Assets.FirstOrDefault(a => a.StockCompanySymbol == SelectedCompany.Symbol);

            //if (existingStock != null && existingStock.StockQuantity > 0)
            //{
            //    player.Balance += SelectedCompany.StockPrice;
            //    existingStock.StockQuantity -= 1;

            //    if (existingStock.StockQuantity == 0)
            //    {
            //        player.Assets.Remove(existingStock);
            //    }

            //    OnPropertyChanged(nameof(player.Balance));
            //    await Shell.Current.DisplayAlert("Stock Sold", $"You sold 1 share of {SelectedCompany.Symbol} for {SelectedCompany.StockPrice:C2}", "OK");
            //}
            //else
            //{
            //    await Shell.Current.DisplayAlert("No Shares Available", "You don't own any shares of this stock to sell.", "OK");
            //}
        }

        void updateAssetValue()
        {
            if (CurrentCompanyAsset != null && SelectedCompany.StockPrice!=0)
                if(CurrentCompanyAsset.StockQuantity!=0)
                CurrentCompanyAsset.AssetValue = Math.Round(CurrentCompanyAsset.StockQuantity * SelectedCompany.StockPrice, 2);
            //for updating also on Statment page... 
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

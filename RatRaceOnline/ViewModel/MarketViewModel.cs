using RatRace3.Models;
using Syncfusion.Maui.Charts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RatRace3.ViewModels
{
    public class MarketViewModel : INotifyPropertyChanged
    {

        //  public AssetModel CurrentAssetModel { get; set; }
        //  public Company CurrentCompany { get; set; }
        //   public List<object> ChartData { get; set; }
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

        public ICommand BuyStockCommand { get; }
        public ICommand SellStockCommand { get; }

        public MarketViewModel()
        {
            IPOCompanies = new ObservableCollection<Company>
            {
                new Company
                {
                    Symbol = "GOOGL",
                    StockPrice = 202.31,
                    StockDetail = "Google LLC - Technology Company.",
                    StockFundementalData = new StockFundementalData
                    {
                        StockSymbol = "GOOGL",
                        TotalCash = 110.92,
                        TotalDebts = 119.01,
                        AnnualIncome = 26.30,
                        EPSpast5Y = 0.4840,
                        EPSthisYr = 1.2805,
                        EPSnext5Y = 1.35,
                        DCFvaluation = 230.94,
                        SustainableCompetitiveAdvantage = 5
                    },
                    PriceCandles = new List<PriceCandleModel>
                    {
                        new PriceCandleModel { Date = DateTime.Now.AddMonths(-2).ToString("MM-yyyy"), Value = 180.31 },
                        new PriceCandleModel { Date = DateTime.Now.AddMonths(-1).ToString("MM-yyyy"), Value = 195.31 }
                    }
                }
                ,
                new Company
                {
                    Symbol = "AAPL",
                    StockPrice = 258.20,
                    StockDetail = "Apple Inc. - Technology Company...",
                    StockFundementalData = new StockFundementalData
                    {
                        StockSymbol = "AAPL",
                        TotalCash = 510.92,
                        TotalDebts = 319.01,
                        AnnualIncome = 388.27,
                        EPSpast5Y = 0.4440,
                        EPSthisYr = 1.2845,
                        EPSnext5Y = 1.34,
                        DCFvaluation = 230.94,
                        SustainableCompetitiveAdvantage = 5
                    },
                    PriceCandles = new List<PriceCandleModel>
                    {
                        new PriceCandleModel { Date = DateTime.Now.AddMonths(-2).ToString("MM-yyyy"), Value = 380.31 },
                        new PriceCandleModel { Date = DateTime.Now.AddMonths(-1).ToString("MM-yyyy"), Value = 495.31 }
                    }
                }
            };

            SelectedCompany = IPOCompanies.FirstOrDefault();
            ChartData = new ObservableCollection<PriceCandleModel>();

            BuyStockCommand = new Command(BuyStock);
            SellStockCommand = new Command(SellStock);
        }

        public void LoadCompanyData(Company company)
        {
            if (company == null || ChartData == null) return;
            ChartData.Clear();
            foreach (var candle in company.PriceCandles)
            {
                ChartData.Add(new PriceCandleModel { Date = candle.Date, Value = candle.Value });
            }


            //var columnSeries = new ColumnSeries
            //{
            //    ItemsSource = appShell.GameViewModel.Market.ChartData,
            //    XBindingPath = "Date",
            //    YBindingPath = "Value",
            //    PaletteBrushes = PaletteBrushes // Use the bound brushes
            //};


            //Chart.PaletteBrushes = PaletteBrushes;
            //Chart.Series = new ChartSeriesCollection { columnSeries };

            OnPropertyChanged(nameof(SelectedCompany));
            OnPropertyChanged(nameof(ChartData));
            //SelectedCompany.StockFundementalData = company.StockFundementalData;
        }

        public void ChangeSelectedCompany(int index)
        {
            if (index >= 0 && index < IPOCompanies.Count)
            {
                SelectedCompany = IPOCompanies[index];
            }
        }

        private async void BuyStock()
        {
            var appShell = (AppShell)Shell.Current;
            var player = appShell.CurrentLevelModel.Players.First();
            double purchaseAmount = SelectedCompany.StockPrice;

            if (player.Balance >= purchaseAmount)
            {
                player.Balance -= purchaseAmount;
                var existingStock = player.Assets.FirstOrDefault(a => a.StockCompanySymbol == SelectedCompany.Symbol);

                if (existingStock != null)
                {
                    existingStock.StockQuantity += 1;
                    existingStock.StockAverageBuyCost = (existingStock.StockAverageBuyCost + SelectedCompany.StockPrice) / 2;
                }
                else
                {
                    player.Assets.Add(new AssetModel
                    {
                        StockCompanySymbol = SelectedCompany.Symbol,
                        AssetName = SelectedCompany.Symbol + " @ $" + SelectedCompany.StockPrice,
                        AssetType = AssetTypes.Stock.ToString(),
                        StockQuantity = 1,
                        StockAverageBuyCost = SelectedCompany.StockPrice,
                        AssetValue = purchaseAmount
                    });
                }

                OnPropertyChanged(nameof(player.Balance));
                await Shell.Current.DisplayAlert("Stock Purchased", $"You bought every share of {SelectedCompany.Symbol} for {SelectedCompany.StockPrice:C2}", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Insufficient Funds", "Not enough money to buy stock.", "OK");
            }
        }

        private async void SellStock()
        {
            var appShell = (AppShell)Shell.Current;
            var player = appShell.CurrentLevelModel.Players.First();
            var existingStock = player.Assets.FirstOrDefault(a => a.StockCompanySymbol == SelectedCompany.Symbol);

            if (existingStock != null && existingStock.StockQuantity > 0)
            {
                player.Balance += SelectedCompany.StockPrice;
                existingStock.StockQuantity -= 1;

                if (existingStock.StockQuantity == 0)
                {
                    player.Assets.Remove(existingStock);
                }

                OnPropertyChanged(nameof(player.Balance));
                await Shell.Current.DisplayAlert("Stock Sold", $"You sold 1 share of {SelectedCompany.Symbol} for {SelectedCompany.StockPrice:C2}", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("No Shares Available", "You don't own any shares of this stock to sell.", "OK");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

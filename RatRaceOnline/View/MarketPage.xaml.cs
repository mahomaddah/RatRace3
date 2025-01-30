namespace RatRace3;

using RatRace3.Models;
using Syncfusion.Maui.Charts;
using System;
using System.Data.SqlTypes;
using System.Globalization;

public partial class MarketPage : ContentPage
{
    public AssetModel CurrentAssetModel { get; set; }
    public Company CurrentCompany { get; set; }
    public IEnumerable<object> ChartData { get; private set; }
    public List<Brush> PaletteBrushes { get; private set; }
    Random random = new Random();
    public MarketPage()
    {

      this.CurrentCompany = new Company { Symbol = "NVDA", StockPrice = 141.34, StockDetail = "Technology company Internet Search Monopoly..." };



        // Set BindingContext

        //    Chart.Series.Add(new ColumnSeries());


        var columnSeries = new ColumnSeries
        {
            ItemsSource = ChartData,
            XBindingPath = "Date",
            YBindingPath = "Value",
            PaletteBrushes = PaletteBrushes // Use the bound brushes
        };

        //    Chart.Series.Clear();

        
        ChartData = new[]
            {
                new { Date = DateTime.Now.Date.ToString("MMM-yyyy"), Value = 30 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(1).ToString("MMM-yyyy"), Value = 45 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(2).ToString("MMM-yyyy"), Value = 25 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(3).ToString("MMM-yyyy"), Value = 40 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(4).ToString("MMM-yyyy"), Value = 43 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(5).ToString("MMM-yyyy"), Value = 44 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(6).ToString("MMM-yyyy"), Value = 50 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(7).ToString("MMM-yyyy"), Value = 48 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(8).ToString("MMM-yyyy"), Value = 58 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(9).ToString("MMM-yyyy"), Value = 158 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(10).ToString("MMM-yyyy"), Value = 128 + random.Next(-50, 100) },                      
                new { Date = DateTime.Now.Date.AddMonths(11).ToString("MMM-yyyy"), Value = 178 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(12).ToString("MMM-yyyy"), Value = 188 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(13).ToString("MMM-yyyy"), Value = 178 + random.Next(-50, 100) },
                new { Date = DateTime.Now.Date.AddMonths(14).ToString("MMM-yyyy"), Value = 188 + random.Next(-50, 100) }
            };


        PaletteBrushes = new List<Brush>
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
        InitializeComponent();
        Chart.PaletteBrushes = PaletteBrushes;
        Chart.Series.Add(columnSeries);
        BindingContext = this;
 
    }

    private void markerPointer_ValueChangeCompleted(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
    {
           TotalPriceLB.Text = (e.Value * CurrentCompany.StockPrice).ToString("C2" , CultureInfo.CreateSpecificCulture("en-US"));
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;

        CurrentCompany = appShell.CurrentCompany;
        StockIcon.Source =CurrentCompany.Symbol.ToLower() + ".png";
        StockSymbol.Text = CurrentCompany.Symbol;       
        ToolTipProperties.SetText(StockIcon, CurrentCompany.StockDetail);
        StockPriceLB.Text = (CurrentCompany.StockPrice).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); 
        CurrentAssetModel = appShell.CurrentCompanyAsset;
        PostionValueOwnedLB.Text= (CurrentAssetModel.StockQuantity*CurrentCompany.StockPrice).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
        //CurrentAssetModel.StockAverageBuyCost;//for P&L after MVP...
        //CurrentAssetModel.StockCompanySymbol;//Not needed here ...
        markerPointer.Value = CurrentAssetModel.StockQuantity;
        TotalPriceLB.Text = (markerPointer.Value * CurrentCompany.StockPrice).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

    }

    private async void SellAssetPosition_Clicked(object sender, EventArgs e)
    {

        ////User SHould be ablae to sell their MSFT by Double clicking on asset this page should show up and msft postion should come here...
        ////ready to sell! bind gameViewModel and This Logics here also make sure double click on asset postion work well ... DONE
        ////aslo a tooltip like : stock market is currentlly at holyday i't will open after Level 1 was Complated and After Post Demo Update.....
        
        var appShell = (AppShell)Shell.Current;
        var Player = appShell.CurrentLevelModel.Players.First();
        if(markerPointer.Value <= CurrentAssetModel.StockQuantity && markerPointer.Value!=0)
        {
            //Sell amonth ...
            CurrentAssetModel.StockQuantity -= markerPointer.Value;

            Player.Balance += Math.Round(CurrentCompany.StockPrice * markerPointer.Value, 2);

            if (CurrentAssetModel.StockQuantity == 0)
                appShell.CurrentLevelModel.Players.First().Assets.Remove(CurrentAssetModel);
        }
        else // Ya adam da Okadar yok ya elimdeki nekadar varsa onu sat kast etmistir...
        {
            if (CurrentAssetModel.StockQuantity > 0.009)
            {
                //daha buyuktur ? 
                bool result = await DisplayAlert("Stock Market", "The value you want to sell is higher than the total amount you hold! Did you mean to  sell all ?", "Yes, All In..", "No!!");
                if (result)
                {
                    //sell all...
                    Player.Balance += Math.Round(CurrentCompany.StockPrice * markerPointer.Value, 2);

                    appShell.CurrentLevelModel.Players.First().Assets.Remove(CurrentAssetModel);

                }
            }
        }

        ContentPage_Loaded(this, new EventArgs());//Work like magic...

        //Update GUI for this page and Statment page ... IF not work with functins than run above code...
        //call // GameView.GameViewModel.LoadPlayerData(Player); from appshell or move GameViewModel To appshell directlly...
        appShell.GameViewModel.LoadPlayerData(Player);
        //var AssetOfPlayer = appShell.CurrentLevelModel.Players.First().Assets.Find(x => x.AssetName == CurrentAssetModel.AssetName);

        ////Orders System li yapmaliyiz Aslinda ileride Gercek economy gibi...

    }

    private void BuyMoreAsset_Clicked(object sender, EventArgs e)
    {
        //  if(Player . Blalance...)
       // CurrentAssetModel.StockAverageBuyCost

    }
}

//Note : ileride gradient e gecmek istersek ... chartlar icin ...
//new GradientStopCollection()
//{
//    new GradientStop() { Offset = 1, Color = Color.FromRgb(255, 231, 199) },
//    new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 182, 159) }
//},

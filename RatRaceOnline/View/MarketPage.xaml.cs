namespace RatRace3;
using RatRace3.Models;
using RatRace3.ViewModel;
using Syncfusion.Maui.Charts;
using System;
using System.Data.SqlTypes;
using System.Globalization;

public partial class MarketPage : ContentView
{
    public AssetModel CurrentAssetModel { get; set; }
    public Company CurrentCompany { get; set; }
    //   public List<object> ChartData { get; set; }
    
   
 
     //List<Brush> PaletteBrushes = new List<Brush> //TODO: Duplicated code Should be deleted... after Refactoring ... 
     //{
     //           Color.FromArgb("#FF638A2D"),
     //           Color.FromArgb("#FFE3AAD6"),
     //           Color.FromArgb("#FFFF7D7D"),
     //           Color.FromArgb("#FF007C9C"),
     //           Color.FromArgb("#FF019FCC"),
     //           Color.FromArgb("#FF94652B"),
     //           Color.FromArgb("#FF89D9A8"),
     //           Color.FromArgb("#FF71CBB1"),
     //           Color.FromArgb("#FF4DB7BE"),
     //           Color.FromArgb("#FF4EB7BD")
     //};

 //   Random random = new Random();

   // GameViewModel gameViewModel;

    public MarketPage()
    {

     // this.CurrentCompany = new Company { Symbol = "NVDA", StockPrice = 141.34, StockDetail = "Technology company Internet Search Monopoly..." };


        InitializeComponent();
        // Set BindingContext

        var appShell = (AppShell)Shell.Current;
        BindingContext = appShell.GameViewModel;

        //    Chart.Series.Add(new ColumnSeries());

        //Real Value investors (Lords) > Momentom investors (traders)> experted workers > workers
        //    Chart.Series.Clear();


        //ChartData = new List<object>
        //{
        //     new { Date = DateTime.Now.Date.AddMonths(-14).ToString("MM-yyyy"), Value = 30 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-13).ToString("MM-yyyy"), Value = 45 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-12).ToString("MM-yyyy"), Value = 25 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-11).ToString("MM-yyyy"), Value = 40 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-10).ToString("MM-yyyy"), Value = 43 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-9).ToString("MM-yyyy"), Value = 44 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-8).ToString("MM-yyyy"), Value = 50 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 48 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 58 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 158 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 128 + random.Next(-50, 100) },                      
        //     new { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 178 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 188 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 178 + random.Next(-50, 100) },
        //     new { Date = DateTime.Now.Date.ToString("MM-yyyy"), Value = 188 + random.Next(-50, 100) }
        //};


        //PaletteBrushes = new List<Brush>
        //    {
        //        Color.FromArgb("#FF638A2D"),
        //        Color.FromArgb("#FFE3AAD6"),
        //        Color.FromArgb("#FFFF7D7D"),
        //        Color.FromArgb("#FF007C9C"),
        //        Color.FromArgb("#FF019FCC"),
        //        Color.FromArgb("#FF94652B"),
        //        Color.FromArgb("#FF89D9A8"),
        //        Color.FromArgb("#FF71CBB1"),
        //        Color.FromArgb("#FF4DB7BE"),
        //        Color.FromArgb("#FF4EB7BD")
        //    };

        //var columnSeries = new ColumnSeries
        //{
        //    ItemsSource = appShell.GameViewModel.Market.ChartData,
        //    XBindingPath = "Date",
        //    YBindingPath = "Value",
        //    PaletteBrushes = PaletteBrushes // Use the bound brushes
        //};


        //Chart.PaletteBrushes = PaletteBrushes;
        //Chart.Series = new ChartSeriesCollection { columnSeries };
        ////BindingContext = this;

        // BindingContext = new GameViewModel();


        //    gameViewModel = appShell.GameViewModel; //belki gerekli ise ama bence cok sikik bir tasarim MVVM olarak
        //     appShell.GameViewModel.LoadCompanyData(CurrentCompany);

    }

    //private void markerPointer_ValueChangeCompleted(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
    //{
    //       TotalPriceLB.Text = (e.Value * CurrentCompany.StockPrice).ToString("C2" , CultureInfo.CreateSpecificCulture("en-US"));
    //bind   ValueChangeCompleted="markerPointer_ValueChangeCompleted"  if you need active again....
    //}

    private async void SellAssetPosition_Clicked(object sender, EventArgs e)
    {

     
    }
    //void updateAssetValue()
    //{
    //    if(CurrentAssetModel!=null)
    //    CurrentAssetModel.AssetValue = Math.Round(CurrentAssetModel.StockQuantity * CurrentCompany.StockPrice,2);
    //    //for updating also on Statment page... 
    //}
    private async void BuyMoreAsset_Clicked(object sender, EventArgs e)
    {


       
    }

    private void BackfromMarketBtn_Clicked(object sender, EventArgs e)
    {
        AppShell appShell = (AppShell)Shell.Current;
       // appShell.GoToAsync("..");
        ((MotherView)(appShell).CurrentPage).Show("gameview");
        appShell.GameViewModel.IPOcompaniesSfCarouselViewModel.VisibleCompanyindex = 5;
    }

    private void ContentView_Loaded(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;

        appShell.GameViewModel.Market.IPOCompanies = appShell.IPOcompanies;
    }
}

//Note : After MVP:  ileride gradient e gecmek istersek ... chartlar icin ...
//new GradientStopCollection()
//{
//    new GradientStop() { Offset = 1, Color = Color.FromRgb(255, 231, 199) },
//    new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 182, 159) }
//},

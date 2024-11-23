namespace RatRace3;
using Syncfusion.Maui.Charts;
public partial class MarketPage : ContentPage
{
    public MarketPage()
    {
        InitializeComponent();


        // Set sample data
        BindingContext = new
        {
            Data = new[]
            {
                new { Category = "A", Value = 30 },
                new { Category = "B", Value = 45 },
                new { Category = "C", Value = 25 },
                 new { Category = "D", Value = 40 },
                  new { Category = "E", Value = 43 },
                   new { Category = "F", Value = 44 },
                    new { Category = "G", Value = 50 },
                     new { Category = "H", Value = 48 },
                      new { Category = "I", Value = 58 }
            }
        };


    }
}
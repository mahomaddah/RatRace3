namespace RatRace3;
using Syncfusion.Maui.Charts;
public partial class MarketPage : ContentPage
{
    public IEnumerable<object> ChartData { get; private set; }
    public List<Brush> PaletteBrushes { get; private set; }
    public MarketPage()
    {

      

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
                new { Date = "12-2023", Value = 30 },
                new { Date = "01-2024", Value = 45 },
                new { Date = "02-2024", Value = 25 },
                new { Date = "03-2024", Value = 40 },
                new { Date = "04-2024", Value = 43 },
                new { Date = "05-2024", Value = 44 },
                new { Date = "06-2024", Value = 50 },
                new { Date = "07-2024", Value = 48 },
                new { Date = "08-2024", Value = 58 },
                new { Date = "09-2024", Value = 158 },
                new { Date = "10-2024", Value = 128 },                      
                new { Date = "11-2024", Value = 178 },
                new { Date = "12-2024", Value = 188 },
            };


        PaletteBrushes = new List<Brush>
            {
                Color.FromArgb("#FF638A2D"),
                Color.FromArgb("#FFE3AAD6"),
                Color.FromArgb("#FFFF7D7D"),
                Color.FromArgb("#FF007C9C"),
                Color.FromArgb("#FF019FCC"),
                Color.FromArgb("#FF94652B"),
                Color.FromArgb("#FFFAF3A0"),
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
}
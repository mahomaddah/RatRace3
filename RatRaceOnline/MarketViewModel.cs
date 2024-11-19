using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
namespace RatRace3
{
    public class MarketViewModel
    {
        public ISeries[] Series { get; set; } = [
    new ColumnSeries<double>
      {
          Values= new List<double>{3.3},
          Fill = new SolidColorPaint(SKColor.Parse("#ff73ab"))
      },
        new ColumnSeries<double>
      {
          Values= new List<double>{3.4},
          Fill = new SolidColorPaint(SKColor.Parse("#4ea1ce"))
      },
        new ColumnSeries<double>
      {
          Values= new List<double>{3.6},
          Fill = new SolidColorPaint(SKColor.Parse("#e1a9d4"))
      },
        new ColumnSeries<double>
      {
          Values= new List<double>{3.8},
          Fill = new SolidColorPaint(SKColor.Parse("#62892d"))

      },
        new ColumnSeries<double>
      {
          Values= new List<double>{3.91},
          Fill = new SolidColorPaint(SKColor.Parse("#81b839"))
      },
        new ColumnSeries<double>
      {
          Values= new List<double>{3.83},
          Fill = new SolidColorPaint(SKColor.Parse("#42A5F5"))
      },
        new ColumnSeries<double>
      {
          Values= new List<double>{3.73},
          Fill = new SolidColorPaint(SKColor.Parse("#0b7b98"))
      },

  ];
    }
}

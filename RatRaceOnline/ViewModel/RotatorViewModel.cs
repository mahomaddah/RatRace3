using RatRace3.Models;
using Syncfusion.Maui.Rotator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.View;

namespace RatRace3.ViewModel
{
    public class RotatorViewModel
    {
        // ViewModel class for Rotator.

        public ObservableCollection<SfRotatorItem> RotatorItems { get; set; }

        public RotatorViewModel()
        {
            RotatorItems = new ObservableCollection<SfRotatorItem>();

  
            RotatorItems.Add(new SfRotatorItem
            {
                Image = "googl.png",
                ItemText = "NASDAQ: GOOGL $125.51"
            });
            RotatorItems.Add(new SfRotatorItem
            {
                Image = "aapl.png",
                ItemText = "NASDAQ: AAPL $258.20"
               
            });
            RotatorItems.Add(new SfRotatorItem
            {
                Image = "msft.png",
                ItemText = "NASDAQ: MSFT $439.33"
               
            });
            
            RotatorItems.Add(new SfRotatorItem { Image = "wmt.png", ItemText = "NYSE: WMT $92.68" });
            RotatorItems.Add(new SfRotatorItem { Image = "tsla.png", ItemText = "NASDAQ: TSLA $462.25" });
            RotatorItems.Add(new SfRotatorItem { Image = "meta.png", ItemText = "NASDAQ: META $607.75" });
            RotatorItems.Add(new SfRotatorItem { Image = "adbe.png", ItemText = "NASDAQ: 447.94" });
            RotatorItems.Add(new SfRotatorItem { Image = "nvda.png", ItemText = "NASDAQ: NVDA $140.22" });
            RotatorItems.Add(new SfRotatorItem { Image = "amzn.png", ItemText = "NASDAQ: AMZN $229.05" });

            //Using a new view as item contetnt way work but have problem with minimized tumpnail images ... 
            //RotatorItems.Add(new SfRotatorItem
            //{
            //    Image = "msft.png",
            //    ItemText = "NASDAQ: MSFT $439.33"
            //  ,
            //    ItemContent = new RotatorItemView
            //    {
            //        BindingContext = new { Image = "msft.png", ItemText = "NASDAQ: MSFT $439.33" }
            //    }
            //});
        }
      
    }
}

using RatRace3.Models;
using Syncfusion.Maui.Rotator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.View;
using System.Globalization;
using System.ComponentModel;
using Microsoft.Extensions.Logging;

namespace RatRace3.ViewModel
{

    public class IPOcompaniesRotatorViewModel
    {
        // ViewModel class for Rotator.

   //     public ObservableCollection<Company> IPOcompanies 
        private ObservableCollection<Company> iPOcompanies;

        public ObservableCollection<Company> IPOcompanies
        {
            get { return iPOcompanies; }
            set { iPOcompanies = value;
                SyncIPOcompaniesItems();
                Thread.Sleep(10);
            }
        }

        public ObservableCollection<SfRotatorItem> RotatorItems { get; private set; }

        private void SyncIPOcompaniesItems()
        {
            RotatorItems = new ObservableCollection<SfRotatorItem>();
            if(iPOcompanies != null)
            foreach (var company in IPOcompanies)
            {
                var image = new Image { Source = company.Symbol + ".png" ,WidthRequest=300,HeightRequest=300  };
              

                var SymbolPricetext = company.Symbol + " " + company.StockPrice.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

                RotatorItems.Add(new SfRotatorItem(image, SymbolPricetext));
                //{ 
                //    Image = company.Symbol + ".png",
                //    ItemText = SymbolPricetext
                //});
            }
            else { Shell.Current.DisplayAlert("Error from IPOCompanyViewmodel.CS.SyncIPOCompaniesItems()", "ipo companies was null","OK"); }
        }
        public IPOcompaniesRotatorViewModel()
        {
            var appShell = (AppShell)Shell.Current;
            IPOcompanies = appShell.IPOcompanies;

        }


    }

    //public class IPOcompaniesRotatorViewModel : INotifyPropertyChanged
    //{
    //    private ObservableCollection<Company> _IPOcompanies;
    //    public ObservableCollection<Company> IPOcompanies
    //    {
    //        get { return _IPOcompanies; }
    //        set
    //        {
    //            _IPOcompanies = value;
    //            OnPropertyChanged(nameof(IPOcompanies)); // UI güncellensin
    //        }
    //    }

    //    public IPOcompaniesRotatorViewModel()
    //    {
    //        var appShell = (AppShell)Shell.Current;
    //        IPOcompanies = appShell.IPOcompanies; // Doğrudan veriyi ViewModel'e bağladık!
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
}

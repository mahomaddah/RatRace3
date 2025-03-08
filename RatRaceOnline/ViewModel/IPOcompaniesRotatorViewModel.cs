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

namespace RatRace3.ViewModel
{

    public class IPOcompaniesRotatorViewModel
    {
        // ViewModel class for Rotator.

        public ObservableCollection<Company> IPOcompanies { get; set; }
        public ObservableCollection<SfRotatorItem> RotatorItems { get; set; }

        public void SyncIPOcompaniesItems()
        {
            RotatorItems = new ObservableCollection<SfRotatorItem>();
            foreach (var company in IPOcompanies)
            {
                RotatorItems.Add(new SfRotatorItem
                {
                    Image = company.Symbol + ".png",
                    ItemText = company.Symbol + " " + company.StockPrice.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))
                });
            }
        }
        public IPOcompaniesRotatorViewModel()
        {
            var appShell = (AppShell)Shell.Current;
            IPOcompanies = appShell.IPOcompanies;

            SyncIPOcompaniesItems();
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

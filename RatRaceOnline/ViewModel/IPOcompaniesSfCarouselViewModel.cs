using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RatRace3.Models;
namespace RatRace3.ViewModel
{
    public class IPOcompaniesSfCarouselViewModel : INotifyPropertyChanged
    {
        private int visibleCompanyindex;

        public int VisibleCompanyindex
        {
            get { return visibleCompanyindex; }
            set { visibleCompanyindex = value;
                  OnPropertyChanged();
                var appShell = (AppShell)Shell.Current;
                if (visibleCompanyindex>-1 && visibleCompanyindex< appShell.IPOcompanies.Count)
                {
                  var selectedCompany= appShell.IPOcompanies.ElementAtOrDefault(visibleCompanyindex);
                    if(selectedCompany!=null)
                    SelectedCompanyFundemental = selectedCompany.StockFundementalData;
                }
            }
        }

        private StockFundementalData selectedCompanyFundemental;

        public StockFundementalData SelectedCompanyFundemental
        {
            get { return selectedCompanyFundemental; }
           private set { selectedCompanyFundemental = value;
                         OnPropertyChanged();
             }
        }



        public IPOcompaniesSfCarouselViewModel()
        {

            imageCollection = new List<Company>();


        }
        private List<Company> imageCollection = new List<Company>();
        public List<Company> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    

    }
}

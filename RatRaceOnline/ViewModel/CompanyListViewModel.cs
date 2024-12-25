using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.Models;

namespace RatRace3.ViewModel
{
    public class CompanyListViewModel
    {
        public ObservableCollection<Company> DataSource { get; set; }

        public CompanyListViewModel()
        {
            
                this.DataSource = new ObservableCollection<Company>
                {
                    new Company { StockDetail = "Consumer Discrationery Walmart company", StockPrice = 12, Symbol = "WMT" },
                    new Company { StockDetail = "US tech company", StockPrice = 101, Symbol = "AAPL" }
                };
        }
    }
}

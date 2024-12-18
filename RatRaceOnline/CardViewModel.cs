using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RatRace3.Models;

namespace RatRace3
{
    public class CardViewModel : INotifyPropertyChanged
    {

        public List<Company> StockMarketCompanys { get; set; } // sonra gercekten List<company> obje turune cevirilcek
        public List<string> Liabilities { get; set; }

        public ICommand ChangeCardIndexCommand { get; }

        public CardViewModel()
        {
            ChangeCardIndexCommand = new Command<int>(index => VisibleIndex = index);
            Liabilities = new List<string> { "Education Loan" , "Phone Debt"  };

            StockMarketCompanys = new List<Company> {
                new Company { Symbol="MSFT" , StockPrice = 231.12 , StockDetail = "Wide ecconomic moat Great Technology company" },
                new Company { Symbol="GOOGL" , StockPrice = 181.12 , StockDetail = "Wide ecconomic moat Great Technology company" }

            };
        }

        private int _visibleIndex;

        public int VisibleIndex
        {
            get => _visibleIndex;
            set
            {
                if (_visibleIndex != value)
                {
                    _visibleIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

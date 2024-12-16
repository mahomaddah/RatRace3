using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RatRace3
{
    public class CardViewModel : INotifyPropertyChanged
    {
        public ICommand ChangeCardIndexCommand { get; }

        public CardViewModel()
        {
            ChangeCardIndexCommand = new Command<int>(index => VisibleIndex = index);
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

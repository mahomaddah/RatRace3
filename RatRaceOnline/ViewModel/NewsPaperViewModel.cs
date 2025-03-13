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
    public class NewsPaperViewModel :INotifyPropertyChanged
    {
      //  public NewsPaperModel CurrentNewsPaperModel { get; set; }
        private NewsPaperModel currentNewsPaperModel;

        public NewsPaperModel CurrentNewsPaperModel
        {
            get { return currentNewsPaperModel; }
            set { currentNewsPaperModel = value;
                OnPropertyChanged();
            }
        }


        public List<NewsPaperModel> NewsPaperModels { get; set; }

        public NewsPaperViewModel()
        {

            //NewsPaperModels = new List<NewsPaperModel>{};

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

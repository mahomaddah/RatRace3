using RatRace3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.ViewModel
{
    public class SelectLevelViewModel : INotifyPropertyChanged
    {
     
        public SelectLevelViewModel()
        {

            imageCollection = new List<LevelModel>();
           

        }
        private List<LevelModel> imageCollection = new List<LevelModel>();
        public List<LevelModel> ImageCollection
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

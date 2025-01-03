using RatRace3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.ViewModel
{
    public class SelectLevelViewModel
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
    }

}

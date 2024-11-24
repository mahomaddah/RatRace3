using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3
{
    public class CarouselViewModel
    {
        public CarouselViewModel()
        {


            ImageCollection.Add(new CarouselModel("undraw_investing.png"));
             ImageCollection.Add(new CarouselModel("software_engineer.png"));
            ImageCollection.Add(new CarouselModel("exams.png"));
           ImageCollection.Add(new CarouselModel("interview.png"));
            ImageCollection.Add(new CarouselModel("dotnet_bot.png"));
            ImageCollection.Add(new CarouselModel("shared_goals.png"));
        }
        private List<CarouselModel> imageCollection = new List<CarouselModel>();
        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
    }

    public class CarouselModel
    {
        public CarouselModel(string imageString)
        {
            Image = imageString;
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.Models;

namespace RatRace3.ViewModel
{
    public class NewsPaperViewModel
    {
        public NewsPaperModel CurrentNewsPaperModel { get; set; }

        public List<NewsPaperModel> NewsPaperModels { get; set; }

        public NewsPaperViewModel()
        {

            NewsPaperModels = new List<NewsPaperModel>
            { };
        }

    }
}

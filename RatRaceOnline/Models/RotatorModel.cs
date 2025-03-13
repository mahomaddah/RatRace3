using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class RotatorModel
    {
        // Model Class for Rotator.
        public RotatorModel()
        {
            
        }
        public RotatorModel(string imageString)
        {
            Image = imageString;
        }
        private String _image;
        public String Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}

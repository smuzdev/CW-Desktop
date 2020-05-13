using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.Model
{
    public class NewsBlock
    {
        public string NewsBlockTitle { get; private set; }
        public string NewsBlockDescription { get; private set; }
        public string NewsBlockImage { get; private set; }

        public NewsBlock(string newsBlockTitle, string newsBlockDescription, string newsBlockImage)
        {
            NewsBlockTitle = newsBlockTitle;
            NewsBlockDescription = newsBlockDescription;
            NewsBlockImage = newsBlockImage;
        }
    }
}

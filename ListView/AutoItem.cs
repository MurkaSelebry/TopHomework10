using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyListView
{
    class AutoItem
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Path { get; set; }


        public BitmapImage ImageSourse
        {
            get { return new BitmapImage(new Uri(Path)); }
            set { ImageSourse = value; }
        }

        public AutoItem() { }

        public AutoItem(string mark, string mod, string fn)
        {
            Model = mod;
            Brand = mark;
            Path = fn;
        }
    }
}

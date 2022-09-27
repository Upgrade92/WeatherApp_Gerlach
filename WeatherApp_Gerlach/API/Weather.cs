using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WeatherApp_Gerlach.API
{
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public BitmapImage icon;
    }
}

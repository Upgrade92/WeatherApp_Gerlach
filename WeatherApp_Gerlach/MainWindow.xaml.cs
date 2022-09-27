using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp_Gerlach.WeatherMap;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using WeatherApp_Gerlach.SupportClasses;

namespace WeatherApp_Gerlach
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={b6ee3ba5f78bd0c33c1bf67c46c95709}
            //b6ee3ba5f78bd0c33c1bf67c46c95709
     
            textboxCity.Text = "Fohnsdorf";
      
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            textblockTemp.Text = Helper.doRequest(textboxCity).ToString();
        }
    }
}

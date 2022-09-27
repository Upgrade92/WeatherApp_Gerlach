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


            HttpClient httpClient = new HttpClient();
            string cityName = "Graz";
            string requestUri = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=b6ee3ba5f78bd0c33c1bf67c46c95709&lang=de&units=metric";

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;
            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);

            textblock.Text = weatherMapResponse.main.feels_like.ToString() + " °C";
=======



            //b6ee3ba5f78bd0c33c1bf67c46c95709
            //https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={b6ee3ba5f78bd0c33c1bf67c46c95709}
        }

        
 
        
    }
}

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using WeatherApp_Gerlach.WeatherMap;

//https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={b6ee3ba5f78bd0c33c1bf67c46c95709}     API Uri
//b6ee3ba5f78bd0c33c1bf67c46c95709                                                                          API key

namespace WeatherApp_Gerlach.SupportClasses
{
    public class HttpHelper
    {
        public static WeatherMapResponse doRequest(TextBox txt)
        {
            HttpClient httpClient = new HttpClient();
            string requestUri = $"https://api.openweathermap.org/data/2.5/weather?q={txt.Text}&appid=b6ee3ba5f78bd0c33c1bf67c46c95709&lang=de&units=metric";
            WeatherMapResponse weatherMapResponse = null;
            try
            {
                HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;
                string response = httpResponse.Content.ReadAsStringAsync().Result;
                weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);
            }
            catch (AggregateException e)
            {
                MessageBox.Show("Internetverbindung überprüfen");
            }
            return weatherMapResponse;
        }
    }
}

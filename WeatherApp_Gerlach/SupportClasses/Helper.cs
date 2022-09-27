using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WeatherApp_Gerlach.WeatherMap;


namespace WeatherApp_Gerlach.SupportClasses
{
    public class Helper
    {
        public static StringBuilder doRequest(TextBox txt)
        {
            HttpClient httpClient = new HttpClient();
            string requestUri = $"https://api.openweathermap.org/data/2.5/weather?q={txt.Text}&appid=b6ee3ba5f78bd0c33c1bf67c46c95709&lang=de&units=metric";

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;
            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);

            StringBuilder sb = new StringBuilder();
            if (weatherMapResponse.main != null)
            {
                sb.Append($"{"Aktuelle Temperatur",-30} :\t {weatherMapResponse.main.temp.ToString("N2"),6}  °C\n");
                sb.Append($"{"Höchsttemperatur",-30} :\t {weatherMapResponse.main.temp_max.ToString("N2"),6}  °C\n");
                sb.Append($"{"Mindesttemperatur",-30}:\t {weatherMapResponse.main.temp_min.ToString("N2"),6}  °C\n");
                sb.Append($"{"Gefühlte Temperatur",-30}:\t {weatherMapResponse.main.feels_like.ToString("N2"),6}  °C\n\n");
                sb.Append($"{"Luftdruck",-38}:\t {weatherMapResponse.main.pressure.ToString(),4} hPa\n");
                sb.Append($"{"Luftfeuchte",-37}:\t {weatherMapResponse.main.humidity.ToString(),8} %\n");
            }
            else
            {
                MessageBox.Show("Ort nicht gefunden","Fehler");
                sb.Append("kein gültiger Ort");
            }

            return sb;
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WeatherApp_Gerlach.WeatherMap;


namespace WeatherApp_Gerlach.SupportClasses
{
    public class Helper
    {
        public static string weather;

        public static WeatherMapResponse doRequest(TextBox txt)
        {
            HttpClient httpClient = new HttpClient();
            string requestUri = $"https://api.openweathermap.org/data/2.5/weather?q={txt.Text}&appid=b6ee3ba5f78bd0c33c1bf67c46c95709&lang=de&units=metric";

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;
            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);

            return weatherMapResponse;
        }


        public static StringBuilder printWeatherData(WeatherMapResponse weatherMapResponse)
        {
            StringBuilder sb = new StringBuilder();
            if (weatherMapResponse.main != null)
            {
                sb.Append($"{"Aktuelle Temperatur",-30} :\t {weatherMapResponse.main.temp.ToString("00.00")}  °C\n");
                sb.Append($"{"Höchsttemperatur",-30} :\t {weatherMapResponse.main.temp_max.ToString("00.00")}  °C\n");
                sb.Append($"{"Mindesttemperatur",-30}:\t {weatherMapResponse.main.temp_min.ToString("00.00")}  °C\n");
                sb.Append($"{"Gefühlte Temperatur",-30}:\t {weatherMapResponse.main.feels_like.ToString("00.00")}  °C\n\n");
                sb.Append($"{"Luftdruck",-38}:\t {weatherMapResponse.main.pressure.ToString()} hPa\n");
                sb.Append($"{"Luftfeuchte",-37}:\t {weatherMapResponse.main.humidity.ToString()} %\n");
                sb.Append($"{"Windgeschwindigkeit",-28}:\t {weatherMapResponse.wind.speed.ToString()} m/s\n");
                sb.Append($"{"Ortschaft",-38}:\t {weatherMapResponse.name.ToString()} \n");
                sb.Append($"{"Wetterlage",-36}:\t {Helper.translateWeather(weatherMapResponse.weather[0].main.ToString())} \n");
            }
            else
            {
                MessageBox.Show("Ort nicht gefunden", "Fehler");
                sb.Append("kein gültiger Ort");
            }
            return sb;
        }

        public static bool IsAlphabets(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return false;

            for (int i = 0; i < inputString.Length; i++)
                if (char.IsLetter(inputString[i])|| char.IsWhiteSpace(inputString[i]))
                    return true;
            return false;
        }

        public static string translateWeather(string weatherInfo)
        {
            switch (weatherInfo)
            {
                case "Clouds":
                    weather = "Bewölkt";
                    break;

                case "Rain":
                    weather = "Regen";
                    break;

                case "Clear":
                    weather = "klarer Himmel";
                    break;

                case "Drizzle":
                    weather = "Niesel";
                    break;

                case "Snow":
                    weather = "Schnee";
                    break;

                case "Thunderstorm":
                    weather = "Gewitter";
                    break;
            }
            return weather;
        }

        public static BitmapImage switchImage()
        {

            BitmapImage image = null;
            switch (weather)
            {
                case "Bewölkt":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\cloud.png", UriKind.RelativeOrAbsolute));
                    break;

                case "Schnee":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\snow.png", UriKind.RelativeOrAbsolute));
                    break;

                case "Gewitter":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\thunderstorm.png", UriKind.RelativeOrAbsolute));
                    break;

                case "klarer Himmel":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\sun.png", UriKind.RelativeOrAbsolute));
                    break;

                case "Niesel":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\cloud.png", UriKind.RelativeOrAbsolute));
                    break;

                case "Regen":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\thunderstorm.png", UriKind.RelativeOrAbsolute));
                    break;
            }
            return image;
        }
    }
}

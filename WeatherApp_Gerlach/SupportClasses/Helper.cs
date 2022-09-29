using System;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using WeatherApp_Gerlach.WeatherMap;

namespace WeatherApp_Gerlach.SupportClasses
{
    public class Helper
    {
        private static string weather;

        private static string weatherDesc;
        public static string WeatherDesc { get { return weatherDesc; } }

        private static string actualTemp;
        public static string ActualTemp { get { return actualTemp; }  }

        public static StringBuilder printWeatherData(WeatherMapResponse weatherMapResponse, MainWindow main)
        {
            StringBuilder sb = new StringBuilder();
            weather = "";
            weatherDesc = "";
            actualTemp = ""; 
            if ((weatherMapResponse != null) && (weatherMapResponse.main != null))
            {
                sb.Append($"{"Höchsttemperatur",-30} :\t {weatherMapResponse.main.temp_max.ToString("00.00")}  °C\n");
                sb.Append($"{"Mindesttemperatur",-30}:\t {weatherMapResponse.main.temp_min.ToString("00.00")}  °C\n");
                sb.Append($"{"Gefühlte Temperatur",-30}:\t {weatherMapResponse.main.feels_like.ToString("00.00")}  °C\n\n");
                sb.Append($"{"Luftdruck",-38}:\t {weatherMapResponse.main.pressure.ToString()} hPa\n");
                sb.Append($"{"Luftfeuchte",-37}:\t {weatherMapResponse.main.humidity.ToString()} %\n");
                sb.Append($"{"Windgeschwindigkeit",-28}:\t {weatherMapResponse.wind.speed.ToString()} m/s\n\n");
                sb.Append($"{"Ortschaft",-38}:\t {weatherMapResponse.name.ToString()} \n");
                sb.Append($"{"Wetterlage",-36}:\t {Helper.translateWeather(weatherMapResponse.weather[0].main.ToString())} \n");

                main.LogoLabel.Visibility = Visibility.Visible;
                actualTemp = weatherMapResponse.main.temp.ToString("00.00") + " °C";
                weatherDesc = weatherMapResponse.weather[0].description.ToString();
            }
            else
            {
                MessageBox.Show("Ort nicht gefunden", "Fehler");
                sb.Append("kein gültiger Ort");
                main.LogoLabel.Visibility = Visibility.Hidden;
            }
            return sb;
        }

        public static bool IsAlphabets(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }

            for (int i = 0; i < inputString.Length; i++)
                if (char.IsLetter(inputString[i]) || char.IsWhiteSpace(inputString[i]))
                {
                    return true;
                }
            return false;
        }

        private static string translateWeather(string weatherInfo)
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

                case "Mist":
                    weather = "Nebel";
                    break;

                case "Fog":
                    weather = "Nebel";
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
                    if (Convert.ToInt32(DateTime.Now.Hour.ToString()) > 18)
                    {
                        image = new BitmapImage(new Uri("..\\..\\Assets\\moon.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        image = new BitmapImage(new Uri("..\\..\\Assets\\sun.png", UriKind.RelativeOrAbsolute));
                    }
                    break;

                case "Niesel":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\rain.png", UriKind.RelativeOrAbsolute));
                    break;

                case "Regen":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\rain.png", UriKind.RelativeOrAbsolute));
                    break;

                case "Nebel":
                    image = new BitmapImage(new Uri("..\\..\\Assets\\fog.png", UriKind.RelativeOrAbsolute));
                    break;

                default:
                    image = new BitmapImage(new Uri("..\\..\\Assets\\startup.png", UriKind.RelativeOrAbsolute));
                    break;
            }
            return image;
        }
    }
}

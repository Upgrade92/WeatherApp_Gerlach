using WeatherApp_Gerlach.API;

namespace WeatherApp_Gerlach.WeatherMap
{
    public class WeatherMapResponse
    {
        public Main main;
        public Weather[] weather;
        public Wind wind;
        //public Clouds clouds;

        public string name;
    }
}

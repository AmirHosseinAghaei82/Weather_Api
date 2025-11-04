namespace WeatherApi.Models.Weather
{
    public class AirPollutionResponse
    {
        public List<PollutionData>? List { get; set; }
    }

    public class PollutionData
    {
        public MainPollution? Main { get; set; }
        public Components? Components { get; set; }
    }

    public class MainPollution
    {
        public int Aqi { get; set; } // Air Quality Index
    }

    public class Components
    {
        public float Co { get; set; }
        public float No2 { get; set; }
        public float Pm2_5 { get; set; }
        public float Pm10 { get; set; }
        public float So2 { get; set; }
        public float O3 { get; set; }
    }
}


namespace WeatherApi.Models.Weather;

public class WeatherOutPut
{

    public string? City { get; set; }
    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public float Temp { get; set; }

    public float Humidity { get; set; }

    public float WindSpeed { get; set; }

    public int AirQualityIndex { get; set; }
    
    public Dictionary<string, float>? MajorPollutants { get; set; }


    

}
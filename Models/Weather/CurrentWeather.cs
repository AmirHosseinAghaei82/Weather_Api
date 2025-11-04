namespace WeatherApi.Models.Weather;

using System.Text.Json.Serialization;

public class CurrentWeather
{

    [JsonPropertyName("temp")]
    public float Temp { get; set; }

    [JsonPropertyName("humidity")]
    public float Humidity { get; set; }

    [JsonPropertyName("wind_speed")]
    public float WindSpeed { get; set; }

}
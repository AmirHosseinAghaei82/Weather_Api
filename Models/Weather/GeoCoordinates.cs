namespace WeatherApi.Models.Weather;

using System.Text.Json.Serialization;

public class GeoCoordinates
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("lat")]
    public float Latitude { get; set; }

    [JsonPropertyName("lon")]
    public float Longitude { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

}
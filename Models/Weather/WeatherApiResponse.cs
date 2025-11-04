namespace WeatherApi.Models.Weather;

using System.Text.Json.Serialization;



public class WeatherApiResponse
{
    [JsonPropertyName("coord")]
    public Coord? Coord { get; set; }

    [JsonPropertyName("main")]
    public Main? Main { get; set; }

    [JsonPropertyName("wind")]
    public Wind? Wind { get; set; }
}

public class Coord
{
    [JsonPropertyName("lat")]
    public float Latitude { get; set; }

    [JsonPropertyName("lon")]
    public float Longitude { get; set; }
}

public class Main
{
    [JsonPropertyName("temp")]
    public float Temp { get; set; }

    [JsonPropertyName("humidity")]
    public float Humidity { get; set; }
}

public class Wind
{
    [JsonPropertyName("speed")]
    public float Speed { get; set; }
}

    
namespace WeatherApi.Services.Interfaces;

using WeatherApi.Models.Weather;

public interface IWeatherService
{

    Task<WeatherOutPut> GetWeatherByCityAsync(string city);

}


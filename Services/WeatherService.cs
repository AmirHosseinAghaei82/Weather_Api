namespace WeatherApi.Services;

using Microsoft.AspNetCore.Components.Web;
using WeatherApi.Models.Weather;
using WeatherApi.Services.Helper.WeatherHelper;
using WeatherApi.Services.Interfaces;



public class WeatherService : IWeatherService
{

    private readonly GeoCoordinatesHelper _geoCoordinatesHelper;

    private readonly WeatherApiResponseHelper _weatherApiResponseHelper;

    private readonly AirPollutionHelper _airHelper;

    private readonly string _apiKey = "5dd6a30908c92c742f035b9f4c01e319";

    public WeatherService(GeoCoordinatesHelper geoCoordinatesHelper, WeatherApiResponseHelper weatherApiResponseHelper, AirPollutionHelper airHelper  )
    {

        _geoCoordinatesHelper = geoCoordinatesHelper;

        _weatherApiResponseHelper = weatherApiResponseHelper;

        _airHelper = airHelper;

    }

    public async Task<WeatherOutPut> GetWeatherByCityAsync(string city)
    {

        try
        {

            var geoCoordinates = await _geoCoordinatesHelper.GetGeoCoordinatesAsync(city, _apiKey);

            var weatherApiResponse = await _weatherApiResponseHelper.GetWeatherApiResponseAsync(geoCoordinates.Latitude, geoCoordinates.Longitude, _apiKey);

            var air = await _airHelper.GetAirPollutionAsync(geoCoordinates.Latitude, geoCoordinates.Longitude, _apiKey);

            var airData = air?.List?.FirstOrDefault();

            var outPut = new WeatherOutPut
            {

                City = city,
                Latitude = geoCoordinates.Latitude,
                Longitude = geoCoordinates.Longitude,
                Temp = weatherApiResponse?.Main?.Temp ?? 0f,
                Humidity = weatherApiResponse?.Main?.Humidity ?? 0f,
                WindSpeed = weatherApiResponse?.Wind?.Speed ?? 0f,
                AirQualityIndex = airData?.Main?.Aqi ?? 0,
                MajorPollutants = airData?.Components != null ?
                new Dictionary<string, float>
            {
                { "CO", airData.Components.Co },
                { "NO2", airData.Components.No2 },
                { "PM2.5", airData.Components.Pm2_5 },
                { "PM10", airData.Components.Pm10 },
                { "SO2", airData.Components.So2 },
                { "O3", airData.Components.O3 }
                }
                : new Dictionary<string, float>()
            
            


            };

            return outPut;


            }
            catch(Exception ex)
            {

                throw new(ex.Message);

            }


    }


}
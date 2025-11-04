
namespace WeatherApi.Services.Helper.WeatherHelper;

using System.Dynamic;
using WeatherApi.Models.Weather;

public class GeoCoordinatesHelper
{

    private readonly HttpClient _httpClient;

    public GeoCoordinatesHelper(HttpClient httpClient)
    {

        _httpClient = httpClient;

    }

    public async Task<GeoCoordinates> GetGeoCoordinatesAsync(string city, string api)
    {

        try
        {

            var geoCoordinates = await _httpClient.GetFromJsonAsync<List<GeoCoordinates>>($"http://api.openweathermap.org/geo/1.0/direct?q={city}&appid={api}");

            if (geoCoordinates == null || geoCoordinates.Count == 0)
            {

                throw new Exception("City not found");

            }

            return geoCoordinates[0];


        }
        catch (Exception ex)
        {

            throw new Exception("Error Calling Geo Api" , ex);

            
        }


    }
}

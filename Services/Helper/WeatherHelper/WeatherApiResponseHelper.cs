namespace WeatherApi.Services.Helper.WeatherHelper;

using WeatherApi.Models.Weather;


public class WeatherApiResponseHelper
{

    private readonly HttpClient _httpClient;

    public WeatherApiResponseHelper(HttpClient httpClient)
    {

        _httpClient = httpClient;

    }

    public async Task<WeatherApiResponse> GetWeatherApiResponseAsync(float lat, float lon, string api)
    {

        try
        {

            var weatherApiResponse = await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={api}&units=metric");

            if (weatherApiResponse == null)
            {

                throw new Exception("city not found");

            }

            return weatherApiResponse;


        }
        catch(Exception ex)
        {

            throw new(ex.Message);
            
        }
        


    }
    


}
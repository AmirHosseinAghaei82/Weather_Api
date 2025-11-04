namespace WeatherApi.Services.Helper.WeatherHelper;
using System.Net.Http.Json;
using WeatherApi.Models.Weather;


    public class AirPollutionHelper
    {
        private readonly HttpClient _httpClient;

        public AirPollutionHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AirPollutionResponse> GetAirPollutionAsync(float lat, float lon, string apiKey)
        {
            var url = $"http://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid={apiKey}";
            var response = await _httpClient.GetFromJsonAsync<AirPollutionResponse>(url);

            if (response == null)
                throw new Exception("Air pollution data not found");

        return response;
            
        }
    }


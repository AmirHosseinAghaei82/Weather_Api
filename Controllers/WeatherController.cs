namespace WeatherApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models.Weather;
using WeatherApi.Services.Interfaces;



[ApiController]

[Route("api/[controller]")]

public class WeatherController : ControllerBase
{

    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {

        _weatherService = weatherService;

    }

    [HttpGet("getweather")]
    
    public async Task<ActionResult<WeatherOutPut>>  GetWeatherByCityAsync([FromQuery] string city)
    {

        try
        {

            var result = await _weatherService.GetWeatherByCityAsync(city);

            return Ok(result);

        }
        catch(Exception ex)
        {

            return BadRequest(ex.Message);
            

        }

    }

}